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
    /// Name.xaml 的互動邏輯
    /// </summary>
    public partial class Name1 : Window
    {
    //    public Board mainWin = new Board();

        public static String highScoreNameGame1;
        public static String highScoreNameGame2;
        public static String highScoreNameGame3;
        public static int highScoreGame1 = 0;
        public static int highScoreGame2 = 0;
        public static int highScoreGame3 = 0;
       // Board b;
        public Name1()
        {
            InitializeComponent();
         //   b = new Board();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            base.Close();
        }

        internal void player_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (MainWindow.gameFlag == 1) { 
                highScoreNameGame1 = String.Copy(player.Text);
                MainWindow.board.set1(highScoreNameGame1, highScoreGame1);
            }
            if (MainWindow.gameFlag == 2) { 
                highScoreNameGame2 = String.Copy(player.Text);
                MainWindow.board.set2(highScoreNameGame2, highScoreGame2);
            }
            if (MainWindow.gameFlag == 3) { 
                highScoreNameGame3 = String.Copy(player.Text);
                MainWindow.board.set3(highScoreNameGame3, highScoreGame3);
            }
           //  if (mainWin != null)
             //   mainWin.TextBox_TextChanged(player.Text);
        }       
    }
}
