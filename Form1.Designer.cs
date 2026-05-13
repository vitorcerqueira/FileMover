namespace FileMoverApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            tabControlMain = new System.Windows.Forms.TabControl();
            tabPageDefault = new System.Windows.Forms.TabPage();
            btnExportExcel = new System.Windows.Forms.Button();
            btnExportGrid = new System.Windows.Forms.Button();
            groupBox1 = new System.Windows.Forms.GroupBox();
            labelSub = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            radioIngnored = new System.Windows.Forms.RadioButton();
            txtSub = new System.Windows.Forms.TextBox();
            txtLimitFile = new System.Windows.Forms.TextBox();
            txtYear = new System.Windows.Forms.TextBox();
            radioCopied = new System.Windows.Forms.RadioButton();
            txtLimitPath = new System.Windows.Forms.TextBox();
            radioAll = new System.Windows.Forms.RadioButton();
            radioPending = new System.Windows.Forms.RadioButton();
            chkUseThread = new System.Windows.Forms.CheckBox();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            progressBar = new System.Windows.Forms.ProgressBar();
            btnMoveFiles = new System.Windows.Forms.Button();
            btnLoadGrid = new System.Windows.Forms.Button();
            dataGridView = new System.Windows.Forms.DataGridView();
            Ordem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Origem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Destino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            SizeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            txtDestinationFolder = new System.Windows.Forms.TextBox();
            txtSourceFolder = new System.Windows.Forms.TextBox();
            btnSelectDestination = new System.Windows.Forms.Button();
            btnSelectSource = new System.Windows.Forms.Button();
            tabPageInfra = new System.Windows.Forms.TabPage();
            groupBoxInfra = new System.Windows.Forms.GroupBox();
            labelInfraSub = new System.Windows.Forms.Label();
            labelInfraLimitPath = new System.Windows.Forms.Label();
            labelInfraLimitFile = new System.Windows.Forms.Label();
            labelInfraYearFilter = new System.Windows.Forms.Label();
            radioInfraIgnored = new System.Windows.Forms.RadioButton();
            txtInfraSub = new System.Windows.Forms.TextBox();
            txtInfraLimitFile = new System.Windows.Forms.TextBox();
            txtInfraYear = new System.Windows.Forms.TextBox();
            radioInfraCopied = new System.Windows.Forms.RadioButton();
            txtInfraLimitPath = new System.Windows.Forms.TextBox();
            radioInfraAll = new System.Windows.Forms.RadioButton();
            radioInfraPending = new System.Windows.Forms.RadioButton();
            chkInfraUseThread = new System.Windows.Forms.CheckBox();
            labelInfraPlanilha = new System.Windows.Forms.Label();
            txtInfraSpreadsheet = new System.Windows.Forms.TextBox();
            btnInfraSelectSpreadsheet = new System.Windows.Forms.Button();
            labelInfraDestino = new System.Windows.Forms.Label();
            progressBarInfra = new System.Windows.Forms.ProgressBar();
            btnInfraMoveFiles = new System.Windows.Forms.Button();
            btnInfraLoadGrid = new System.Windows.Forms.Button();
            btnInfraExportGrid = new System.Windows.Forms.Button();
            dataGridViewInfra = new System.Windows.Forms.DataGridView();
            OrdemInfra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            OrigemInfra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DestinoInfra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            SubInfraColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            EquipInfraColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            KmInicioColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            KmFimColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            SizeInfraColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            txtInfraDestinationFolder = new System.Windows.Forms.TextBox();
            btnInfraSelectDestination = new System.Windows.Forms.Button();
            tabPageEquipment = new System.Windows.Forms.TabPage();
            groupBoxEquipment = new System.Windows.Forms.GroupBox();
            labelEquipmentSub = new System.Windows.Forms.Label();
            labelEquipmentLimitPath = new System.Windows.Forms.Label();
            radioEquipmentIgnored = new System.Windows.Forms.RadioButton();
            txtEquipmentSub = new System.Windows.Forms.TextBox();
            radioEquipmentCopied = new System.Windows.Forms.RadioButton();
            txtEquipmentLimitPath = new System.Windows.Forms.TextBox();
            radioEquipmentAll = new System.Windows.Forms.RadioButton();
            radioEquipmentPending = new System.Windows.Forms.RadioButton();
            chkEquipmentUseThread = new System.Windows.Forms.CheckBox();
            labelEquipmentPlanilha = new System.Windows.Forms.Label();
            txtEquipmentSpreadsheet = new System.Windows.Forms.TextBox();
            btnEquipmentSelectSpreadsheet = new System.Windows.Forms.Button();
            labelEquipmentDestino = new System.Windows.Forms.Label();
            labelEquipmentAno = new System.Windows.Forms.Label();
            txtEquipmentYear = new System.Windows.Forms.TextBox();
            progressBarEquipment = new System.Windows.Forms.ProgressBar();
            btnEquipmentCreateFolders = new System.Windows.Forms.Button();
            btnEquipmentLoadGrid = new System.Windows.Forms.Button();
            btnEquipmentExportGrid = new System.Windows.Forms.Button();
            dataGridViewEquipment = new System.Windows.Forms.DataGridView();
            OrdemEquipment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DestinoEquipment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            SubEquipmentColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            EquipEquipmentColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            KmInicioEquipmentColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            KmFimEquipmentColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            StatusEquipmentColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            txtEquipmentDestinationFolder = new System.Windows.Forms.TextBox();
            btnEquipmentSelectDestination = new System.Windows.Forms.Button();
            tabControlMain.SuspendLayout();
            tabPageDefault.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            tabPageInfra.SuspendLayout();
            groupBoxInfra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewInfra).BeginInit();
            tabPageEquipment.SuspendLayout();
            groupBoxEquipment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEquipment).BeginInit();
            SuspendLayout();
            // 
            // tabControlMain
            // 
            tabControlMain.Controls.Add(tabPageDefault);
            tabControlMain.Controls.Add(tabPageInfra);
            tabControlMain.Controls.Add(tabPageEquipment);
            tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControlMain.Location = new System.Drawing.Point(0, 0);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new System.Drawing.Size(1371, 587);
            tabControlMain.TabIndex = 0;
            // 
            // tabPageDefault
            // 
            tabPageDefault.Controls.Add(btnExportExcel);
            tabPageDefault.Controls.Add(btnExportGrid);
            tabPageDefault.Controls.Add(groupBox1);
            tabPageDefault.Controls.Add(label2);
            tabPageDefault.Controls.Add(label1);
            tabPageDefault.Controls.Add(progressBar);
            tabPageDefault.Controls.Add(btnMoveFiles);
            tabPageDefault.Controls.Add(btnLoadGrid);
            tabPageDefault.Controls.Add(dataGridView);
            tabPageDefault.Controls.Add(txtDestinationFolder);
            tabPageDefault.Controls.Add(txtSourceFolder);
            tabPageDefault.Controls.Add(btnSelectDestination);
            tabPageDefault.Controls.Add(btnSelectSource);
            tabPageDefault.Location = new System.Drawing.Point(4, 24);
            tabPageDefault.Name = "tabPageDefault";
            tabPageDefault.Padding = new System.Windows.Forms.Padding(3);
            tabPageDefault.Size = new System.Drawing.Size(1363, 559);
            tabPageDefault.TabIndex = 0;
            tabPageDefault.Text = "Move files";
            tabPageDefault.UseVisualStyleBackColor = true;
            // 
            // btnExportExcel
            // 
            btnExportExcel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnExportExcel.Location = new System.Drawing.Point(1107, 519);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new System.Drawing.Size(121, 32);
            btnExportExcel.TabIndex = 15;
            btnExportExcel.Text = "Exportar Excel";
            btnExportExcel.UseVisualStyleBackColor = true;
            btnExportExcel.Click += btnExportExcel_Click;
            // 
            // btnExportGrid
            // 
            btnExportGrid.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnExportGrid.Location = new System.Drawing.Point(1234, 519);
            btnExportGrid.Name = "btnExportGrid";
            btnExportGrid.Size = new System.Drawing.Size(121, 32);
            btnExportGrid.TabIndex = 14;
            btnExportGrid.Text = "Report Copiados";
            btnExportGrid.UseVisualStyleBackColor = true;
            btnExportGrid.Click += btnExportGrid_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            groupBox1.Controls.Add(labelSub);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(radioIngnored);
            groupBox1.Controls.Add(txtSub);
            groupBox1.Controls.Add(txtLimitFile);
            groupBox1.Controls.Add(txtYear);
            groupBox1.Controls.Add(radioCopied);
            groupBox1.Controls.Add(txtLimitPath);
            groupBox1.Controls.Add(radioAll);
            groupBox1.Controls.Add(radioPending);
            groupBox1.Controls.Add(chkUseThread);
            groupBox1.Location = new System.Drawing.Point(868, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(487, 90);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filtros";
            // 
            // labelSub
            // 
            labelSub.AutoSize = true;
            labelSub.Location = new System.Drawing.Point(102, 14);
            labelSub.Name = "labelSub";
            labelSub.Size = new System.Drawing.Size(27, 15);
            labelSub.TabIndex = 22;
            labelSub.Text = "Sub";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(334, 14);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(92, 15);
            label5.TabIndex = 20;
            label5.Text = "Limite de pastas";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(188, 14);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(104, 15);
            label4.TabIndex = 19;
            label4.Text = "Limite de arquivos";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(6, 14);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(29, 15);
            label3.TabIndex = 14;
            label3.Text = "Ano";
            // 
            // radioIngnored
            // 
            radioIngnored.AutoSize = true;
            radioIngnored.Location = new System.Drawing.Point(298, 61);
            radioIngnored.Name = "radioIngnored";
            radioIngnored.Size = new System.Drawing.Size(78, 19);
            radioIngnored.TabIndex = 16;
            radioIngnored.Text = "Ignorados";
            radioIngnored.UseVisualStyleBackColor = true;
            // 
            // txtSub
            // 
            txtSub.Location = new System.Drawing.Point(102, 32);
            txtSub.Name = "txtSub";
            txtSub.Size = new System.Drawing.Size(80, 23);
            txtSub.TabIndex = 17;
            // 
            // txtLimitFile
            // 
            txtLimitFile.Location = new System.Drawing.Point(188, 32);
            txtLimitFile.Name = "txtLimitFile";
            txtLimitFile.Size = new System.Drawing.Size(140, 23);
            txtLimitFile.TabIndex = 18;
            // 
            // txtYear
            // 
            txtYear.Location = new System.Drawing.Point(6, 32);
            txtYear.Name = "txtYear";
            txtYear.Size = new System.Drawing.Size(90, 23);
            txtYear.TabIndex = 16;
            // 
            // radioCopied
            // 
            radioCopied.AutoSize = true;
            radioCopied.Location = new System.Drawing.Point(188, 61);
            radioCopied.Name = "radioCopied";
            radioCopied.Size = new System.Drawing.Size(75, 19);
            radioCopied.TabIndex = 15;
            radioCopied.Text = "Copiados";
            radioCopied.UseVisualStyleBackColor = true;
            // 
            // txtLimitPath
            // 
            txtLimitPath.Location = new System.Drawing.Point(334, 32);
            txtLimitPath.Name = "txtLimitPath";
            txtLimitPath.Size = new System.Drawing.Size(125, 23);
            txtLimitPath.TabIndex = 9;
            // 
            // radioAll
            // 
            radioAll.AutoSize = true;
            radioAll.Checked = true;
            radioAll.Location = new System.Drawing.Point(6, 61);
            radioAll.Name = "radioAll";
            radioAll.Size = new System.Drawing.Size(57, 19);
            radioAll.TabIndex = 13;
            radioAll.TabStop = true;
            radioAll.Text = "Todos";
            radioAll.UseVisualStyleBackColor = true;
            // 
            // radioPending
            // 
            radioPending.AutoSize = true;
            radioPending.Location = new System.Drawing.Point(84, 61);
            radioPending.Name = "radioPending";
            radioPending.Size = new System.Drawing.Size(80, 19);
            radioPending.TabIndex = 14;
            radioPending.Text = "Pendentes";
            radioPending.UseVisualStyleBackColor = true;
            // 
            // chkUseThread
            // 
            chkUseThread.AutoSize = true;
            chkUseThread.Checked = true;
            chkUseThread.CheckState = System.Windows.Forms.CheckState.Checked;
            chkUseThread.Location = new System.Drawing.Point(418, 61);
            chkUseThread.Name = "chkUseThread";
            chkUseThread.Size = new System.Drawing.Size(63, 19);
            chkUseThread.TabIndex = 21;
            chkUseThread.Text = "Thread";
            chkUseThread.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(8, 67);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(47, 15);
            label2.TabIndex = 11;
            label2.Text = "Destino";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(8, 32);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(47, 15);
            label1.TabIndex = 10;
            label1.Text = "Origem";
            // 
            // progressBar
            // 
            progressBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            progressBar.Location = new System.Drawing.Point(235, 519);
            progressBar.Name = "progressBar";
            progressBar.Size = new System.Drawing.Size(866, 34);
            progressBar.TabIndex = 7;
            // 
            // btnMoveFiles
            // 
            btnMoveFiles.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnMoveFiles.Location = new System.Drawing.Point(118, 519);
            btnMoveFiles.Name = "btnMoveFiles";
            btnMoveFiles.Size = new System.Drawing.Size(111, 34);
            btnMoveFiles.TabIndex = 6;
            btnMoveFiles.Text = "Iniciar";
            btnMoveFiles.UseVisualStyleBackColor = true;
            btnMoveFiles.Click += btnMoveFiles_Click;
            // 
            // btnLoadGrid
            // 
            btnLoadGrid.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnLoadGrid.Location = new System.Drawing.Point(8, 519);
            btnLoadGrid.Name = "btnLoadGrid";
            btnLoadGrid.Size = new System.Drawing.Size(104, 34);
            btnLoadGrid.TabIndex = 5;
            btnLoadGrid.Text = "Carregar";
            btnLoadGrid.UseVisualStyleBackColor = true;
            btnLoadGrid.Click += btnLoadGrid_Click;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { Ordem, Origem, Destino, SizeColumn });
            dataGridView.Location = new System.Drawing.Point(8, 102);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 62;
            dataGridView.Size = new System.Drawing.Size(1347, 411);
            dataGridView.TabIndex = 4;
            // 
            // Ordem
            // 
            Ordem.HeaderText = "Ordem";
            Ordem.Name = "Ordem";
            Ordem.ReadOnly = true;
            Ordem.Width = 69;
            // 
            // Origem
            // 
            Origem.HeaderText = "Source";
            Origem.MinimumWidth = 8;
            Origem.Name = "Origem";
            Origem.Width = 68;
            // 
            // Destino
            // 
            Destino.HeaderText = "Destination";
            Destino.MinimumWidth = 8;
            Destino.Name = "Destino";
            Destino.Width = 92;
            // 
            // SizeColumn
            // 
            SizeColumn.HeaderText = "Size";
            SizeColumn.MinimumWidth = 8;
            SizeColumn.Name = "SizeColumn";
            SizeColumn.Width = 52;
            // 
            // txtDestinationFolder
            // 
            txtDestinationFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtDestinationFolder.Location = new System.Drawing.Point(80, 61);
            txtDestinationFolder.Name = "txtDestinationFolder";
            txtDestinationFolder.Size = new System.Drawing.Size(616, 23);
            txtDestinationFolder.TabIndex = 3;
            // 
            // txtSourceFolder
            // 
            txtSourceFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtSourceFolder.Location = new System.Drawing.Point(80, 26);
            txtSourceFolder.Name = "txtSourceFolder";
            txtSourceFolder.Size = new System.Drawing.Size(616, 23);
            txtSourceFolder.TabIndex = 2;
            // 
            // btnSelectDestination
            // 
            btnSelectDestination.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSelectDestination.Location = new System.Drawing.Point(702, 59);
            btnSelectDestination.Name = "btnSelectDestination";
            btnSelectDestination.Size = new System.Drawing.Size(160, 28);
            btnSelectDestination.TabIndex = 1;
            btnSelectDestination.Text = "Escolher pasta";
            btnSelectDestination.UseVisualStyleBackColor = true;
            btnSelectDestination.Click += btnSelectDestination_Click;
            // 
            // btnSelectSource
            // 
            btnSelectSource.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSelectSource.Location = new System.Drawing.Point(702, 24);
            btnSelectSource.Name = "btnSelectSource";
            btnSelectSource.Size = new System.Drawing.Size(160, 28);
            btnSelectSource.TabIndex = 0;
            btnSelectSource.Text = "Escolher pasta";
            btnSelectSource.UseVisualStyleBackColor = true;
            btnSelectSource.Click += btnSelectSource_Click;
            // 
            // tabPageInfra
            // 
            tabPageInfra.Controls.Add(groupBoxInfra);
            tabPageInfra.Controls.Add(labelInfraPlanilha);
            tabPageInfra.Controls.Add(txtInfraSpreadsheet);
            tabPageInfra.Controls.Add(btnInfraSelectSpreadsheet);
            tabPageInfra.Controls.Add(labelInfraDestino);
            tabPageInfra.Controls.Add(progressBarInfra);
            tabPageInfra.Controls.Add(btnInfraMoveFiles);
            tabPageInfra.Controls.Add(btnInfraLoadGrid);
            tabPageInfra.Controls.Add(btnInfraExportGrid);
            tabPageInfra.Controls.Add(dataGridViewInfra);
            tabPageInfra.Controls.Add(txtInfraDestinationFolder);
            tabPageInfra.Controls.Add(btnInfraSelectDestination);
            tabPageInfra.Location = new System.Drawing.Point(4, 24);
            tabPageInfra.Name = "tabPageInfra";
            tabPageInfra.Padding = new System.Windows.Forms.Padding(3);
            tabPageInfra.Size = new System.Drawing.Size(1363, 559);
            tabPageInfra.TabIndex = 1;
            tabPageInfra.Text = "Rename";
            tabPageInfra.UseVisualStyleBackColor = true;
            // 
            // groupBoxInfra
            // 
            groupBoxInfra.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            groupBoxInfra.Controls.Add(labelInfraSub);
            groupBoxInfra.Controls.Add(labelInfraLimitPath);
            groupBoxInfra.Controls.Add(labelInfraLimitFile);
            groupBoxInfra.Controls.Add(labelInfraYearFilter);
            groupBoxInfra.Controls.Add(radioInfraIgnored);
            groupBoxInfra.Controls.Add(txtInfraSub);
            groupBoxInfra.Controls.Add(txtInfraLimitFile);
            groupBoxInfra.Controls.Add(txtInfraYear);
            groupBoxInfra.Controls.Add(radioInfraCopied);
            groupBoxInfra.Controls.Add(txtInfraLimitPath);
            groupBoxInfra.Controls.Add(radioInfraAll);
            groupBoxInfra.Controls.Add(radioInfraPending);
            groupBoxInfra.Controls.Add(chkInfraUseThread);
            groupBoxInfra.Location = new System.Drawing.Point(868, 22);
            groupBoxInfra.Name = "groupBoxInfra";
            groupBoxInfra.Size = new System.Drawing.Size(487, 90);
            groupBoxInfra.TabIndex = 13;
            groupBoxInfra.TabStop = false;
            groupBoxInfra.Text = "Filtros";
            // 
            // labelInfraSub
            // 
            labelInfraSub.AutoSize = true;
            labelInfraSub.Location = new System.Drawing.Point(102, 14);
            labelInfraSub.Name = "labelInfraSub";
            labelInfraSub.Size = new System.Drawing.Size(27, 15);
            labelInfraSub.TabIndex = 22;
            labelInfraSub.Text = "Sub";
            // 
            // labelInfraLimitPath
            // 
            labelInfraLimitPath.AutoSize = true;
            labelInfraLimitPath.Location = new System.Drawing.Point(334, 14);
            labelInfraLimitPath.Name = "labelInfraLimitPath";
            labelInfraLimitPath.Size = new System.Drawing.Size(92, 15);
            labelInfraLimitPath.TabIndex = 20;
            labelInfraLimitPath.Text = "Limite de pastas";
            // 
            // labelInfraLimitFile
            // 
            labelInfraLimitFile.AutoSize = true;
            labelInfraLimitFile.Location = new System.Drawing.Point(188, 14);
            labelInfraLimitFile.Name = "labelInfraLimitFile";
            labelInfraLimitFile.Size = new System.Drawing.Size(104, 15);
            labelInfraLimitFile.TabIndex = 19;
            labelInfraLimitFile.Text = "Limite de arquivos";
            // 
            // labelInfraYearFilter
            // 
            labelInfraYearFilter.AutoSize = true;
            labelInfraYearFilter.Location = new System.Drawing.Point(6, 14);
            labelInfraYearFilter.Name = "labelInfraYearFilter";
            labelInfraYearFilter.Size = new System.Drawing.Size(29, 15);
            labelInfraYearFilter.TabIndex = 14;
            labelInfraYearFilter.Text = "Ano";
            // 
            // radioInfraIgnored
            // 
            radioInfraIgnored.AutoSize = true;
            radioInfraIgnored.Location = new System.Drawing.Point(313, 61);
            radioInfraIgnored.Name = "radioInfraIgnored";
            radioInfraIgnored.Size = new System.Drawing.Size(78, 19);
            radioInfraIgnored.TabIndex = 16;
            radioInfraIgnored.Text = "Ignorados";
            radioInfraIgnored.UseVisualStyleBackColor = true;
            // 
            // txtInfraSub
            // 
            txtInfraSub.Location = new System.Drawing.Point(102, 32);
            txtInfraSub.Name = "txtInfraSub";
            txtInfraSub.Size = new System.Drawing.Size(80, 23);
            txtInfraSub.TabIndex = 17;
            // 
            // txtInfraLimitFile
            // 
            txtInfraLimitFile.Location = new System.Drawing.Point(188, 32);
            txtInfraLimitFile.Name = "txtInfraLimitFile";
            txtInfraLimitFile.Size = new System.Drawing.Size(140, 23);
            txtInfraLimitFile.TabIndex = 18;
            // 
            // txtInfraYear
            // 
            txtInfraYear.Location = new System.Drawing.Point(6, 32);
            txtInfraYear.Name = "txtInfraYear";
            txtInfraYear.Size = new System.Drawing.Size(90, 23);
            txtInfraYear.TabIndex = 16;
            // 
            // radioInfraCopied
            // 
            radioInfraCopied.AutoSize = true;
            radioInfraCopied.Location = new System.Drawing.Point(206, 61);
            radioInfraCopied.Name = "radioInfraCopied";
            radioInfraCopied.Size = new System.Drawing.Size(75, 19);
            radioInfraCopied.TabIndex = 15;
            radioInfraCopied.Text = "Copiados";
            radioInfraCopied.UseVisualStyleBackColor = true;
            // 
            // txtInfraLimitPath
            // 
            txtInfraLimitPath.Location = new System.Drawing.Point(334, 32);
            txtInfraLimitPath.Name = "txtInfraLimitPath";
            txtInfraLimitPath.Size = new System.Drawing.Size(125, 23);
            txtInfraLimitPath.TabIndex = 9;
            // 
            // radioInfraAll
            // 
            radioInfraAll.AutoSize = true;
            radioInfraAll.Checked = true;
            radioInfraAll.Location = new System.Drawing.Point(6, 61);
            radioInfraAll.Name = "radioInfraAll";
            radioInfraAll.Size = new System.Drawing.Size(57, 19);
            radioInfraAll.TabIndex = 13;
            radioInfraAll.TabStop = true;
            radioInfraAll.Text = "Todos";
            radioInfraAll.UseVisualStyleBackColor = true;
            // 
            // radioInfraPending
            // 
            radioInfraPending.AutoSize = true;
            radioInfraPending.Location = new System.Drawing.Point(92, 61);
            radioInfraPending.Name = "radioInfraPending";
            radioInfraPending.Size = new System.Drawing.Size(80, 19);
            radioInfraPending.TabIndex = 14;
            radioInfraPending.Text = "Pendentes";
            radioInfraPending.UseVisualStyleBackColor = true;
            // 
            // chkInfraUseThread
            // 
            chkInfraUseThread.AutoSize = true;
            chkInfraUseThread.Checked = true;
            chkInfraUseThread.CheckState = System.Windows.Forms.CheckState.Checked;
            chkInfraUseThread.Location = new System.Drawing.Point(397, 61);
            chkInfraUseThread.Name = "chkInfraUseThread";
            chkInfraUseThread.Size = new System.Drawing.Size(63, 19);
            chkInfraUseThread.TabIndex = 21;
            chkInfraUseThread.Text = "Thread";
            chkInfraUseThread.UseVisualStyleBackColor = true;
            // 
            // labelInfraPlanilha
            // 
            labelInfraPlanilha.AutoSize = true;
            labelInfraPlanilha.Location = new System.Drawing.Point(8, 32);
            labelInfraPlanilha.Name = "labelInfraPlanilha";
            labelInfraPlanilha.Size = new System.Drawing.Size(49, 15);
            labelInfraPlanilha.TabIndex = 12;
            labelInfraPlanilha.Text = "Planilha";
            // 
            // txtInfraSpreadsheet
            // 
            txtInfraSpreadsheet.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtInfraSpreadsheet.Location = new System.Drawing.Point(80, 26);
            txtInfraSpreadsheet.Name = "txtInfraSpreadsheet";
            txtInfraSpreadsheet.Size = new System.Drawing.Size(616, 23);
            txtInfraSpreadsheet.TabIndex = 11;
            // 
            // btnInfraSelectSpreadsheet
            // 
            btnInfraSelectSpreadsheet.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnInfraSelectSpreadsheet.Location = new System.Drawing.Point(702, 22);
            btnInfraSelectSpreadsheet.Name = "btnInfraSelectSpreadsheet";
            btnInfraSelectSpreadsheet.Size = new System.Drawing.Size(142, 28);
            btnInfraSelectSpreadsheet.TabIndex = 10;
            btnInfraSelectSpreadsheet.Text = "Escolher planilha";
            btnInfraSelectSpreadsheet.UseVisualStyleBackColor = true;
            btnInfraSelectSpreadsheet.Click += btnInfraSelectSpreadsheet_Click;
            // 
            // labelInfraDestino
            // 
            labelInfraDestino.AutoSize = true;
            labelInfraDestino.Location = new System.Drawing.Point(8, 67);
            labelInfraDestino.Name = "labelInfraDestino";
            labelInfraDestino.Size = new System.Drawing.Size(62, 15);
            labelInfraDestino.TabIndex = 9;
            labelInfraDestino.Text = "Pasta base";
            // 
            // progressBarInfra
            // 
            progressBarInfra.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            progressBarInfra.Location = new System.Drawing.Point(235, 519);
            progressBarInfra.Name = "progressBarInfra";
            progressBarInfra.Size = new System.Drawing.Size(993, 34);
            progressBarInfra.TabIndex = 7;
            // 
            // btnInfraMoveFiles
            // 
            btnInfraMoveFiles.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnInfraMoveFiles.Location = new System.Drawing.Point(118, 519);
            btnInfraMoveFiles.Name = "btnInfraMoveFiles";
            btnInfraMoveFiles.Size = new System.Drawing.Size(111, 34);
            btnInfraMoveFiles.TabIndex = 6;
            btnInfraMoveFiles.Text = "Iniciar";
            btnInfraMoveFiles.UseVisualStyleBackColor = true;
            btnInfraMoveFiles.Click += btnInfraMoveFiles_Click;
            // 
            // btnInfraLoadGrid
            // 
            btnInfraLoadGrid.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnInfraLoadGrid.Location = new System.Drawing.Point(8, 519);
            btnInfraLoadGrid.Name = "btnInfraLoadGrid";
            btnInfraLoadGrid.Size = new System.Drawing.Size(104, 34);
            btnInfraLoadGrid.TabIndex = 5;
            btnInfraLoadGrid.Text = "Carregar";
            btnInfraLoadGrid.UseVisualStyleBackColor = true;
            btnInfraLoadGrid.Click += btnInfraLoadGrid_Click;
            // 
            // btnInfraExportGrid
            // 
            btnInfraExportGrid.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnInfraExportGrid.Location = new System.Drawing.Point(1234, 519);
            btnInfraExportGrid.Name = "btnInfraExportGrid";
            btnInfraExportGrid.Size = new System.Drawing.Size(121, 32);
            btnInfraExportGrid.TabIndex = 14;
            btnInfraExportGrid.Text = "Exportar Excel";
            btnInfraExportGrid.UseVisualStyleBackColor = true;
            btnInfraExportGrid.Click += btnInfraExportGrid_Click;
            // 
            // dataGridViewInfra
            // 
            dataGridViewInfra.AllowUserToAddRows = false;
            dataGridViewInfra.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dataGridViewInfra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewInfra.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewInfra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewInfra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { OrdemInfra, OrigemInfra, DestinoInfra, SubInfraColumn, EquipInfraColumn, KmInicioColumn, KmFimColumn, SizeInfraColumn });
            dataGridViewInfra.Location = new System.Drawing.Point(8, 118);
            dataGridViewInfra.Name = "dataGridViewInfra";
            dataGridViewInfra.RowHeadersWidth = 62;
            dataGridViewInfra.Size = new System.Drawing.Size(1347, 395);
            dataGridViewInfra.TabIndex = 4;
            // 
            // OrdemInfra
            // 
            OrdemInfra.HeaderText = "Ordem";
            OrdemInfra.Name = "OrdemInfra";
            OrdemInfra.ReadOnly = true;
            OrdemInfra.Width = 69;
            // 
            // OrigemInfra
            // 
            OrigemInfra.HeaderText = "Source";
            OrigemInfra.MinimumWidth = 8;
            OrigemInfra.Name = "OrigemInfra";
            OrigemInfra.Width = 68;
            // 
            // DestinoInfra
            // 
            DestinoInfra.HeaderText = "Destination";
            DestinoInfra.MinimumWidth = 8;
            DestinoInfra.Name = "DestinoInfra";
            DestinoInfra.Width = 92;
            // 
            // SubInfraColumn
            // 
            SubInfraColumn.HeaderText = "SUB";
            SubInfraColumn.MinimumWidth = 8;
            SubInfraColumn.Name = "SubInfraColumn";
            SubInfraColumn.Width = 53;
            // 
            // EquipInfraColumn
            // 
            EquipInfraColumn.HeaderText = "EQUIP_INFRA";
            EquipInfraColumn.MinimumWidth = 8;
            EquipInfraColumn.Name = "EquipInfraColumn";
            EquipInfraColumn.Width = 103;
            // 
            // KmInicioColumn
            // 
            KmInicioColumn.HeaderText = "KM INICIO";
            KmInicioColumn.MinimumWidth = 8;
            KmInicioColumn.Name = "KmInicioColumn";
            KmInicioColumn.Width = 88;
            // 
            // KmFimColumn
            // 
            KmFimColumn.HeaderText = "KM FIM";
            KmFimColumn.MinimumWidth = 8;
            KmFimColumn.Name = "KmFimColumn";
            KmFimColumn.Width = 73;
            // 
            // SizeInfraColumn
            // 
            SizeInfraColumn.HeaderText = "Size";
            SizeInfraColumn.MinimumWidth = 8;
            SizeInfraColumn.Name = "SizeInfraColumn";
            SizeInfraColumn.Width = 52;
            // 
            // txtInfraDestinationFolder
            // 
            txtInfraDestinationFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtInfraDestinationFolder.Location = new System.Drawing.Point(80, 61);
            txtInfraDestinationFolder.Name = "txtInfraDestinationFolder";
            txtInfraDestinationFolder.Size = new System.Drawing.Size(616, 23);
            txtInfraDestinationFolder.TabIndex = 2;
            // 
            // btnInfraSelectDestination
            // 
            btnInfraSelectDestination.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnInfraSelectDestination.Location = new System.Drawing.Point(702, 57);
            btnInfraSelectDestination.Name = "btnInfraSelectDestination";
            btnInfraSelectDestination.Size = new System.Drawing.Size(142, 28);
            btnInfraSelectDestination.TabIndex = 1;
            btnInfraSelectDestination.Text = "Escolher pasta";
            btnInfraSelectDestination.UseVisualStyleBackColor = true;
            btnInfraSelectDestination.Click += btnInfraSelectDestination_Click;
            // 
            // tabPageEquipment
            // 
            tabPageEquipment.Controls.Add(groupBoxEquipment);
            tabPageEquipment.Controls.Add(labelEquipmentPlanilha);
            tabPageEquipment.Controls.Add(txtEquipmentSpreadsheet);
            tabPageEquipment.Controls.Add(btnEquipmentSelectSpreadsheet);
            tabPageEquipment.Controls.Add(labelEquipmentDestino);
            tabPageEquipment.Controls.Add(labelEquipmentAno);
            tabPageEquipment.Controls.Add(txtEquipmentYear);
            tabPageEquipment.Controls.Add(progressBarEquipment);
            tabPageEquipment.Controls.Add(btnEquipmentCreateFolders);
            tabPageEquipment.Controls.Add(btnEquipmentLoadGrid);
            tabPageEquipment.Controls.Add(btnEquipmentExportGrid);
            tabPageEquipment.Controls.Add(dataGridViewEquipment);
            tabPageEquipment.Controls.Add(txtEquipmentDestinationFolder);
            tabPageEquipment.Controls.Add(btnEquipmentSelectDestination);
            tabPageEquipment.Location = new System.Drawing.Point(4, 24);
            tabPageEquipment.Name = "tabPageEquipment";
            tabPageEquipment.Padding = new System.Windows.Forms.Padding(3);
            tabPageEquipment.Size = new System.Drawing.Size(1363, 559);
            tabPageEquipment.TabIndex = 2;
            tabPageEquipment.Text = "Criar pastas Equipamentos";
            tabPageEquipment.UseVisualStyleBackColor = true;
            // 
            // groupBoxEquipment
            // 
            groupBoxEquipment.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            groupBoxEquipment.Controls.Add(labelEquipmentSub);
            groupBoxEquipment.Controls.Add(labelEquipmentLimitPath);
            groupBoxEquipment.Controls.Add(radioEquipmentIgnored);
            groupBoxEquipment.Controls.Add(txtEquipmentSub);
            groupBoxEquipment.Controls.Add(radioEquipmentCopied);
            groupBoxEquipment.Controls.Add(txtEquipmentLimitPath);
            groupBoxEquipment.Controls.Add(radioEquipmentAll);
            groupBoxEquipment.Controls.Add(radioEquipmentPending);
            groupBoxEquipment.Controls.Add(chkEquipmentUseThread);
            groupBoxEquipment.Location = new System.Drawing.Point(850, 22);
            groupBoxEquipment.Name = "groupBoxEquipment";
            groupBoxEquipment.Size = new System.Drawing.Size(505, 90);
            groupBoxEquipment.TabIndex = 13;
            groupBoxEquipment.TabStop = false;
            groupBoxEquipment.Text = "Filtros";
            // 
            // labelEquipmentSub
            // 
            labelEquipmentSub.AutoSize = true;
            labelEquipmentSub.Location = new System.Drawing.Point(6, 14);
            labelEquipmentSub.Name = "labelEquipmentSub";
            labelEquipmentSub.Size = new System.Drawing.Size(27, 15);
            labelEquipmentSub.TabIndex = 22;
            labelEquipmentSub.Text = "Sub";
            // 
            // labelEquipmentLimitPath
            // 
            labelEquipmentLimitPath.AutoSize = true;
            labelEquipmentLimitPath.Location = new System.Drawing.Point(188, 14);
            labelEquipmentLimitPath.Name = "labelEquipmentLimitPath";
            labelEquipmentLimitPath.Size = new System.Drawing.Size(92, 15);
            labelEquipmentLimitPath.TabIndex = 20;
            labelEquipmentLimitPath.Text = "Limite de pastas";
            // 
            // radioEquipmentIgnored
            // 
            radioEquipmentIgnored.AutoSize = true;
            radioEquipmentIgnored.Location = new System.Drawing.Point(313, 61);
            radioEquipmentIgnored.Name = "radioEquipmentIgnored";
            radioEquipmentIgnored.Size = new System.Drawing.Size(78, 19);
            radioEquipmentIgnored.TabIndex = 16;
            radioEquipmentIgnored.Text = "Ignorados";
            radioEquipmentIgnored.UseVisualStyleBackColor = true;
            // 
            // txtEquipmentSub
            // 
            txtEquipmentSub.Location = new System.Drawing.Point(6, 32);
            txtEquipmentSub.Name = "txtEquipmentSub";
            txtEquipmentSub.Size = new System.Drawing.Size(176, 23);
            txtEquipmentSub.TabIndex = 17;
            // 
            // radioEquipmentCopied
            // 
            radioEquipmentCopied.AutoSize = true;
            radioEquipmentCopied.Location = new System.Drawing.Point(206, 61);
            radioEquipmentCopied.Name = "radioEquipmentCopied";
            radioEquipmentCopied.Size = new System.Drawing.Size(75, 19);
            radioEquipmentCopied.TabIndex = 15;
            radioEquipmentCopied.Text = "Copiados";
            radioEquipmentCopied.UseVisualStyleBackColor = true;
            // 
            // txtEquipmentLimitPath
            // 
            txtEquipmentLimitPath.Location = new System.Drawing.Point(188, 32);
            txtEquipmentLimitPath.Name = "txtEquipmentLimitPath";
            txtEquipmentLimitPath.Size = new System.Drawing.Size(140, 23);
            txtEquipmentLimitPath.TabIndex = 9;
            // 
            // radioEquipmentAll
            // 
            radioEquipmentAll.AutoSize = true;
            radioEquipmentAll.Checked = true;
            radioEquipmentAll.Location = new System.Drawing.Point(6, 61);
            radioEquipmentAll.Name = "radioEquipmentAll";
            radioEquipmentAll.Size = new System.Drawing.Size(57, 19);
            radioEquipmentAll.TabIndex = 13;
            radioEquipmentAll.TabStop = true;
            radioEquipmentAll.Text = "Todos";
            radioEquipmentAll.UseVisualStyleBackColor = true;
            // 
            // radioEquipmentPending
            // 
            radioEquipmentPending.AutoSize = true;
            radioEquipmentPending.Location = new System.Drawing.Point(92, 61);
            radioEquipmentPending.Name = "radioEquipmentPending";
            radioEquipmentPending.Size = new System.Drawing.Size(80, 19);
            radioEquipmentPending.TabIndex = 14;
            radioEquipmentPending.Text = "Pendentes";
            radioEquipmentPending.UseVisualStyleBackColor = true;
            // 
            // chkEquipmentUseThread
            // 
            chkEquipmentUseThread.AutoSize = true;
            chkEquipmentUseThread.Checked = true;
            chkEquipmentUseThread.CheckState = System.Windows.Forms.CheckState.Checked;
            chkEquipmentUseThread.Location = new System.Drawing.Point(397, 61);
            chkEquipmentUseThread.Name = "chkEquipmentUseThread";
            chkEquipmentUseThread.Size = new System.Drawing.Size(63, 19);
            chkEquipmentUseThread.TabIndex = 21;
            chkEquipmentUseThread.Text = "Thread";
            chkEquipmentUseThread.UseVisualStyleBackColor = true;
            // 
            // labelEquipmentPlanilha
            // 
            labelEquipmentPlanilha.AutoSize = true;
            labelEquipmentPlanilha.Location = new System.Drawing.Point(8, 32);
            labelEquipmentPlanilha.Name = "labelEquipmentPlanilha";
            labelEquipmentPlanilha.Size = new System.Drawing.Size(49, 15);
            labelEquipmentPlanilha.TabIndex = 12;
            labelEquipmentPlanilha.Text = "Planilha";
            // 
            // txtEquipmentSpreadsheet
            // 
            txtEquipmentSpreadsheet.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtEquipmentSpreadsheet.Location = new System.Drawing.Point(80, 26);
            txtEquipmentSpreadsheet.Name = "txtEquipmentSpreadsheet";
            txtEquipmentSpreadsheet.Size = new System.Drawing.Size(616, 23);
            txtEquipmentSpreadsheet.TabIndex = 11;
            // 
            // btnEquipmentSelectSpreadsheet
            // 
            btnEquipmentSelectSpreadsheet.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnEquipmentSelectSpreadsheet.Location = new System.Drawing.Point(702, 25);
            btnEquipmentSelectSpreadsheet.Name = "btnEquipmentSelectSpreadsheet";
            btnEquipmentSelectSpreadsheet.Size = new System.Drawing.Size(142, 28);
            btnEquipmentSelectSpreadsheet.TabIndex = 10;
            btnEquipmentSelectSpreadsheet.Text = "Escolher planilha";
            btnEquipmentSelectSpreadsheet.UseVisualStyleBackColor = true;
            btnEquipmentSelectSpreadsheet.Click += btnEquipmentSelectSpreadsheet_Click;
            // 
            // labelEquipmentDestino
            // 
            labelEquipmentDestino.AutoSize = true;
            labelEquipmentDestino.Location = new System.Drawing.Point(8, 67);
            labelEquipmentDestino.Name = "labelEquipmentDestino";
            labelEquipmentDestino.Size = new System.Drawing.Size(62, 15);
            labelEquipmentDestino.TabIndex = 9;
            labelEquipmentDestino.Text = "Pasta base";
            // 
            // labelEquipmentAno
            // 
            labelEquipmentAno.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            labelEquipmentAno.AutoSize = true;
            labelEquipmentAno.Location = new System.Drawing.Point(555, 67);
            labelEquipmentAno.Name = "labelEquipmentAno";
            labelEquipmentAno.Size = new System.Drawing.Size(29, 15);
            labelEquipmentAno.TabIndex = 15;
            labelEquipmentAno.Text = "Ano";
            // 
            // txtEquipmentYear
            // 
            txtEquipmentYear.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            txtEquipmentYear.Location = new System.Drawing.Point(601, 64);
            txtEquipmentYear.Name = "txtEquipmentYear";
            txtEquipmentYear.Size = new System.Drawing.Size(80, 23);
            txtEquipmentYear.TabIndex = 16;
            // 
            // progressBarEquipment
            // 
            progressBarEquipment.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            progressBarEquipment.Location = new System.Drawing.Point(235, 519);
            progressBarEquipment.Name = "progressBarEquipment";
            progressBarEquipment.Size = new System.Drawing.Size(993, 34);
            progressBarEquipment.TabIndex = 7;
            // 
            // btnEquipmentCreateFolders
            // 
            btnEquipmentCreateFolders.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnEquipmentCreateFolders.Location = new System.Drawing.Point(118, 519);
            btnEquipmentCreateFolders.Name = "btnEquipmentCreateFolders";
            btnEquipmentCreateFolders.Size = new System.Drawing.Size(111, 34);
            btnEquipmentCreateFolders.TabIndex = 6;
            btnEquipmentCreateFolders.Text = "Iniciar";
            btnEquipmentCreateFolders.UseVisualStyleBackColor = true;
            btnEquipmentCreateFolders.Click += btnEquipmentCreateFolders_Click;
            // 
            // btnEquipmentLoadGrid
            // 
            btnEquipmentLoadGrid.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnEquipmentLoadGrid.Location = new System.Drawing.Point(8, 519);
            btnEquipmentLoadGrid.Name = "btnEquipmentLoadGrid";
            btnEquipmentLoadGrid.Size = new System.Drawing.Size(104, 34);
            btnEquipmentLoadGrid.TabIndex = 5;
            btnEquipmentLoadGrid.Text = "Carregar";
            btnEquipmentLoadGrid.UseVisualStyleBackColor = true;
            btnEquipmentLoadGrid.Click += btnEquipmentLoadGrid_Click;
            // 
            // btnEquipmentExportGrid
            // 
            btnEquipmentExportGrid.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnEquipmentExportGrid.Location = new System.Drawing.Point(1234, 519);
            btnEquipmentExportGrid.Name = "btnEquipmentExportGrid";
            btnEquipmentExportGrid.Size = new System.Drawing.Size(121, 32);
            btnEquipmentExportGrid.TabIndex = 14;
            btnEquipmentExportGrid.Text = "Exportar Excel";
            btnEquipmentExportGrid.UseVisualStyleBackColor = true;
            btnEquipmentExportGrid.Click += btnEquipmentExportGrid_Click;
            // 
            // dataGridViewEquipment
            // 
            dataGridViewEquipment.AllowUserToAddRows = false;
            dataGridViewEquipment.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dataGridViewEquipment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewEquipment.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewEquipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewEquipment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { OrdemEquipment, DestinoEquipment, SubEquipmentColumn, EquipEquipmentColumn, KmInicioEquipmentColumn, KmFimEquipmentColumn, StatusEquipmentColumn });
            dataGridViewEquipment.Location = new System.Drawing.Point(8, 118);
            dataGridViewEquipment.Name = "dataGridViewEquipment";
            dataGridViewEquipment.RowHeadersWidth = 62;
            dataGridViewEquipment.Size = new System.Drawing.Size(1347, 395);
            dataGridViewEquipment.TabIndex = 4;
            // 
            // OrdemEquipment
            // 
            OrdemEquipment.HeaderText = "Ordem";
            OrdemEquipment.Name = "OrdemEquipment";
            OrdemEquipment.ReadOnly = true;
            OrdemEquipment.Width = 69;
            // 
            // DestinoEquipment
            // 
            DestinoEquipment.HeaderText = "Destino";
            DestinoEquipment.MinimumWidth = 8;
            DestinoEquipment.Name = "DestinoEquipment";
            DestinoEquipment.Width = 72;
            // 
            // SubEquipmentColumn
            // 
            SubEquipmentColumn.HeaderText = "SUB";
            SubEquipmentColumn.MinimumWidth = 8;
            SubEquipmentColumn.Name = "SubEquipmentColumn";
            SubEquipmentColumn.Width = 53;
            // 
            // EquipEquipmentColumn
            // 
            EquipEquipmentColumn.HeaderText = "EQUIP_INFRA";
            EquipEquipmentColumn.MinimumWidth = 8;
            EquipEquipmentColumn.Name = "EquipEquipmentColumn";
            EquipEquipmentColumn.Width = 103;
            // 
            // KmInicioEquipmentColumn
            // 
            KmInicioEquipmentColumn.HeaderText = "KM INICIO";
            KmInicioEquipmentColumn.MinimumWidth = 8;
            KmInicioEquipmentColumn.Name = "KmInicioEquipmentColumn";
            KmInicioEquipmentColumn.Width = 88;
            // 
            // KmFimEquipmentColumn
            // 
            KmFimEquipmentColumn.HeaderText = "KM FIM";
            KmFimEquipmentColumn.MinimumWidth = 8;
            KmFimEquipmentColumn.Name = "KmFimEquipmentColumn";
            KmFimEquipmentColumn.Width = 73;
            // 
            // StatusEquipmentColumn
            // 
            StatusEquipmentColumn.HeaderText = "Status";
            StatusEquipmentColumn.MinimumWidth = 8;
            StatusEquipmentColumn.Name = "StatusEquipmentColumn";
            StatusEquipmentColumn.Width = 64;
            // 
            // txtEquipmentDestinationFolder
            // 
            txtEquipmentDestinationFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtEquipmentDestinationFolder.Location = new System.Drawing.Point(80, 61);
            txtEquipmentDestinationFolder.Name = "txtEquipmentDestinationFolder";
            txtEquipmentDestinationFolder.Size = new System.Drawing.Size(469, 23);
            txtEquipmentDestinationFolder.TabIndex = 2;
            // 
            // btnEquipmentSelectDestination
            // 
            btnEquipmentSelectDestination.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnEquipmentSelectDestination.Location = new System.Drawing.Point(702, 61);
            btnEquipmentSelectDestination.Name = "btnEquipmentSelectDestination";
            btnEquipmentSelectDestination.Size = new System.Drawing.Size(142, 28);
            btnEquipmentSelectDestination.TabIndex = 1;
            btnEquipmentSelectDestination.Text = "Escolher pasta";
            btnEquipmentSelectDestination.UseVisualStyleBackColor = true;
            btnEquipmentSelectDestination.Click += btnEquipmentSelectDestination_Click;
            // 
            // Form1
            // 
            ClientSize = new System.Drawing.Size(1371, 587);
            Controls.Add(tabControlMain);
            Name = "Form1";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Rumo - Cópia de arquivos";
            FormClosing += MainForm_FormClosing;
            Load += Form1_Load;
            tabControlMain.ResumeLayout(false);
            tabPageDefault.ResumeLayout(false);
            tabPageDefault.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            tabPageInfra.ResumeLayout(false);
            tabPageInfra.PerformLayout();
            groupBoxInfra.ResumeLayout(false);
            groupBoxInfra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewInfra).EndInit();
            tabPageEquipment.ResumeLayout(false);
            tabPageEquipment.PerformLayout();
            groupBoxEquipment.ResumeLayout(false);
            groupBoxEquipment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEquipment).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageDefault;
        private System.Windows.Forms.Button btnSelectSource;
        private System.Windows.Forms.Button btnSelectDestination;
        private System.Windows.Forms.TextBox txtSourceFolder;
        private System.Windows.Forms.TextBox txtDestinationFolder;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnLoadGrid;
        private System.Windows.Forms.Button btnMoveFiles;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox txtLimitPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioPending;
        private System.Windows.Forms.RadioButton radioAll;
        private System.Windows.Forms.RadioButton radioCopied;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.TextBox txtLimitFile;
        private System.Windows.Forms.RadioButton radioIngnored;
        private System.Windows.Forms.CheckBox chkUseThread;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelSub;
        private System.Windows.Forms.TextBox txtSub;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ordem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Origem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Destino;
        private System.Windows.Forms.DataGridViewTextBoxColumn SizeColumn;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Button btnExportGrid;
        private System.Windows.Forms.TabPage tabPageInfra;
        private System.Windows.Forms.TabPage tabPageEquipment;
        private System.Windows.Forms.GroupBox groupBoxEquipment;
        private System.Windows.Forms.Label labelEquipmentSub;
        private System.Windows.Forms.Label labelEquipmentLimitPath;
        private System.Windows.Forms.RadioButton radioEquipmentIgnored;
        private System.Windows.Forms.TextBox txtEquipmentSub;
        private System.Windows.Forms.RadioButton radioEquipmentCopied;
        private System.Windows.Forms.TextBox txtEquipmentLimitPath;
        private System.Windows.Forms.RadioButton radioEquipmentAll;
        private System.Windows.Forms.RadioButton radioEquipmentPending;
        private System.Windows.Forms.CheckBox chkEquipmentUseThread;
        private System.Windows.Forms.Label labelEquipmentPlanilha;
        private System.Windows.Forms.TextBox txtEquipmentSpreadsheet;
        private System.Windows.Forms.Button btnEquipmentSelectSpreadsheet;
        private System.Windows.Forms.Label labelEquipmentDestino;
        private System.Windows.Forms.Label labelEquipmentAno;
        private System.Windows.Forms.TextBox txtEquipmentYear;
        private System.Windows.Forms.ProgressBar progressBarEquipment;
        private System.Windows.Forms.Button btnEquipmentCreateFolders;
        private System.Windows.Forms.Button btnEquipmentLoadGrid;
        private System.Windows.Forms.Button btnEquipmentExportGrid;
        private System.Windows.Forms.DataGridView dataGridViewEquipment;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrdemEquipment;
        private System.Windows.Forms.DataGridViewTextBoxColumn DestinoEquipment;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubEquipmentColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EquipEquipmentColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn KmInicioEquipmentColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn KmFimEquipmentColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusEquipmentColumn;
        private System.Windows.Forms.TextBox txtEquipmentDestinationFolder;
        private System.Windows.Forms.Button btnEquipmentSelectDestination;
        private System.Windows.Forms.Label labelInfraPlanilha;
        private System.Windows.Forms.TextBox txtInfraSpreadsheet;
        private System.Windows.Forms.Button btnInfraSelectSpreadsheet;
        private System.Windows.Forms.GroupBox groupBoxInfra;
        private System.Windows.Forms.Label labelInfraLimitPath;
        private System.Windows.Forms.Label labelInfraLimitFile;
        private System.Windows.Forms.Label labelInfraYearFilter;
        private System.Windows.Forms.RadioButton radioInfraIgnored;
        private System.Windows.Forms.TextBox txtInfraLimitFile;
        private System.Windows.Forms.TextBox txtInfraYear;
        private System.Windows.Forms.RadioButton radioInfraCopied;
        private System.Windows.Forms.TextBox txtInfraLimitPath;
        private System.Windows.Forms.RadioButton radioInfraAll;
        private System.Windows.Forms.RadioButton radioInfraPending;
        private System.Windows.Forms.CheckBox chkInfraUseThread;
        private System.Windows.Forms.Label labelInfraDestino;
        private System.Windows.Forms.Label labelInfraSub;
        private System.Windows.Forms.TextBox txtInfraSub;
        private System.Windows.Forms.ProgressBar progressBarInfra;
        private System.Windows.Forms.Button btnInfraMoveFiles;
        private System.Windows.Forms.Button btnInfraLoadGrid;
        private System.Windows.Forms.Button btnInfraExportGrid;
        private System.Windows.Forms.DataGridView dataGridViewInfra;
        private System.Windows.Forms.TextBox txtInfraDestinationFolder;
        private System.Windows.Forms.Button btnInfraSelectDestination;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrdemInfra;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrigemInfra;
        private System.Windows.Forms.DataGridViewTextBoxColumn DestinoInfra;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubInfraColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EquipInfraColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn KmInicioColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn KmFimColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SizeInfraColumn;
    }
}
