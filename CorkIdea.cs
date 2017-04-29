using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

    public class CorkIdeaCtrlSys
    {
        internal static Dictionary<string, BoardNote> BoardNoteList = new Dictionary<string, BoardNote>();

    }
}
