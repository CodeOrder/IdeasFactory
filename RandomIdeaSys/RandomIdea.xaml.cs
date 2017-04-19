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

namespace IdeasFactory.RandomIdeaSys
{
    /// <summary>
    /// RandomIdea.xaml 的交互逻辑
    /// </summary>
    public partial class RandomIdea : Window
    {
        static IdeaSys.SimpleIdea current_idea = null;
        public RandomIdea()
        {
            current_idea = new IdeaSys.SimpleIdea(new string[] { "主语", "没看见", "谓语" });
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            int mode = this.ModeSetting.SelectedIndex + 1;
            if (mode == 1)                                          //who where what mode
            {
                string[] subjects = File.ReadAllLines("Dictionary\\subject.ini", Encoding.Default);
                string[] preps = File.ReadAllLines("Dictionary\\preposition.ini", Encoding.Default);
                string[] predicates = File.ReadAllLines("Dictionary\\predicate.ini", Encoding.Default);

                Random subram = new Random();
                Random prepram = new Random();
                Random predram = new Random();
                this.FirstBlock.Text = subjects[subram.Next(0, subjects.Length - 1)];
                this.SecondBlock.Text = preps[prepram.Next(0, preps.Length - 1)];
                this.ThirdBlock.Text = predicates[predram.Next(0, predicates.Length - 1)];
            }
            else
            {
                string[] subjects = File.ReadAllLines("Dictionary\\subject.ini", Encoding.Default);
                string[] verbs = File.ReadAllLines("Dictionary\\targetverb.ini", Encoding.Default);

                Random subram = new Random();
                Random vebram = new Random();
                this.FirstBlock.Text = subjects[subram.Next(0, subjects.Length - 1)];
                this.SecondBlock.Text = verbs[vebram.Next(0, verbs.Length - 1)];
                this.ThirdBlock.Text = subjects[subram.Next(0, subjects.Length - 1)];
            }
            current_idea = new IdeaSys.SimpleIdea(new string[] { this.FirstBlock.Text, this.SecondBlock.Text, this.ThirdBlock.Text });
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            IdeaSys.IOsys.SaveSimpleIdea(current_idea);
            MessageBox.Show("文件已经保存到根目录下的IF_result_" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".ida");
        }
    }
}
