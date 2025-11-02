using System;
using System.IO;
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
                string subAux = "";

                int posPathSource = textBox1.Text.Split('\\').Length;

                string[] pathFiles = Service.GetArquivosOrigem(textBox1.Text);

                if (pathFiles.Length == 0) return;

                foreach (string pathFile in pathFiles)
                {
                    string[] pathFilePart = pathFile.Split('\\');

                    string fileName = pathFilePart[^1];

                    (string sub, string km, string ano, string disciplina, string modalidade, string nomePastaFoto) = Service.ProcessPathParts(pathFilePart, posPathSource);

                    bool temSub = !string.IsNullOrEmpty(sub);
                    bool temKm = !string.IsNullOrEmpty(km);
                    bool temAno = !string.IsNullOrEmpty(ano);
                    bool temDisciplina = !string.IsNullOrEmpty(disciplina);
                    bool temmodalidade = !string.IsNullOrEmpty(modalidade);
                    bool temnomePastaFoto = !string.IsNullOrEmpty(nomePastaFoto);

                    string pathDisciplinaDestino = Service.getPathDisciplinaDestino(disciplina);

                    string fileNameDestination = Path.Combine(textBox1.Text, pathDisciplinaDestino, sub, km, modalidade, ano, nomePastaFoto, fileName);

                    if (fileNameDestination == pathFile)
                    {
                        // chamar funcao para salvar em csv para excel
                    }
                }
            }));
        }
    }
}
