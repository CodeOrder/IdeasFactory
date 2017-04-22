using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IdeasFactory.ArtworkSys
{
    /// <summary>
    /// ArtworkMainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ArtworkMainWindow : Window
    {
        public ArtworkMainWindow()
        {
            this.WindowStyle = WindowStyle.None;
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PaintingButton_Click(object sender, RoutedEventArgs e)
        {
            Artwork_PaintingWindow painting = new Artwork_PaintingWindow();
            painting.Show();
        }
    }
}
