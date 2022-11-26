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

namespace WpfControls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.MyInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
            this.inkRadio.IsChecked = true;
            this.comboColors.SelectedIndex = 0;
        }

        private void RadioButtonClicked(object sender, RoutedEventArgs e)
        {
            this.MyInkCanvas.EditingMode = (sender as RadioButton)?.Content.ToString() switch
            {
                "Ink Mode!" => InkCanvasEditingMode.Ink,
                "Erase Mode!" => InkCanvasEditingMode.EraseByStroke,
                "Select Mode!" => InkCanvasEditingMode.Select,
                _ => this.MyInkCanvas.EditingMode,
            };
        }

        private void ColorChangen(object sender, SelectionChangedEventArgs e)
        {
            string colorToUse = (this.comboColors.SelectedItem as StackPanel).Tag.ToString();
            this.MyInkCanvas.DefaultDrawingAttributes.Color = (Color)ColorConverter.ConvertFromString(colorToUse);
        }
    }
}
