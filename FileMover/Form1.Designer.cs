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
            btnExportGrid = new System.Windows.Forms.Button();
            groupBox1 = new System.Windows.Forms.GroupBox();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            radioIngnored = new System.Windows.Forms.RadioButton();
            txtLimitFile = new System.Windows.Forms.TextBox();
            txtYear = new System.Windows.Forms.TextBox();
            radioCopied = new System.Windows.Forms.RadioButton();
            txtLimitPath = new System.Windows.Forms.TextBox();
            radioAll = new System.Windows.Forms.RadioButton();
            radioPending = new System.Windows.Forms.RadioButton();
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
            labelInfraLimitPath = new System.Windows.Forms.Label();
            labelInfraLimitFile = new System.Windows.Forms.Label();
            labelInfraYearFilter = new System.Windows.Forms.Label();
            radioInfraIgnored = new System.Windows.Forms.RadioButton();
            txtInfraLimitFile = new System.Windows.Forms.TextBox();
            txtInfraYear = new System.Windows.Forms.TextBox();
            radioInfraCopied = new System.Windows.Forms.RadioButton();
            txtInfraLimitPath = new System.Windows.Forms.TextBox();
            radioInfraAll = new System.Windows.Forms.RadioButton();
            radioInfraPending = new System.Windows.Forms.RadioButton();
            labelInfraPlanilha = new System.Windows.Forms.Label();
            txtInfraSpreadsheet = new System.Windows.Forms.TextBox();
            btnInfraSelectSpreadsheet = new System.Windows.Forms.Button();
            labelInfraDestino = new System.Windows.Forms.Label();
            progressBarInfra = new System.Windows.Forms.ProgressBar();
            btnInfraMoveFiles = new System.Windows.Forms.Button();
            btnInfraLoadGrid = new System.Windows.Forms.Button();
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
            tabControlMain.SuspendLayout();
            tabPageDefault.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            tabPageInfra.SuspendLayout();
            groupBoxInfra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewInfra).BeginInit();
            SuspendLayout();
            // 
            // tabControlMain
            // 
            tabControlMain.Controls.Add(tabPageDefault);
            tabControlMain.Controls.Add(tabPageInfra);
            tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControlMain.Location = new System.Drawing.Point(0, 0);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new System.Drawing.Size(1371, 587);
            tabControlMain.TabIndex = 0;
            // 
            // tabPageDefault
            // 
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
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(radioIngnored);
            groupBox1.Controls.Add(txtLimitFile);
            groupBox1.Controls.Add(txtYear);
            groupBox1.Controls.Add(radioCopied);
            groupBox1.Controls.Add(txtLimitPath);
            groupBox1.Controls.Add(radioAll);
            groupBox1.Controls.Add(radioPending);
            groupBox1.Location = new System.Drawing.Point(868, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(487, 90);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filtros";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(306, 10);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(92, 15);
            label5.TabIndex = 20;
            label5.Text = "Limite de pastas";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(136, 14);
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
            label3.Size = new System.Drawing.Size(71, 15);
            label3.TabIndex = 14;
            label3.Text = "Digite o ano";
            // 
            // radioIngnored
            // 
            radioIngnored.AutoSize = true;
            radioIngnored.Location = new System.Drawing.Point(313, 61);
            radioIngnored.Name = "radioIngnored";
            radioIngnored.Size = new System.Drawing.Size(78, 19);
            radioIngnored.TabIndex = 16;
            radioIngnored.Text = "Ignorados";
            radioIngnored.UseVisualStyleBackColor = true;
            // 
            // txtLimitFile
            // 
            txtLimitFile.Location = new System.Drawing.Point(136, 32);
            txtLimitFile.Name = "txtLimitFile";
            txtLimitFile.Size = new System.Drawing.Size(164, 23);
            txtLimitFile.TabIndex = 18;
            // 
            // txtYear
            // 
            txtYear.Location = new System.Drawing.Point(6, 32);
            txtYear.Name = "txtYear";
            txtYear.Size = new System.Drawing.Size(124, 23);
            txtYear.TabIndex = 16;
            // 
            // radioCopied
            // 
            radioCopied.AutoSize = true;
            radioCopied.Location = new System.Drawing.Point(206, 61);
            radioCopied.Name = "radioCopied";
            radioCopied.Size = new System.Drawing.Size(75, 19);
            radioCopied.TabIndex = 15;
            radioCopied.Text = "Copiados";
            radioCopied.UseVisualStyleBackColor = true;
            // 
            // txtLimitPath
            // 
            txtLimitPath.Location = new System.Drawing.Point(306, 32);
            txtLimitPath.Name = "txtLimitPath";
            txtLimitPath.Size = new System.Drawing.Size(153, 23);
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
            radioPending.Location = new System.Drawing.Point(92, 61);
            radioPending.Name = "radioPending";
            radioPending.Size = new System.Drawing.Size(80, 19);
            radioPending.TabIndex = 14;
            radioPending.Text = "Pendentes";
            radioPending.UseVisualStyleBackColor = true;
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
            progressBar.Size = new System.Drawing.Size(993, 34);
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
            groupBoxInfra.Controls.Add(labelInfraLimitPath);
            groupBoxInfra.Controls.Add(labelInfraLimitFile);
            groupBoxInfra.Controls.Add(labelInfraYearFilter);
            groupBoxInfra.Controls.Add(radioInfraIgnored);
            groupBoxInfra.Controls.Add(txtInfraLimitFile);
            groupBoxInfra.Controls.Add(txtInfraYear);
            groupBoxInfra.Controls.Add(radioInfraCopied);
            groupBoxInfra.Controls.Add(txtInfraLimitPath);
            groupBoxInfra.Controls.Add(radioInfraAll);
            groupBoxInfra.Controls.Add(radioInfraPending);
            groupBoxInfra.Location = new System.Drawing.Point(868, 22);
            groupBoxInfra.Name = "groupBoxInfra";
            groupBoxInfra.Size = new System.Drawing.Size(487, 90);
            groupBoxInfra.TabIndex = 13;
            groupBoxInfra.TabStop = false;
            groupBoxInfra.Text = "Filtros";
            // 
            // labelInfraLimitPath
            // 
            labelInfraLimitPath.AutoSize = true;
            labelInfraLimitPath.Location = new System.Drawing.Point(306, 10);
            labelInfraLimitPath.Name = "labelInfraLimitPath";
            labelInfraLimitPath.Size = new System.Drawing.Size(92, 15);
            labelInfraLimitPath.TabIndex = 20;
            labelInfraLimitPath.Text = "Limite de pastas";
            // 
            // labelInfraLimitFile
            // 
            labelInfraLimitFile.AutoSize = true;
            labelInfraLimitFile.Location = new System.Drawing.Point(136, 14);
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
            labelInfraYearFilter.Size = new System.Drawing.Size(71, 15);
            labelInfraYearFilter.TabIndex = 14;
            labelInfraYearFilter.Text = "Digite o ano";
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
            // txtInfraLimitFile
            // 
            txtInfraLimitFile.Location = new System.Drawing.Point(136, 32);
            txtInfraLimitFile.Name = "txtInfraLimitFile";
            txtInfraLimitFile.Size = new System.Drawing.Size(164, 23);
            txtInfraLimitFile.TabIndex = 18;
            // 
            // txtInfraYear
            // 
            txtInfraYear.Location = new System.Drawing.Point(6, 32);
            txtInfraYear.Name = "txtInfraYear";
            txtInfraYear.Size = new System.Drawing.Size(124, 23);
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
            txtInfraLimitPath.Location = new System.Drawing.Point(306, 32);
            txtInfraLimitPath.Name = "txtInfraLimitPath";
            txtInfraLimitPath.Size = new System.Drawing.Size(153, 23);
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
            progressBarInfra.Size = new System.Drawing.Size(1120, 34);
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ordem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Origem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Destino;
        private System.Windows.Forms.DataGridViewTextBoxColumn SizeColumn;
        private System.Windows.Forms.Button btnExportGrid;
        private System.Windows.Forms.TabPage tabPageInfra;
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
        private System.Windows.Forms.Label labelInfraDestino;
        private System.Windows.Forms.ProgressBar progressBarInfra;
        private System.Windows.Forms.Button btnInfraMoveFiles;
        private System.Windows.Forms.Button btnInfraLoadGrid;
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
