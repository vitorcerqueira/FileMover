using ClosedXML.Excel;
using FileMover;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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
                        new XElement("LastSub", ""),
                        new XElement("LastDestinationValue", ""),
                        new XElement("LastInfraSpreadsheet", ""),
                        new XElement("LastInfraDestinationValue", ""),
                        new XElement("LastInfraLimitPath", ""),
                        new XElement("LastInfraLimitFile", ""),
                        new XElement("LastInfraYear", ""),
                        new XElement("LastInfraSub", "")));

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
                txtSub.Text = GetConfigValue(config, "LastSub");
                txtDestinationFolder.Text = GetConfigValue(config, "LastDestinationValue");
                txtInfraSpreadsheet.Text = GetConfigValue(config, "LastInfraSpreadsheet");
                txtInfraDestinationFolder.Text = GetConfigValue(config, "LastInfraDestinationValue");
                txtInfraLimitPath.Text = GetConfigValue(config, "LastInfraLimitPath");
                txtInfraLimitFile.Text = GetConfigValue(config, "LastInfraLimitFile");
                txtInfraYear.Text = GetConfigValue(config, "LastInfraYear");
                txtInfraSub.Text = GetConfigValue(config, "LastInfraSub");
                txtEquipmentSpreadsheet.Text = GetConfigValue(config, "LastInfraSpreadsheet");
                txtEquipmentDestinationFolder.Text = GetConfigValue(config, "LastInfraDestinationValue");
                txtEquipmentLimitPath.Text = GetConfigValue(config, "LastInfraLimitPath");
                txtEquipmentYear.Text = GetConfigValue(config, "LastInfraYear");
                txtEquipmentSub.Text = GetConfigValue(config, "LastInfraSub");
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
                        new XElement("LastSub", txtSub.Text),
                        new XElement("LastDestinationValue", txtDestinationFolder.Text),
                        new XElement("LastInfraSpreadsheet", txtInfraSpreadsheet.Text),
                        new XElement("LastInfraDestinationValue", txtInfraDestinationFolder.Text),
                        new XElement("LastInfraLimitPath", txtInfraLimitPath.Text),
                        new XElement("LastInfraLimitFile", txtInfraLimitFile.Text),
                        new XElement("LastInfraYear", txtInfraYear.Text),
                        new XElement("LastInfraSub", txtInfraSub.Text)));

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

        private void btnEquipmentSelectSpreadsheet_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Planilhas Excel|*.xlsx;*.xlsm;*.xls";
            dialog.Title = "Selecione a planilha de cadastro";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtEquipmentSpreadsheet.Text = dialog.FileName;
                SaveLastValues();
            }
        }

        private void btnEquipmentSelectDestination_Click(object sender, EventArgs e)
        {
            SelectFolder(txtEquipmentDestinationFolder);
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
                if (chkUseThread.Checked)
                {
                    new Thread(LoadDefaultGrid).Start();
                }
                else
                {
                    //new Thread(LoadDefaultGrid).Start();
                    LoadDefaultGrid();
                }

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
            if (chkUseThread.Checked)
            {
                new Thread(() => ProcessFiles(dataGridView, progressBar, txtDestinationFolder.Text, requiredSpaceInMB, true, false)).Start();
            }
            else
            {
                //new Thread(() => ProcessFiles(dataGridView, progressBar, txtDestinationFolder.Text, requiredSpaceInMB, true, false)).Start();
                ProcessFiles(dataGridView, progressBar, txtDestinationFolder.Text, requiredSpaceInMB, true, false);
            }

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
                if (chkInfraUseThread.Checked)
                {
                    new Thread(LoadInfraGrid).Start();
                }
                else
                {
                    //new Thread(LoadInfraGrid).Start();
                    LoadInfraGrid();
                }
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
            if (chkInfraUseThread.Checked)
            {
                new Thread(() => ProcessFiles(dataGridViewInfra, progressBarInfra, txtInfraDestinationFolder.Text, requiredInfraSpaceInMB, true, true)).Start();
            }
            else
            {
                //new Thread(() => ProcessFiles(dataGridViewInfra, progressBarInfra, txtInfraDestinationFolder.Text, requiredInfraSpaceInMB, true, true)).Start();
                ProcessFiles(dataGridViewInfra, progressBarInfra, txtInfraDestinationFolder.Text, requiredInfraSpaceInMB, true, true);
            }

            // CopyFiles(dataGridViewInfra, progressBarInfra, txtInfraDestinationFolder.Text, requiredInfraSpaceInMB, false)
        }

        private void btnEquipmentLoadGrid_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEquipmentSpreadsheet.Text) ||
                string.IsNullOrWhiteSpace(txtEquipmentDestinationFolder.Text))
            {
                MessageBox.Show("Selecione a planilha e a pasta base da aba Criar pastas Equipamentos.", "Atencao",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                if (chkEquipmentUseThread.Checked)
                {
                    new Thread(LoadEquipmentGrid).Start();
                }
                else
                {
                    LoadEquipmentGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro inesperado: {ex.Message}");
            }
        }

        private void btnEquipmentCreateFolders_Click(object sender, EventArgs e)
        {
            if (dataGridViewEquipment.Rows.Count == 0)
            {
                MessageBox.Show("Carregue o grid antes de criar as pastas.", "Atencao",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (chkEquipmentUseThread.Checked)
            {
                new Thread(() => CreateEquipmentFolders(dataGridViewEquipment, progressBarEquipment)).Start();
            }
            else
            {
                CreateEquipmentFolders(dataGridViewEquipment, progressBarEquipment);
            }
        }

        private void btnEquipmentExportGrid_Click(object sender, EventArgs e)
        {
            ExportGridToExcel(dataGridViewEquipment, "Equipamentos");
        }

        private void LoadDefaultGrid()
        {
            try
            {
                //Invoke(new Action(LoadDefaultGridCore));
                RunOnUiThread(LoadDefaultGridCore);
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

                //Invoke(new Action(() => LoadInfraGridCore(ranges)));
                RunOnUiThread(() => LoadInfraGridCore(ranges));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar aba Infra: {ex.Message}", "Atenção", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadEquipmentGrid()
        {
            try
            {
                var ranges = Service.LoadInfraKmRanges(txtEquipmentSpreadsheet.Text);
                RunOnUiThread(() => LoadEquipmentGridCore(ranges));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar aba Criar pastas Equipamentos: {ex.Message}", "Atencao",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDefaultGridCore()
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
                bool isDuplicateDefault = File.Exists(fileNameDestination);
                if (isDuplicateDefault)
                    fileNameDestination = GetUniqueDestinationPath(fileNameDestination);
                bool achou = File.Exists(fileNameDestination);

                if (temSub && temKm && temAno && temDisciplina)
                {
                    double tamanhoBytes = new FileInfo(pathFile).Length;
                    string tamanhoFileSource = Service.getTamanhoFile(tamanhoBytes);

                    if (Service.validaSubMalhaSul(sub) &&
                        ((radioAll.Checked) || (!achou && radioPending.Checked) || (achou && radioCopied.Checked)) &&
                        ano.Contains(txtYear.Text) &&
                        sub.Contains(txtSub.Text, StringComparison.OrdinalIgnoreCase))
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
                        AddRowToGrid(dataGridView, linha, pathFile, fileNameDestination, tamanhoFileSource, achou, false, isDuplicateDefault);
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
        }

        private void LoadInfraGridCore(System.Collections.Generic.List<Service.InfraKmRange> ranges)
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
                string currentEquipInfra = GetCurrentInfraFolder(relativeParts);
                string ano = Service.ExtractYear(relativeParts, 0);
                string destination = "";
                string sub = "";
                string equipInfra = "";
                string kmInicio = "";
                string kmFim = "";
                bool achou = false;
                bool valido = false;
                bool isDuplicateInfra = false;

                Service.InfraKmRange range = null;

                bool encontrouRangePorKm = !string.IsNullOrWhiteSpace(sourceSub) &&
                                           !string.IsNullOrWhiteSpace(kmFolder) &&
                                           Service.TryFindInfraKmRange(sourceSub, kmFolder, ranges, out range);

                bool encontrouRangePorEquip = !encontrouRangePorKm &&
                                              !string.IsNullOrWhiteSpace(sourceSub) &&
                                              !string.IsNullOrWhiteSpace(currentEquipInfra) &&
                                              Service.TryFindInfraRangeByEquip(sourceSub, currentEquipInfra, ranges, out range);

                if (encontrouRangePorKm || encontrouRangePorEquip)
                {
                    sub = range.Sub;
                    equipInfra = range.EquipInfra;
                    kmInicio = FormatInfraKm(range.KmInicio);
                    kmFim = FormatInfraKm(range.KmFim);
                    string[] destinationParts = relativeParts.ToArray();

                    for (int i = 0; i < destinationParts.Length; i++)
                    {
                        if (destinationParts[i].StartsWith("km", StringComparison.OrdinalIgnoreCase) ||
                            string.Equals(SanitizePathSegment(destinationParts[i]), SanitizePathSegment(currentEquipInfra), StringComparison.OrdinalIgnoreCase))
                        {
                            destinationParts[i] = SanitizePathSegment(equipInfra);
                            break;
                        }
                    }

                    destination = Path.Combine(new[] { txtInfraDestinationFolder.Text }.Concat(destinationParts).ToArray());
                    bool infraOriginalExists = !PathsAreEquivalent(pathFile, destination) && File.Exists(destination);
                    isDuplicateInfra = infraOriginalExists;
                    if (isDuplicateInfra)
                        destination = GetUniqueDestinationPath(destination);
                    achou = PathsAreEquivalent(pathFile, destination) || File.Exists(destination);
                    valido = true;
                }

                double tamanhoBytes = new FileInfo(pathFile).Length;
                string tamanho = Service.getTamanhoFile(tamanhoBytes);

                if (valido)
                {
                    bool statusCompativel = radioInfraAll.Checked ||
                                            (!achou && radioInfraPending.Checked) ||
                                            (achou && radioInfraCopied.Checked);

                    if (statusCompativel &&
                        ano.Contains(txtInfraYear.Text) &&
                        sub.Contains(txtInfraSub.Text, StringComparison.OrdinalIgnoreCase))
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
                        AddRowToInfraGrid(linha, pathFile, destination, sub, equipInfra, kmInicio, kmFim, tamanho, achou, false, isDuplicateInfra);
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
        }

        private void LoadEquipmentGridCore(List<Service.InfraKmRange> ranges)
        {
            dataGridViewEquipment.Rows.Clear();
            progressBarEquipment.Maximum = 1;
            progressBarEquipment.Value = 0;

            int totLimitPath = int.TryParse(txtEquipmentLimitPath.Text, out int temp1) ? temp1 : 0;
            string equipmentYear = string.IsNullOrWhiteSpace(txtEquipmentYear.Text) ? DateTime.Now.Year.ToString() : txtEquipmentYear.Text.Trim();

            if (ranges.Count == 0)
            {
                return;
            }

            progressBarEquipment.Maximum = Math.Max(1, ranges.Count);
            int linha = 0;
            HashSet<string> addedDestinations = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (Service.InfraKmRange range in ranges
                .OrderBy(item => NormalizeEquipmentSubValue(item.Sub))
                .ThenBy(item => SanitizePathSegment(item.EquipInfra), StringComparer.OrdinalIgnoreCase)
                .ThenBy(item => item.KmInicio))
            {
                string sub = NormalizeEquipmentSubValue(range.Sub);
                string equipInfra = SanitizePathSegment(range.EquipInfra);
                string kmInicio = FormatInfraKm(range.KmInicio);
                string kmFim = FormatInfraKm(range.KmFim);
                string destinationFolder = Path.Combine(txtEquipmentDestinationFolder.Text, sub, equipInfra, equipmentYear);

                if (!addedDestinations.Add(destinationFolder))
                {
                    continue;
                }

                bool existe = Directory.Exists(destinationFolder);
                bool statusCompativel = radioEquipmentAll.Checked ||
                                        (!existe && radioEquipmentPending.Checked) ||
                                        (existe && radioEquipmentCopied.Checked);

                if (statusCompativel &&
                    EquipmentSubMatchesFilter(sub, txtEquipmentSub.Text))
                {
                    if (!string.IsNullOrWhiteSpace(txtEquipmentLimitPath.Text))
                    {
                        if (linha >= totLimitPath)
                        {
                            break;
                        }
                    }

                    linha++;
                    AddRowToEquipmentGrid(linha, destinationFolder, sub, equipInfra, kmInicio, kmFim, existe, false);
                    AdvanceProgress(progressBarEquipment);
                }
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

        private static bool EquipmentSubMatchesFilter(string subValue, string filterValue)
        {
            string normalizedFilter = NormalizeSubFilterValue(filterValue);
            if (string.IsNullOrWhiteSpace(normalizedFilter))
            {
                return true;
            }

            return string.Equals(NormalizeSubFilterValue(subValue), normalizedFilter, StringComparison.OrdinalIgnoreCase);
        }

        private static string NormalizeEquipmentSubValue(string value)
        {
            string normalized = NormalizeSubFilterValue(value);
            return string.IsNullOrWhiteSpace(normalized) ? value.Trim() : normalized;
        }

        private static string NormalizeSubFilterValue(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return string.Empty;
            }

            string digits = new string(value.Where(char.IsDigit).ToArray());
            if (int.TryParse(digits, out int number))
            {
                return $"Sub {number:00}";
            }

            return value.Trim();
        }

        private static string GetCurrentInfraFolder(string[] relativeParts)
        {
            for (int i = 0; i < relativeParts.Length; i++)
            {
                if (relativeParts[i].StartsWith("km", StringComparison.OrdinalIgnoreCase))
                {
                    return string.Empty;
                }

                if (i > 0 && relativeParts[i].Contains("-"))
                {
                    return relativeParts[i];
                }
            }

            return string.Empty;
        }

        private static void AddRowToGrid(DataGridView grid, int linha, string origem, string destino, string tamanho, bool achou, bool ignorar, bool isDuplicate = false)
        {
            int rowIndex = grid.Rows.Add(linha, origem, destino, tamanho);
            grid.Rows[rowIndex].DefaultCellStyle.BackColor =
                ignorar ? Color.Orange :
                achou ? Color.Green :
                isDuplicate ? Color.Gold :
                Color.Tomato;
        }

        private void AddRowToInfraGrid(int linha, string origem, string destino, string sub, string equipInfra, string kmInicio, string kmFim, string tamanho, bool achou, bool ignorar, bool isDuplicate = false)
        {
            int rowIndex = dataGridViewInfra.Rows.Add(linha, origem, destino, sub, equipInfra, kmInicio, kmFim, tamanho);
            dataGridViewInfra.Rows[rowIndex].DefaultCellStyle.BackColor =
                ignorar ? Color.Orange :
                achou ? Color.Green :
                isDuplicate ? Color.Gold :
                Color.Tomato;
        }

        private void AddRowToEquipmentGrid(int linha, string destino, string sub, string equipInfra, string kmInicio, string kmFim, bool achou, bool ignorar)
        {
            string status = ignorar ? "Ignorado" : achou ? "Ja existe" : "Pendente";
            int rowIndex = dataGridViewEquipment.Rows.Add(linha, destino, sub, equipInfra, kmInicio, kmFim, status);
            dataGridViewEquipment.Rows[rowIndex].DefaultCellStyle.BackColor = ignorar ? Color.Orange : achou ? Color.Green : Color.Tomato;
        }

        private static void AdvanceProgress(ProgressBar progressBarControl)
        {
            if (progressBarControl.Value < progressBarControl.Maximum)
            {
                progressBarControl.Value++;
            }
        }

        private void RunOnUiThread(Action action)
        {
            if (InvokeRequired)
            {
                Invoke(action);
                return;
            }

            action();
        }

        private static bool PathsAreEquivalent(string firstPath, string secondPath)
        {
            if (string.IsNullOrWhiteSpace(firstPath) || string.IsNullOrWhiteSpace(secondPath))
            {
                return false;
            }

            string normalizedFirst = Path.GetFullPath(firstPath)
                .TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
            string normalizedSecond = Path.GetFullPath(secondPath)
                .TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);

            return string.Equals(normalizedFirst, normalizedSecond, StringComparison.OrdinalIgnoreCase);
        }

        private void CreateEquipmentFolders(DataGridView grid, ProgressBar progress)
        {
            try
            {
                RunOnUiThread(() =>
                {
                    progress.Maximum = Math.Max(1, grid.Rows.Count);
                    progress.Value = 0;
                });

                int createdCount = 0;

                foreach (DataGridViewRow row in grid.Rows)
                {
                    string destinationFolder = row.Cells[1].Value?.ToString() ?? string.Empty;
                    bool shouldCreate = !string.IsNullOrWhiteSpace(destinationFolder) && !Directory.Exists(destinationFolder);

                    if (shouldCreate)
                    {
                        Directory.CreateDirectory(destinationFolder);
                        createdCount++;
                    }

                    RunOnUiThread(() =>
                    {
                        if (!string.IsNullOrWhiteSpace(destinationFolder))
                        {
                            row.Cells[6].Value = Directory.Exists(destinationFolder) ? "Ja existe" : "Pendente";
                            row.DefaultCellStyle.BackColor = Directory.Exists(destinationFolder) ? Color.Green : Color.Tomato;
                        }

                        AdvanceProgress(progress);
                    });
                }

                MessageBox.Show(
                    createdCount > 0
                        ? $"Pastas criadas com sucesso: {createdCount}"
                        : "Nenhuma pasta nova precisou ser criada.",
                    "Atencao",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"Erro de permissao: {ex.Message}");
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Erro de entrada/saida: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro inesperado: {ex.Message}");
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

                //Invoke(new Action(() =>
                //{
                //    progress.Maximum = Math.Max(1, grid.Rows.Count);
                //    progress.Value = 0;
                //}));
                RunOnUiThread(() =>
                {
                    progress.Maximum = Math.Max(1, grid.Rows.Count);
                    progress.Value = 0;
                });

                StreamWriter writer = null;
                string reportPath = string.Empty;
                bool copiedAny = false;
                int changedFilesCount = 0;

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
                            bool destDirAlreadyExisted = !string.IsNullOrWhiteSpace(destinationDir) && Directory.Exists(destinationDir);

                            if (!string.IsNullOrWhiteSpace(destinationDir) && !destDirAlreadyExisted)
                            {
                                Directory.CreateDirectory(destinationDir);
                            }

                            if (moveInsteadOfCopy)
                            {
                                if (destDirAlreadyExisted)
                                {
                                    // Diretório de destino já existia: copia primeiro e só apaga a origem após confirmar
                                    File.Copy(sourceFile, destFile, false);
                                    if (File.Exists(destFile))
                                    {
                                        File.Delete(sourceFile);
                                        RemoveEmptyDirectories(Path.GetDirectoryName(sourceFile));
                                    }
                                }
                                else
                                {
                                    // Diretório recém-criado: mover é seguro e atômico
                                    File.Move(sourceFile, destFile);
                                    RemoveEmptyDirectories(Path.GetDirectoryName(sourceFile));
                                }
                            }
                            else
                            {
                                File.Copy(sourceFile, destFile, true);
                            }

                            copiedAny = true;
                            changedFilesCount++;

                            if (generateReport)
                            {
                                if (writer == null)
                                {
                                    reportPath = BuildReportPath(moveInsteadOfCopy);
                                    writer = CreateReportWriter(reportPath, moveInsteadOfCopy, destinationRoot);
                                }

                                WriteReportEntry(writer, changedFilesCount, sourceFile, destFile);
                            }
                        }

                        //Invoke(new Action(() => AdvanceProgress(progress)));
                        RunOnUiThread(() => AdvanceProgress(progress));
                    }
                }
                finally
                {
                    if (writer != null)
                    {
                        WriteReportSummary(writer, changedFilesCount);
                    }

                    writer?.Close();
                }

                MessageBox.Show(
                    copiedAny
                        ? BuildSuccessMessage(moveInsteadOfCopy, reportPath)
                        : "Não foi encontrado arquivos para copiar!",
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

        private static string BuildReportPath(bool moveInsteadOfCopy)
        {
            Directory.CreateDirectory(@"c:\temp");

            string operationName = moveInsteadOfCopy ? "Rename" : "MoveFiles";
            return $@"c:\temp\FileMover_{operationName}_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
        }

        private static StreamWriter CreateReportWriter(string reportPath, bool moveInsteadOfCopy, string destinationRoot)
        {
            StreamWriter writer = new StreamWriter(reportPath, false, Encoding.UTF8);
            string operationName = moveInsteadOfCopy ? "Rename" : "Move Files";

            writer.WriteLine("FILEMOVER - RELATORIO DE ALTERACOES");
            writer.WriteLine($"Aba      : {operationName}");
            writer.WriteLine($"Gerado em: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
            writer.WriteLine($"Destino  : {destinationRoot}");
            writer.WriteLine(new string('=', 80));
            writer.WriteLine();

            return writer;
        }

        private static void WriteReportEntry(StreamWriter writer, int itemNumber, string sourceFile, string destFile)
        {
            writer.WriteLine($"[{itemNumber:000}]");
            writer.WriteLine($"Antes: {sourceFile}");
            writer.WriteLine($"Agora: {destFile}");
            writer.WriteLine();
        }

        private static void WriteReportSummary(StreamWriter writer, int changedFilesCount)
        {
            writer.WriteLine(new string('=', 80));
            writer.WriteLine($"Total de arquivos alterados: {changedFilesCount}");
        }

        private static string BuildSuccessMessage(bool moveInsteadOfCopy, string reportPath)
        {
            string actionText = moveInsteadOfCopy ? "Arquivos renomeados com sucesso!" : "Arquivos movidos com sucesso!";

            if (string.IsNullOrWhiteSpace(reportPath))
            {
                return actionText;
            }

            return $"{actionText}\r\n\r\nLog gerado em:\r\n{reportPath}";
        }

        private void btnExportGrid_Click(object sender, EventArgs e)
        {
            SaveLastValues();

            var reportForm = new Report();
            reportForm.ShowDialog();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            ExportGridToExcel(dataGridView, "MoveFiles");
        }

        private void btnInfraExportGrid_Click(object sender, EventArgs e)
        {
            ExportGridToExcel(dataGridViewInfra, "Infra");
        }

        private void ExportGridToExcel(DataGridView grid, string sheetName)
        {
            if (grid.Rows.Count == 0)
            {
                MessageBox.Show("O grid esta vazio. Carregue os dados antes de exportar.", "Atencao",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            SaveLastValues();
            string exportPath = BuildExcelExportPath(sheetName);

            try
            {
                using XLWorkbook workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add(SanitizeWorksheetName(sheetName));
                List<DataGridViewColumn> visibleColumns = grid.Columns
                    .Cast<DataGridViewColumn>()
                    .Where(column => column.Visible)
                    .OrderBy(column => column.DisplayIndex)
                    .ToList();

                for (int columnIndex = 0; columnIndex < visibleColumns.Count; columnIndex++)
                {
                    DataGridViewColumn column = visibleColumns[columnIndex];
                    var headerCell = worksheet.Cell(1, columnIndex + 1);
                    headerCell.Value = column.HeaderText;
                    headerCell.Style.Font.Bold = true;
                    headerCell.Style.Fill.BackgroundColor = XLColor.LightGray;
                }

                for (int rowIndex = 0; rowIndex < grid.Rows.Count; rowIndex++)
                {
                    DataGridViewRow gridRow = grid.Rows[rowIndex];

                    for (int columnIndex = 0; columnIndex < visibleColumns.Count; columnIndex++)
                    {
                        DataGridViewColumn column = visibleColumns[columnIndex];
                        var worksheetCell = worksheet.Cell(rowIndex + 2, columnIndex + 1);
                        object value = gridRow.Cells[column.Index].Value;
                        worksheetCell.Value = value?.ToString() ?? string.Empty;
                    }

                    Color rowColor = gridRow.DefaultCellStyle.BackColor;
                    if (!rowColor.IsEmpty)
                    {
                        var range = worksheet.Range(rowIndex + 2, 1, rowIndex + 2, visibleColumns.Count);
                        range.Style.Fill.BackgroundColor = XLColor.FromColor(rowColor);
                    }
                }

                worksheet.Columns().AdjustToContents();
                workbook.SaveAs(exportPath);

                MessageBox.Show($"Planilha exportada com sucesso:\r\n{exportPath}", "Exportacao",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao exportar planilha: {ex.Message}", "Atencao",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string BuildExcelExportPath(string sheetName)
        {
            Directory.CreateDirectory(@"c:\temp");
            return $@"c:\temp\FileMover_{sheetName}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
        }

        private static string SanitizeWorksheetName(string sheetName)
        {
            char[] invalidChars = { ':', '\\', '/', '?', '*', '[', ']' };
            string sanitized = sheetName ?? "Planilha";

            foreach (char invalidChar in invalidChars)
            {
                sanitized = sanitized.Replace(invalidChar, '_');
            }

            if (string.IsNullOrWhiteSpace(sanitized))
            {
                return "Planilha";
            }

            return sanitized.Length > 31
                ? sanitized.Substring(0, 31)
                : sanitized;
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

        private static string GetUniqueDestinationPath(string destPath)
        {
            if (!File.Exists(destPath))
                return destPath;

            string dir = Path.GetDirectoryName(destPath) ?? string.Empty;
            string name = Path.GetFileNameWithoutExtension(destPath);
            string ext = Path.GetExtension(destPath);

            int counter = 1;
            string uniquePath;
            do
            {
                uniquePath = Path.Combine(dir, $"{name}_{counter}{ext}");
                counter++;
            } while (File.Exists(uniquePath));

            return uniquePath;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
    }
}
