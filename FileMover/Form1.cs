using FileMover;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FileMoverApp
{
    public partial class Form1 : Form
    {
        private const string ConfigFilePath = "Config.xml";
        private double requiredSpaceInMB = 0;
        private double requiredInfraSpaceInMB = 0;

        public Form1()
        {
            InitializeComponent();
            EnsureConfigFileExists();
            LoadLastValues();
        }

        private void EnsureConfigFileExists()
        {
            if (File.Exists(ConfigFilePath))
            {
                return;
            }

            try
            {
                var config = new XDocument(
                    new XElement("Configuration",
                        new XElement("LastLimitPath", ""),
                        new XElement("LastSourceValue", ""),
                        new XElement("LastLimitFile", ""),
                        new XElement("LastYear", ""),
                        new XElement("LastDestinationValue", ""),
                        new XElement("LastInfraSpreadsheet", ""),
                        new XElement("LastInfraDestinationValue", ""),
                        new XElement("LastInfraLimitPath", ""),
                        new XElement("LastInfraLimitFile", ""),
                        new XElement("LastInfraYear", "")));

                config.Save(ConfigFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao criar o arquivo de configuração: " + ex.Message, "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLastValues()
        {
            try
            {
                XDocument config = XDocument.Load(ConfigFilePath);

                txtLimitPath.Text = GetConfigValue(config, "LastLimitPath");
                txtSourceFolder.Text = GetConfigValue(config, "LastSourceValue");
                txtLimitFile.Text = GetConfigValue(config, "LastLimitFile");
                txtYear.Text = GetConfigValue(config, "LastYear");
                txtDestinationFolder.Text = GetConfigValue(config, "LastDestinationValue");
                txtInfraSpreadsheet.Text = GetConfigValue(config, "LastInfraSpreadsheet");
                txtInfraDestinationFolder.Text = GetConfigValue(config, "LastInfraDestinationValue");
                txtInfraLimitPath.Text = GetConfigValue(config, "LastInfraLimitPath");
                txtInfraLimitFile.Text = GetConfigValue(config, "LastInfraLimitFile");
                txtInfraYear.Text = GetConfigValue(config, "LastInfraYear");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar o valor: " + ex.Message, "Atenção", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private static string GetConfigValue(XDocument config, string elementName)
        {
            return config.Root?.Element(elementName)?.Value ?? string.Empty;
        }

        private void SaveLastValues()
        {
            try
            {
                var config = new XDocument(
                    new XElement("Configuration",
                        new XElement("LastLimitPath", txtLimitPath.Text),
                        new XElement("LastSourceValue", txtSourceFolder.Text),
                        new XElement("LastLimitFile", txtLimitFile.Text),
                        new XElement("LastYear", txtYear.Text),
                        new XElement("LastDestinationValue", txtDestinationFolder.Text),
                        new XElement("LastInfraSpreadsheet", txtInfraSpreadsheet.Text),
                        new XElement("LastInfraDestinationValue", txtInfraDestinationFolder.Text),
                        new XElement("LastInfraLimitPath", txtInfraLimitPath.Text),
                        new XElement("LastInfraLimitFile", txtInfraLimitFile.Text),
                        new XElement("LastInfraYear", txtInfraYear.Text)));

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
            SaveLastValues();
        }

        private void btnSelectSource_Click(object sender, EventArgs e)
        {
            SelectFolder(txtSourceFolder);
        }

        private void btnSelectDestination_Click(object sender, EventArgs e)
        {
            SelectFolder(txtDestinationFolder);
        }

        private void btnInfraSelectDestination_Click(object sender, EventArgs e)
        {
            SelectFolder(txtInfraDestinationFolder);
        }

        private void SelectFolder(TextBox targetTextBox)
        {
            using FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                targetTextBox.Text = fbd.SelectedPath;
                SaveLastValues();
            }
        }

        private void btnInfraSelectSpreadsheet_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Planilhas Excel|*.xlsx;*.xlsm;*.xls";
            dialog.Title = "Selecione a planilha de cadastro";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtInfraSpreadsheet.Text = dialog.FileName;
                SaveLastValues();
            }
        }

        private void btnLoadGrid_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSourceFolder.Text))
            {
                MessageBox.Show("Selecione a pasta de origem.", "Atenção", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                SaveLastValues();
                new Thread(LoadDefaultGrid).Start();

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
            if (string.IsNullOrWhiteSpace(txtSourceFolder.Text) || string.IsNullOrWhiteSpace(txtDestinationFolder.Text))
            {
                MessageBox.Show("Selecione as pastas de origem e destino.", "Atenção", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            SaveLastValues();
            new Thread(() => ProcessFiles(dataGridView, progressBar, txtDestinationFolder.Text, requiredSpaceInMB, true, false)).Start();

            // CopyFiles(dataGridView, progressBar, txtDestinationFolder.Text, requiredSpaceInMB, true));
        }

        private void btnInfraLoadGrid_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtInfraSpreadsheet.Text) ||
                string.IsNullOrWhiteSpace(txtInfraDestinationFolder.Text))
            {
                MessageBox.Show("Selecione a planilha e a pasta base da aba Infra.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                SaveLastValues();
                new Thread(LoadInfraGrid).Start();

                //LoadInfraGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro inesperado: {ex.Message}");
            }
        }

        private void btnInfraMoveFiles_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtInfraDestinationFolder.Text))
            {
                MessageBox.Show("Selecione a pasta base da aba Infra.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            SaveLastValues();
            new Thread(() => ProcessFiles(dataGridViewInfra, progressBarInfra, txtInfraDestinationFolder.Text, requiredInfraSpaceInMB, false, true)).Start();

            // CopyFiles(dataGridViewInfra, progressBarInfra, txtInfraDestinationFolder.Text, requiredInfraSpaceInMB, false)
        }

        private void LoadDefaultGrid()
        {
            try
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

                    progressBar.Maximum = 1;
                    progressBar.Value = 0;

                    string[] pathFiles = Service.GetArquivosOrigem(txtSourceFolder.Text);
                    if (pathFiles.Length == 0)
                    {
                        return;
                    }

                    progressBar.Maximum = Math.Max(1, totLimitFile == 0 ? pathFiles.Length : totLimitFile);

                    foreach (string pathFile in pathFiles)
                    {
                        if (totLimitFile == 0 && !string.IsNullOrWhiteSpace(txtLimitFile.Text))
                        {
                            break;
                        }

                        string[] pathFilePart = pathFile.Split('\\');
                        string fileName = pathFilePart[^1];

                        (string sub, string km, string ano, string disciplina, string modalidade, string nomePastaFoto) =
                            Service.ProcessPathParts(pathFilePart, posPathSource);

                        bool temSub = !string.IsNullOrEmpty(sub);
                        bool temKm = !string.IsNullOrEmpty(km);
                        bool temAno = !string.IsNullOrEmpty(ano);
                        bool temDisciplina = !string.IsNullOrEmpty(disciplina);

                        string pathDisciplinaDestino = Service.getPathDisciplinaDestino(disciplina);
                        string fileNameDestination = Path.Combine(txtDestinationFolder.Text, pathDisciplinaDestino, sub, km, modalidade, ano, nomePastaFoto, fileName);
                        bool achou = File.Exists(fileNameDestination);

                        if (temSub && temKm && temAno && temDisciplina)
                        {
                            double tamanhoBytes = new FileInfo(pathFile).Length;
                            string tamanhoFileSource = Service.getTamanhoFile(tamanhoBytes);

                            if (Service.validaSubMalhaSul(sub) &&
                                ((radioAll.Checked) || (!achou && radioPending.Checked) || (achou && radioCopied.Checked)) &&
                                ano.Contains(txtYear.Text))
                            {
                                if (!string.IsNullOrWhiteSpace(txtLimitFile.Text))
                                {
                                    totLimitFile--;
                                }

                                if (sub != subAux)
                                {
                                    subAux = sub;

                                    if (!string.IsNullOrWhiteSpace(txtLimitPath.Text))
                                    {
                                        totLimitPath--;

                                        if (totLimitPath < 0)
                                        {
                                            break;
                                        }
                                    }
                                }

                                requiredSpaceInMB += tamanhoBytes / (1024.0 * 1024.0);
                                linha++;
                                AddRowToGrid(dataGridView, linha, pathFile, fileNameDestination, tamanhoFileSource, achou, false);
                                AdvanceProgress(progressBar);
                            }
                        }
                        else if (!radioPending.Checked && !radioCopied.Checked)
                        {
                            if (!string.IsNullOrWhiteSpace(txtLimitFile.Text))
                            {
                                totLimitFile--;
                            }

                            linha++;
                            AddRowToGrid(dataGridView, linha, pathFile, "", "", achou, true);
                            AdvanceProgress(progressBar);
                        }
                    }
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar grid: {ex.Message}", "Atenção", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadInfraGrid()
        {
            try
            {
                var ranges = Service.LoadInfraKmRanges(txtInfraSpreadsheet.Text);

                Invoke(new Action(() =>
                {
                    requiredInfraSpaceInMB = 0;
                    dataGridViewInfra.Rows.Clear();
                    progressBarInfra.Maximum = 1;
                    progressBarInfra.Value = 0;
                    int totLimitPath = int.TryParse(txtInfraLimitPath.Text, out int temp1) ? temp1 : 0;
                    int totLimitFile = int.TryParse(txtInfraLimitFile.Text, out int temp2) ? temp2 : 0;
                    string pathAux = "";

                    string[] pathFiles = Service.GetArquivosOrigem(txtInfraDestinationFolder.Text);
                    if (pathFiles.Length == 0)
                    {
                        return;
                    }

                    progressBarInfra.Maximum = Math.Max(1, totLimitFile == 0 ? pathFiles.Length : totLimitFile);
                    int linha = 0;

                    foreach (string pathFile in pathFiles)
                    {
                        if (totLimitFile == 0 && !string.IsNullOrWhiteSpace(txtInfraLimitFile.Text))
                        {
                            break;
                        }

                        string relativePath = Path.GetRelativePath(txtInfraDestinationFolder.Text, pathFile);
                        string[] relativeParts = relativePath.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
                        string sourceSub = Service.ExtractSub(relativeParts, 0);
                        string kmFolder = Service.ExtractKm(relativeParts, 0);
                        string ano = Service.ExtractYear(relativeParts, 0);
                        string destination = "";
                        string sub = "";
                        string equipInfra = "";
                        string kmInicio = "";
                        string kmFim = "";
                        bool achou = false;
                        bool valido = false;

                        if (!string.IsNullOrWhiteSpace(sourceSub) &&
                            !string.IsNullOrWhiteSpace(kmFolder) &&
                            Service.TryFindInfraKmRange(sourceSub, kmFolder, ranges, out Service.InfraKmRange range))
                        {
                            sub = range.Sub;
                            equipInfra = range.EquipInfra;
                            kmInicio = FormatInfraKm(range.KmInicio);
                            kmFim = FormatInfraKm(range.KmFim);
                            string[] destinationParts = relativeParts.ToArray();

                            for (int i = 0; i < destinationParts.Length; i++)
                            {
                                if (destinationParts[i].StartsWith("km", StringComparison.OrdinalIgnoreCase))
                                {
                                    destinationParts[i] = SanitizePathSegment(equipInfra);
                                    break;
                                }
                            }

                            destination = Path.Combine(new[] { txtInfraDestinationFolder.Text }.Concat(destinationParts).ToArray());
                            achou = File.Exists(destination);
                            valido = true;
                        }

                        double tamanhoBytes = new FileInfo(pathFile).Length;
                        string tamanho = Service.getTamanhoFile(tamanhoBytes);

                        if (valido)
                        {
                            bool statusCompativel = radioInfraAll.Checked ||
                                                   (!achou && radioInfraPending.Checked) ||
                                                   (achou && radioInfraCopied.Checked);

                            if (statusCompativel && ano.Contains(txtInfraYear.Text))
                            {
                                if (!string.IsNullOrWhiteSpace(txtInfraLimitFile.Text))
                                {
                                    totLimitFile--;
                                }

                                string currentPath = BuildInfraGroupKey(relativeParts);
                                if (currentPath != pathAux)
                                {
                                    pathAux = currentPath;

                                    if (!string.IsNullOrWhiteSpace(txtInfraLimitPath.Text))
                                    {
                                        totLimitPath--;

                                        if (totLimitPath < 0)
                                        {
                                            break;
                                        }
                                    }
                                }

                                requiredInfraSpaceInMB += tamanhoBytes / (1024.0 * 1024.0);
                                linha++;
                                AddRowToInfraGrid(linha, pathFile, destination, sub, equipInfra, kmInicio, kmFim, tamanho, achou, false);
                                AdvanceProgress(progressBarInfra);
                            }
                        }
                        else if (!radioInfraPending.Checked && !radioInfraCopied.Checked)
                        {
                            if (!string.IsNullOrWhiteSpace(txtInfraLimitFile.Text))
                            {
                                totLimitFile--;
                            }

                            linha++;
                            AddRowToInfraGrid(linha, pathFile, "", sub, equipInfra, kmInicio, kmFim, tamanho, false, true);
                            AdvanceProgress(progressBarInfra);
                        }
                    }
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar aba Infra: {ex.Message}", "Atenção", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private static string BuildInfraGroupKey(string[] relativeParts)
        {
            string[] parts = new string[0];

            for (int i = 0; i < relativeParts.Length; i++)
            {
                if (relativeParts[i].StartsWith("km", StringComparison.OrdinalIgnoreCase))
                {
                    parts = relativeParts.Take(i + 1).ToArray();
                    break;
                }
            }

            if (parts.Length == 0)
            {
                parts = relativeParts.Length > 1 ? relativeParts.Take(relativeParts.Length - 1).ToArray() : relativeParts;
            }

            return Path.Combine(parts);
        }

        private static string SanitizePathSegment(string value)
        {
            return (value ?? string.Empty).Replace("/", "-").Trim();
        }

        private static string FormatInfraKm(double value)
        {
            return value.ToString("0.###");
        }

        private static void AddRowToGrid(DataGridView grid, int linha, string origem, string destino, string tamanho, bool achou, bool ignorar)
        {
            int rowIndex = grid.Rows.Add(linha, origem, destino, tamanho);
            grid.Rows[rowIndex].DefaultCellStyle.BackColor = ignorar ? Color.Orange : achou ? Color.Green : Color.Tomato;
        }

        private void AddRowToInfraGrid(int linha, string origem, string destino, string sub, string equipInfra, string kmInicio, string kmFim, string tamanho, bool achou, bool ignorar)
        {
            int rowIndex = dataGridViewInfra.Rows.Add(linha, origem, destino, sub, equipInfra, kmInicio, kmFim, tamanho);
            dataGridViewInfra.Rows[rowIndex].DefaultCellStyle.BackColor = ignorar ? Color.Orange : achou ? Color.Green : Color.Tomato;
        }

        private static void AdvanceProgress(ProgressBar progressBarControl)
        {
            if (progressBarControl.Value < progressBarControl.Maximum)
            {
                progressBarControl.Value++;
            }
        }

        private void ProcessFiles(DataGridView grid, ProgressBar progress, string destinationRoot, double requiredSpaceMb, bool generateReport, bool moveInsteadOfCopy)
        {
            try
            {
                DriveInfo drive = new DriveInfo(Path.GetPathRoot(destinationRoot));
                double availableFreeSpace = drive.AvailableFreeSpace / (1024.0 * 1024.0);

                if (availableFreeSpace < requiredSpaceMb)
                {
                    MessageBox.Show(
                        "Não há espaço suficiente disponível em " + drive.Name +
                        " \n \n Requerido: " + requiredSpaceMb.ToString("F2") +
                        " MB \n \n Livre : " + availableFreeSpace.ToString("F2") + " MB",
                        "Atenção",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                Invoke(new Action(() =>
                {
                    progress.Maximum = Math.Max(1, grid.Rows.Count);
                    progress.Value = 0;
                }));

                StreamWriter writer = null;
                string auxPath = "";
                bool copiedAny = false;

                if (generateReport)
                {
                    Directory.CreateDirectory(@"c:\temp");
                    writer = new StreamWriter(@$"c:\temp\Relatorio_FileMover_{DateTime.Now:yyyyMMdd_HHmmss}.txt");
                }

                try
                {
                    foreach (DataGridViewRow row in grid.Rows)
                    {
                        string sourceFile = row.Cells[1].Value?.ToString() ?? "";
                        string destFile = row.Cells[2].Value?.ToString() ?? "";

                        if (!string.IsNullOrWhiteSpace(sourceFile) &&
                            !string.IsNullOrWhiteSpace(destFile) &&
                            !File.Exists(destFile))
                        {
                            string destinationDir = Path.GetDirectoryName(destFile);

                            if (!string.IsNullOrWhiteSpace(destinationDir) && !Directory.Exists(destinationDir))
                            {
                                Directory.CreateDirectory(destinationDir);
                            }

                            if (moveInsteadOfCopy)
                            {
                                File.Move(sourceFile, destFile);
                                RemoveEmptyDirectories(Path.GetDirectoryName(sourceFile));
                            }
                            else
                            {
                                File.Copy(sourceFile, destFile, true);
                            }

                            copiedAny = true;

                            if (writer != null)
                            {
                                string path = Service.GetPathUntil2(sourceFile, "sub");

                                if (auxPath != path)
                                {
                                    auxPath = path;
                                    writer.WriteLine(path);
                                }

                                string km = Service.GetPathUntil(sourceFile, "km");
                                writer.WriteLine(km.PadLeft(5));
                            }
                        }

                        Invoke(new Action(() => AdvanceProgress(progress)));
                    }
                }
                finally
                {
                    writer?.Close();
                }

                MessageBox.Show(
                    copiedAny ? "Arquivos movidos com sucesso!" : "Não foi encontrado arquivos para copiar!",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
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

        private void btnExportGrid_Click(object sender, EventArgs e)
        {
            SaveLastValues();

            var reportForm = new Report();
            reportForm.ShowDialog();
        }

        private static void RemoveEmptyDirectories(string directoryPath)
        {
            while (!string.IsNullOrWhiteSpace(directoryPath) &&
                   Directory.Exists(directoryPath) &&
                   !Directory.EnumerateFileSystemEntries(directoryPath).Any())
            {
                string parentDirectory = Path.GetDirectoryName(directoryPath);
                Directory.Delete(directoryPath);
                directoryPath = parentDirectory;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
