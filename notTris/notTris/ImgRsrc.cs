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
    class ImgRsrc
    {
        public static Brush GetMenuImg()
        {
            ImageBrush menuimg = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(@"gui/menu.png", UriKind.Relative))
            };
            return menuimg;
        }

        public static Brush GetBgImg()
        {
            ImageBrush background = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(@"gui/background.png", UriKind.Relative))
            };
            return background;
        }

        public static Brush GetGameOverImg()
        {
            ImageBrush background = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(@"gui/gameover.png", UriKind.Relative))
            };
            return background;
        }

        public static Brush GetMatrixBg()
        {
            ImageBrush matrix = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(@"gui/matrix.png", UriKind.Relative))
            };
            return matrix;
        }

        public Brush GetMinoBrush(int ident)
        {
            ImageBrush TIO = new ImageBrush
            {
                ImageSource =
            new BitmapImage(new Uri(@"gui/tionew.png", UriKind.Relative))
            };

            ImageBrush JS = new ImageBrush
            {
                ImageSource =
            new BitmapImage(new Uri(@"gui/jsnew.png", UriKind.Relative))
            };

            ImageBrush LZ = new ImageBrush
            {
                ImageSource =
            new BitmapImage(new Uri(@"gui/lznew.png", UriKind.Relative))
            };


            switch (ident)
            {
                case 1: // I
                    return TIO;
                case 2: // J
                    return JS;
                case 3: // L
                    return LZ;
                case 4: // O
                    return TIO;
                case 5: // T
                    return TIO;
                case 6: // S
                    return JS;
                case 7: // Z 
                    return LZ;
                default:
                    return null;
            }
        }
    }
}
