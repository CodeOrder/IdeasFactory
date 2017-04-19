using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
