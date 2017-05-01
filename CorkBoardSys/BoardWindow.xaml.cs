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
using System.Diagnostics;
namespace IdeasFactory.CorkBoardSys
{
    /// <summary>
    /// BoardWindow.xaml 的交互逻辑
    /// </summary>
    public partial class BoardWindow : Window
    {
        int status = 0;
        public BoardWindow()
        {
            InitializeComponent();
        }

        private void MouseLeftButton_Down(object sender, MouseButtonEventArgs e)
        {
            if(e.GetPosition(this).Y < this.Width * 0.05)
            this.DragMove();
        }

        private void MouseRightButton_Down(object sender, MouseButtonEventArgs e)
        {
            if (status == 0)
            {
                BoardNote boardnote = new BoardNote(this.PanelGrid);
                //boardnote.Name = (string)boardnote.name;
                //boardnote.Name = "Duang";
                boardnote.Margin = new Thickness(e.GetPosition(null).X,
                                                 e.GetPosition(null).Y, 0, 0);            //移动到鼠标单击的位置
                this.PanelGrid.Children.Add(boardnote);
                //IdeaSys.CorkIdeaCtrlSys.BoardNoteList.Add(boardnote.name, boardnote);
            }
            else if (status == 1)
            {
                BoardPicture boardpic = new BoardPicture(this.PanelGrid);
                //boardnote.Name = (string)boardnote.name;
                //boardnote.Name = "Duang";
                boardpic.Margin = new Thickness(e.GetPosition(null).X,
                                                 e.GetPosition(null).Y, 0, 0);            //移动到鼠标单击的位置
                this.PanelGrid.Children.Add(boardpic);
            }
        }

        private void ChooseTextButton_Click(object sender, RoutedEventArgs e)
        {
            this.ChooseTextButton.IsEnabled = false;
            this.ChoosePICButton.IsEnabled = true;
            this.status = 0;
            this.Background = new SolidColorBrush { Color = Color.FromRgb(255, 255, 255) };
        }

        private void ChoosePICButton_Click(object sender, RoutedEventArgs e)
        {
            this.ChoosePICButton.IsEnabled = false;
            this.ChooseTextButton.IsEnabled = true;
            this.status = 1;
            this.Background = new SolidColorBrush { Color = Color.FromRgb(100, 100, 100) };
        }
    }
}
