using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace IdeasFactory.IdeaSys
{
    static class IOsys
    {
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
