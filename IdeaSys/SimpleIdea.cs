using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace IdeasFactory.IdeaSys
{
    class SimpleIdea                                                                         //Used to contain a "simple" idea
    {                                                                                        //has a title, three parts and an addtime string
        internal string title;
        internal string[] content = new string[3];
        internal string addtime;
        public SimpleIdea(string _title, string[] _content)
        {
            this.title = _title;
            this.content = _content;
            this.addtime = DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss");
        }
        internal SimpleIdea(string[] _content)
        {
            this.title = "IF_result" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + "_untitled_idea";
            this.content = _content;
            this.addtime = DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss");
        }

        internal static SimpleIdea LoadSimpleIdea(string filename)
        {
            string[] contents = File.ReadAllLines(filename, Encoding.Default)[0].Split(' ');
            return new SimpleIdea(filename, contents);
        }
        internal static void SaveSimpleIdea(SimpleIdea idea)
        {
            StreamWriter writer = new StreamWriter(idea.title + ".ida");
            for (int i = 0; i < idea.content.Length; i++)
                writer.Write(idea.content[i] + " ");
            writer.Close();
            writer.Dispose();
        }
    }
}
