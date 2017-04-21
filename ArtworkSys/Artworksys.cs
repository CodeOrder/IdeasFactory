using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace IdeasFactory.ArtworkSys
{
    static class Artworksys
    {
        //painting_info格式：标题，作者，时间（可选）

        internal static Painting CurrentPainting;
        internal static Music CurrentMusic;
        internal static int CurrentPaintingNO = 0;
        internal static int CurrentMusicNO = 0;
        internal static string libpath = File.ReadAllLines("Data\\libpath.dat", Encoding.Default)[0];
        internal static string[] PaintingInfo = File.ReadAllLines("Data\\paintings.dat");
        internal static string[] MusicInfo = File.ReadAllLines("Data\\music.dat");

        static int painting_count = PaintingInfo.Length;
        static int music_count = MusicInfo.Length;
        internal static void GetNext(string type)               //获取下一个画作，保存在CurrentPainting
        {
            switch (type.ToCharArray()[0])
            {
                case 'p':
                    if (CurrentPaintingNO < painting_count)
                        CurrentPaintingNO += 1;
                    else
                        CurrentPaintingNO = 0;

                    string[] info = new string[PaintingInfo[CurrentPaintingNO - 1].Split(',').Length];
                    for (int i = 0; i < info.Length; i++)
                        info[i] = PaintingInfo[CurrentPaintingNO - 1].Split(',')[i];
                    CurrentPainting = new Painting(info);
                    break;
            }
        }
    }
}
