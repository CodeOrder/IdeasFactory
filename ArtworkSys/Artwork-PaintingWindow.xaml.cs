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
using System.IO;

namespace IdeasFactory.ArtworkSys
{
    /// <summary>
    /// Artwork_PaintingWindow.xaml 的交互逻辑
    /// </summary>
    /// Info文件格式：文件名：画作代码.jpg
    ///             标题
    ///             作者
    ///             年代（可选）
    ///             可选信息
    public partial class Artwork_PaintingWindow : Window
    {
        public Artwork_PaintingWindow()
        {
            Int32.TryParse(File.ReadAllLines(Environment.CurrentDirectory+"\\Library\\painting_count.ini")[0],out paintingcount);
            InitializeComponent();
            FileStream fs = new FileStream(Environment.CurrentDirectory + "\\Library\\" + currentID + ".jpg", FileMode.Open, FileAccess.Read);
            System.Drawing.Image image = System.Drawing.Image.FromStream(fs);
            this.Width = image.Width;
            this.Height = image.Height;
            ImageBrush brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Library\\" + currentID + ".jpg", UriKind.Absolute));
            this.WindowGrid.Background = brush;

            string info = null;
            foreach (string s in LoadInfo(currentID))
            {
                info += s;
                info += "   ";
            }
            this.InfoLabel.Content = info;
            this.TitleLabel.Content = info.Split(' ')[0];
        }

        private static int paintingcount = 0;
        private static int currentID = 1;
        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentID < paintingcount)
                currentID += 1;
            else
                currentID = 1;

            FileStream fs = new FileStream(Environment.CurrentDirectory + "\\Library\\" + currentID + ".jpg", FileMode.Open, FileAccess.Read);
            System.Drawing.Image image = System.Drawing.Image.FromStream(fs);
            this.Width = image.Width;
            this.Height = image.Height;
            ImageBrush brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Library\\" + currentID + ".jpg", UriKind.Absolute));
            this.WindowGrid.Background = brush;

            string info = null;
            foreach(string s in LoadInfo(currentID))
            {
                info += s;
                info += "   ";
            }
            this.InfoLabel.Content = info;
            this.TitleLabel.Content = info.Split(' ')[0];
        }

        private static string[] LoadInfo(int painting_num)
        {
            string[] info = File.ReadAllLines(Environment.CurrentDirectory + "\\Library\\" + painting_num + ".dat",Encoding.Default);
            return info;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
