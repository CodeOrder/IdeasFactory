using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdeasFactory.ArtworkSys
{
    abstract class Artwork
    {
        internal string name;
        internal string time;
    }

    class Painting : Artwork
    {
        internal string painter;
        public Painting(string[] args)
        {
            if (args.Length == 3)           //args的第一项为（无用的）路径
                this.time = args[2];
            this.name = args[0];
            this.painter = args[1];
        }
    }

    class Music : Artwork
    {
        internal string musician;
        internal string album;
        internal string style;
        public Music(string[] args)         //格式：标题，音乐家，专辑，风格，后两项可选
        {
            switch (args.Length)
            {
                case 3:
                    this.album = args[2];
                    break;
                case 4:
                    this.album = args[2];
                    this.style = args[4];
                    break;
            }
            this.name = args[0];
            this.musician = args[1];
        }
    }
}
