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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int gameFlag = 0;
        public static Board board = new Board();
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Game1 child = new Game1();
            child.Owner = this;
            child.Show();
            gameFlag = 1;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            
            board.Owner = this;
            board.Show();
        }
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            base.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Game2 child = new Game2();
            child.Owner = this;
            child.Show();
            gameFlag = 2;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Game3 child = new Game3();
            child.Owner = this;
            child.Show();
            gameFlag = 3;
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.Show();
        }
    }
}
