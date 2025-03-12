namespace FileMoverApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnSelectSource;
        private System.Windows.Forms.Button btnSelectDestination;
        private System.Windows.Forms.TextBox txtSourceFolder;
        private System.Windows.Forms.TextBox txtDestinationFolder;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnLoadGrid;
        private System.Windows.Forms.Button btnMoveFiles;
        private System.Windows.Forms.ProgressBar progressBar;

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
            btnSelectSource = new System.Windows.Forms.Button();
            btnSelectDestination = new System.Windows.Forms.Button();
            txtSourceFolder = new System.Windows.Forms.TextBox();
            txtDestinationFolder = new System.Windows.Forms.TextBox();
            dataGridView = new System.Windows.Forms.DataGridView();
            btnLoadGrid = new System.Windows.Forms.Button();
            btnMoveFiles = new System.Windows.Forms.Button();
            progressBar = new System.Windows.Forms.ProgressBar();
            txtLimitPath = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            radioIngnored = new System.Windows.Forms.RadioButton();
            txtLimitFile = new System.Windows.Forms.TextBox();
            txtYear = new System.Windows.Forms.TextBox();
            radioCopied = new System.Windows.Forms.RadioButton();
            radioAll = new System.Windows.Forms.RadioButton();
            radioPending = new System.Windows.Forms.RadioButton();
            Ordem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Origem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Destino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnSelectSource
            // 
            btnSelectSource.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSelectSource.Location = new System.Drawing.Point(912, 26);
            btnSelectSource.Name = "btnSelectSource";
            btnSelectSource.Size = new System.Drawing.Size(160, 28);
            btnSelectSource.TabIndex = 0;
            btnSelectSource.Text = "Escolher pasta";
            btnSelectSource.UseVisualStyleBackColor = true;
            btnSelectSource.Click += btnSelectSource_Click;
            // 
            // btnSelectDestination
            // 
            btnSelectDestination.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSelectDestination.Location = new System.Drawing.Point(912, 61);
            btnSelectDestination.Name = "btnSelectDestination";
            btnSelectDestination.Size = new System.Drawing.Size(160, 31);
            btnSelectDestination.TabIndex = 1;
            btnSelectDestination.Text = "Escolher pasta";
            btnSelectDestination.UseVisualStyleBackColor = true;
            btnSelectDestination.Click += btnSelectDestination_Click;
            // 
            // txtSourceFolder
            // 
            txtSourceFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtSourceFolder.Location = new System.Drawing.Point(84, 26);
            txtSourceFolder.Name = "txtSourceFolder";
            txtSourceFolder.Size = new System.Drawing.Size(822, 23);
            txtSourceFolder.TabIndex = 2;
            // 
            // txtDestinationFolder
            // 
            txtDestinationFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtDestinationFolder.Location = new System.Drawing.Point(84, 61);
            txtDestinationFolder.Name = "txtDestinationFolder";
            txtDestinationFolder.Size = new System.Drawing.Size(822, 23);
            txtDestinationFolder.TabIndex = 3;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { Ordem, Origem, Destino, Size });
            dataGridView.Location = new System.Drawing.Point(12, 100);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 62;
            dataGridView.Size = new System.Drawing.Size(1553, 461);
            dataGridView.TabIndex = 4;
            // 
            // btnLoadGrid
            // 
            btnLoadGrid.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnLoadGrid.Location = new System.Drawing.Point(12, 567);
            btnLoadGrid.Name = "btnLoadGrid";
            btnLoadGrid.Size = new System.Drawing.Size(104, 34);
            btnLoadGrid.TabIndex = 5;
            btnLoadGrid.Text = "Carregar";
            btnLoadGrid.UseVisualStyleBackColor = true;
            btnLoadGrid.Click += btnLoadGrid_Click;
            // 
            // btnMoveFiles
            // 
            btnMoveFiles.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnMoveFiles.Location = new System.Drawing.Point(122, 567);
            btnMoveFiles.Name = "btnMoveFiles";
            btnMoveFiles.Size = new System.Drawing.Size(111, 34);
            btnMoveFiles.TabIndex = 6;
            btnMoveFiles.Text = "Iniciar";
            btnMoveFiles.UseVisualStyleBackColor = true;
            btnMoveFiles.Click += btnMoveFiles_Click;
            // 
            // progressBar
            // 
            progressBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            progressBar.Location = new System.Drawing.Point(239, 567);
            progressBar.Name = "progressBar";
            progressBar.Size = new System.Drawing.Size(1326, 34);
            progressBar.TabIndex = 7;
            // 
            // txtLimitPath
            // 
            txtLimitPath.Location = new System.Drawing.Point(306, 32);
            txtLimitPath.Name = "txtLimitPath";
            txtLimitPath.Size = new System.Drawing.Size(153, 23);
            txtLimitPath.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(11, 30);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(47, 15);
            label1.TabIndex = 10;
            label1.Text = "Origem";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(12, 65);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(47, 15);
            label2.TabIndex = 11;
            label2.Text = "Destino";
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
            groupBox1.Location = new System.Drawing.Point(1078, 4);
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
            radioCopied.CheckedChanged += radioCopied_CheckedChanged;
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
            // Size
            // 
            Size.HeaderText = "Size";
            Size.MinimumWidth = 8;
            Size.Name = "Size";
            Size.Width = 52;
            // 
            // Form1
            // 
            ClientSize = new System.Drawing.Size(1577, 621);
            Controls.Add(groupBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(progressBar);
            Controls.Add(btnMoveFiles);
            Controls.Add(btnLoadGrid);
            Controls.Add(dataGridView);
            Controls.Add(txtDestinationFolder);
            Controls.Add(txtSourceFolder);
            Controls.Add(btnSelectDestination);
            Controls.Add(btnSelectSource);
            Name = "Form1";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Rumo - Cópia de arquivos";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            FormClosing += MainForm_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

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
        private System.Windows.Forms.DataGridViewTextBoxColumn Size;
    }
}
