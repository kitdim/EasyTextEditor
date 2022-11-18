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
    }
}
