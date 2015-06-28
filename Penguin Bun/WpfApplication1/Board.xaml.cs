using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Board.xaml 的互動邏輯
    /// </summary>
    public partial class Board : Window
    {
        public Board()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            base.Close();
        }
       private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            base.Close();
        }
        /*
        internal void TextBox_TextChanged(string s)
        {
            player.Text = s;
        }

        private void player_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        */
        public void set1(String name , int score){
            name1.Content = name;
            score1.Content = score;
        }
        public void set2(String name, int score)
        {
            name2.Content = name;
            score2.Content = score;
        }
        public void set3(String name, int score)
        {
            name3.Content = name;
            score3.Content = score;
        }
    }
}
