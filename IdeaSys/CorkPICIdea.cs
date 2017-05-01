using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdeasFactory.IdeaSys
{
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
}
