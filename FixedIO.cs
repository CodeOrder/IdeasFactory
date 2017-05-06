using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace IdeasFactory
{
    public class FixedIO
    {
        public static string[] GetAllLines(string path)
        {
            FileStream file = new FileStream(path, FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(file,Encoding.UTF8);
            List<string> lines = new List<string>();
            string line = reader.ReadLine();
            while (line != null)
            {
                lines.Add(line);
                line = reader.ReadLine();
            }
            reader.Close();
            reader.Dispose();
            return lines.ToArray();
        }
    }
}
