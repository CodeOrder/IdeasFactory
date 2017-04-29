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
            BoardNote boardnote = new BoardNote(this.PanelGrid);
            //boardnote.Name = (string)boardnote.name;
            boardnote.Name = "Duang";
            boardnote.Margin = new Thickness(e.GetPosition(null).X,
                                             e.GetPosition(null).Y,0,0);            //移动到鼠标单击的位置
            this.PanelGrid.Children.Add(boardnote);
            IdeaSys.CorkIdeaCtrlSys.BoardNoteList.Add(boardnote.name, boardnote);
        }
    }
}
