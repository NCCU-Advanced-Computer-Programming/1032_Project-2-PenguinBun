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
 
    public partial class Game1 : Window
    {
        internal DispatcherTimer scoreTimer;

        float scoreTimeCounter = 0, gameTimeCounter = 0;
        int score = 0;
        float level = 4.0f, pauseTime = 2.0f, answerTime = 0.0f;
        bool isLose = true;
        bool gameover = false;
        bool down = false;
      

        private Thickness left, right;



        private ImageBrush myBrush1 = new ImageBrush();
        private ImageBrush myBrush2 = new ImageBrush();
        private ImageBrush childBrush = new ImageBrush();
        private String randomQuestion;
        private Random random = new Random();
        private Storyboard playMoveUp = new Storyboard();
        private Storyboard playMoveDown = new Storyboard();

        private String[] parent = new String[6]
        {"RAndY",     
        "YAndW",
        "YAndB",
        "BAndB",
        "BAndR",
        "RAndW"};

        public Game1()
        {
            InitializeComponent();
            scoreTimer = new DispatcherTimer();
            scoreTimer.Interval = TimeSpan.FromSeconds(1.0);
            scoreTimer.Tick += new EventHandler(Timer_Tick);

            left = lblLeft.Margin;
            right = lblRight.Margin;

        }



        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!gameover)
            {
                scoreTimeCounter++;
               

                gameTimeCounter++;

                if (isLose)
                {
                    if (scoreTimeCounter > level * 2)
                    { //lose
                        Lose();
                    }


                    else if (scoreTimeCounter == 1)
                    {
                        getQuestion();

                        AnimateMoveUp(150);
                        down = true;
                    }

                    else if (scoreTimeCounter > level && down)
                    {
                        AnimateMoveDown(150);
                        down = false;
                    }
                }

                else
                {
                    if (scoreTimeCounter >= (answerTime + pauseTime))
                    {
                        isLose = true;
                        scoreTimeCounter = 0;
                    }
                }


            }
        }

        private void AnimateMoveDown(double x)
        {

            ThicknessAnimation moveDownleft = new ThicknessAnimation();
            moveDownleft.From = lblLeft.Margin;

            moveDownleft.To = new Thickness(lblLeft.Margin.Left, lblLeft.Margin.Top + x,
                lblLeft.Margin.Right, lblLeft.Margin.Bottom - x);
            moveDownleft.Duration = new Duration(TimeSpan.FromSeconds(level));

            Storyboard.SetTargetName(moveDownleft, "lblLeft");
            Storyboard.SetTargetProperty(moveDownleft, new PropertyPath(Canvas.MarginProperty));

            ThicknessAnimation moveDownright = new ThicknessAnimation();
            moveDownright.From = lblRight.Margin;

            moveDownright.To = new Thickness(lblRight.Margin.Left, lblRight.Margin.Top + x,
                lblRight.Margin.Right, lblRight.Margin.Bottom - x);
            moveDownright.Duration = new Duration(TimeSpan.FromSeconds(level));

            Storyboard.SetTargetName(moveDownright, "lblRight");
            Storyboard.SetTargetProperty(moveDownright, new PropertyPath(Canvas.MarginProperty));


            if (playMoveDown.Children.Count > 0)
            {

                playMoveDown.Children.Clear();
            }
            playMoveDown.Children.Add(moveDownleft);
            playMoveDown.Children.Add(moveDownright);
            playMoveDown.Begin(this, true);
        }
        void AnimateMoveUp(double x)
        {

            ThicknessAnimation moveUpleft = new ThicknessAnimation();
            moveUpleft.From = left;

            moveUpleft.To = new Thickness(left.Left, left.Top - x,
                left.Right, left.Bottom + x);
            moveUpleft.Duration = new Duration(TimeSpan.FromSeconds(level));
            Storyboard.SetTargetName(moveUpleft, "lblLeft");
            Storyboard.SetTargetProperty(moveUpleft, new PropertyPath(Canvas.MarginProperty));

            ThicknessAnimation moveUpright = new ThicknessAnimation();
            moveUpright.From = right;

            moveUpright.To = new Thickness(right.Left, right.Top - x,
                right.Right, right.Bottom + x);
            moveUpright.Duration = new Duration(TimeSpan.FromSeconds(level));
            Storyboard.SetTargetName(moveUpright, "lblRight");
            Storyboard.SetTargetProperty(moveUpright, new PropertyPath(Canvas.MarginProperty));


            if (playMoveUp.Children.Count > 0)
            {

                playMoveUp.Children.Clear();
            }
            playMoveUp.Children.Add(moveUpleft);
            playMoveUp.Children.Add(moveUpright);
            playMoveUp.Begin(this, true);

        }

        private void Start()
        {
            Reset();
            scoreTimer.Start();
        }

        private void Reset()
        {
            stopAnimation();
            scoreTimeCounter = 0;
            gameTimeCounter = 0;
            score = 0;
            lblScore.Content = score.ToString();

            level = 4.0f;
            pauseTime = 2.0f;
            answerTime = 0.0f;
            gameover = false;
            correctAnswer.Background = null;
            wrongAnswer.Background = null;
            childAnswer.Background = null;
        }

        private void Lose()
        {
            ImageBrush answerBrush = new ImageBrush();
            answerBrush.ImageSource =
            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images/叉叉.png"));
            wrongAnswer.Background = answerBrush;
            stopAnimation();
            gameover = true;

            if (score >= Name1.highScoreGame1)
            {
                Name1.highScoreGame1 = score;
                if (System.Windows.MessageBox.Show("Congratulations! You get the highest score : " + score.ToString(), "GameOver", MessageBoxButton.OK, MessageBoxImage.Question) == MessageBoxResult.OK)
                {

                    Name1 child = new Name1();
                    child.Owner = this;
                    child.Show();
                    highScoreLbl.Content = Name1.highScoreGame1;

                }
            }
            else if (System.Windows.MessageBox.Show("Your score is : " + score.ToString() +
                "\n The highest score is : " + Name1.highScoreNameGame1 + " , " + Name1.highScoreGame1, "GameOver", MessageBoxButton.OK, MessageBoxImage.Question) == MessageBoxResult.OK) ;
           
       


        }

        private void stopAnimation()
        {

            playMoveUp.Pause(this);
            playMoveUp.Children.Clear();
            playMoveDown.Pause(this);
            playMoveDown.Children.Clear();

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (gameTimeCounter == 0 && score == 0) Start();
        }

        private void getQuestion()
        {

            correctAnswer.Background = null;
            childAnswer.Background = null;
            answerTime = 0;
            lblLeft.Margin = left;
            lblRight.Margin = right;
            randomQuestion = parent[random.Next(0, parent.Length)];


            switch (randomQuestion)
            {
                case "RAndY":
                    switch (random.Next(0, 3))
                    {
                        case 0: // R & Y                           
                            myBrush1.ImageSource =
                            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images/父母1.png"));
                            lblLeft.Background = myBrush1;
                            myBrush2.ImageSource =
                            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images/父母2.png"));
                            lblRight.Background = myBrush2;
                            break;
                        case 1: // Y & R
                            myBrush1.ImageSource =
                            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images/父母2.png"));
                            lblLeft.Background = myBrush1;
                            myBrush2.ImageSource =
                            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images/父母1.png"));
                            lblRight.Background = myBrush2;
                            break;
                        case 2: // O & O
                            myBrush1.ImageSource =
                            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images/小孩1.png"));
                            lblLeft.Background = myBrush1;
                            myBrush2.ImageSource =
                            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images/小孩1.png"));
                            lblRight.Background = myBrush2;
                            break;
                    }
                    break;

                case "YAndW":
                    switch (random.Next(0, 2))
                    {
                        case 0: // Y & W                           
                            myBrush1.ImageSource =
                            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images/父母2.png"));
                            lblLeft.Background = myBrush1;
                            myBrush2.ImageSource =
                            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images/父母3.png"));
                            lblRight.Background = myBrush2;
                            break;
                        case 1: // W & Y
                            myBrush1.ImageSource =
                            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images/父母3.png"));
                            lblLeft.Background = myBrush1;
                            myBrush2.ImageSource =
                            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images/父母2.png"));
                            lblRight.Background = myBrush2;

                            break;
                    }

                    break;
                case "YAndB":
                    switch (random.Next(0, 2))
                    {
                        case 0: // Y & B                           
                            myBrush1.ImageSource =
                            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images/父母2.png"));
                            lblLeft.Background = myBrush1;
                            myBrush2.ImageSource =
                            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images/父母5.png"));
                            lblRight.Background = myBrush2;
                            break;
                        case 1: // B & Y
                            myBrush1.ImageSource =
                            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images/父母5.png"));
                            lblLeft.Background = myBrush1;
                            myBrush2.ImageSource =
                            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images/父母2.png"));
                            lblRight.Background = myBrush2;

                            break;
                    }

                    break;
                case "BAndB":
                    switch (random.Next(0, 2))
                    {
                        case 0: // B & B                         
                            myBrush1.ImageSource =
                            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images/父母5.png"));
                            lblLeft.Background = myBrush1;
                            myBrush2.ImageSource =
                            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images/父母4.png"));
                            lblRight.Background = myBrush2;
                            break;
                        case 1: // B & B
                            myBrush1.ImageSource =
                            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images/父母4.png"));
                            lblLeft.Background = myBrush1;
                            myBrush2.ImageSource =
                            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images/父母5.png"));
                            lblRight.Background = myBrush2;
                            break;
                    }

                    break;
                case "BAndR":
                    switch (random.Next(0, 2))
                    {
                        case 0: // B & R                           
                            myBrush1.ImageSource =
                            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images/父母5.png"));
                            lblLeft.Background = myBrush1;
                            myBrush2.ImageSource =
                            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images/父母1.png"));
                            lblRight.Background = myBrush2;
                            break;
                        case 1: // R & B
                            myBrush1.ImageSource =
                            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images/父母1.png"));
                            lblLeft.Background = myBrush1;
                            myBrush2.ImageSource =
                            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images/父母5.png"));
                            lblRight.Background = myBrush2;
                            break;
                    }
                    break;
                case "RAndW":
                    switch (random.Next(0, 2))
                    {
                        case 0: // R & W                           
                            myBrush1.ImageSource =
                            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images/父母1.png"));
                            lblLeft.Background = myBrush1;
                            myBrush2.ImageSource =
                            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images/父母3.png"));
                            lblRight.Background = myBrush2;
                            break;
                        case 1: // W & R
                            myBrush1.ImageSource =
                            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images/父母3.png"));
                            lblLeft.Background = myBrush1;
                            myBrush2.ImageSource =
                            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images/父母1.png"));
                            lblRight.Background = myBrush2;

                            break;
                    }
                    break;
            }

        }
        private void changeScore()
        {
            isLose = false;
            answerTime = scoreTimeCounter;
            stopAnimation();

            ImageBrush answerBrush = new ImageBrush();
            answerBrush.ImageSource =
            new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images/愛心.png"));

            correctAnswer.Background = answerBrush;
            if (answerTime >= 0 && answerTime <= 2 * level / 3) score += 7;
            else if (answerTime > 2 * level / 3 && answerTime <= 4 * level / 3) score += 5;
            else if (answerTime > 4 * level / 3 && answerTime <= 2 * level) score += 2;

            lblScore.Content = score.ToString();


            //關卡設計
            if (gameTimeCounter >= 10 && level > 1)
            {
                level--;
                gameTimeCounter = 0;
            }

        }

        private void gameControl(String number)
        {

            switch (number)
            {

                case "RAndY":
                    if (randomQuestion == "RAndY")
                    {

                        childBrush.ImageSource =
                             new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images/小孩1.png"));
                        childAnswer.Background = childBrush;
                        changeScore();
                    }
                    else Lose();
                    break;

                case "YAndW":
                    if (randomQuestion == "YAndW")
                    {
                        childBrush.ImageSource =
                             new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images/小孩2.png"));
                        childAnswer.Background = childBrush;
                        changeScore();
                    }
                    else Lose();
                    break;
                case "YAndB":
                    if (randomQuestion == "YAndB")
                    {
                        childBrush.ImageSource =
                             new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images/小孩3.png"));
                        childAnswer.Background = childBrush;
                        changeScore();
                    }
                    else Lose();
                    break;
                case "BAndB":
                    if (randomQuestion == "BAndB")
                    {
                        childBrush.ImageSource =
                             new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images/小孩4.png"));
                        childAnswer.Background = childBrush;
                        changeScore();
                    }
                    else Lose();
                    break;
                case "BAndR":
                    if (randomQuestion == "BAndR")
                    {
                        childBrush.ImageSource =
                             new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images/小孩5.png"));
                        childAnswer.Background = childBrush;
                        changeScore();
                    }
                    else Lose();
                    break;
                case "RAndW":
                    if (randomQuestion == "RAndW")
                    {
                        childBrush.ImageSource =
                             new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images/小孩6.png"));
                        childAnswer.Background = childBrush;
                        changeScore();
                    }
                    else Lose();
                    break;
                default:

                    break;
            }

        }

        private void childButton1_Click(object sender, RoutedEventArgs e)
        {
            gameControl("RAndY");
        }

        private void childButton2_Click(object sender, RoutedEventArgs e)
        {
            gameControl("YAndW");
        }

        private void childButton3_Click(object sender, RoutedEventArgs e)
        {
            gameControl("YAndB");
        }

        private void childButton4_Click(object sender, RoutedEventArgs e)
        {
            gameControl("BAndB");
        }

        private void childButton5_Click(object sender, RoutedEventArgs e)
        {
            gameControl("BAndR");
        }

        private void childButton6_Click(object sender, RoutedEventArgs e)
        {
            gameControl("RAndW");
        }



        private void MenuItemStart_Click(object sender, RoutedEventArgs e)
        {
            if (gameTimeCounter == 0) Start();
        }

        private void MenuItemReset_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            //返回選單
            base.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Lose();
        }

         



    }
}
