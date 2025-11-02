using FileMover;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FileMoverApp
{
    public partial class Form1 : Form
    {
        private const string ConfigFilePath = "Config.xml";
        private double requiredSpaceInMB = 0;

        public Form1()
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
                        new XElement("LastLimitPath", txtLimitPath.Text),
                        new XElement("LastSourceValue", txtSourceFolder.Text),
                        new XElement("LastLimitFile", txtLimitFile.Text),
                        new XElement("LastYear", txtYear.Text),
                        new XElement("LastDestinationValue", txtDestinationFolder.Text)
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
                            new XElement("LastSourceValue", ""),
                            new XElement("LastLimitPath", ""),
                            new XElement("LastLimitFile", ""),
                            new XElement("LastYear", ""),
                            new XElement("LastDestinationValue", "")
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

                var valueElement1 = config.Root.Element("LastLimitPath");

                if (valueElement1 != null)
                {
                    txtLimitPath.Text = valueElement1.Value;
                }

                var valueElement2 = config.Root.Element("LastSourceValue");

                if (valueElement2 != null)
                {
                    txtSourceFolder.Text = valueElement2.Value;
                }

                var valueElement3 = config.Root.Element("LastLimitFile");

                if (valueElement3 != null)
                {
                    txtLimitFile.Text = valueElement3.Value;
                }

                var valueElement4 = config.Root.Element("LastYear");

                if (valueElement4 != null)
                {
                    txtYear.Text = valueElement4.Value;
                }

                var valueElement5 = config.Root.Element("LastDestinationValue");

                if (valueElement5 != null)
                {
                    txtDestinationFolder.Text = valueElement5.Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar o valor: " + ex.Message, "Atenção", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveLastLimitPath();
        }

        private void btnSelectSource_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtSourceFolder.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnSelectDestination_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtDestinationFolder.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnLoadGrid_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSourceFolder.Text))
            {
                MessageBox.Show("Please select a source folder.", "Atenção", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                var thread = new Thread(LoadGrid2);
                thread.Start();

                //LoadGrid2();
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

        private void btnMoveFiles_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSourceFolder.Text) || string.IsNullOrEmpty(txtDestinationFolder.Text))
                {
                    MessageBox.Show("Please select both source and destination folders.");
                    return;
                }

                var thread = new Thread(CopyFiles);
                thread.Start();
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

        private void LoadGrid2()
        {
            Invoke(new Action(() =>
            {
                requiredSpaceInMB = 0;
                dataGridView.Rows.Clear();

                int totLimitPath = int.TryParse(txtLimitPath.Text, out int temp1) ? temp1 : 0;
                int totLimitFile = int.TryParse(txtLimitFile.Text, out int temp2) ? temp2 : 0;
                int linha = 0;

                string subAux = "";

                int posPathSource = txtSourceFolder.Text.Split('\\').Length;

                progressBar.Maximum = 0; //pathFiles.Length;
                progressBar.Value = 0;

                string[] pathFiles = Service.GetArquivosOrigem(txtSourceFolder.Text);

                if (pathFiles.Length == 0) return;

                progressBar.Maximum = totLimitFile; //pathFiles.Length;

                foreach (string pathFile in pathFiles)
                {
                    if (totLimitFile == 0) break;

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

                    string fileNameDestination = Path.Combine(txtDestinationFolder.Text, pathDisciplinaDestino, sub, km, modalidade, ano, nomePastaFoto, fileName);

                    bool achou = File.Exists(fileNameDestination);

                    if (temSub && temKm && temAno && temDisciplina)
                    {
                        double tamanhoMB = new FileInfo(pathFile).Length;
                        string tamanhoFileSource = Service.getTamanhoFile(tamanhoMB);

                        if (temSub & Service.validaSubMalhaSul(sub)) // && sub == "Sub 01"
                        {
                            if (((radioAll.Checked) || (!achou && radioPending.Checked) || (achou && radioCopied.Checked)) && ano.Contains(txtYear.Text))
                            {
                                totLimitFile--;

                                if (sub != subAux)
                                {
                                    subAux = sub;

                                    totLimitPath--;

                                    if (totLimitPath < 0) break;
                                }

                                requiredSpaceInMB += tamanhoMB / (1024.0 * 1024.0);

                                linha++;
                                AddRowToGrid(linha, pathFile, fileNameDestination, tamanhoFileSource, achou, false);

                                progressBar.Invoke(new Action(() => progressBar.Value++));

                                //progressBar.Value++;
                            }
                        }
                    }
                    else if (!radioPending.Checked && !radioCopied.Checked)
                    {
                        totLimitFile--;

                        linha++;
                        AddRowToGrid(linha, pathFile, "", "", achou, true);

                        progressBar.Invoke(new Action(() => progressBar.Value++));

                        //progressBar.Value++;
                    }
                }
            }));
        }

        private void AddRowToGrid(int linha, string pathFile, string fileNameDestination, string tamanhoFileSource, bool achou, bool ignorar)
        {
            //// Suspendendo o layout para otimizar a adição de várias linhas
            //dataGridView.SuspendLayout();

            //// Adiciona uma nova linha sem precisar atribuir valores ainda
            //int rowIndex = dataGridView.Rows.Add();

            //// Definindo os valores das células de uma vez
            //dataGridView.Rows[rowIndex].Cells[0].Value = rowIndex + 1; // Número da linha
            //dataGridView.Rows[rowIndex].Cells[1].Value = pathFile; // Segunda coluna
            //dataGridView.Rows[rowIndex].Cells[2].Value = fileNameDestination; // Terceira coluna
            //dataGridView.Rows[rowIndex].Cells[3].Value = tamanhoFileSource; // Quarta coluna

            //// Definindo a cor da linha com base nas condições
            //dataGridView.Rows[rowIndex].DefaultCellStyle.BackColor = ignorar ? Color.Orange : achou ? Color.Green : Color.Tomato;

            //// Retomando o layout para renderizar tudo de uma vez
            //dataGridView.ResumeLayout();

            int rowIndex = dataGridView.Rows.Add(linha, pathFile, fileNameDestination, tamanhoFileSource);

            dataGridView.Rows[rowIndex].DefaultCellStyle.BackColor = ignorar ? Color.Orange : achou ? Color.Green : Color.Tomato;
        }

        private void CopyFiles()
        {
            try
            {
                DriveInfo drive = new DriveInfo(Path.GetPathRoot(Path.GetPathRoot(txtDestinationFolder.Text)));

                double availableFreeSpace = drive.AvailableFreeSpace / (1024.0 * 1024.0);

                if (availableFreeSpace >= requiredSpaceInMB)
                {
                    Invoke(new Action(() =>
                    {
                        progressBar.Maximum = dataGridView.Rows.Count;
                        progressBar.Value = 0;

                        Boolean achou = false;

                        var writer = new StreamWriter(@$"c:\temp\Relatorio_FileMover_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.txt");

                        string auxPath = "";

                        foreach (DataGridViewRow row in dataGridView.Rows)
                        {
                            string sourceFile = row.Cells[1].Value.ToString();
                            string destFile = row.Cells[2].Value.ToString();

                            if (!File.Exists(destFile))
                            {
                                try
                                {
                                    string destinationDir = Path.GetDirectoryName(destFile);

                                    if (!Directory.Exists(destinationDir))
                                    {
                                        Directory.CreateDirectory(destinationDir);
                                    }

                                    File.Copy(sourceFile, destFile, true);

                                    string path = Service.GetPathUntil2(sourceFile, "sub");

                                    if (auxPath != path)
                                    {
                                        auxPath = path;

                                        writer.WriteLine(path);
                                    }

                                    string km = Service.GetPathUntil(sourceFile, "km");

                                    writer.WriteLine(km.PadLeft(5));

                                    achou = true;

                                    //Thread.Sleep(1000);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"Error copy file {sourceFile}: {ex.Message}", "Atenção",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }

                            //progressBar.Value++;

                            progressBar.Invoke(new Action(() => progressBar.Value++));
                        }

                        if (achou)
                        {
                            writer.Close();

                            MessageBox.Show("Arquivos movidos com sucesso!", "Atenção", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            MessageBox.Show("Não foi encontrado arquivos para copiar!", "Atenção", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                        }
                    }));
                }
                else
                {
                    MessageBox.Show("Não há espaço suficiente disponível em " + drive.Name + " \n \n Requerido: " + requiredSpaceInMB.ToString("F2") + " MB \n \n Livre : " + availableFreeSpace.ToString("F2") + " MB", "Atenção", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

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

        private void Form1_Load(object sender, EventArgs e)
        {
            //txtSourceFolder.Text = "C:\\temp1";
            //txtDestinationFolder.Text = "C:\\temp2";

            //txtDestinationFolder.Text = "C:\\Rumo\\Infraestrutura e OAEs - 10. ENGENHARIA\\7-Cadastro e Gestão de Ativos";
            //txtSourceFolder.Text = "C:\\Delvined\\Inspeção de Pontes\\Métrica";
        }

        private void btnExportGrid_Click(object sender, EventArgs e)
        {
            var reportForm = new Report();
            reportForm.ShowDialog(); // Abre como modal. Use Show() se quiser não modal.
        }
    }
}