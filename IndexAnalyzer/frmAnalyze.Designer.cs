namespace IndexViewer
{
    partial class frmAnalyze
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridAnalyzer = new System.Windows.Forms.DataGridView();
            this.mStrip = new System.Windows.Forms.MenuStrip();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toTabDelmitedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commaDelimitedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imgLoading = new System.Windows.Forms.PictureBox();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.prgBarRows = new System.Windows.Forms.ProgressBar();
            this.tmrCheckProgress = new System.Windows.Forms.Timer(this.components);
            this.bWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAnalyzer)).BeginInit();
            this.mStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoading)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridAnalyzer
            // 
            this.dataGridAnalyzer.AllowUserToAddRows = false;
            this.dataGridAnalyzer.AllowUserToDeleteRows = false;
            this.dataGridAnalyzer.AllowUserToResizeRows = false;
            this.dataGridAnalyzer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAnalyzer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridAnalyzer.Location = new System.Drawing.Point(0, 24);
            this.dataGridAnalyzer.Name = "dataGridAnalyzer";
            this.dataGridAnalyzer.RowHeadersVisible = false;
            this.dataGridAnalyzer.Size = new System.Drawing.Size(908, 267);
            this.dataGridAnalyzer.TabIndex = 0;
            // 
            // mStrip
            // 
            this.mStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToolStripMenuItem});
            this.mStrip.Location = new System.Drawing.Point(0, 0);
            this.mStrip.Name = "mStrip";
            this.mStrip.Size = new System.Drawing.Size(908, 24);
            this.mStrip.TabIndex = 1;
            this.mStrip.Text = "menuStrip1";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toExcelToolStripMenuItem,
            this.toTabDelmitedToolStripMenuItem,
            this.commaDelimitedToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // toExcelToolStripMenuItem
            // 
            this.toExcelToolStripMenuItem.Name = "toExcelToolStripMenuItem";
            this.toExcelToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.toExcelToolStripMenuItem.Text = "Excel";
            this.toExcelToolStripMenuItem.Click += new System.EventHandler(this.toExcelToolStripMenuItem_Click);
            // 
            // toTabDelmitedToolStripMenuItem
            // 
            this.toTabDelmitedToolStripMenuItem.Name = "toTabDelmitedToolStripMenuItem";
            this.toTabDelmitedToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.toTabDelmitedToolStripMenuItem.Text = "Tab Delmited";
            this.toTabDelmitedToolStripMenuItem.Click += new System.EventHandler(this.toTabDelmitedToolStripMenuItem_Click);
            // 
            // commaDelimitedToolStripMenuItem
            // 
            this.commaDelimitedToolStripMenuItem.Name = "commaDelimitedToolStripMenuItem";
            this.commaDelimitedToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.commaDelimitedToolStripMenuItem.Text = "Comma Delimited";
            this.commaDelimitedToolStripMenuItem.Click += new System.EventHandler(this.toCommaDelimitedToolStripMenuItem_Click);
            // 
            // imgLoading
            // 
            this.imgLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgLoading.Image = global::IndexViewer.Properties.Resources.loading;
            this.imgLoading.Location = new System.Drawing.Point(0, 24);
            this.imgLoading.Name = "imgLoading";
            this.imgLoading.Size = new System.Drawing.Size(908, 267);
            this.imgLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgLoading.TabIndex = 2;
            this.imgLoading.TabStop = false;
            this.imgLoading.Visible = false;
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.prgBarRows);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 291);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(908, 20);
            this.pnlFooter.TabIndex = 3;
            // 
            // prgBarRows
            // 
            this.prgBarRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prgBarRows.Location = new System.Drawing.Point(0, 0);
            this.prgBarRows.Name = "prgBarRows";
            this.prgBarRows.Size = new System.Drawing.Size(908, 20);
            this.prgBarRows.TabIndex = 1;
            // 
            // tmrCheckProgress
            // 
            this.tmrCheckProgress.Tick += new System.EventHandler(this.tmrCheckProgress_Tick);
            // 
            // bWorker
            // 
            this.bWorker.WorkerReportsProgress = true;
            this.bWorker.WorkerSupportsCancellation = true;
            this.bWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bWorker_DoWork);
            // 
            // frmAnalyze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 311);
            this.Controls.Add(this.imgLoading);
            this.Controls.Add(this.dataGridAnalyzer);
            this.Controls.Add(this.mStrip);
            this.Controls.Add(this.pnlFooter);
            this.MainMenuStrip = this.mStrip;
            this.Name = "frmAnalyze";
            this.Text = "Analyzer";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAnalyzer)).EndInit();
            this.mStrip.ResumeLayout(false);
            this.mStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoading)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridAnalyzer;
        private System.Windows.Forms.MenuStrip mStrip;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toTabDelmitedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commaDelimitedToolStripMenuItem;
        private System.Windows.Forms.PictureBox imgLoading;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Timer tmrCheckProgress;
        private System.Windows.Forms.ProgressBar prgBarRows;
        private System.ComponentModel.BackgroundWorker bWorker;
    }
}