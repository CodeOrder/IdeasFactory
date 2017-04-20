using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Diagnostics;
using System.Timers;

namespace IdeasFactory.RandomIdeaSys
{
    /// <summary>
    /// RandomIdea.xaml 的交互逻辑
    /// </summary>
    public partial class RandomIdea : Window
    {
        static IdeaSys.SimpleIdea current_idea = null;
        string[] subjects = File.ReadAllLines("Dictionary\\subject.ini", Encoding.Default);
        string[] preps = File.ReadAllLines("Dictionary\\preposition.ini", Encoding.Default);
        string[] predicates = File.ReadAllLines("Dictionary\\predicate.ini", Encoding.Default);
        string[] verbs = File.ReadAllLines("Dictionary\\targetverb.ini", Encoding.Default);
        string[] funcs = File.ReadAllLines("Dictionary\\function.ini", Encoding.Default);

        System.Timers.Timer TigerAnimationTimer = new System.Timers.Timer();

        public RandomIdea()
        {
            current_idea = new IdeaSys.SimpleIdea(new string[] { "主语", "没看见", "谓语" });
            TigerAnimationTimer.Elapsed += new ElapsedEventHandler(TigerAnimation);
            TigerAnimationTimer.Interval = 50;
            TigerAnimationTimer.Enabled = false;

            InitializeComponent();
        }

        int FinishedValue = 0;
        private void TigerAnimation(object sender, EventArgs e)
        {
            this.Dispatcher.Invoke(new Action(delegate
            {
                FinishedValue += 1;
                if (FinishedValue < 10)
                {
                    this.FirstBlock.Text = subjects[FinishedValue % subjects.Length];
                    this.SecondBlock.Text = preps[FinishedValue % preps.Length];
                    this.ThirdBlock.Text = predicates[FinishedValue % predicates.Length];
                }
                else
                {
                    TigerAnimationTimer.Enabled = false;
                    FinishedValue = 0;
                    MakeRandom();
                }
            }));
        }

        private void MakeRandom()
        {
            int mode = this.ModeSetting.SelectedIndex + 1;
            if (mode == 1)                                          //主谓+地点
            {
                Random subram = new Random();
                Random prepram = new Random();
                Random predram = new Random();
                this.FirstBlock.Text = subjects[subram.Next(0, subjects.Length - 1)];
                this.SecondBlock.Text = preps[prepram.Next(0, preps.Length - 1)];
                this.ThirdBlock.Text = predicates[predram.Next(0, predicates.Length - 1)];
            }
            else if(mode ==2 )                                      //及物动词
            {
                Random subram = new Random();
                Random vebram = new Random();
                this.FirstBlock.Text = subjects[subram.Next(0, subjects.Length - 1)];
                this.SecondBlock.Text = verbs[vebram.Next(0, verbs.Length - 1)];
                this.ThirdBlock.Text = subjects[subram.Next(0, subjects.Length - 1)];
            }
            else if (mode == 3)
            {
                Random funcram = new Random();
                this.FirstBlock.Text = "一个能";
                this.SecondBlock.Text = funcs[funcram.Next(0, funcs.Length - 1)];
                this.ThirdBlock.Text = "的程序";
            }
            current_idea = new IdeaSys.SimpleIdea(new string[] { this.FirstBlock.Text, this.SecondBlock.Text, this.ThirdBlock.Text });
       
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            TigerAnimationTimer.Enabled = true;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            IdeaSys.IOsys.SaveSimpleIdea(current_idea);
            MessageBox.Show("文件已经保存到根目录下的IF_result_" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".ida");
        }
    }
}
