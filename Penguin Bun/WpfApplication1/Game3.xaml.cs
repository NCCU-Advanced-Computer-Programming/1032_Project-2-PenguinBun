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
using System.Windows.Threading;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Media.Animation;


namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Game3 : Window
    {
        internal DispatcherTimer scoreTimer;

        int scoreTimeCounter = 0, gameTimeCounter = 0;
        int level = 1;
        bool gameover = false;
        Thickness TheBun, fence1, fence2, fence3;
        Thickness Block1, Block2, Block3, Block4, Block5;
        ImageBrush myBrush1 = new ImageBrush();
        ImageBrush myBrush2 = new ImageBrush();
        ImageBrush myBrush3 = new ImageBrush();
        ImageBrush myBrush4 = new ImageBrush();
        ImageBrush myBrush5 = new ImageBrush();
        Random random = new Random();
        Storyboard playMoveUp = new Storyboard();
        Storyboard playMoveDown = new Storyboard();
        Storyboard playMovefence1 = new Storyboard();
        Storyboard playMovefence2 = new Storyboard();
        Storyboard playMovefence3 = new Storyboard();

        Storyboard playMoveBlock1 = new Storyboard();
        Storyboard playMoveBlock2 = new Storyboard();
        Storyboard playMoveBlock3 = new Storyboard();
        Storyboard playMoveBlock4 = new Storyboard();
        Storyboard playMoveBlock5 = new Storyboard();
        Storyboard playMoveBlock6 = new Storyboard();
        Storyboard playMoveBlock7 = new Storyboard();
        Storyboard playMoveBlock8 = new Storyboard();
        Storyboard playMoveBlock9 = new Storyboard();
        Storyboard playMoveBlock10 = new Storyboard();
        Storyboard playMoveBlock11 = new Storyboard();
        Storyboard playMoveBlock12 = new Storyboard();
        Storyboard playMoveBlock13 = new Storyboard();
        Storyboard playMoveBlock14 = new Storyboard();
        Storyboard playMoveBlock15 = new Storyboard();
        
     

        public Game3()
        {
            InitializeComponent();
            scoreTimer = new DispatcherTimer();
            scoreTimer.Interval = TimeSpan.FromSeconds(1.0);
            scoreTimer.Tick += new EventHandler(Timer_Tick);
            fence1 = lbl1.Margin;
            fence2 = lbl2.Margin;
            fence3 = lbl3.Margin;
            TheBun = Bun.Margin;
            Block1 = block1.Margin;
            Block2 = block2.Margin;
            Block3 = block3.Margin;
            Block4 = block4.Margin;
            Block5 = block5.Margin;
            lbl1.Background = myBrush1;
            lbl2.Background = myBrush1;
            lbl3.Background = myBrush1;
            block1.Background = myBrush2;
            block2.Background = myBrush2;
            block3.Background = myBrush2;
            block4.Background = myBrush2;
            block5.Background = myBrush2;
            block6.Background = myBrush3;
            block7.Background = myBrush3;
            block8.Background = myBrush3;
            block9.Background = myBrush3;
            block10.Background = myBrush3;
            block11.Background = myBrush4;
            block12.Background = myBrush4;
            block13.Background = myBrush4;
            block14.Background = myBrush4;
            block15.Background = myBrush4;


            myBrush1.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images3/柵欄.png"));
            myBrush2.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images3/Rock.png"));
            myBrush3.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images3/Rabbit.png"));
            myBrush4.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images3/Monkey.png"));



        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!gameover)
            {
                scoreTimeCounter++;
                lblScore.Content = "Score:" + scoreTimeCounter.ToString("000");
                lblA.Content = "Level:" + level.ToString("0");


                if (scoreTimeCounter % 10 == 0 && level < 10)
                { level++; }

                gameTimeCounter++;
                if (gameTimeCounter % 6 == 1)
                {
                    getfence();
                    AnimateMoveLeft1();
                }
                else if (gameTimeCounter % 6 == 3)
                {
                    getfence2();
                    AnimateMoveLeft2();
                }
                else if (gameTimeCounter % 6 == 5)
                {
                    getfence3();
                    AnimateMoveLeft3();
                }

                if (level == 1)
                {
                    if (gameTimeCounter % 3 == 0)
                    {
                        getquestion1(3);
                    }

                }

                if (level == 2)
                {
                    if (gameTimeCounter % 3 == 0)
                    {
                        getquestion4();
                    }
                }

                if (level == 3)
                {
                    if (gameTimeCounter % 4 == 1)
                    {
                        getquestion1(3);
                    }

                    if (gameTimeCounter % 4 == 3)
                    {
                        getquestion2(4);
                    }
                }

                if (level == 4)
                {
                    if (gameTimeCounter % 4 == 1)
                    {
                        getquestion1(2);
                    }

                    if (gameTimeCounter % 4 == 3)
                    {
                        getquestion5();
                    }
                }

                if (level == 5)
                {
                    if (gameTimeCounter % 4 == 1)
                    {
                        getquestion5();
                    }

                    if (gameTimeCounter % 4 == 3)
                    {
                        getquestion4();
                    }
                }

                if (level == 6)
                {
                    if (gameTimeCounter % 3 == 1)
                    {
                        getquestion1(4);
                    }

                    if (gameTimeCounter % 3 == 2)
                    {
                        getquestion2(4);
                    }

                    if (gameTimeCounter % 3 == 0)
                    {
                        getquestion3(4);
                    }
                }

                if (level == 7)
                {
                    if (gameTimeCounter % 3 == 1)
                    {
                        getquestion1(4);
                    }

                    if (gameTimeCounter % 3 == 2)
                    {
                        getquestion5();
                    }

                    if (gameTimeCounter % 3 == 0)
                    {
                        getquestion3(4);
                    }
                }

                if (level == 8)
                {
                    if (gameTimeCounter % 3 == 1)
                    {
                        getquestion4();
                    }

                    if (gameTimeCounter % 3 == 2)
                    {
                        getquestion2(4);
                    }

                    if (gameTimeCounter % 3 == 0)
                    {
                        getquestion6();
                    }
                }

                if (level == 9)
                {
                    if (gameTimeCounter % 3 == 1)
                    {
                        getquestion4();
                    }

                    if (gameTimeCounter % 3 == 2)
                    {
                        getquestion5();
                    }

                    if (gameTimeCounter % 3 == 0)
                    {
                        getquestion6();
                    }
                }





                if (block1.Margin.Left < -500 && block1.Margin.Left > -600 && Bun.Margin.Top < -54)
                {
                    Lose();
                }

                if (block2.Margin.Left < -500 && block2.Margin.Left > -600 && Bun.Margin.Top > -54 && Bun.Margin.Top < -18)
                {
                    Lose();
                }

                if (block3.Margin.Left < -500 && block3.Margin.Left > -600 && Bun.Margin.Top > -18 && Bun.Margin.Top < 18)
                {
                    Lose();
                }

                if (block4.Margin.Left < -500 && block4.Margin.Left > -600 && Bun.Margin.Top > 18 && Bun.Margin.Top < 54)
                {
                    Lose();
                }

                if (block5.Margin.Left < -500 && block5.Margin.Left > -600 && Bun.Margin.Top > 54)
                {
                    Lose();
                }

                if (block6.Margin.Left < -500 && block6.Margin.Left > -600 && Bun.Margin.Top < -54)
                {
                    Lose();
                }

                if (block7.Margin.Left < -500 && block7.Margin.Left > -600 && Bun.Margin.Top > -54 && Bun.Margin.Top < -18)
                {
                    Lose();
                }

                if (block8.Margin.Left < -500 && block8.Margin.Left > -600 && Bun.Margin.Top > -18 && Bun.Margin.Top < 18)
                {
                    Lose();
                }

                if (block9.Margin.Left < -500 && block9.Margin.Left > -600 && Bun.Margin.Top > 18 && Bun.Margin.Top < 54)
                {
                    Lose();
                }

                if (block10.Margin.Left < -500 && block10.Margin.Left > -600 && Bun.Margin.Top > 54)
                {
                    Lose();
                }

                if (block11.Margin.Left < -500 && block11.Margin.Left > -600 && Bun.Margin.Top < -54)
                {
                    Lose();
                }

                if (block12.Margin.Left < -500 && block12.Margin.Left > -600 && Bun.Margin.Top > -54 && Bun.Margin.Top < -18)
                {
                    Lose();
                }

                if (block13.Margin.Left < -500 && block13.Margin.Left > -600 && Bun.Margin.Top > -18 && Bun.Margin.Top < 18)
                {
                    Lose();
                }

                if (block14.Margin.Left < -500 && block14.Margin.Left > -600 && Bun.Margin.Top > 18 && Bun.Margin.Top < 54)
                {
                    Lose();
                }

                if (block15.Margin.Left < -500 && block15.Margin.Left > -600 && Bun.Margin.Top > 54)
                {
                    Lose();
                }

            }
        }

        void AnimateMoveUp()
        {
            ThicknessAnimation moveUp = new ThicknessAnimation();
            moveUp.From = Bun.Margin;
            moveUp.To = new Thickness(TheBun.Left, TheBun.Top - 90,
                TheBun.Right, TheBun.Bottom + 90);
            moveUp.Duration = new Duration(TimeSpan.FromSeconds(-((TheBun.Top - 90) - Bun.Margin.Top) / 180));
            Storyboard.SetTargetName(moveUp, "Bun");
            Storyboard.SetTargetProperty(moveUp, new PropertyPath(Canvas.MarginProperty));
            playMoveUp.Children.Add(moveUp);
            playMoveUp.Begin(this, true);



        }
        void AnimateMoveDown()
        {
            ThicknessAnimation moveDown = new ThicknessAnimation();
            moveDown.From = Bun.Margin;
            moveDown.To = new Thickness(TheBun.Left, TheBun.Top + 90,
                TheBun.Right, TheBun.Bottom - 90);
            moveDown.Duration = new Duration(TimeSpan.FromSeconds(((TheBun.Top + 90) - Bun.Margin.Top) / 180));
            Storyboard.SetTargetName(moveDown, "Bun");
            Storyboard.SetTargetProperty(moveDown, new PropertyPath(Canvas.MarginProperty));
            playMoveDown.Children.Add(moveDown);
            playMoveDown.Begin(this, true);
        }
        void AnimateMoveLeft1()
        {
            ThicknessAnimation moveUpleft = new ThicknessAnimation();
            moveUpleft.From = fence1;
            moveUpleft.To = new Thickness(-2000, lbl1.Margin.Top,
                -2000, lbl1.Margin.Bottom);

            moveUpleft.Duration = new Duration(TimeSpan.FromSeconds(8));

            Storyboard.SetTargetName(moveUpleft, "lbl1");
            Storyboard.SetTargetProperty(moveUpleft, new PropertyPath(Canvas.MarginProperty));
            playMovefence1.Children.Add(moveUpleft);
            playMovefence1.Begin(this, true);

        }
        void AnimateMoveLeft2()
        {
            ThicknessAnimation moveUpleft2 = new ThicknessAnimation();
            moveUpleft2.From = fence2;
            moveUpleft2.To = new Thickness(-2000, lbl2.Margin.Top,
                -2000, lbl2.Margin.Bottom);
            moveUpleft2.Duration = new Duration(TimeSpan.FromSeconds(8));
            Storyboard.SetTargetName(moveUpleft2, "lbl2");
            Storyboard.SetTargetProperty(moveUpleft2, new PropertyPath(Canvas.MarginProperty));
            playMovefence2.Children.Add(moveUpleft2);
            playMovefence2.Begin(this, true);
        }
        void AnimateMoveLeft3()
        {
            ThicknessAnimation moveUpleft3 = new ThicknessAnimation();
            moveUpleft3.From = fence3;
            moveUpleft3.To = new Thickness(-2000, lbl3.Margin.Top,
                -2000, lbl3.Margin.Bottom);
            moveUpleft3.Duration = new Duration(TimeSpan.FromSeconds(8));
            Storyboard.SetTargetName(moveUpleft3, "lbl3");
            Storyboard.SetTargetProperty(moveUpleft3, new PropertyPath(Canvas.MarginProperty));
            playMovefence3.Children.Add(moveUpleft3);
            playMovefence3.Begin(this, true);
        }
        void AnimateMoveLeft4()
        {
            ThicknessAnimation moveUpleft4 = new ThicknessAnimation();
            moveUpleft4.From = Block1;
            moveUpleft4.To = new Thickness(-2000, block1.Margin.Top,
                +2000, block1.Margin.Bottom);
            moveUpleft4.Duration = new Duration(TimeSpan.FromSeconds(8));
            Storyboard.SetTargetName(moveUpleft4, "block1");
            Storyboard.SetTargetProperty(moveUpleft4, new PropertyPath(Canvas.MarginProperty));
            playMoveBlock1.Children.Add(moveUpleft4);
            playMoveBlock1.Begin(this, true);

        }
        void AnimateMoveLeft5()
        {
            ThicknessAnimation moveUpleft5 = new ThicknessAnimation();
            moveUpleft5.From = Block2;
            moveUpleft5.To = new Thickness(-2000, block2.Margin.Top,
                +2000, block2.Margin.Bottom);
            moveUpleft5.Duration = new Duration(TimeSpan.FromSeconds(8));
            Storyboard.SetTargetName(moveUpleft5, "block2");
            Storyboard.SetTargetProperty(moveUpleft5, new PropertyPath(Canvas.MarginProperty));
            playMoveBlock2.Children.Add(moveUpleft5);
            playMoveBlock2.Begin(this, true);

        }
        void AnimateMoveLeft6()
        {
            ThicknessAnimation moveUpleft6 = new ThicknessAnimation();
            moveUpleft6.From = Block3;
            moveUpleft6.To = new Thickness(-2000, block3.Margin.Top,
                +2000, block3.Margin.Bottom);
            moveUpleft6.Duration = new Duration(TimeSpan.FromSeconds(8));
            Storyboard.SetTargetName(moveUpleft6, "block3");
            Storyboard.SetTargetProperty(moveUpleft6, new PropertyPath(Canvas.MarginProperty));
            playMoveBlock3.Children.Add(moveUpleft6);
            playMoveBlock3.Begin(this, true);
        }
        void AnimateMoveLeft7()
        {
            ThicknessAnimation moveUpleft7 = new ThicknessAnimation();
            moveUpleft7.From = Block4;
            moveUpleft7.To = new Thickness(-2000, block4.Margin.Top,
                +2000, block4.Margin.Bottom);
            moveUpleft7.Duration = new Duration(TimeSpan.FromSeconds(8));
            Storyboard.SetTargetName(moveUpleft7, "block4");
            Storyboard.SetTargetProperty(moveUpleft7, new PropertyPath(Canvas.MarginProperty));
            playMoveBlock4.Children.Add(moveUpleft7);
            playMoveBlock4.Begin(this, true);
        }
        void AnimateMoveLeft8()
        {
            ThicknessAnimation moveUpleft8 = new ThicknessAnimation();
            moveUpleft8.From = Block5;
            moveUpleft8.To = new Thickness(-2000, block5.Margin.Top,
                +2000, block5.Margin.Bottom);
            moveUpleft8.Duration = new Duration(TimeSpan.FromSeconds(8));
            Storyboard.SetTargetName(moveUpleft8, "block5");
            Storyboard.SetTargetProperty(moveUpleft8, new PropertyPath(Canvas.MarginProperty));
            playMoveBlock5.Children.Add(moveUpleft8);
            playMoveBlock5.Begin(this, true);
        }
        void AnimateMoveLeft9()
        {
            ThicknessAnimation moveUpleft4 = new ThicknessAnimation();
            moveUpleft4.From = Block1;
            moveUpleft4.To = new Thickness(-2000, block1.Margin.Top,
                +2000, block1.Margin.Bottom);
            moveUpleft4.Duration = new Duration(TimeSpan.FromSeconds(8));
            Storyboard.SetTargetName(moveUpleft4, "block6");
            Storyboard.SetTargetProperty(moveUpleft4, new PropertyPath(Canvas.MarginProperty));
            playMoveBlock6.Children.Add(moveUpleft4);
            playMoveBlock6.Begin(this, true);

        }
        void AnimateMoveLeft10()
        {
            ThicknessAnimation moveUpleft5 = new ThicknessAnimation();
            moveUpleft5.From = Block2;
            moveUpleft5.To = new Thickness(-2000, block2.Margin.Top,
                +2000, block2.Margin.Bottom);
            moveUpleft5.Duration = new Duration(TimeSpan.FromSeconds(8));
            Storyboard.SetTargetName(moveUpleft5, "block7");
            Storyboard.SetTargetProperty(moveUpleft5, new PropertyPath(Canvas.MarginProperty));
            playMoveBlock7.Children.Add(moveUpleft5);
            playMoveBlock7.Begin(this, true);

        }
        void AnimateMoveLeft11()
        {
            ThicknessAnimation moveUpleft6 = new ThicknessAnimation();
            moveUpleft6.From = Block3;
            moveUpleft6.To = new Thickness(-2000, block3.Margin.Top,
                +2000, block3.Margin.Bottom);
            moveUpleft6.Duration = new Duration(TimeSpan.FromSeconds(8));
            Storyboard.SetTargetName(moveUpleft6, "block8");
            Storyboard.SetTargetProperty(moveUpleft6, new PropertyPath(Canvas.MarginProperty));
            playMoveBlock8.Children.Add(moveUpleft6);
            playMoveBlock8.Begin(this, true);
        }
        void AnimateMoveLeft12()
        {
            ThicknessAnimation moveUpleft7 = new ThicknessAnimation();
            moveUpleft7.From = Block4;
            moveUpleft7.To = new Thickness(-2000, block4.Margin.Top,
                +2000, block4.Margin.Bottom);
            moveUpleft7.Duration = new Duration(TimeSpan.FromSeconds(8));
            Storyboard.SetTargetName(moveUpleft7, "block9");
            Storyboard.SetTargetProperty(moveUpleft7, new PropertyPath(Canvas.MarginProperty));
            playMoveBlock9.Children.Add(moveUpleft7);
            playMoveBlock9.Begin(this, true);
        }
        void AnimateMoveLeft13()
        {
            ThicknessAnimation moveUpleft8 = new ThicknessAnimation();
            moveUpleft8.From = Block5;
            moveUpleft8.To = new Thickness(-2000, block5.Margin.Top,
                +2000, block5.Margin.Bottom);
            moveUpleft8.Duration = new Duration(TimeSpan.FromSeconds(8));
            Storyboard.SetTargetName(moveUpleft8, "block10");
            Storyboard.SetTargetProperty(moveUpleft8, new PropertyPath(Canvas.MarginProperty));
            playMoveBlock10.Children.Add(moveUpleft8);
            playMoveBlock10.Begin(this, true);
        }
        void AnimateMoveLeft14()
        {
            ThicknessAnimation moveUpleft4 = new ThicknessAnimation();
            moveUpleft4.From = Block1;
            moveUpleft4.To = new Thickness(-2000, block1.Margin.Top,
                +2000, block1.Margin.Bottom);
            moveUpleft4.Duration = new Duration(TimeSpan.FromSeconds(8));
            Storyboard.SetTargetName(moveUpleft4, "block11");
            Storyboard.SetTargetProperty(moveUpleft4, new PropertyPath(Canvas.MarginProperty));
            playMoveBlock11.Children.Add(moveUpleft4);
            playMoveBlock11.Begin(this, true);

        }
        void AnimateMoveLeft15()
        {
            ThicknessAnimation moveUpleft5 = new ThicknessAnimation();
            moveUpleft5.From = Block2;
            moveUpleft5.To = new Thickness(-2000, block2.Margin.Top,
                +2000, block2.Margin.Bottom);
            moveUpleft5.Duration = new Duration(TimeSpan.FromSeconds(8));
            Storyboard.SetTargetName(moveUpleft5, "block12");
            Storyboard.SetTargetProperty(moveUpleft5, new PropertyPath(Canvas.MarginProperty));
            playMoveBlock12.Children.Add(moveUpleft5);
            playMoveBlock12.Begin(this, true);

        }
        void AnimateMoveLeft16()
        {
            ThicknessAnimation moveUpleft6 = new ThicknessAnimation();
            moveUpleft6.From = Block3;
            moveUpleft6.To = new Thickness(-2000, block3.Margin.Top,
                +2000, block3.Margin.Bottom);
            moveUpleft6.Duration = new Duration(TimeSpan.FromSeconds(8));
            Storyboard.SetTargetName(moveUpleft6, "block13");
            Storyboard.SetTargetProperty(moveUpleft6, new PropertyPath(Canvas.MarginProperty));
            playMoveBlock13.Children.Add(moveUpleft6);
            playMoveBlock13.Begin(this, true);
        }
        void AnimateMoveLeft17()
        {
            ThicknessAnimation moveUpleft7 = new ThicknessAnimation();
            moveUpleft7.From = Block4;
            moveUpleft7.To = new Thickness(-2000, block4.Margin.Top,
                +2000, block4.Margin.Bottom);
            moveUpleft7.Duration = new Duration(TimeSpan.FromSeconds(8));
            Storyboard.SetTargetName(moveUpleft7, "block14");
            Storyboard.SetTargetProperty(moveUpleft7, new PropertyPath(Canvas.MarginProperty));
            playMoveBlock14.Children.Add(moveUpleft7);
            playMoveBlock14.Begin(this, true);
        }
        void AnimateMoveLeft18()
        {
            ThicknessAnimation moveUpleft8 = new ThicknessAnimation();
            moveUpleft8.From = Block5;
            moveUpleft8.To = new Thickness(-2000, block5.Margin.Top,
                +2000, block5.Margin.Bottom);
            moveUpleft8.Duration = new Duration(TimeSpan.FromSeconds(8));
            Storyboard.SetTargetName(moveUpleft8, "block15");
            Storyboard.SetTargetProperty(moveUpleft8, new PropertyPath(Canvas.MarginProperty));
            playMoveBlock15.Children.Add(moveUpleft8);
            playMoveBlock15.Begin(this, true);
        }


        private void Start()
        {
            Reset();
            scoreTimer.Start();
        }
        private void Reset()
        {

            scoreTimeCounter = 0;
            gameTimeCounter = 0;
            level = 1;
            lbl1.Margin = fence1;
            lbl2.Margin = fence2;
            lbl3.Margin = fence3;
            Bun.Margin = TheBun;
            block1.Margin = Block1;
            block2.Margin = Block2;
            block3.Margin = Block3;
            block4.Margin = Block4;
            block5.Margin = Block5;
            gameover = false;
        }
        private void Lose()
        {
            stopAnimation();
            gameover = true;



            if (scoreTimeCounter >= Name1.highScoreGame3)
            {
                Name1.highScoreGame3 = scoreTimeCounter;
                if (System.Windows.MessageBox.Show("Congratulations! You get the highest score : " + scoreTimeCounter.ToString(), "GameOver", MessageBoxButton.OK, MessageBoxImage.Question) == MessageBoxResult.OK)
                {

                    Name1 child = new Name1();
                    child.Owner = this;
                    child.Show();
                    highScoreLbl.Content = Name1.highScoreGame3;

                }
            }
             else if (System.Windows.MessageBox.Show("Your score is : " + scoreTimeCounter.ToString() +
                "\n The highest score is : " + Name1.highScoreNameGame3 + " , " + Name1.highScoreGame3, "GameOver", MessageBoxButton.OK, MessageBoxImage.Question) == MessageBoxResult.OK) ;
           
        }
        private void stopAnimation()
        {
            playMovefence1.Stop(this);
            playMovefence2.Stop(this);
            playMovefence3.Stop(this);
            playMoveUp.Stop(this);
            playMoveDown.Stop(this);
            playMoveBlock1.Stop(this);
            playMoveBlock2.Stop(this);
            playMoveBlock3.Stop(this);
            playMoveBlock4.Stop(this);
            playMoveBlock5.Stop(this);
            playMoveBlock6.Stop(this);
            playMoveBlock7.Stop(this);
            playMoveBlock8.Stop(this);
            playMoveBlock9.Stop(this);
            playMoveBlock10.Stop(this);
            playMoveBlock11.Stop(this);
            playMoveBlock12.Stop(this);
            playMoveBlock13.Stop(this);
            playMoveBlock14.Stop(this);
            playMoveBlock15.Stop(this);
        }
        private void getfence()
        {
            lbl1.Margin = fence1;
        }
        private void getfence2()
        {
            lbl2.Margin = fence2;
        }
        private void getfence3()
        {
            lbl3.Margin = fence3;
        }
        private void getblock1()
        {
            block1.Margin = Block1;
        }
        private void getblock2()
        {
            block2.Margin = Block2;
        }
        private void getblock3()
        {
            block3.Margin = Block3;
        }
        private void getblock4()
        {
            block4.Margin = Block4;
        }
        private void getblock5()
        {
            block5.Margin = Block5;
        }
        private void getblock6()
        {
            block6.Margin = Block1;
        }
        private void getblock7()
        {
            block7.Margin = Block1;
        }
        private void getblock8()
        {
            block8.Margin = Block1;
        }
        private void getblock9()
        {
            block9.Margin = Block1;
        }
        private void getblock10()
        {
            block10.Margin = Block1;
        }
        private void getblock11()
        {
            block11.Margin = Block1;
        }
        private void getblock12()
        {
            block12.Margin = Block2;
        }
        private void getblock13()
        {
            block13.Margin = Block3;
        }
        private void getblock14()
        {
            block14.Margin = Block4;
        }
        private void getblock15()
        {
            block15.Margin = Block5;
        }
        private void getquestion1(int X)
        {
            for (int i = 0; i < X; i++)
            {
                switch (random.Next(0, 4))
                {
                    case 0:
                        getblock1();
                        AnimateMoveLeft4();
                        break;

                    case 1:
                        getblock2();
                        AnimateMoveLeft5();
                        break;

                    case 2:
                        getblock3();
                        AnimateMoveLeft6();
                        break;

                    case 3:
                        getblock4();
                        AnimateMoveLeft7();
                        break;

                    case 4:
                        getblock5();
                        AnimateMoveLeft8();
                        break;
                }
            }
        }
        private void getquestion2(int X)
        {
            for (int i = 0; i < X; i++)
            {
                switch (random.Next(0, 4))
                {
                    case 0:
                        getblock6();
                        AnimateMoveLeft9();
                        break;

                    case 1:
                        getblock7();
                        AnimateMoveLeft10();
                        break;

                    case 2:
                        getblock8();
                        AnimateMoveLeft11();
                        break;

                    case 3:
                        getblock9();
                        AnimateMoveLeft12();
                        break;

                    case 4:
                        getblock10();
                        AnimateMoveLeft13();
                        break;
                }
            }
        }
        private void getquestion3(int X)
        {
            for (int i = 0; i < X; i++)
            {
                switch (random.Next(0, 4))
                {
                    case 0:
                        getblock11();
                        AnimateMoveLeft14();
                        break;

                    case 1:
                        getblock12();
                        AnimateMoveLeft15();
                        break;

                    case 2:
                        getblock13();
                        AnimateMoveLeft16();
                        break;

                    case 3:
                        getblock14();
                        AnimateMoveLeft17();
                        break;

                    case 4:
                        getblock15();
                        AnimateMoveLeft18();
                        break;
                }
            }
        }
        private void getquestion4()
        {

            switch (random.Next(0, 4))
            {
                case 0:
                    getblock2();
                    AnimateMoveLeft5();
                    getblock3();
                    AnimateMoveLeft6();
                    getblock4();
                    AnimateMoveLeft7();
                    getblock5();
                    AnimateMoveLeft8();
                    break;

                case 1:
                    getblock1();
                    AnimateMoveLeft4();
                    getblock3();
                    AnimateMoveLeft6();
                    getblock4();
                    AnimateMoveLeft7();
                    getblock5();
                    AnimateMoveLeft8();
                    break;

                case 2:
                    getblock1();
                    AnimateMoveLeft4();
                    getblock2();
                    AnimateMoveLeft5();
                    getblock4();
                    AnimateMoveLeft7();
                    getblock5();
                    AnimateMoveLeft8();
                    break;

                case 3:
                    getblock1();
                    AnimateMoveLeft4();
                    getblock2();
                    AnimateMoveLeft5();
                    getblock3();
                    AnimateMoveLeft6();
                    getblock5();
                    AnimateMoveLeft8();
                    break;

                case 4:
                    getblock1();
                    AnimateMoveLeft4();
                    getblock2();
                    AnimateMoveLeft5();
                    getblock3();
                    AnimateMoveLeft6();
                    getblock4();
                    AnimateMoveLeft7();
                    break;
            }

        }
        private void getquestion5()
        {

            switch (random.Next(0, 4))
            {
                case 0:
                    getblock7();
                    AnimateMoveLeft10();
                    getblock8();
                    AnimateMoveLeft11();
                    getblock9();
                    AnimateMoveLeft12();
                    getblock10();
                    AnimateMoveLeft13();
                    break;

                case 1:
                    getblock6();
                    AnimateMoveLeft9();
                    getblock8();
                    AnimateMoveLeft11();
                    getblock9();
                    AnimateMoveLeft12();
                    getblock10();
                    AnimateMoveLeft13();
                    break;

                case 2:
                    getblock6();
                    AnimateMoveLeft9();
                    getblock7();
                    AnimateMoveLeft10();
                    getblock9();
                    AnimateMoveLeft12();
                    getblock10();
                    AnimateMoveLeft13();
                    break;

                case 3:
                    getblock6();
                    AnimateMoveLeft9();
                    getblock7();
                    AnimateMoveLeft10();
                    getblock8();
                    AnimateMoveLeft11();
                    getblock10();
                    AnimateMoveLeft13();
                    break;

                case 4:
                    getblock6();
                    AnimateMoveLeft9();
                    getblock7();
                    AnimateMoveLeft10();
                    getblock8();
                    AnimateMoveLeft11();
                    getblock9();
                    AnimateMoveLeft12();
                    break;
            }

        }
        private void getquestion6()
        {

            switch (random.Next(0, 4))
            {
                case 0:
                    getblock12();
                    AnimateMoveLeft15();
                    getblock13();
                    AnimateMoveLeft16();
                    getblock14();
                    AnimateMoveLeft17();
                    getblock15();
                    AnimateMoveLeft18();
                    break;

                case 1:
                    getblock11();
                    AnimateMoveLeft14();
                    getblock13();
                    AnimateMoveLeft16();
                    getblock14();
                    AnimateMoveLeft17();
                    getblock15();
                    AnimateMoveLeft18();
                    break;

                case 2:
                    getblock11();
                    AnimateMoveLeft14();
                    getblock12();
                    AnimateMoveLeft15();
                    getblock14();
                    AnimateMoveLeft17();
                    getblock15();
                    AnimateMoveLeft18();
                    break;

                case 3:
                    getblock11();
                    AnimateMoveLeft14();
                    getblock12();
                    AnimateMoveLeft15();
                    getblock13();
                    AnimateMoveLeft16();
                    getblock15();
                    AnimateMoveLeft18();
                    break;

                case 4:
                    getblock11();
                    AnimateMoveLeft14();
                    getblock12();
                    AnimateMoveLeft15();
                    getblock13();
                    AnimateMoveLeft16();
                    getblock14();
                    AnimateMoveLeft17();
                    break;
            }

        }


        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (gameTimeCounter == 0)
            {
                Start();

            }
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            //返回選單
            base.Close();
        }

        private void MenuItemStart_Click(object sender, RoutedEventArgs e)
        {
            if (gameTimeCounter == 0) Start();
        }

        private void MenuItemReset_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        private void Window_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            // playMoveDown.Stop(this);
            AnimateMoveDown();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // playMoveUp.Stop(this);
            AnimateMoveUp();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Lose();
        }

    }
}
