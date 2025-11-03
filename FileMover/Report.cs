using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FileMover
{
    public partial class Report : Form
    {
        private const string ConfigFilePath = "Config_Report.xml";
        public Report()
        {
            InitializeComponent();
            EnsureConfigFileExists();
            LoadLastLimitPath();
        }

        private void SaveLastLimitPath()
        {
            try
            {
                XDocument config = new XDocument(
                        new XElement("Configuration",
                        new XElement("LastDestinationValue", textBox1.Text),
                        new XElement("LastKmDe", textBox2.Text),
                        new XElement("LastKmAte", textBox3.Text),
                        new XElement("LastSubDe", textBox4.Text),
                        new XElement("LastSubAte", textBox8.Text),
                        new XElement("LastDisciplina", textBox5.Text),
                        new XElement("LastYearDe", textBox6.Text),
                        new XElement("LastYearAte", textBox7.Text)
                    )
                );
                config.Save(ConfigFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar o valor: " + ex.Message, "Atenção", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void EnsureConfigFileExists()
        {
            if (!File.Exists(ConfigFilePath))
            {
                try
                {
                    XDocument config = new XDocument(
                        new XElement("Configuration",
                        new XElement("LastDestinationValue", ""),
                        new XElement("LastKmDe", ""),
                        new XElement("LastKmAte", ""),
                        new XElement("LastSubDe", ""),
                        new XElement("LastSubAte", ""),
                        new XElement("LastDisciplina", ""),
                        new XElement("LastYearDe", ""),
                        new XElement("LastYearAte", "")
                        )
                    );
                    config.Save(ConfigFilePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao criar o arquivo de configuração: " + ex.Message, "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadLastLimitPath()
        {
            try
            {
                XDocument config = XDocument.Load(ConfigFilePath);

                var valueElement1 = config.Root.Element("LastDestinationValue");

                if (valueElement1 != null)
                {
                    textBox1.Text = valueElement1.Value;
                }

                var valueElement2 = config.Root.Element("LastKmDe");

                if (valueElement2 != null)
                {
                    textBox2.Text = valueElement2.Value;
                }

                var valueElement3 = config.Root.Element("LastKmAte");

                if (valueElement3 != null)
                {
                    textBox3.Text = valueElement3.Value;
                }

                var valueElement4 = config.Root.Element("LastDisciplina");

                if (valueElement4 != null)
                {
                    textBox5.Text = valueElement4.Value;
                }

                var valueElement5 = config.Root.Element("LastYearDe");

                if (valueElement5 != null)
                {
                    textBox6.Text = valueElement5.Value;
                }

                var valueElement6 = config.Root.Element("LastYearAte");

                if (valueElement6 != null)
                {
                    textBox7.Text = valueElement6.Value;
                }

                var valueElement7 = config.Root.Element("LastSubDe");

                if (valueElement7 != null)
                {
                    textBox4.Text = valueElement7.Value;
                }
                var valueElement8 = config.Root.Element("LastSubAte");

                if (valueElement8 != null)
                {
                    textBox8.Text = valueElement8.Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar o valor: " + ex.Message, "Atenção", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnSelectDestination_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    SaveLastLimitPath();
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
                SaveLastLimitPath();

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
                var sw = Stopwatch.StartNew();

                int posPathSource = textBox1.Text.Split('\\').Length;
                string[] pathFiles = Service.GetArquivosOrigem(textBox1.Text);
                if (pathFiles.Length == 0) return;

                // ---------- CAPTURA DE FILTROS ----------
                int startYear = int.Parse(textBox6.Text);
                int endYear = int.Parse(textBox7.Text);

                string kmIni = textBox2.Text.Trim();
                string kmFim = textBox3.Text.Trim();

                string subIni = textBox4.Text.Trim();  // "Sub 01" ou "01"
                string subFim = textBox8.Text.Trim();  // "Sub 02" ou "02"

                string discFiltro = textBox5.Text.Trim();

                bool filtraKm = !string.IsNullOrEmpty(kmIni) || !string.IsNullOrEmpty(kmFim);
                bool filtraDisciplina = !string.IsNullOrEmpty(discFiltro);

                // se só um lado do sub vier preenchido, considera como "exato"
                if (!string.IsNullOrEmpty(subIni) && string.IsNullOrEmpty(subFim)) subFim = subIni;
                if (string.IsNullOrEmpty(subIni) && !string.IsNullOrEmpty(subFim)) subIni = subFim;
                bool filtraSub = !string.IsNullOrEmpty(subIni) && !string.IsNullOrEmpty(subFim);

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
                    if (filtraDisciplina && !pathDisciplinaDestino.Contains(discFiltro, StringComparison.OrdinalIgnoreCase))
                        continue;

                    // SUB: compara por número (intervalo)
                    if (filtraSub)
                    {
                        int subNum = ParseSubInt(sub);       // "Sub 01" -> 1
                        int subIniNu = ParseSubInt(subIni);    // "01"     -> 1
                        int subFimNu = ParseSubInt(subFim);    // "02"     -> 2

                        if (subNum == int.MinValue || subIniNu == int.MinValue || subFimNu == int.MinValue)
                            continue;

                        if (subNum < subIniNu || subNum > subFimNu)
                            continue;
                    }

                    // KM: compara por número (inteiro antes de vírgula ou '+')
                    if (filtraKm)
                    {
                        double kmNum = ParseKmFlexible(km);
                        double kmIniNu = ParseKmFlexible(kmIni);
                        double kmFimNu = ParseKmFlexible(kmFim);

                        if (double.IsNaN(kmNum) || double.IsNaN(kmIniNu) || double.IsNaN(kmFimNu))
                            continue;

                        if (kmNum < kmIniNu || kmNum > kmFimNu)
                            continue;
                    }


                    var key = (km.Trim(), pathDisciplinaDestino.Trim(), sub.Trim());
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

                sw.Stop();

                // Metadados
                writer.WriteLine($"# Relatório gerado: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                writer.WriteLine($"# Destino: {textBox1.Text}");
                writer.WriteLine($"# Disciplina: {(filtraDisciplina ? textBox5.Text : "Todos")}");
                writer.WriteLine($"# Km: {(filtraKm ? $"{kmIni} até {kmFim}" : "Todos")}");
                writer.WriteLine($"# Sub: {(filtraSub ? $"{subIni} até {subFim}" : "Todos")}");
                writer.WriteLine($"# Anos: {startYear}–{endYear}");
                writer.WriteLine($"# Linhas (KM/Disciplina/Sub): {rows.Count}");
                writer.WriteLine($"# Tempo de processamento: {sw.Elapsed:hh\\:mm\\:ss\\.fff}");
                writer.WriteLine(); // separador

                // Cabeçalho
                writer.WriteLine(string.Join(';',
                    new[] { "km", "disciplina", "sub" }.Concat(anos.Select(a => a.ToString()))));

                foreach (var kv in rows.OrderBy(r => r.Key.km).ThenBy(r => r.Key.disciplina).ThenBy(r => r.Key.sub))
                {
                    var (km, disciplina, sub) = kv.Key;
                    var anosEncontrados = kv.Value;

                    var linha = new List<string> { km, disciplina, sub };
                    foreach (var a in anos)
                        linha.Add(anosEncontrados.Contains(a) ? "SIM" : "NÃO");

                    writer.WriteLine(string.Join(';', linha));
                }

                //MessageBox.Show($"Arquivo salvo em:\n{fileNameCsv}");

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

            string s = value.Trim().ToUpperInvariant();

            // remove prefixos e sufixos irrelevantes
            s = s.Replace("KM", "")
                 .Replace("PT", "")
                 .Trim();

            // corta tudo a partir de vírgula ou "+"
            int idxVirg = s.IndexOf(',');
            int idxMais = s.IndexOf('+');
            int idxCorte = -1;

            if (idxVirg >= 0 && idxMais >= 0)
                idxCorte = Math.Min(idxVirg, idxMais);
            else if (idxVirg >= 0)
                idxCorte = idxVirg;
            else if (idxMais >= 0)
                idxCorte = idxMais;

            if (idxCorte >= 0)
                s = s.Substring(0, idxCorte);

            // extrai o primeiro número que encontrar
            var match = System.Text.RegularExpressions.Regex.Match(s, @"\d+");
            if (match.Success && double.TryParse(match.Value, out double km))
                return km;

            return double.NaN;
        }

        // Extrai o primeiro número inteiro do texto do SUB.
        // Exemplos: "Sub 01" -> 1 | "SUB-25" -> 25 | "15" -> 15
        private static int ParseSubInt(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return int.MinValue;
            var m = System.Text.RegularExpressions.Regex.Match(value, @"\d+");
            if (m.Success && int.TryParse(m.Value, out int v)) return v;
            return int.MinValue;
        }


        private void Report_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveLastLimitPath();
        }

        private void Report_Load(object sender, EventArgs e)
        {

        }
    }
}
