using IndexAnalyzer.Objects;
using IndexAnalyzer.Static;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using System.IO;

namespace IndexAnalyzer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<IndexDefinition> IndexDefinitions { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            this.IndexDefinitions = new ObservableCollection<IndexDefinition>();
            this.DataContext = this.IndexDefinitions;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MenuItem_Exit_Click(this, null);
        }

        private void btnSelectFile_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog;
            Nullable<bool> result;

            openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.DefaultExt = ".txt";
            openFileDialog.Filter = "Text Files (*.txt)|*.txt";
            result = openFileDialog.ShowDialog();
            if (result == true)
                this.txtFilePath.Text = openFileDialog.FileName;
        }

        private void btnAnalyzeFile_Click(object sender, RoutedEventArgs e)
        {
            AnalysisConfiguration analysisConfiguration;

            // Validate input
            if (string.IsNullOrEmpty(this.txtFilePath.Text))
            {
                MessageBox.Show("You must specify a file to analyze.", Constants.Application.Name + " " + Constants.Application.Version, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (this.IndexDefinitions.Count < 1)
            {
                MessageBox.Show("You must specify atleast one index to analyze.", Constants.Application.Name + " " + Constants.Application.Version, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            foreach (IndexDefinition indexDefinition in this.IndexDefinitions)
            {
                if (string.IsNullOrWhiteSpace(indexDefinition.Name) || indexDefinition.Position == null || indexDefinition.Length == null)
                {
                    MessageBox.Show("You must provide atleast the name, position, and length for all index definitions.", Constants.Application.Name + " " + Constants.Application.Version, MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            // Prep config
            analysisConfiguration = new AnalysisConfiguration()
            {
                File = new FileInfo(this.txtFilePath.Text),
                ShouldIgnoreHeaderRow = this.chkIgnoreHeader.IsChecked,
                ShouldIgnoreTrailerRow = this.chkIgnoreFooter.IsChecked,
                ShouldIncludeRowIdColumn = this.chkIncludeRowIdColumn.IsChecked,
                ShouldIncludeFlagColumn = this.chkIncludeFlagColumn.IsChecked,
                IndexDefinitions = this.IndexDefinitions.ToList<IndexDefinition>()
            }.SortIndexDefinitionsByPosition();

            if (analysisConfiguration.IndexDefinitions[0].Position == 1)
                analysisConfiguration.IndexOffset = IndexOffset.One;
            else
                analysisConfiguration.IndexOffset = IndexOffset.Zero;

            // Start analysis
            AnalysisWindow analysisWindow = new AnalysisWindow(analysisConfiguration);
            analysisWindow.Show();
        }

        private void btnImportDefinitions_Click(object sender, RoutedEventArgs e)
        {
            MenuItem_ImportTemplate_Click(this, e);
        }

        private void btnExportDefinitions_Click(object sender, RoutedEventArgs e)
        {
            MenuItem_ExportTemplate_Click(this, e);
        }

        private void btnClearDefinitions_Click(object sender, RoutedEventArgs e)
        {
            this.IndexDefinitions = new ObservableCollection<IndexDefinition>();
            this.DataContext = this.IndexDefinitions;
        }

        #region Menu Events
        private void MenuItem_ImportTemplate_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog;
            string jsonData;
            Nullable<bool> result;
            MessageBoxResult messageBoxResult;

            if (this.IndexDefinitions.Count > 0)
            {
                messageBoxResult = MessageBox.Show("Importing a template will clear your current definitions. Are you sure you want to continue?", Constants.Application.Name + " " + Constants.Application.Version, MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (messageBoxResult == MessageBoxResult.No)
                    return;
            }

            openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.DefaultExt = ".json";
            openFileDialog.Filter = "JSON Files|*.json";
            result = openFileDialog.ShowDialog();

            if (result == true)
            {
                jsonData = File.ReadAllText(openFileDialog.FileName);
                if (!string.IsNullOrWhiteSpace(jsonData))
                {
                    try
                    {
                        this.IndexDefinitions = JsonConvert.DeserializeObject<ObservableCollection<IndexDefinition>>(jsonData);
                        this.DataContext = this.IndexDefinitions;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Unable to load definitions from the selected file.", Constants.Application.Name + " " + Constants.Application.Version, MessageBoxButton.OK, MessageBoxImage.Error);
                    }                           
                }
            }
        }

        private void MenuItem_ExportTemplate_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog saveFileDialog;
            string jsonData;
            Nullable<bool> result;

            this.dgIndexDefinitions.CommitEdit();

            if (this.IndexDefinitions.Count > 0)
            {
                saveFileDialog = new Microsoft.Win32.SaveFileDialog();
                saveFileDialog.DefaultExt = ".json";
                saveFileDialog.Filter = "JSON Files|*.json";
                result = saveFileDialog.ShowDialog();

                if (result == true)
                {
                    jsonData = JsonConvert.SerializeObject(IndexDefinitions);
                    File.WriteAllText(saveFileDialog.FileName, jsonData);
                }
            }
            else
            {
                MessageBox.Show("You must have atleast 1 index defined before exporting.", Constants.Application.Name + " " + Constants.Application.Version, MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void MenuItem_Exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult;

            if (this.IndexDefinitions.Count > 0)
            {
                messageBoxResult = MessageBox.Show("It appears you have index definitions defined. Closing the application will result in these being lost. Are you sure you want to continue?", Constants.Application.Name + " " + Constants.Application.Version, MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (messageBoxResult == MessageBoxResult.Yes)
                    Environment.Exit(0);
            }
        }
        #endregion
    }
}
