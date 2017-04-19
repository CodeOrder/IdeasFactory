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

namespace IdeasFactory
{
    /// <summary>
    /// AboutusWindow.xaml 的交互逻辑
    /// </summary>
    public partial class AboutusWindow : Window
    {
        public AboutusWindow()
        {
            InitializeComponent();
            this.AboutBlock.Text += "\n\n\n计算机并不能真正有自己的点子，但它能以绝佳的方式激励人们去创造新的可能";
        }
    }
}
