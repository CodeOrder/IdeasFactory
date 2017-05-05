using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;
using IdeasFactory.CorkBoardSys;

namespace IdeasFactory.IdeaSys
{
    public class CorkIdea
    {
        internal string color;
        internal string title;
        internal string content;
        internal string sign;
        internal string time;
        public CorkIdea(string[] cmd)           //内容 标题 签名 颜色
        {
            this.time = DateTime.Now.ToShortDateString();
            this.content = cmd[0];
            switch (cmd.Length)
            {
                case 2:
                    this.title = cmd[1];
                    break;
                case 3:
                    this.title = cmd[1];
                    this.sign = cmd[2];
                    break;
                case 4:
                    this.title = cmd[1];
                    this.sign = cmd[2];
                    this.color = cmd[3];
                    break;
            }
        }
    }

    public class CorkPICIdea
    {
        internal string picpath = null;
        internal string description = "";
        internal CorkPICIdea(string[] cmd)
        {
            this.picpath = cmd[0];
            if (cmd.Length == 2)
                this.description = cmd[1];
        }
    }

    public class CorkIdeaCtrlSys
    {
        internal static Dictionary<string, BoardNote> BoardNoteList = new Dictionary<string, BoardNote>();
        internal static Dictionary<string, BoardPicture> BoardPICList = new Dictionary<string, BoardPicture>();
        internal static Dictionary<string, BoardNote> SavingBoardNoteList = new Dictionary<string, BoardNote>();
        internal static Dictionary<string, BoardPicture> SavingBoardPICList = new Dictionary<string, BoardPicture>();

        /// <summary>
        /// 格式：控件的名称|控件的位置（Left,Top）|控件内嵌的笔记标题|空间内嵌的笔记内容
        /// </summary>
        internal static Dictionary<string, BoardNote> LoadCorkNotes(Grid parent)
        {
            Dictionary<string, BoardNote> result = new Dictionary<string, BoardNote>();
            string[] lines = FixedIO.GetAllLines(Environment.CurrentDirectory + "/Data/boardnote.dat");
            foreach (string line in lines)
            {
                BoardNote currentLog = new BoardNote(parent);
                string[] splits = line.Split('|');
                foreach (string gs in splits)
                currentLog.name = splits[0];

                string[] margin = splits[1].Split(',');                             //读取margin的值
                double ml, mt;
                Double.TryParse(margin[0], out ml);
                Double.TryParse(margin[1], out mt);

                Thickness loadmargin = new Thickness(ml,mt,0,0);
                currentLog.Margin = loadmargin;

                currentLog.titlebox.Text = splits[2];
                currentLog.ContentIdea.title = splits[2];
                currentLog.contentbox.Text = splits[3];
                currentLog.ContentIdea.content = splits[3];
                result.Add(splits[0],currentLog);               //注册到方法的返回中
            }
            return result;
        }

        /// <summary>
        /// 格式：控件的名称|控件的位置（Left,Top）|控件的图片（BitmapImage）|关于图片的描述
        /// </summary>
        internal static Dictionary<string, BoardPicture> LoadCorkPICNotes(Grid parent)
        {
            Dictionary<string, BoardPicture> result = new Dictionary<string, BoardPicture>();
            string[] lines = File.ReadAllLines(Environment.CurrentDirectory + "/Data/boardpicture.dat");
            foreach (string line in lines)
            {
                BoardPicture currentPIC = new BoardPicture(parent);
                string[] splits = line.Split('|');
                currentPIC.name = splits[0];

                string[] margins = splits[1].Split(',');
                double ml, mt;
                Double.TryParse(margins[0], out ml);
                Double.TryParse(margins[1], out mt);
                Thickness loadmargin = new Thickness(ml, mt,0,0);
                currentPIC.Margin = loadmargin;

                currentPIC.picture = new BitmapImage(new Uri(splits[2], UriKind.Absolute));
                currentPIC.imagebox.Background = new ImageBrush { ImageSource = currentPIC.picture };
                currentPIC.ContentIdea.description = splits[3];
                result.Add(splits[0], currentPIC);
            }
            return result;
        }

        /// <summary>
        /// 格式：控件的名称|控件的位置（Left,Top）|控件内嵌的笔记标题|空间内嵌的笔记内容
        /// 格式：控件的名称|控件的位置（Left,Top）|控件的图片（BitmapImage）|关于图片的描述
        /// </summary>
        internal static void UpdateSaveFile()                               //更新笔记的保存文件
        {
            StreamWriter writer = new StreamWriter(Environment.CurrentDirectory+"/Data/boardnote.dat");
            foreach (BoardNote note in SavingBoardNoteList.Values)
            {
                string line = null;
                line += note.name + "|";
                line += note.Margin.Left + "," + note.Margin.Top + "|";
                line += note.ContentIdea.title + "|";
                line += note.ContentIdea.content;
                writer.WriteLine(line);
            }
            writer.Close();
            writer.Dispose();

            writer = new StreamWriter(Environment.CurrentDirectory + "/Data/boardpicture.dat");
            foreach (BoardPicture note in SavingBoardPICList.Values)
            {
                string line = null;
                line += note.name + "|";
                line += note.Margin.Left + "," + note.Margin.Top +  "|";
                line += note.picture.UriSource + "|";
                line += note.ContentIdea.description;
                writer.WriteLine(line);
            }
            writer.Close();
            writer.Dispose();
        }
    }
}
