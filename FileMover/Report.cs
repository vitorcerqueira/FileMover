using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace FileMover
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        private void btnSelectDestination_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = fbd.SelectedPath;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please select a source folder.", "Atenção", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                var thread = new Thread(Run);
                thread.Start();

                //Run();
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"Erro de permissão: {ex.Message}");
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Erro de entrada/saída: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro inesperado: {ex.Message}");
            }
        }

        private void Run()
        {
            Invoke(new Action(() =>
            {
                int posPathSource = textBox1.Text.Split('\\').Length;
                string[] pathFiles = Service.GetArquivosOrigem(textBox1.Text);
                if (pathFiles.Length == 0) return;

                // ---------- CAPTURA DE FILTROS ----------
                // informe o intervalo em tela (textbox, numericUpDown etc.)
                int startYear = int.Parse(textBox6.Text);  // ex.: 2021
                int endYear = int.Parse(textBox7.Text);    // ex.: 2025
                string kmIni = textBox2.Text.Trim();
                string kmFim = textBox3.Text.Trim();
                string discFiltro = textBox5.Text.Trim();

                // SUBS: textbox4 até textbox8
                var subsFiltro = new List<string>();
                foreach (var tb in new[] { textBox4, textBox8 })
                {
                    if (tb != null && !string.IsNullOrWhiteSpace(tb.Text))
                        subsFiltro.Add(tb.Text.Trim());
                }

                bool filtraKm = !string.IsNullOrEmpty(kmIni) || !string.IsNullOrEmpty(kmFim);
                bool filtraDisciplina = !string.IsNullOrEmpty(discFiltro);
                bool filtraSub = subsFiltro.Count > 0;

                // ---------- AGREGAÇÃO ----------
                var rows = new Dictionary<(string km, string disciplina, string sub), HashSet<int>>();

                foreach (string pathFile in pathFiles)
                {
                    string[] pathFilePart = pathFile.Split('\\');
                    string fileName = pathFilePart[^1];

                    (string sub, string km, string ano, string disciplina, string modalidade, string nomePastaFoto)
                        = Service.ProcessPathParts(pathFilePart, posPathSource);

                    string pathDisciplinaDestino = Service.getPathDisciplinaDestino(disciplina);
                    string fileNameDestination = Path.Combine(textBox1.Text, pathDisciplinaDestino, sub, km, modalidade, ano, nomePastaFoto, fileName);
                    if (fileNameDestination != pathFile) continue;

                    if (!int.TryParse(ano, out int year)) continue;
                    if (year < startYear || year > endYear) continue;

                    // ---------- FILTROS DINÂMICOS ----------
                    if (filtraDisciplina && !disciplina.Equals(discFiltro, StringComparison.OrdinalIgnoreCase))
                        continue;

                    if (filtraSub && !subsFiltro.Contains(sub, StringComparer.OrdinalIgnoreCase))
                        continue;

                    if (filtraKm)
                    {
                        double kmNum = ParseKmFlexible(km);      // "km 219,3 pt" -> 219.3
                        double kmIniNu = ParseKmFlexible(kmIni);   // "219"        -> 219.0
                        double kmFimNu = ParseKmFlexible(kmFim);   // "220"        -> 220.0

                        if (double.IsNaN(kmNum) || double.IsNaN(kmIniNu) || double.IsNaN(kmFimNu))
                            continue; // não conseguiu interpretar algum valor

                        if (kmNum < kmIniNu || kmNum > kmFimNu)
                            continue;
                    }


                    var key = (km.Trim(), disciplina.Trim(), sub.Trim());
                    if (!rows.TryGetValue(key, out var set))
                    {
                        set = new HashSet<int>();
                        rows[key] = set;
                    }
                    set.Add(year);
                }

                // ---------- GERA CSV ----------
                Directory.CreateDirectory(@"c:\temp");
                var fileNameCsv = $@"c:\temp\relatorio_arquivos_copiados_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                var anos = Enumerable.Range(startYear, endYear - startYear + 1).ToArray();

                using var writer = new StreamWriter(fileNameCsv, false, Encoding.UTF8);
                writer.WriteLine(string.Join(';', new[] { "km", "disciplina", "sub" }.Concat(anos.Select(a => a.ToString()))));

                foreach (var kv in rows.OrderBy(r => r.Key.km).ThenBy(r => r.Key.disciplina).ThenBy(r => r.Key.sub))
                {
                    var (km, disciplina, sub) = kv.Key;
                    var anosEncontrados = kv.Value;

                    var linha = new List<string> { km, disciplina, sub };
                    foreach (var a in anos)
                        linha.Add(anosEncontrados.Contains(a) ? "SIM" : "NÃO");

                    writer.WriteLine(string.Join(';', linha));
                }

                MessageBox.Show($"Arquivo salvo em:\n{fileNameCsv}");

                // abrir automaticamente o CSV no Excel ou app padrão
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = fileNameCsv,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao abrir o arquivo:\n{ex.Message}");
                }
            }));
        }

        // Parser flexível de KM
        private static double ParseKmFlexible(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return double.NaN;

            // Remove palavras comuns e espaços
            string s = value.Trim()
                            .ToUpperInvariant()
                            .Replace("KM", "")
                            .Replace("PT", "")
                            .Trim();

            // Caso 1: formato "251+825" (km + metros)
            if (s.Contains("+"))
            {
                var parts = s.Split('+');
                if (parts.Length == 2
                    && double.TryParse(parts[0].Trim().Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out var km)
                    && double.TryParse(parts[1].Trim().Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out var metros))
                {
                    // metros é em metros → converte para km
                    return km + (metros / 1000.0);
                }
            }

            // Caso 2: primeiro número com vírgula/ponto (ex.: "219,3", "219.3")
            var m = Regex.Match(s, @"(\d+(?:[.,]\d+)?)");
            if (m.Success &&
                double.TryParse(m.Groups[1].Value.Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out var v))
            {
                return v;
            }

            return double.NaN;
        }
    }
}
