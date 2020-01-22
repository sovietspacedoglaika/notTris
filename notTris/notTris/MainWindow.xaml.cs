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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Drawing;
using notTris;

namespace NotTris 
{
    public partial class MainWindow : Window
    {
        DispatcherTimer time; 
        NotMatrix currMatrix; 
        int dropDuration;
        bool gameover;

        SoundRsrc music = new SoundRsrc();
    
        public int GetDropDur()
        {
            return dropDuration;
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        void MainWindow_Initialized(object sender, EventArgs e)
        {
            
            time = new DispatcherTimer();
            time.Tick += new EventHandler(GameTick);
            StartMenu();
            
        }

        private void StartMenu()
        {
            music.SickIntro();
            Background = ImgRsrc.GetMenuImg();

        }

        private void StartGame()
        {
            MainGrid.Children.Clear(); 
            currMatrix = new NotMatrix(MainGrid);
            Background = ImgRsrc.GetBgImg();
            MainGrid.Background = ImgRsrc.GetMatrixBg();
            SolidColorBrush fontcol = new SolidColorBrush(Color.FromRgb(244, 215, 170));
            CurrScore.Foreground = fontcol;
            Level.Foreground = fontcol;
            music.SickBGMusic();

            time.Stop();               
            time.Start();
        }
       
        void GameTick(object sender, EventArgs e)
        {
            gameover = currMatrix.GetGameState();

            if (gameover == true)
            {
                Stop();
                MainGrid.Children.Clear();
                MainGrid.Background = Brushes.Transparent;
                Background = ImgRsrc.GetGameOverImg();
                CurrScore.Foreground = Brushes.Transparent;
                Level.Foreground = Brushes.Transparent;
                music.GameOver();

            }

            CurrScore.Content = currMatrix.GetScore().ToString("");
            Level.Content = currMatrix.GetLevel().ToString("");

            if (currMatrix.GetLevel() <= 0)
            {
                dropDuration = 800;
            } else
            {
                dropDuration = 800 / currMatrix.GetLevel();
            }

            time.Interval = new TimeSpan(0, 0, 0, 0, dropDuration);
            currMatrix.MinoMoveDown();
        }

        private void Stop()
        {
            time.Stop();
        }

        private void HandleKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                    if (time.IsEnabled) currMatrix.MinoMoveLeft();
                    break;
                case Key.Right:
                    if (time.IsEnabled) currMatrix.MinoMoveRight();
                    break;
                case Key.Down:
                    if (time.IsEnabled) currMatrix.MinoMoveDown();
                    break;
                case Key.Up:
                    if (time.IsEnabled) currMatrix.MinoSpin();
                    break;
                case Key.Space:
                    StartGame();
                    break;
                case Key.Escape:
                    Application X = Application.Current;
                    X.Shutdown();
                    break;
                default:
                    break;
            }
        }
    }
}