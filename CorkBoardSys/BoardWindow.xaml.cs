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
using IdeasFactory.IdeaSys;
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
            this.Closing += BoardWindow_Closing;
        }

        void BoardWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CorkIdeaCtrlSys.UpdateSaveFile();
            MessageBox.Show("在保存链表中的所有笔记（文字和图片）都已保存");
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
                boardnote.Margin = new Thickness(e.GetPosition(null).X,
                                                 e.GetPosition(null).Y, 0, 0);            //移动到鼠标单击的位置
                this.PanelGrid.Children.Add(boardnote);
                CorkIdeaCtrlSys.BoardNoteList.Add(boardnote.name, boardnote);
            }
            else if (status == 1)
            {
                BoardPicture boardpic = new BoardPicture(this.PanelGrid);
                boardpic.Margin = new Thickness(e.GetPosition(null).X,
                                                 e.GetPosition(null).Y, 0, 0);            //移动到鼠标单击的位置
                this.PanelGrid.Children.Add(boardpic);
                CorkIdeaCtrlSys.BoardPICList.Add(boardpic.name, boardpic);
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

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            CorkIdeaCtrlSys.BoardNoteList = new Dictionary<string, BoardNote>();
            CorkIdeaCtrlSys.BoardNoteList = CorkIdeaCtrlSys.LoadCorkNotes(this.PanelGrid);
            CorkIdeaCtrlSys.SavingBoardNoteList = CorkIdeaCtrlSys.BoardNoteList;            //同时也覆盖到要保存的链表中
            foreach (BoardNote note in CorkIdeaCtrlSys.BoardNoteList.Values)
                this.PanelGrid.Children.Add(note);                  //添加到窗口中

            CorkIdeaCtrlSys.BoardPICList = new Dictionary<string, BoardPicture>();
            CorkIdeaCtrlSys.BoardPICList = CorkIdeaCtrlSys.LoadCorkPICNotes(this.PanelGrid);
            CorkIdeaCtrlSys.SavingBoardPICList = CorkIdeaCtrlSys.BoardPICList;
            foreach (BoardPicture note in CorkIdeaCtrlSys.BoardPICList.Values)
                this.PanelGrid.Children.Add(note);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
