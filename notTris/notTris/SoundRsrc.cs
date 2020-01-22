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
using notTris;

namespace notTris
{
    class SoundRsrc
    {
        MediaPlayer sicktunes = new MediaPlayer();
        
        public void SickIntro()
        {
            if (sicktunes != null)
            {
                sicktunes.Open(new Uri("sound/intro.mp3", UriKind.Relative));
                sicktunes.MediaEnded += new EventHandler(Still2Short);
                sicktunes.Play();
                return;
            }
        }

        private void Still2Short(object sender, EventArgs e)
        {
            sicktunes.Open(new Uri("sound/intro.mp3", UriKind.Relative));
            sicktunes.Play();
        }

        public void SickBGMusic()
        {
            if (sicktunes != null)
            {
                sicktunes.Open(new Uri("sound/carlkojima40sec.mp3", UriKind.Relative));
                sicktunes.MediaEnded += new EventHandler(Song2Short);
                sicktunes.Play();
                return;
            }
        }
        
        private void Song2Short(object sender, EventArgs e)
        {
            sicktunes.Open(new Uri("sound/carlkojima40sec.mp3", UriKind.Relative));
            sicktunes.Play();
        }
            
        public void GameOver()
        {
            sicktunes.Stop();
            MediaPlayer sucksYouLost = new MediaPlayer();
            sucksYouLost.Open(new Uri("sound/carlkojima5sec.mp3", UriKind.Relative));
            sucksYouLost.Play();
            System.Threading.Thread.Sleep(5000);
            SickBGMusic();
            
        }
    }
}
