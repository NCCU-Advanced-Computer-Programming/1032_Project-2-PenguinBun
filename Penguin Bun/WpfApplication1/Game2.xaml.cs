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
    public partial class Game2 : Window
    {
        internal DispatcherTimer scoreTimer;

        int scoreTimeCounter = 0, gameTimeCounter = 0;
        int score = 0;
        bool isCorrect = true;
        bool isLose = true;
        bool gameover = false;
        int question, key = 1;
        int person = 1;
        Thickness left, right, checkanswer, place1, place2, place3;
        ImageBrush myBrush1 = new ImageBrush();
        ImageBrush myBrush2 = new ImageBrush();
        ImageBrush myBrush3 = new ImageBrush();
        ImageBrush myBrush4 = new ImageBrush();
        ImageBrush myBrush5 = new ImageBrush();
        Random random = new Random();
        Storyboard playMoveLeft = new Storyboard();
        Storyboard playMoveRight = new Storyboard();


        public Game2()
        {
            InitializeComponent();
            scoreTimer = new DispatcherTimer();
            scoreTimer.Interval = TimeSpan.FromSeconds(1.0);
            scoreTimer.Tick += new EventHandler(Timer_Tick);


            left = lblLeft.Margin;
            right = lblRight.Margin;
            checkanswer = check.Margin;
            place1 = person1.Margin;
            place2 = person2.Margin;
            place3 = person3.Margin;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!gameover)
            {
                scoreTimeCounter++;
              

                gameTimeCounter++;
                if (lblLeft.Margin.Left + 194 < checkanswer.Left && isCorrect == false)
                {
                    Lose();
                }

                if (lblRight.Margin.Left + 194 < checkanswer.Left && isCorrect == false)
                {
                    Lose();
                }

              

                if (isLose)
                {

                    if (isCorrect)
                    {
                        if (key == 1)
                        {
                            getQuestion();
                            isCorrect = false;
                            AnimateMoveLeft1(614.0);
                            lblLeft.Margin = left;


                            // key = 2;
                        }
                    
                    }
                }
            }
        }


        void AnimateMoveLeft1(double x)
        {
            ThicknessAnimation moveUpleft = new ThicknessAnimation();
            moveUpleft.From = left;
            moveUpleft.To = new Thickness(lblLeft.Margin.Left - x, lblLeft.Margin.Top,
                lblLeft.Margin.Right - x, lblLeft.Margin.Bottom);
            if (gameTimeCounter <= 30)
            {
                moveUpleft.Duration = new Duration(TimeSpan.FromSeconds(4 - gameTimeCounter / 10));
            }
            else
            {
                moveUpleft.Duration = new Duration(TimeSpan.FromSeconds(1));
            }
            Storyboard.SetTargetName(moveUpleft, "lblLeft");
            Storyboard.SetTargetProperty(moveUpleft, new PropertyPath(Canvas.MarginProperty));
            playMoveLeft.Children.Add(moveUpleft);

            playMoveLeft.Begin(this, true);
        

        }

        void AnimateMoveLeft2(double x)
        {
            ThicknessAnimation moveUpleft2 = new ThicknessAnimation();
            moveUpleft2.From = right;
            moveUpleft2.To = new Thickness(lblRight.Margin.Left - x, lblRight.Margin.Top,
                lblRight.Margin.Right - x, lblRight.Margin.Bottom);
            moveUpleft2.Duration = new Duration(TimeSpan.FromSeconds(2));
            Storyboard.SetTargetName(moveUpleft2, "lblRight");
            Storyboard.SetTargetProperty(moveUpleft2, new PropertyPath(Canvas.MarginProperty));
            playMoveLeft.Children.Add(moveUpleft2);

            playMoveLeft.Begin(this, true);
            
        }




        private void Start()
        {
            Reset();
            //music1.Play();
            scoreTimer.Start();

        }

        private void Reset()
        {

            scoreTimeCounter = 0;
            gameTimeCounter = 0;
            score = 0;
            lblScore.Content = score.ToString();
            lblLeft.Margin = left;
            lblRight.Margin = right;
            key = 1;
            isCorrect = true;

            gameover = false;
            correctAnswer.Background = null;
            wrongAnswer.Background = null;

        }

        private void Lose()
        {
            ImageBrush answerBrush = new ImageBrush();
            answerBrush.ImageSource =
            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images2/叉叉.png"));
            wrongAnswer.Background = answerBrush;
            stopAnimation();
            gameover = true;


         if (score >= Name1.highScoreGame2)
            {
                Name1.highScoreGame2 = score;
                if (System.Windows.MessageBox.Show("Congratulations! You get the highest score : " + score.ToString(), "GameOver", MessageBoxButton.OK, MessageBoxImage.Question) == MessageBoxResult.OK)
                {

                    Name1 child = new Name1();
                    child.Owner = this;
                    child.Show();
                    highScoreLbl.Content = Name1.highScoreGame2;

                }
            }
            else if (System.Windows.MessageBox.Show("Your score is : " + score.ToString() +
                "\n The highest score is : " + Name1.highScoreNameGame2 + " , " + Name1.highScoreGame2, "GameOver", MessageBoxButton.OK, MessageBoxImage.Question) == MessageBoxResult.OK) ;
           

        }
        private void stopAnimation()
        {
            playMoveLeft.Stop(this);          
            playMoveRight.Stop(this);        
        }

        private void getQuestion()
        {
            if (person == 1)
            {
                person3.Margin = place3;
                person2.Margin = place2;
                person1.Margin = place1;
            }
            else if (person == 2)
            {
                person1.Margin = place3;
                person2.Margin = place1;
                person3.Margin = place2;
            }
            else
            {
                person2.Margin = place3;
                person3.Margin = place1;
                person1.Margin = place2;
            }
            correctAnswer.Background = null;
            lblLeft.Margin = left;
            lblRight.Margin = right;
            question = random.Next(0, 8);

            switch (question)
            {
                case 0:
                    myBrush1.ImageSource =
                            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images2/纜車1.png"));
                    lblLeft.Background = myBrush1;
                    myBrush2.ImageSource =
                            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images2/纜車1.png"));
                    lblRight.Background = myBrush2;
                    if (person == 2)
                    {
                        myBrush3.ImageSource =
                    new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images2/小孩1.png"));
                        person1.Background = myBrush3;
                    }
                    else if (person == 3)
                    {
                        myBrush4.ImageSource =
                    new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images2/小孩1.png"));
                        person2.Background = myBrush4;
                    }
                    else
                    {
                        myBrush5.ImageSource =
                   new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images2/小孩1.png"));
                        person3.Background = myBrush5;
                    }

                    break;
                case 1:
                    myBrush1.ImageSource =
                            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images2/纜車2.png"));
                    lblLeft.Background = myBrush1;
                    myBrush2.ImageSource =
                            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images2/纜車2.png"));
                    lblRight.Background = myBrush2;
                    if (person == 2)
                    {
                        myBrush3.ImageSource =
                    new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images2/小孩3.png"));
                        person1.Background = myBrush3;
                    }
                    else if (person == 3)
                    {
                        myBrush4.ImageSource =
                    new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images2/小孩3.png"));
                        person2.Background = myBrush4;
                    }
                    else
                    {
                        myBrush5.ImageSource =
                   new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images2/小孩3.png"));
                        person3.Background = myBrush5;
                    }
                    break;
                case 2:
                    myBrush1.ImageSource =
                            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images2/纜車3.png"));
                    lblLeft.Background = myBrush1;
                    myBrush2.ImageSource =
                            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images2/纜車3.png"));
                    lblRight.Background = myBrush2;
                    if (person == 2)
                    {
                        myBrush3.ImageSource =
                    new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images2/小孩4.png"));
                        person1.Background = myBrush3;
                    }
                    else if (person == 3)
                    {
                        myBrush4.ImageSource =
                    new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images2/小孩4.png"));
                        person2.Background = myBrush4;
                    }
                    else
                    {
                        myBrush5.ImageSource =
                   new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images2/小孩4.png"));
                        person3.Background = myBrush5;
                    }
                    break;
                case 3:
                    myBrush1.ImageSource =
                            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images2/纜車4.png"));
                    lblLeft.Background = myBrush1;
                    myBrush2.ImageSource =
                            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images2/纜車4.png"));
                    lblRight.Background = myBrush2;
                    if (person == 2)
                    {
                        myBrush3.ImageSource =
                    new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images2/父母1.png"));
                        person1.Background = myBrush3;
                    }
                    else if (person == 3)
                    {
                        myBrush4.ImageSource =
                    new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images2/父母1.png"));
                        person2.Background = myBrush4;
                    }
                    else
                    {
                        myBrush5.ImageSource =
                   new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images2/父母1.png"));
                        person3.Background = myBrush5;
                    }
                    break;
                case 4:
                    myBrush1.ImageSource =
                            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images2/纜車5.png"));
                    lblLeft.Background = myBrush1;
                    myBrush2.ImageSource =
                            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images2/纜車5.png"));
                    lblRight.Background = myBrush2;
                    if (person == 2)
                    {
                        myBrush3.ImageSource =
                    new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images2/父母2.png"));
                        person1.Background = myBrush3;
                    }
                    else if (person == 3)
                    {
                        myBrush4.ImageSource =
                    new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images2/父母2.png"));
                        person2.Background = myBrush4;
                    }
                    else
                    {
                        myBrush5.ImageSource =
                   new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images2/父母2.png"));
                        person3.Background = myBrush5;
                    }
                    break;
                case 5:
                    myBrush1.ImageSource =
                            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images2/纜車6.png"));
                    lblLeft.Background = myBrush1;
                    myBrush2.ImageSource =
                            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images2/纜車6.png"));
                    lblRight.Background = myBrush2;
                    if (person == 2)
                    {
                        myBrush3.ImageSource =
                    new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images2/父母3.png"));
                        person1.Background = myBrush3;
                    }
                    else if (person == 3)
                    {
                        myBrush4.ImageSource =
                    new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images2/父母3.png"));
                        person2.Background = myBrush4;
                    }
                    else
                    {
                        myBrush5.ImageSource =
                   new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images2/父母3.png"));
                        person3.Background = myBrush5;
                    }
                    break;
                case 6:
                    myBrush1.ImageSource =
                            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images2/纜車7.png"));
                    lblLeft.Background = myBrush1;
                    myBrush2.ImageSource =
                            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images2/纜車7.png"));
                    lblRight.Background = myBrush2;
                    if (person == 2)
                    {
                        myBrush3.ImageSource =
                    new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images2/父母4.png"));
                        person1.Background = myBrush3;
                    }
                    else if (person == 3)
                    {
                        myBrush4.ImageSource =
                    new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images2/父母4.png"));
                        person2.Background = myBrush4;
                    }
                    else
                    {
                        myBrush5.ImageSource =
                   new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images2/父母4.png"));
                        person3.Background = myBrush5;
                    }
                    break;
                case 7:
                    myBrush1.ImageSource =
                            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images2/纜車8.png"));
                    lblLeft.Background = myBrush1;
                    myBrush2.ImageSource =
                            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images2/纜車8.png"));
                    lblRight.Background = myBrush2;
                    if (person == 2)
                    {
                        myBrush3.ImageSource =
                    new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images2/父母5.png"));
                        person1.Background = myBrush3;
                    }
                    else if (person == 3)
                    {
                        myBrush4.ImageSource =
                    new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images2/父母5.png"));
                        person2.Background = myBrush4;
                    }
                    else
                    {
                        myBrush5.ImageSource =
                   new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images2/父母5.png"));
                        person3.Background = myBrush5;
                    }
                    break;
                case 8:
                    myBrush1.ImageSource =
                            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images2/纜車9.png"));
                    lblLeft.Background = myBrush1;
                    myBrush2.ImageSource =
                            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images2/纜車9.png"));
                    lblRight.Background = myBrush2;
                    if (person == 2)
                    {
                        myBrush3.ImageSource =
                    new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images2/父母6.png"));
                        person1.Background = myBrush3;
                    }
                    else if (person == 3)
                    {
                        myBrush4.ImageSource =
                    new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images2/父母6.png"));
                        person2.Background = myBrush4;
                    }
                    else
                    {
                        myBrush5.ImageSource =
                   new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images2/父母6.png"));
                        person3.Background = myBrush5;
                    }
                    break;

            }
        }

        private void changeScore()
        {
           
            if (person == 1)
            {
                person1.Background = null;
                person = 2;


            }
            else if (person == 2)
            {
                person2.Background = null;
                person = 3;

            }
            else
            {
                person3.Background = null;
                person = 1;
            }

            ImageBrush answerBrush = new ImageBrush();
            answerBrush.ImageSource =
            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images/愛心.png"));

            correctAnswer.Background = answerBrush;
            score += (1);
            lblScore.Content = score.ToString();

            isCorrect = true;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (gameTimeCounter == 0) Start();
            else
            {
                if (key == 1)
                {
                    if (lblLeft.Margin.Left < checkanswer.Left && (lblLeft.Margin.Left + 194) > (checkanswer.Left + 50))
                    {
                        changeScore();
                    }
                    else
                    {
                        Lose();
                    }
                }
                else
                {
                    if (lblRight.Margin.Left < checkanswer.Left && lblRight.Margin.Right > checkanswer.Right)
                    {
                        changeScore();
                    }
                    else
                    {
                        Lose();
                    }
                }
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

        private void Window_Closed(object sender, EventArgs e)
        {
            Lose();
        }
    }
}
