using System;
using System.Windows;
using System.Windows.Media;
using notTris;

namespace notTris
{
    public class NotaMino
    {
        private Point minoPos;
        private Point[] minoShape;
        private Brush minoClr;
        private bool spin;
        private int ident;

        Random rng = new Random();
        ImgRsrc getImg = new ImgRsrc();

        public NotaMino()
        {
            minoPos = new Point(0, -1);
            minoClr = Brushes.Transparent;
            minoShape = RandomMino();
        }

        public Brush GetMinoClr()
        {
            return minoClr;
        }
        public Point GetMinoPos()
        {
            return minoPos;
        }
        public Point[] GetMinoShape()
        {
            return minoShape;
        }

        private Point[] RandomMino()
        {
            switch (rng.Next(1,8))
            {
                case 1: // I
                    DrawI();
                    minoShape = DrawI();
                    break;
                case 2: // J
                    DrawJ();
                    minoShape = DrawJ();
                    break;
                case 3: // L
                    DrawL();
                    minoShape = DrawL();
                    break;
                case 4: // O
                    DrawO();
                    minoShape = DrawO();
                    break;
                case 5: // T
                    DrawT();
                    minoShape = DrawT();
                    break;
                case 6: // S
                    DrawS();
                    minoShape = DrawS();
                    break;
                case 7: // Z 
                    DrawZ();
                    minoShape = DrawZ();
                    break;
            }

            return minoShape;
        }

        // DRAWING MINOS
        public Point[] DrawI()
        { // I
            spin = true;
            ident = 1;
            minoClr = getImg.GetMinoBrush(ident);
            return new Point[]
            {
                new Point(0,-1),
                new Point(-1,-1),
                new Point(1,-1),
                new Point(2,-1)
            };
        }

        public Point[] DrawJ()
        { // J
            spin = true;
            ident = 2;
            minoClr = getImg.GetMinoBrush(ident);
            return new Point[]
            {
                new Point(-1,-1),
                new Point(-1,0),
                new Point(0,0),
                new Point(1,0)
            };
        }

        public Point[] DrawL()
        { // L
            spin = true;
            ident = 3;
            minoClr = getImg.GetMinoBrush(ident);
            return new Point[]
            {
                new Point(0,0),
                new Point(-1,0),
                new Point(1,0),
                new Point(1,-1)
            };
        }

        public Point[] DrawO()
        { // O
            spin = false;
            ident = 4;
            minoClr = getImg.GetMinoBrush(ident);
            return new Point[]
            {
                new Point(0,0),
                new Point(0,-1),
                new Point(1,0),
                new Point(1,-1)
            };
        }

        public Point[] DrawT()
        { // T
            spin = true;
            ident = 5;
            minoClr = getImg.GetMinoBrush(ident);
            return new Point[]
            {
                new Point(0,0),
                new Point(-1,0),
                new Point(0,-1),
                new Point(1,0)
            };
        }

        public Point[] DrawS()
        { // S
            spin = true;
            ident = 6;
            minoClr = getImg.GetMinoBrush(ident);
            return new Point[]
            {
                new Point(0,0),
                new Point(-1,0),
                new Point(0,-1),
                new Point(1,-1)
            };
        }

        public Point[] DrawZ()
        { // Z
            spin = true;
            ident = 7;
            minoClr = getImg.GetMinoBrush(ident);
            return new Point[]
            {
                new Point(0,-1),
                new Point(-1,-1),
                new Point(0,0),
                new Point(1,0)
            };
        }

        public void MoveLeft()
        {
            minoPos.X -= 1;
        }

        public void MoveRight()
        {
            minoPos.X += 1;
        }

        public void MoveDown()
        {
            minoPos.Y += 1;
        }

        public void Spin()
        {
            if (spin)
            {

                for (int i = 0; i < minoShape.Length; i++)
                {
                    double x = minoShape[i].X;
                    minoShape[i].X = minoShape[i].Y * -1;
                    minoShape[i].Y = x;
                }
            }
        }
    }
}




