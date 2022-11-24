using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace VisualLayoutTester
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetF1CommandBinding();
        }

        private void SetF1CommandBinding()
        {
            var helpBinding = new CommandBinding(ApplicationCommands.Help);
            helpBinding.CanExecute += CanHelpExecute;
            helpBinding.Executed += HelpExecuted;
            CommandBindings.Add(helpBinding);
        }
        private void CanHelpExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void HelpExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Look, it is not that difficult. Just type somethings!", "Help!");
        }

        protected void FileExit_Click(object sender, RoutedEventArgs args)
        {
            Close();
        }

        protected void ToolsSpellingHints_Click(object sender, RoutedEventArgs args) 
        {
            var spellingHints = string.Empty;
            var error = txtData.GetSpellingError(txtData.CaretIndex);

            if (error != null)
            {
                foreach (var hint in error.Suggestions)
                {
                    spellingHints += $"{hint}";
                }

                lblSpellingHints.Content = spellingHints;
                expanderSpellings.IsExpanded = true;
            }
        }
        protected void MouseEnterExitArea(object sender, RoutedEventArgs args) => statBarText.Text = "Exit the Aplication";
        protected void MouseEnterToolsHintsArea(object sender, RoutedEventArgs args) => statBarText.Text = "Show Spelling Suggestions";
        protected void MouseLeaveArea(object sender, RoutedEventArgs args) => statBarText.Text = "Ready";
        private void OpenCmdCanExecuted(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute = true;
        private void SaveCmdCanExecuted(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute = true;

        private void OpenCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var openDlg = new OpenFileDialog { Filter = "Texr Files |*.txt" };
            if (true == openDlg.ShowDialog())
            {
                string dataFromFile = File.ReadAllText(openDlg.FileName);
                txtData.Text = dataFromFile;
            }
        }
        private void SaveCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var saveDlg = new OpenFileDialog { Filter = "Texr Files |*.txt" };
            if (true == saveDlg.ShowDialog())
            {
                File.WriteAllText(saveDlg.FileName, txtData.Text);
            }
        }

    }
}
