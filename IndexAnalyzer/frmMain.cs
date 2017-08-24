using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IndexAnalyzer.Objects;
using System.Threading;
using System.IO;

namespace IndexAnalyzer
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            // Subscribe to events
            this.Load += FrmMain_Load;
            this.FormClosing += FrmMain_FormClosing;
        }

        #region Control Methods
        private void FrmMain_Load(object sender, EventArgs e)
        {
            // Clean up the temporary directory
            Thread nThread = new Thread(() => CleanupTempDirectory());
            nThread.Start();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Clean up the temporary directory
            Thread nThread = new Thread(() => CleanupTempDirectory());
            nThread.Start();
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            DialogResult Result = fDialog.ShowDialog();

            if (Result == DialogResult.OK)
                if (fDialog.CheckFileExists)
                    this.txtFilePath.Text = fDialog.FileName;
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtFilePath.Text))
            {
                MessageBox.Show("You must specify a file to analyze.", Program.AppName + " " + Program.AppVersion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.dataGridIndexes.RowCount <= 1)
            {
                // We have only one row, validate its contents
                DataGridViewRow Row = this.dataGridIndexes.Rows[0];
                DataGridViewCell Name = Row.Cells[0];
                DataGridViewCell StartPosition = Row.Cells[1];
                DataGridViewCell Length = Row.Cells[2];

                if (Name.Value == null || StartPosition.Value == null || Length.Value == null)
                {
                    MessageBox.Show("You must define atleast one index to view.", Program.AppName + " " + Program.AppVersion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Initialize list of indexes
            List<IndexItem> IndexDefinitions = new List<IndexItem>();
            foreach (DataGridViewRow Row in this.dataGridIndexes.Rows)
            {
                // Get the cells
                DataGridViewCell Name = Row.Cells[0];
                DataGridViewCell StartPosition = Row.Cells[1];
                DataGridViewCell Length = Row.Cells[2];

                // If the name, position, and length are all null, we can just skip this line
                if (Name.Value == null && StartPosition.Value == null && Length.Value == null) continue;

                // If any of the items are null, we are missing data
                if (Name.Value == null || StartPosition.Value == null || Length.Value == null)
                {
                    MessageBox.Show("Each index definition must contain a name, start position, and a length.", Program.AppName + " " + Program.AppVersion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    IndexDefinitions.Add(new IndexItem(Name.Value.ToString(), StartPosition.Value.ToString(), Length.Value.ToString()));
                }
            }

            // Create a new configuration object
            AnalyzerConfiguration Configuration = new AnalyzerConfiguration(this.txtFilePath.Text, (this.chkIsZeroBased.Checked == false ? 1 : 0), this.chkIgnoreHeaderRow.Checked, this.chkIgnoreTrailerRow.Checked);

            // Open the viewer form
            frmAnalyze Analyzer = new frmAnalyze(IndexDefinitions, Configuration);
            Analyzer.Show();
        }

        #region Column Definition Methods
        private void btnLoadDefinitions_Click(object sender, EventArgs e)
        {
            DialogResult Result = fDialog.ShowDialog();

            if (Result == DialogResult.OK)
            {
                if (fDialog.CheckFileExists)
                {
                    // Clear the rows out
                    this.dataGridIndexes.Rows.Clear();

                    // Declare variables
                    int count = 0;
                    StreamReader fStream = new StreamReader(fDialog.OpenFile());

                    while (!fStream.EndOfStream)
                    {
                        string Line = fStream.ReadLine();
                        string[] ColumnValues = Line.Split(new char[] { '\t' }, StringSplitOptions.None);
                        if (ColumnValues.Length >= 3)
                        {
                            this.dataGridIndexes.Rows.Add();
                            this.dataGridIndexes.Rows[count].Cells[0].Value = ColumnValues[0];
                            this.dataGridIndexes.Rows[count].Cells[1].Value = ColumnValues[1];
                            this.dataGridIndexes.Rows[count].Cells[2].Value = ColumnValues[2];
                        }

                        count++;
                    }

                    fStream.Close();
                }
            }
        }

        private void btnExportDefinitions_Click(object sender, EventArgs e)
        {
            DialogResult Result = sDialog.ShowDialog();

            if (Result == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(sDialog.FileName))
                {
                    StreamWriter fStream = new StreamWriter(sDialog.OpenFile());
                    foreach (DataGridViewRow Row in this.dataGridIndexes.Rows)
                    {
                        if (Row.Cells == null || Row.Cells.Count == 0) continue;
                        DataGridViewCell Name = Row.Cells[0];
                        DataGridViewCell StartPosition = Row.Cells[1];
                        DataGridViewCell Length = Row.Cells[2];
                        if (StartPosition.Value == null || Length.Value == null) continue;

                        string nRow = string.Format("{0}\t{1}\t{2}\n"
                            , Name.Value.ToString()
                            , StartPosition.Value.ToString()
                            , Length.Value.ToString()
                        );

                        fStream.Write(nRow);
                    }
                    fStream.Close();
                }
            }
        }
        #endregion
        #endregion

        #region Helper Methods
        private void CleanupTempDirectory()
        {
            if (Directory.Exists(Constants.Working.Path))
            {
                foreach (FileInfo Item in new DirectoryInfo(Constants.Working.Path).GetFiles())
                {
                    try { Item.Delete(); }
                    catch { }
                }
            }
            else
                Directory.CreateDirectory(Constants.Working.Path);
        }
        #endregion
    }
}