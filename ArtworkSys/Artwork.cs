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
        public Painting(string _name, string _painter)
        {
            this.name = _name;
            this.painter = _painter;
        }
        public Painting(string _name, string _painter, string _time)
        {
            this.name = _name;
            this.painter = _painter;
            this.time = _time;
        }
    }
}
