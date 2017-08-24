namespace IndexViewer
{
    partial class frmMain
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
            this.fDialog = new System.Windows.Forms.OpenFileDialog();
            this.lblFileToView = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnFile = new System.Windows.Forms.Button();
            this.dataGridIndexes = new System.Windows.Forms.DataGridView();
            this.txtName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtStartPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.btnLoadDefinitions = new System.Windows.Forms.Button();
            this.btnExportDefinitions = new System.Windows.Forms.Button();
            this.sDialog = new System.Windows.Forms.SaveFileDialog();
            this.chkIsZeroBased = new System.Windows.Forms.CheckBox();
            this.chkIgnoreHeaderRow = new System.Windows.Forms.CheckBox();
            this.chkIgnoreTrailerRow = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridIndexes)).BeginInit();
            this.SuspendLayout();
            // 
            // fDialog
            // 
            this.fDialog.Filter = "Text|*.txt";
            // 
            // lblFileToView
            // 
            this.lblFileToView.AutoSize = true;
            this.lblFileToView.Location = new System.Drawing.Point(12, 7);
            this.lblFileToView.Name = "lblFileToView";
            this.lblFileToView.Size = new System.Drawing.Size(79, 13);
            this.lblFileToView.TabIndex = 0;
            this.lblFileToView.Text = "File To Analyze";
            this.lblFileToView.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(15, 23);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(330, 20);
            this.txtFilePath.TabIndex = 1;
            // 
            // btnFile
            // 
            this.btnFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFile.Location = new System.Drawing.Point(351, 22);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(75, 23);
            this.btnFile.TabIndex = 2;
            this.btnFile.Text = "File";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // dataGridIndexes
            // 
            this.dataGridIndexes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridIndexes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtName,
            this.txtStartPosition,
            this.txtLength});
            this.dataGridIndexes.Location = new System.Drawing.Point(15, 51);
            this.dataGridIndexes.Name = "dataGridIndexes";
            this.dataGridIndexes.Size = new System.Drawing.Size(411, 148);
            this.dataGridIndexes.TabIndex = 3;
            // 
            // txtName
            // 
            this.txtName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txtName.HeaderText = "Name";
            this.txtName.Name = "txtName";
            // 
            // txtStartPosition
            // 
            this.txtStartPosition.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.txtStartPosition.HeaderText = "Start Position";
            this.txtStartPosition.Name = "txtStartPosition";
            this.txtStartPosition.Width = 94;
            // 
            // txtLength
            // 
            this.txtLength.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.txtLength.HeaderText = "Length";
            this.txtLength.Name = "txtLength";
            this.txtLength.Width = 65;
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnalyze.Location = new System.Drawing.Point(15, 255);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(411, 23);
            this.btnAnalyze.TabIndex = 4;
            this.btnAnalyze.Text = "Analyze";
            this.btnAnalyze.UseVisualStyleBackColor = true;
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // btnLoadDefinitions
            // 
            this.btnLoadDefinitions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadDefinitions.Location = new System.Drawing.Point(322, 205);
            this.btnLoadDefinitions.Name = "btnLoadDefinitions";
            this.btnLoadDefinitions.Size = new System.Drawing.Size(104, 23);
            this.btnLoadDefinitions.TabIndex = 5;
            this.btnLoadDefinitions.Text = "Load Definitions";
            this.btnLoadDefinitions.UseVisualStyleBackColor = true;
            this.btnLoadDefinitions.Click += new System.EventHandler(this.btnLoadDefinitions_Click);
            // 
            // btnExportDefinitions
            // 
            this.btnExportDefinitions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportDefinitions.Location = new System.Drawing.Point(212, 205);
            this.btnExportDefinitions.Name = "btnExportDefinitions";
            this.btnExportDefinitions.Size = new System.Drawing.Size(104, 23);
            this.btnExportDefinitions.TabIndex = 6;
            this.btnExportDefinitions.Text = "Export Definitions";
            this.btnExportDefinitions.UseVisualStyleBackColor = true;
            this.btnExportDefinitions.Click += new System.EventHandler(this.btnExportDefinitions_Click);
            // 
            // sDialog
            // 
            this.sDialog.Filter = "Text (Tab Delmited)|*.txt";
            // 
            // chkIsZeroBased
            // 
            this.chkIsZeroBased.AutoSize = true;
            this.chkIsZeroBased.Location = new System.Drawing.Point(15, 232);
            this.chkIsZeroBased.Name = "chkIsZeroBased";
            this.chkIsZeroBased.Size = new System.Drawing.Size(138, 17);
            this.chkIsZeroBased.TabIndex = 7;
            this.chkIsZeroBased.Text = "Is Position Zero-Based?";
            this.chkIsZeroBased.UseVisualStyleBackColor = true;
            // 
            // chkIgnoreHeaderRow
            // 
            this.chkIgnoreHeaderRow.AutoSize = true;
            this.chkIgnoreHeaderRow.Location = new System.Drawing.Point(15, 209);
            this.chkIgnoreHeaderRow.Name = "chkIgnoreHeaderRow";
            this.chkIgnoreHeaderRow.Size = new System.Drawing.Size(100, 17);
            this.chkIgnoreHeaderRow.TabIndex = 8;
            this.chkIgnoreHeaderRow.Text = "Ignore Header?";
            this.chkIgnoreHeaderRow.UseVisualStyleBackColor = true;
            // 
            // chkIgnoreTrailerRow
            // 
            this.chkIgnoreTrailerRow.AutoSize = true;
            this.chkIgnoreTrailerRow.Location = new System.Drawing.Point(121, 209);
            this.chkIgnoreTrailerRow.Name = "chkIgnoreTrailerRow";
            this.chkIgnoreTrailerRow.Size = new System.Drawing.Size(94, 17);
            this.chkIgnoreTrailerRow.TabIndex = 9;
            this.chkIgnoreTrailerRow.Text = "Ignore Trailer?";
            this.chkIgnoreTrailerRow.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 292);
            this.Controls.Add(this.btnExportDefinitions);
            this.Controls.Add(this.chkIgnoreTrailerRow);
            this.Controls.Add(this.chkIgnoreHeaderRow);
            this.Controls.Add(this.chkIsZeroBased);
            this.Controls.Add(this.btnLoadDefinitions);
            this.Controls.Add(this.btnAnalyze);
            this.Controls.Add(this.dataGridIndexes);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.lblFileToView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmMain";
            this.Text = "Index Analyzer";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridIndexes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog fDialog;
        private System.Windows.Forms.Label lblFileToView;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.DataGridView dataGridIndexes;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtStartPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtLength;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.Button btnLoadDefinitions;
        private System.Windows.Forms.Button btnExportDefinitions;
        private System.Windows.Forms.SaveFileDialog sDialog;
        private System.Windows.Forms.CheckBox chkIsZeroBased;
        private System.Windows.Forms.CheckBox chkIgnoreHeaderRow;
        private System.Windows.Forms.CheckBox chkIgnoreTrailerRow;
    }
}

