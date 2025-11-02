using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FileMover
{
    public partial class Report : Form
    {
        // informe o intervalo em tela (textbox, numericUpDown etc.)
        private int startYear => int.Parse(textBox6.Text);  // ex.: 2021
        private int endYear => int.Parse(textBox7.Text);    // ex.: 2025

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

                // ---- 1) Agregador: km+disciplina+sub -> anos encontrados
                var rows = new Dictionary<(string km, string disciplina, string sub), HashSet<int>>();

                foreach (string pathFile in pathFiles)
                {
                    string[] pathFilePart = pathFile.Split('\\');
                    string fileName = pathFilePart[^1];

                    (string sub, string km, string ano, string disciplina, string modalidade, string nomePastaFoto)
                        = Service.ProcessPathParts(pathFilePart, posPathSource);

                    // monte o caminho de destino para validar
                    string pathDisciplinaDestino = Service.getPathDisciplinaDestino(disciplina);
                    string fileNameDestination = Path.Combine(textBox1.Text, pathDisciplinaDestino, sub, km, modalidade, ano, nomePastaFoto, fileName);

                    if (fileNameDestination != pathFile) continue; // só considera os válidos

                    // valida campos essenciais
                    if (string.IsNullOrWhiteSpace(km) ||
                        string.IsNullOrWhiteSpace(disciplina) ||
                        string.IsNullOrWhiteSpace(sub) ||
                        string.IsNullOrWhiteSpace(ano)) continue;

                    if (!int.TryParse(ano, out int year)) continue;
                    if (year < startYear || year > endYear) continue; // fora do intervalo pedido

                    var key = (km.Trim(), disciplina.Trim(), sub.Trim());
                    if (!rows.TryGetValue(key, out var set))
                    {
                        set = new HashSet<int>();
                        rows[key] = set;
                    }
                    set.Add(year); // marca que para esse km/disciplina/sub houve arquivo nesse ano
                }

                // ---- 2) Gera o CSV
                Directory.CreateDirectory(@"c:\temp");
                var fileNameCsv = $@"c:\temp\relatorio_arquivos_copiados_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                var anos = Enumerable.Range(startYear, endYear - startYear + 1).ToArray();

                using var writer = new StreamWriter(fileNameCsv, false, Encoding.UTF8);

                // cabeçalho (use "disciplina" ou "duciplina" conforme desejar no arquivo)
                writer.WriteLine(string.Join(';',
                    new[] { "km", "disciplina", "sub" }.Concat(anos.Select(a => a.ToString()))));

                // ordenação opcional
                foreach (var kv in rows.OrderBy(r => r.Key.km).ThenBy(r => r.Key.disciplina).ThenBy(r => r.Key.sub))
                {
                    var (km, disciplina, sub) = kv.Key;
                    var anosEncontrados = kv.Value;

                    var linha = new List<string> { km, disciplina, sub };
                    foreach (var a in anos)
                        linha.Add(anosEncontrados.Contains(a) ? "SIM" : "NÃO");

                    writer.WriteLine(string.Join(';', linha));
                }

                // se quiser avisar onde salvou:
                MessageBox.Show($"Arquivo salvo em:\n{fileNameCsv}");
            }));
        }
    }
}
