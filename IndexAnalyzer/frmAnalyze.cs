using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IndexViewer.Objects;
using OfficeOpenXml;
using System.Threading;
using System.IO;

namespace IndexViewer
{
    public partial class frmAnalyze : Form
    {
        private List<IndexItem> _IndexDefinitions;
        private AnalyzerConfiguration _Configurations;
        private int _RowCount;

        public frmAnalyze(List<IndexItem> IndexDefinitions, AnalyzerConfiguration Configurations)
        {
            _IndexDefinitions = IndexDefinitions;
            _Configurations = Configurations;

            InitializeComponent();

            // Subscribe to events
            this.Load += frmAnalyze_Load;
            this.FormClosing += frmAnalyze_FormClosing;
        }

        private void frmAnalyze_Load(object sender, EventArgs e)
        {
            // Prep the progress bar
            this.prgBarRows.Maximum = 0;
            this.prgBarRows.Minimum = 0;
            this.prgBarRows.Value = 0;

            // Focus this form
            this.Focus();

            // Kick off the background worker
            bWorker.RunWorkerAsync();
        }

        private void frmAnalyze_FormClosing(object sender, FormClosingEventArgs e)
        {
            // If the worker is running, cancel it
            if (bWorker.IsBusy)
                bWorker.CancelAsync();
        }

        #region Menu Strip Methods
        private void toExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Prepare data table
            DataTable nTable = (DataTable)this.dataGridAnalyzer.DataSource;

            // Setup the thread
            Thread nThread = new Thread(() => ExportToExcel(nTable, ".xlsx"));

            // Start the thread
            nThread.Start();
        }

        private void toTabDelmitedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Prepare data table
            DataTable nTable = (DataTable)this.dataGridAnalyzer.DataSource;
            string Delimiter = "\t";

            // Setup the thread
            Thread nThread = new Thread(() => ExportDelimited(nTable, Delimiter, ".txt"));

            // Start the thread
            nThread.Start();
        }

        private void toCommaDelimitedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Prepare data table
            DataTable nTable = (DataTable)this.dataGridAnalyzer.DataSource;
            string Delimiter = ",";

            // Setup the thread
            Thread nThread = new Thread(() => ExportDelimited(nTable, Delimiter, ".csv"));

            // Start the thread
            nThread.Start();
        }
        #endregion

        #region Export Methods
        public void ExportToExcel(DataTable TableToExport, string FileExtension)
        {
            try
            {
                // Create the file using the FileInfo object
                FileInfo nFile = new FileInfo(Constants.Working.Path + @"\" + Guid.NewGuid() + FileExtension);

                // Export to excel
                using (ExcelPackage Package = new ExcelPackage(nFile))
                {
                    ExcelWorksheet nWorksheet = Package.Workbook.Worksheets.Add("Viewer");
                    nWorksheet.Cells["A1"].LoadFromDataTable(TableToExport, true);

                    using (ExcelRange Range = nWorksheet.Cells[1, 1, 1, TableToExport.Columns.Count])
                    {
                        Range.Style.Font.Bold = true;
                        Range.AutoFitColumns();
                    }

                    Package.Save();
                }

                // Open the file
                System.Diagnostics.Process.Start(nFile.FullName);
            }
            catch { }
        }

        public void ExportDelimited(DataTable TableToExport, string Delimiter, string FileExtension)
        {
            // Create the file using the FileInfo object
            FileInfo nFile = new FileInfo(Constants.Working.Path + @"\" + Guid.NewGuid() + FileExtension);

            // Build the file contents
            StringBuilder sBuilder = new StringBuilder();
            foreach (DataRow Row in TableToExport.Rows)
            {
                sBuilder.AppendLine(String.Join(Delimiter, Row.ItemArray));
            }
            
            // Export the contents to the file
            File.WriteAllText(nFile.FullName, sBuilder.ToString());

            // Open the file
            System.Diagnostics.Process.Start(nFile.FullName);
        }
        #endregion

        #region Timer Methods
        private void tmrCheckProgress_Tick(object sender, EventArgs e)
        {
            this.prgBarRows.Value = _RowCount;
        }
        #endregion

        #region Control Helper Methods
        public void UpdateControlStates(DataTable nTable = null, bool Loading = false, bool CheckProgress = false, int ProgressBarMax = 0)
        {
            if (this.InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    if (nTable != null)
                        this.dataGridAnalyzer.DataSource = nTable;

                    this.imgLoading.Visible = Loading;
                    this.tmrCheckProgress.Enabled = CheckProgress;
                    this.pnlFooter.Visible = CheckProgress;
                    this.prgBarRows.Maximum = ProgressBarMax;
                }));
            }
            else
            {
                if (nTable != null)
                    this.dataGridAnalyzer.DataSource = nTable;

                this.imgLoading.Visible = Loading;
                this.tmrCheckProgress.Enabled = CheckProgress;
                this.pnlFooter.Visible = CheckProgress;
                this.prgBarRows.Maximum = ProgressBarMax;
            }
        }
        #endregion

        #region Thread Methods
        private void bWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            // Show loading image and start progress check
            //UpdateControlStates(null, true, true, 0);

            // Initialize the data table
            DataTable nTable = new DataTable();
            Dictionary<int, List<IndexItem>> IndexResults = BuildIndexResults();

            // Set the control states
            UpdateControlStates(null, true, true, IndexResults.Count);

            // Add a row column
            nTable.Columns.Add("Row");

            // Iterate over the columns provided and build the column list
            foreach (IndexItem Index in _IndexDefinitions)
            {
                // Setup column name
                string ColumnName = Index.Name;

                // Loop over each column and check for a column
                while (true)
                {
                    bool ChangeOccured = false;
                    foreach (DataColumn Column in nTable.Columns)
                    {
                        if (Column.ColumnName == ColumnName)
                        {
                            // Get the number currently appended to the end of the column name
                            int CurrentNumber = 1;
                            int.TryParse(ColumnName.Substring(Index.Name.Length, ColumnName.Length - Index.Name.Length), out CurrentNumber);

                            // Set column name appending new number at end
                            ColumnName = Index.Name + (++CurrentNumber).ToString();

                            // Indicate a change
                            ChangeOccured = true;

                            // Break from loop
                            break;
                        }
                    }

                    if (ChangeOccured) continue;
                    else break;
                }

                // Add this column
                nTable.Columns.Add(ColumnName);

                // Check for cancellation
                if (this.bWorker.CancellationPending == true)
                    return;
            }

            // Iterate over the content and build cells
            for (int i = 0; i < IndexResults.Count; i++)
            {
                // Declare cell item
                var Cell = new object[nTable.Columns.Count];
                string Flags = string.Empty;

                // Set row cell data
                Cell[0] = i; 

                // Set content row data
                for (int x = 0; x < IndexResults.ElementAt(i).Value.Count; x++)
                    Cell[x + 1] = IndexResults.ElementAt(i).Value[x].Value;

                // Add the cell to the table
                nTable.Rows.Add(Cell);

                // Increment the row counter
                _RowCount++;

                // Check for cancellation
                if (this.bWorker.CancellationPending == true)
                    return;
            }

            // Update the controls
            UpdateControlStates(nTable, false, false, IndexResults.Count);
        }

        public Dictionary<int, List<IndexItem>> BuildIndexResults()
        {
            // Declare return value
            Dictionary<int, List<IndexItem>> ReturnValue = new Dictionary<int, List<IndexItem>>();

            // Check if the file exists
            if (!File.Exists(_Configurations.FilePath))
                return ReturnValue;

            // Declare working variables
            int Count = 0;

            // Start the stream reader
            using (StreamReader fStream = new StreamReader(_Configurations.FilePath))
            {
                while (!fStream.EndOfStream)
                {
                    string Line = fStream.ReadLine();
                    //string Flags = string.Empty;
                    List<IndexItem> Items = new List<IndexItem>();

                    foreach (IndexItem Index in _IndexDefinitions)
                    {
                        // If the defined content length exceeds the line definition
                        //if ((Index.StartPosition - _Configurations.Offset + Index.Length) > Line.Length)
                        //    Flags += "The current length of the line is " + Line.Length + " but per the index definition \"" + Index.Name + "\", the line needs to be " + (Index.StartPosition + Index.Length) + " characters long.";

                        // Grab index value
                        string Value;
                        if (((Index.StartPosition - _Configurations.Offset) + Index.Length) > Line.Length)
                            Value = Line.Substring(Index.StartPosition - _Configurations.Offset, Line.Length - (Index.StartPosition - _Configurations.Offset));
                        else
                            Value = Line.Substring(Index.StartPosition - _Configurations.Offset, Index.Length);

                        // Add to results table
                        Items.Add(new IndexItem(Index.Name, Index.StartPosition, Index.Length, Value)); // sub 1 from the start position. Index file specs are usually not zero based (add option for this later)
                    }

                    ReturnValue.Add(Count, Items);
                    Count++;
                }

                // Close the stream
                fStream.Close();
            }

            // Return the value
            return ReturnValue;
        }
        #endregion
    }
}
