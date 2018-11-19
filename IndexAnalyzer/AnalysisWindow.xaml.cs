using IndexAnalyzer.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Threading;
using System.Data;
using System.IO;
using OfficeOpenXml;
using System.ComponentModel;
using IndexAnalyzer.Static;

namespace IndexAnalyzer
{
    /// <summary>
    /// Interaction logic for AnalysisWindow.xaml
    /// </summary>
    public partial class AnalysisWindow : Window
    {
        private int _workCount;      
        private int _workCountMax;
        private BackgroundWorker _backgroundWorker;
        private AnalysisConfiguration _analysisConfiguration;

        public AnalysisWindow(AnalysisConfiguration analysisConfiguration)
        {
            InitializeComponent();
            _analysisConfiguration = analysisConfiguration;
        }

        #region Control Methods
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Force focus
            this.Focus();

            // Prep view
            //this.grdWorkingOverlay.Visibility = (working == true ? Visibility.Visible : Visibility.Hidden);
            this.btnCloseAnalysis.Visibility = Visibility.Hidden;
            this.prgAnalysis.Visibility = Visibility.Visible;

            this.prgAnalysis.Minimum = 0;
            this.prgAnalysis.Maximum = 100;
            this.prgAnalysis.Value = 0;

            // Start working!
            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.WorkerReportsProgress = true;
            _backgroundWorker.WorkerSupportsCancellation = true;
            _backgroundWorker.DoWork += BackgroundWorker_DoWork;
            _backgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
            _backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
            _backgroundWorker.RunWorkerAsync();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (_backgroundWorker.IsBusy)
                _backgroundWorker.CancelAsync();
        }

        private void btnCloseAnalysis_Click(object sender, RoutedEventArgs e)
        {
            if (_backgroundWorker.IsBusy)
                _backgroundWorker.CancelAsync();

            this.Close();
        }
        #endregion

        #region Worker Methods
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Initialize the data table
            string columnName = string.Empty;
            List<Tuple<int, string, List<IndexItem>>> indexValues;
            DataTable dataTable;
            bool changeOccured = false;
            int columnOffset = 0;

            // Init
            dataTable = new DataTable();
            _workCountMax = (File.ReadLines(_analysisConfiguration.File.FullName).Count() * 2) 
                            - ((_analysisConfiguration.ShouldIgnoreHeaderRow == true) ? 0 : 2)
                            - ((_analysisConfiguration.ShouldIgnoreTrailerRow == true) ? 0 : 2);

            //
            // Build Columns
            // Init date table and add a row column
            if (_analysisConfiguration.ShouldIncludeRowIdColumn == true)
                dataTable.Columns.Add($"{Constants.Application.Abbr}_RowId", typeof(System.Int64));

            if (_analysisConfiguration.ShouldIncludeFlagColumn == true)
                dataTable.Columns.Add($"{Constants.Application.Abbr}_Flags");

            // Iterate over the columns provided and build the column list
            foreach (IndexDefinition index in _analysisConfiguration.IndexDefinitions)
            {
                // Setup column name
                columnName = index.Name;

                // Loop over each column and check for a column
                while (true)
                {
                    changeOccured = false;
                    foreach (DataColumn Column in dataTable.Columns)
                    {
                        if (Column.ColumnName == columnName)
                        {
                            // Get the number currently appended to the end of the column name
                            int.TryParse(columnName.Substring(index.Name.Length, columnName.Length - index.Name.Length), out var currentNumber);

                            // Set column name appending new number at end
                            columnName = index.Name + (++currentNumber).ToString();

                            // Indicate a change
                            changeOccured = true;

                            // Break from loop
                            break;
                        }
                    }

                    if (changeOccured) continue; else break;
                }

                // Add this column
                dataTable.Columns.Add(columnName);

                // Check for cancellation
                if (_backgroundWorker.CancellationPending)
                    return;
            }

            //
            // Iterate over the content and build cells
            indexValues = BuildIndexResults();
            for (int i = 0; i < indexValues.Count; i++)
            {
                try
                {
                    // Declare cell items
                    object[] Cell = new object[dataTable.Columns.Count];
                    columnOffset = 0;

                    // Add RowId column value
                    if (_analysisConfiguration.ShouldIncludeRowIdColumn == true)
                        Cell[columnOffset++] = indexValues[i].Item1;

                    // Add Flag column value spot
                    if (_analysisConfiguration.ShouldIncludeFlagColumn == true)
                        Cell[columnOffset++] = indexValues[i].Item2;

                    // Set content row data
                    for (int x = 0; x < indexValues[i].Item3.Count; x++)
                        Cell[x + columnOffset] = indexValues[i].Item3[x].Value;

                    // Add the cell to the table
                    dataTable.Rows.Add(Cell);
                }
                catch { }

                // Check for cancellation
                if (_backgroundWorker.CancellationPending)
                    return;
                else
                    _backgroundWorker.ReportProgress(Convert.ToInt32(((double)++_workCount / (double)_workCountMax) * 100));
            }

            //
            // Set source
            this.Dispatcher.Invoke(() => this.dgAnalysisResults.ItemsSource = dataTable.DefaultView);
        }

        public List<Tuple<int, string, List<IndexItem>>> BuildIndexResults()
        {
            // Declare return value
            int count = 0;
            string value = string.Empty;
            string line = string.Empty;
            string flags = string.Empty;
            List<IndexItem> items;
            List<Tuple<int, string, List<IndexItem>>> returnValue = new List<Tuple<int, string, List<IndexItem>>>();

            // Check if the file exists
            if (!_analysisConfiguration.File.Exists)
                return returnValue;

            // Start the stream reader
            using (StreamReader fileStream = new StreamReader(_analysisConfiguration.File.FullName))
            {
                while (!fileStream.EndOfStream)
                {
                    try
                    {
                        line = fileStream.ReadLine();
                        value = string.Empty;
                        items = new List<IndexItem>();

                        foreach (IndexDefinition indexDefinition in _analysisConfiguration.IndexDefinitions)
                        {
                            flags = string.Empty;

                            try
                            {
                                // If the defined content length exceeds the line definition
                                if (((indexDefinition.Position - (int)_analysisConfiguration.IndexOffset) + indexDefinition.Length) > line.Length)
                                    value = line.Substring(indexDefinition.Position.Value - (int)_analysisConfiguration.IndexOffset, line.Length - (indexDefinition.Position.Value - (int)_analysisConfiguration.IndexOffset));
                                else
                                    value = line.Substring(indexDefinition.Position.Value - (int)_analysisConfiguration.IndexOffset, indexDefinition.Length.Value);

                                // Trim the value found
                                value = value.Trim();

                                // Check for issues
                                flags += ValidateDataType(value, indexDefinition.DataType) + " ";

                                // Add to results table
                                items.Add(new IndexItem(value, flags, indexDefinition)); // sub 1 from the start position. Index file specs are usually not zero based (add option for this later)
                            }
                            catch { }
                        }

                        returnValue.Add(Tuple.Create(count++, String.Join(" ", items.Select(x => x.Flags)).Trim(), items));
                    }
                    catch { }

                    // Check for cancellation
                    if (_backgroundWorker.CancellationPending)
                        return returnValue;
                    else
                        _backgroundWorker.ReportProgress(Convert.ToInt32(((double)++_workCount / (double)_workCountMax) * 100));
                }

                // Close the stream
                fileStream.Close();
            }

            // Remove the header and trailer record if indicated
            if (_analysisConfiguration.ShouldIgnoreHeaderRow == true)
                returnValue.RemoveAt(0); // Remove first item in list

            if (_analysisConfiguration.ShouldIgnoreTrailerRow == true)
                returnValue.RemoveAt(returnValue.Count - 1); // Remove last item in list

            // Return the value
            return returnValue;
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.prgAnalysis.Value = e.ProgressPercentage;
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.btnCloseAnalysis.Visibility = Visibility.Visible;
            this.prgAnalysis.Visibility = Visibility.Hidden;
        }
        #endregion

        #region Validation Methods 
        private string ValidateDataType(string value, string dataType)
        {
            string flag = string.Empty;
            Type type = null;
            string flagTemplate = "Value \"{0}\" cannot be parsed to type \"{1}\".";
        
            try
            {
                if (!dataType.Equals("None"))
                {
                    type = Type.GetType(dataType);

                    switch(dataType)
                    {
                        case "System.Char":
                            if (!Char.TryParse(value, out var charTrash))
                                flag = string.Format(flagTemplate, value, dataType);
                            break;
                        case "System.String":
                            break;
                        case "System.Decimal":
                            if (!decimal.TryParse(value, out var decimalTrash))
                                flag = string.Format(flagTemplate, value, dataType);
                            break;
                        case "System.Int32":
                            if (!Int32.TryParse(value, out var int32Trash))
                                flag = string.Format(flagTemplate, value, dataType);
                            break;
                        case "System.Int64":
                            if (!Int64.TryParse(value, out var int64Trash))
                                flag = string.Format(flagTemplate, value, dataType);
                            break;
                        case "System.Boolean":
                            if (!Boolean.TryParse(value, out var booleanTrash))
                                flag = string.Format(flagTemplate, value, dataType);
                            break;
                        case "System.DateTime":
                            if (!DateTime.TryParse(value, out var datetimeTrash))
                                flag = string.Format(flagTemplate, value, dataType);
                            break;
                        default:
                            flag = "Unable to determine datatype.";
                            break;
                    }
                }
            }
            catch
            {
                flag = "Unable to validate datatype.";
            }

            return flag;
        }
        #endregion

        #region Export Methods
        private string GetSavePath(string defaultExtension, string filter)
        {
            Microsoft.Win32.SaveFileDialog saveFileDialog;
            Nullable<bool> result;

            saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.DefaultExt = defaultExtension;
            saveFileDialog.Filter = filter;
            result = saveFileDialog.ShowDialog();

            if (result == true)
                return saveFileDialog.FileName;
            else
                return string.Empty;
        }

        public void ExportToExcel(string filePath, DataTable tableToExport)
        {
            FileInfo file;
            ExcelWorksheet excelWorksheet;
            ExcelRange excelRange;

            // Create the file using the FileInfo object
            file = new FileInfo(filePath);
            if (file.Exists)
                file.Delete();

            // Export to excel
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                excelWorksheet = excelPackage.Workbook.Worksheets.Add("Export");
                excelWorksheet.Cells["A1"].LoadFromDataTable(tableToExport, true);

                excelRange = excelWorksheet.Cells[1, 1, 1, tableToExport.Columns.Count];
                excelRange.Style.Font.Bold = true;
                excelRange.AutoFitColumns();

                excelPackage.Save();
            }

            // Open the file
            System.Diagnostics.Process.Start(file.FullName);
        }

        public void ExportDelimited(string filePath, string delimiter, DataTable tableToExport)
        {
            StringBuilder builder;
            FileInfo file;

            // Create the file using the FileInfo object
            file = new FileInfo(filePath);
            if (file.Exists)
                file.Delete();

            // Build the file contents
            builder = new StringBuilder();
            foreach (DataRow dataRow in tableToExport.Rows)
                builder.AppendLine(String.Join(delimiter, dataRow.ItemArray));

            // Export the contents to the file
            File.WriteAllText(file.FullName, builder.ToString());

            // Open the file
            System.Diagnostics.Process.Start(file.FullName);
        }
        #endregion

        #region Menu Methods
        private void MenuItem_ExportExcel_Click(object sender, RoutedEventArgs e)
        {
            string filePath = string.Empty;
            DataTable dataTable = null;

            filePath = GetSavePath(".xlsx", "Excel Files|*.xlsx");
            dataTable = ((DataView)this.dgAnalysisResults.ItemsSource).ToTable();

            if (!string.IsNullOrWhiteSpace(filePath))
                Task.Run(() => ExportToExcel(filePath, dataTable));
        }

        private void MenuItem_ExportTabDelimited_Click(object sender, RoutedEventArgs e)
        {
            string filePath = string.Empty;
            DataTable dataTable = null;

            filePath = GetSavePath(".txt", "Text Files|*.txt");
            dataTable = ((DataView)this.dgAnalysisResults.ItemsSource).ToTable();

            if (!string.IsNullOrWhiteSpace(filePath))
                Task.Run(() => ExportDelimited(filePath, "\t", dataTable));
        }

        private void MenuItem_ExportPipeDelimited_Click(object sender, RoutedEventArgs e)
        {
            string filePath = string.Empty;
            DataTable dataTable = null;

            filePath = GetSavePath(".pip", "Pipe-Delimited Files|*.pip");
            dataTable = ((DataView)this.dgAnalysisResults.ItemsSource).ToTable();

            if (!string.IsNullOrWhiteSpace(filePath))
                Task.Run(() => ExportDelimited(filePath, "|", dataTable));
        }

        private void MenuItem_ExportCommaDelimited_Click(object sender, RoutedEventArgs e)
        {
            string filePath = string.Empty;
            DataTable dataTable = null;

            filePath = GetSavePath(".csv", "Comma-Delimited Files|*.csv");
            dataTable = ((DataView)this.dgAnalysisResults.ItemsSource).ToTable();

            if (!string.IsNullOrWhiteSpace(filePath))
                Task.Run(() => ExportDelimited(filePath, ",", dataTable));
        }
        #endregion
    }
}