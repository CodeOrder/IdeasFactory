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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;

namespace IdeasFactory
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            System.Timers.Timer BulbUpdateTimer = new System.Timers.Timer();
            BulbUpdateTimer.Elapsed += new ElapsedEventHandler(Update);
            BulbUpdateTimer.Interval = 50;
            BulbUpdateTimer.Enabled = true;
        }
        private void RandomButton_Click(object sender, RoutedEventArgs e)
        {
            IdeasFactory.RandomIdeaSys.RandomIdea ranwin = new RandomIdeaSys.RandomIdea();
            ranwin.Show();
        }

        Thickness mov;
        int mode = 0, spdmode = 0;
        double speed = 1.0;
        private void Update(object sender, EventArgs e)
        {
            this.Dispatcher.Invoke(new Action(delegate
            {
                if (speed >= 10)
                    spdmode = 1;
                if (speed <= 1)
                    spdmode = 0;
                if (spdmode == 1)
                    speed -= 1;
                if (spdmode == 0)
                    speed += 1;

                mov = this.BulbImage.Margin;
                if (mode == 0)
                    mov.Left -= speed;
                if (mode == 1)
                    mov.Left += speed;
                if (mov.Left <= 221)
                    mode = 1;
                if (mov.Left >= 454)
                    mode = 0;
                this.BulbImage.Margin = mov;
            }));
        }

        private void BulbImage_Click(object sender, RoutedEventArgs e)
        {
            AboutusWindow about = new AboutusWindow();
            about.Show();
        }
    }
}
