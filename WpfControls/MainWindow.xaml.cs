using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.IO;
using System.Windows.Ink;

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

        private void SaveData(object sender, RoutedEventArgs e)
        {
            using (FileStream fs = new FileStream("StrokeData.bin", FileMode.Create))
            {
                this.MyInkCanvas.Strokes.Save(fs);
                fs.Close();
                MessageBox.Show("Image Saved", "Saved");
            }
        }

        private void ClearData(object sender, RoutedEventArgs e)
        {
            using (FileStream fs = new FileStream("StrokeData.bin", FileMode.Open, FileAccess.Read))
            {
                StrokeCollection strokes = new StrokeCollection(fs);
                this.MyInkCanvas.Strokes = strokes;
            }
        }

        private void LoadData(object sender, RoutedEventArgs e)
        {
            this.MyInkCanvas.Strokes.Clear();
        }
    }
}
