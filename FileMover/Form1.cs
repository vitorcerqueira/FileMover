using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
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
                //var thread = new Thread(LoadGrid2);
                //thread.Start();

                LoadGrid2();
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

        static string[] GetArquivosOrigem(string caminho)
        {
            string[] resultado = Array.Empty<string>();

            // Cria e exibe uma tela de carregamento
            using (Form loadingForm = new Form())
            {
                loadingForm.Text = "Aguarde...";
                loadingForm.StartPosition = FormStartPosition.CenterScreen;
                loadingForm.Size = new System.Drawing.Size(250, 100);
                loadingForm.ControlBox = false;
                loadingForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                loadingForm.TopMost = true;

                Label label = new Label()
                {
                    Text = "Aguarde carregando arquivos...",
                    AutoSize = true,
                    Location = new System.Drawing.Point(35, 20)
                };

                loadingForm.Controls.Add(label);
                loadingForm.Shown += async (sender, e) =>
                {
                    resultado = await Task.Run(() =>
                        Directory.GetFiles(caminho, "*", SearchOption.AllDirectories)
                        .Where(arquivo =>
                        {
                            FileAttributes atributos = File.GetAttributes(arquivo);

                            bool ret = (atributos & FileAttributes.Hidden) == 0 && (atributos & FileAttributes.System) == 0;

                            return ret;
                        })
                        .OrderBy(arquivo => arquivo, StringComparer.OrdinalIgnoreCase) // Ordena pelo caminho completo
                        .ToArray()
                    );

                    loadingForm.Close();
                };

                loadingForm.ShowDialog();
            }

            return resultado;
        }

        private void LoadGrid2()
        {
            //Invoke(new Action(() =>
            //{
            requiredSpaceInMB = 0;
            dataGridView.Rows.Clear();

            int totLimitPath = int.TryParse(txtLimitPath.Text, out int temp1) ? temp1 : 0;
            int totLimitFile = int.TryParse(txtLimitFile.Text, out int temp2) ? temp2 : 0;
            int totFilesCount = 0;

            bool shouldBreak = false;
            string subAux = "";

            int posPathSource = txtSourceFolder.Text.Split('\\').Length;

            progressBar.Maximum = 0; //pathFiles.Length;
            progressBar.Value = 0;

            string[] pathFiles = GetArquivosOrigem(txtSourceFolder.Text);

            if (pathFiles.Length == 0) return;

            progressBar.Maximum = totLimitFile; //pathFiles.Length;

            //foreach (string pathSource in pathsSource)
            //{
            //    if (shouldBreak || totPath <= 0) break;

            //    var pathFileSourceOrdenado = Directory.GetFiles(pathSource, "*.*", SearchOption.AllDirectories)
            //                                          .OrderBy(c => string.Join("\\", c.Split('\\').Skip(1)))
            //                                          .ToList();

            foreach (string pathFile in pathFiles)
            {
                if (totLimitFile <= 0) break;

                string[] pathFilePart = pathFile.Split('\\');

                string fileName = pathFilePart[^1];

                (string sub, string km, string ano, string disciplina, string modalidade, string nomePastaFoto) = ProcessPathParts(pathFilePart, posPathSource);

                bool temSub = !string.IsNullOrEmpty(sub);
                bool temKm = !string.IsNullOrEmpty(km);
                bool temAno = !string.IsNullOrEmpty(ano);
                bool temDisciplina = !string.IsNullOrEmpty(disciplina);
                bool temmodalidade = !string.IsNullOrEmpty(modalidade);
                bool temnomePastaFoto = !string.IsNullOrEmpty(nomePastaFoto);

                string pathDisciplinaDestino = getPathDisciplinaDestino(disciplina);

                string fileNameDestination = Path.Combine(txtDestinationFolder.Text, pathDisciplinaDestino, sub, km, modalidade, ano, nomePastaFoto, fileName);

                bool achou = File.Exists(fileNameDestination);

                if (temSub && temKm && temAno && temDisciplina)
                {
                    double tamanhoMB = new FileInfo(pathFile).Length;
                    string tamanhoFileSource = getTamanhoFile(tamanhoMB);

                    if (temSub & validaSubMalhaSul(sub) && sub == "Sub 01")
                    {
                        if (((radioAll.Checked) || (!achou && radioPending.Checked) || (achou && radioCopied.Checked)) && ano.Contains(txtYear.Text))
                        {
                            totLimitFile--;

                            //if (sub != subAux)
                            //{
                            //    subAux = sub;
                            //    totLimitPath--;
                            //}

                            requiredSpaceInMB += tamanhoMB;

                            AddRowToGrid(pathFile, fileNameDestination, tamanhoFileSource, achou, false);

                            //totFilesCount++;

                            //if (totLimitFile > 0 && totFilesCount >= totLimitFile)
                            //{
                            //    shouldBreak = true;
                            //    break;
                            //}

                            //progressBar.Invoke(new Action(() => progressBar.Value++));

                            progressBar.Value++;
                        }
                    }
                }
                else if (!radioPending.Checked && !radioCopied.Checked)
                {
                    totLimitFile--;

                    //if ((!temSub || !temKm || !temAno || !temDisciplina) && (!achou && !radioPending.Checked) && (!radioCopied.Checked) && (!radioAll.Checked))
                    //{

                    AddRowToGrid(pathFile, "", "", achou, true);

                    //progressBar.Invoke(new Action(() => progressBar.Value++));

                    progressBar.Value++;
                }
            }
            //}
            //}));
        }

        private bool validaSubMalhaSul(string valor)
        {
            HashSet<string> valoresPermitidos = new HashSet<string>();

            valoresPermitidos.Add("Sub 01");
            valoresPermitidos.Add("Sub 02");
            valoresPermitidos.Add("Sub 03");
            valoresPermitidos.Add("Sub 04");
            valoresPermitidos.Add("Sub 05");
            valoresPermitidos.Add("Sub 06");
            valoresPermitidos.Add("Sub 07");
            valoresPermitidos.Add("Sub 08");
            valoresPermitidos.Add("Sub 09");
            valoresPermitidos.Add("Sub 10");
            valoresPermitidos.Add("Sub 11");
            valoresPermitidos.Add("Sub 12");
            valoresPermitidos.Add("Sub 13");
            valoresPermitidos.Add("Sub 14");
            valoresPermitidos.Add("Sub 15");
            valoresPermitidos.Add("Sub 16");
            valoresPermitidos.Add("Sub 17");
            valoresPermitidos.Add("Sub 18");
            valoresPermitidos.Add("Sub 19");
            valoresPermitidos.Add("Sub 20");
            valoresPermitidos.Add("Sub 21");
            valoresPermitidos.Add("Sub 22");
            valoresPermitidos.Add("Sub 23");
            valoresPermitidos.Add("Sub 24");
            valoresPermitidos.Add("Sub 25");
            valoresPermitidos.Add("Sub 26");
            valoresPermitidos.Add("Sub 27");
            valoresPermitidos.Add("Sub 28");
            valoresPermitidos.Add("Sub 29");
            valoresPermitidos.Add("Sub 30");
            valoresPermitidos.Add("Sub 31");
            valoresPermitidos.Add("Sub 32");
            valoresPermitidos.Add("Sub 33");
            valoresPermitidos.Add("Sub 34");
            valoresPermitidos.Add("Sub 35");
            valoresPermitidos.Add("Sub 36");
            valoresPermitidos.Add("Sub 37");
            valoresPermitidos.Add("Sub 38");
            valoresPermitidos.Add("Sub 39");
            valoresPermitidos.Add("Sub 40");
            valoresPermitidos.Add("Sub 41");
            valoresPermitidos.Add("Sub 45");

            return valoresPermitidos.Contains(valor);
        }

        private string getTamanhoFile(double tamanhoMB = 0)
        {
            string tamanhoFileSource = $"{Math.Round(tamanhoMB / (1024.0 * 1024.0), 2)} MB";

            return (tamanhoFileSource);
        }

        private string getPathDisciplinaDestino(string disciplina)
        {
            /*
                01. Pontes = PT 
                02. Infraestrutura = AT = ATERRO / SM = SEÇAO MISTA / CT = CORTE / BU = BUEIRO / CO = CONTENÇAO 
                03. PNs = PN
                04. Túneis = TU  
            */

            if (disciplina.ToUpper().Equals("PT"))
            {
                return "01. Pontes";
            }
            else if (disciplina.ToUpper().Equals("AT"))
            {
                return "02. Infraestrutura";
            }
            else if (disciplina.ToUpper().Equals("SM"))
            {
                return "02. Infraestrutura";
            }
            else if (disciplina.ToUpper().Equals("CT"))
            {
                return "02. Infraestrutura";
            }
            else if (disciplina.ToUpper().Equals("BU"))
            {
                return "02. Infraestrutura";
            }
            else if (disciplina.ToUpper().Equals("CO"))
            {
                return "02. Infraestrutura";
            }
            else if (disciplina.ToUpper().Equals("PN"))
            {
                return "03. PNs";
            }
            else if (disciplina.ToUpper().Equals("TU"))
            {
                return "04. Túneis";
            }

            return "";
        }

        private (string sub, string km, string ano, string disciplina, string modalidade, string nomePastaFoto) ProcessPathParts(string[] pathFilePart, int posPathSource)
        {
            string sub = ExtractSub(pathFilePart, posPathSource);
            string km = ExtractKm(pathFilePart, posPathSource);
            string disciplina = ExtractDisciplina(pathFilePart, posPathSource);
            string ano = ExtractYear(pathFilePart, posPathSource);
            string modalidade = ExtractModalidade(pathFilePart, posPathSource);
            string nomePastaFoto = ExtractNomePastaFoto(pathFilePart, posPathSource);

            return (sub, km, ano, disciplina, modalidade, nomePastaFoto);
        }

        private string ExtractNomePastaFoto(string[] pathFilePart, int posPathSource)
        {
            string[] formatos =
            {
                "yyyy-MM-dd", "yyyyMMdd", "dd-MM-yyyy", "dd.MM.yyyy", "dd_MM_yyyy"
            };

            foreach (var namePath in pathFilePart.Skip(posPathSource))
            {
                foreach (var formato in formatos)
                {
                    var match = Regex.Match(namePath, "(\\d{4}-\\d{2}-\\d{2})|(\\d{8})|(\\d{2}-\\d{2}-\\d{4})|(\\d{2}\\.\\d{2}\\.\\d{4})|(\\d{2}_\\d{2}_\\d{4})");

                    if (match.Success && DateTime.TryParseExact(match.Value, formato, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime data))
                    {
                        return $"foto_{data:yyyy-MM-dd}";
                    }
                }
            }

            return "";
        }

        private string ExtractYear(string[] pathFilePart, int posPathSource)
        {
            foreach (var namePath in pathFilePart.Skip(posPathSource))
            {
                string regexDot = @"(19|20)\d{2}";

                if (Regex.IsMatch(namePath, regexDot))
                {
                    return Regex.Match(namePath, regexDot).Value;
                }
            }

            return "";
        }

        private string ExtractSub(string[] pathFilePart, int posPathSource)
        {
            foreach (var namePath in pathFilePart.Skip(posPathSource))
            {
                if (namePath.StartsWith("sub", StringComparison.CurrentCultureIgnoreCase) && !namePath.Contains("km", StringComparison.CurrentCultureIgnoreCase))
                {
                    string numericPart = new string(namePath.Where(char.IsDigit).ToArray());
                    return int.TryParse(numericPart, out int number) ? $"Sub {number:00}" : namePath;
                }
            }
            return "";
        }

        private string ExtractKm(string[] pathFilePart, int posPathSource)
        {
            foreach (var namePath in pathFilePart.Skip(posPathSource))
            {
                if (namePath.StartsWith("km", StringComparison.CurrentCultureIgnoreCase))
                {
                    //string[] namePathList = namePath.Split(' ');

                    //if (namePathList.Length > 0)
                    //{
                    //    return namePathList[0] + " " + (namePathList.Length > 1 ? namePathList[1] : "");
                    //}

                    return namePath;
                }
            }

            return "";
        }

        private string ExtractDisciplina(string[] pathFilePart, int posPathSource)
        {
            foreach (var namePath in pathFilePart.Skip(posPathSource))
            {
                if (namePath.StartsWith("km", StringComparison.CurrentCultureIgnoreCase))
                {
                    string[] namePathList = namePath.Split(' ');

                    return namePathList.Length == 3 ? namePathList[^1] : "";
                }
            }

            return "";
        }

        private string ExtractModalidade(string[] pathFilePart, int posPathSource)
        {
            for (int i = posPathSource; i < pathFilePart.Length - 1; i++)
            {
                string namePathFile = pathFilePart[i];

                // primeira tentativa
                if (!namePathFile.StartsWith("sub", StringComparison.CurrentCultureIgnoreCase) && !namePathFile.StartsWith("km", StringComparison.CurrentCultureIgnoreCase))
                {
                    if (namePathFile.StartsWith("Inspeção", StringComparison.CurrentCultureIgnoreCase))
                    {
                        return "01. Inspeções";
                    }

                    if (namePathFile.StartsWith("Sinalização", StringComparison.CurrentCultureIgnoreCase))
                    {
                        return "02. Sinalização";
                    }
                }
            };

            return "01. Inspeções"; // default
        }

        private void AddRowToGrid(string pathFile, string fileNameDestination, string tamanhoFileSource, bool achou, bool ignorar)
        {
            int rowIndex = dataGridView.Rows.Add(pathFile, fileNameDestination, tamanhoFileSource);
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
                            string sourceFile = row.Cells[0].Value.ToString();
                            string destFile = row.Cells[1].Value.ToString();

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

                                    string path = GetPathUntil2(sourceFile, "sub");

                                    if (auxPath != path)
                                    {
                                        auxPath = path;

                                        writer.WriteLine(path);
                                    }

                                    string km = GetPathUntil(sourceFile, "km");

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

        static string GetPathUntil(string path, string find)
        {
            string[] list = path.Split("\\");

            for (int i = 0; i < list.Length; i++)
            {
                if (list[i].ToUpper().StartsWith(find.ToUpper()))
                {
                    return list[i];
                }
            }

            return "";
        }

        static string GetPathUntil2(string path, string find)
        {
            string[] list = path.Split("\\");
            string aux = "";

            for (int i = 0; i < list.Length; i++)
            {
                aux += list[i] + "\\";

                if (list[i].ToUpper().StartsWith(find.ToUpper()))
                {
                    return aux;
                }
            }

            return "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //txtSourceFolder.Text = "C:\\temp1";
            //txtDestinationFolder.Text = "C:\\temp2";

            //txtDestinationFolder.Text = "C:\\Rumo\\Infraestrutura e OAEs - 10. ENGENHARIA\\7-Cadastro e Gestão de Ativos";
            //txtSourceFolder.Text = "C:\\Delvined\\Inspeção de Pontes\\Métrica";
        }

        private void radioCopied_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}