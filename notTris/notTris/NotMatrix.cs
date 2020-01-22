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
    public class NotMatrix 
    {
        readonly private int rows;
        readonly private int columns;

        private bool gameover;
        private int score;
        private int lines;
        private int level;

        public bool GetGameState()
        {
            return gameover;
        }

        public int GetRows()
        {
            return rows;
        }

        public int GetColumns()
        {
            return columns;
        }
        
        public int GetScore()
        {
            return score;
        }

        public int GetLines()
        {
            return lines;
        }

        public int GetLevel()
        {
            return level;
        }
        
        private NotaMino currentMino;
        readonly private Label[,] controllers;
        readonly private Brush nothing = Brushes.Transparent;

        public NotMatrix(Grid NotaMatrix)
        {
            rows = NotaMatrix.RowDefinitions.Count;       
            columns = NotaMatrix.ColumnDefinitions.Count;
            score = 0;
            lines = 0;
            level = 1;
            gameover = false;

            controllers = new Label[columns, rows];     
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    controllers[i, j] = new Label();
                    Grid.SetRow(controllers[i, j], j);     
                    Grid.SetColumn(controllers[i, j], i);
                    NotaMatrix.Children.Add(controllers[i, j]);
                }
            }
            currentMino = new NotaMino();    
            DrawCurrMino();                
        }

        private void DrawCurrMino()
        {
            Point minoPos = currentMino.GetMinoPos();
            Point[] minoShape = currentMino.GetMinoShape();
            Brush minoClr = currentMino.GetMinoClr();
            foreach (Point block in minoShape) 
            {
                controllers[(int)(block.X + minoPos.X) + ((columns / 2) - 1), (int)(block.Y + minoPos.Y) + 2].Background = minoClr;
            }

        }

        private void DeleteMino()
        {
            Point minoPos = currentMino.GetMinoPos();
            Point[] minoShape = currentMino.GetMinoShape();
        
            foreach (Point block in minoShape)
            {
                controllers[(int)(block.X + minoPos.X) + ((columns / 2) - 1), (int)(block.Y + minoPos.Y) + 2].Background = nothing; 
            }
        }

        private void RowCheck()
        {
            bool full;

            for (int i = rows - 1; i > 0; i--)
            {
                full = true;
                for (int j = 0; j < columns; j++)
                {
                    if (controllers[j, i].Background == nothing)
                    {
                        full = false;
                    }
                }
                if (full) 
                {
                    ClearRow(i);

                    
                    score += 100;
                    lines += 1;
                    level = 1 + (lines / 10);
                    i++;
                }
            }
        }

        private void ClearRow(int row)
        {
            for (int i = row; i > 2; i--)
            {
                for (int j = 0; j < columns; j++)
                {
                    controllers[j, i].Background = controllers[j, i - 1].Background;
                }
            }
        }

        public void MinoMoveLeft()
        {
            Point minoPos = currentMino.GetMinoPos();
            Point[] minoShape = currentMino.GetMinoShape();
            bool move = true;

            DeleteMino(); 

            foreach (Point block in minoShape)
            {
                if (((int)(block.X + minoPos.X) + ((columns / 2) - 1) - 1) < 0)
                {
                    move = false;
                }

                else if (controllers[((int)(block.X + minoPos.X) + ((columns / 2) - 1) - 1), (int)(block.Y + minoPos.Y) + 2].Background != nothing)
                {
                    move = false;
                }
            }

            if (move)
            {
                currentMino.MoveLeft();
                DrawCurrMino();
            }

            else
            {
                DrawCurrMino();
            }
        }

        public void MinoMoveRight()
        {
            Point minoPos = currentMino.GetMinoPos();
            Point[] minoShape = currentMino.GetMinoShape();
            bool move = true;

            DeleteMino();

            foreach (Point block in minoShape)
            {
                if (((int)(block.X + minoPos.X) + ((columns / 2) - 1) + 1) >= columns)
                {
                    move = false;
                }
                else if (controllers[((int)(block.X + minoPos.X) + ((columns / 2) - 1) + 1), (int)(block.Y + minoPos.Y) + 2].Background != nothing)
                {
                    move = false;
                }
            }
            if (move)
            {
                currentMino.MoveRight();
                DrawCurrMino();
            }
            else
            {
                DrawCurrMino();
            }
        }

        public void MinoMoveDown()
        {
            Point minoPos = currentMino.GetMinoPos();
            Point[] minoShape = currentMino.GetMinoShape();
            bool move = true;

            DeleteMino();

            foreach (Point block in minoShape)
            {
                if (((int)(block.Y + minoPos.Y) + 2 + 1) >= rows) 
                {
                    move = false;
                }
                else if (controllers[((int)(block.X + minoPos.X) + ((columns / 2) - 1)), (int)(block.Y + minoPos.Y) + 2 + 1].Background != nothing) 
                {
                    move = false;
                    if (((int)(block.Y + minoPos.Y) + 2 + 1) <= 1)
                    {
                        gameover = true;
                    }
                }
            }
            if (move)
            {
                currentMino.MoveDown();
                DrawCurrMino();
            }
            else
            {
                DrawCurrMino();
                RowCheck(); 
                currentMino = new NotaMino();
            }
        }
        
        public void MinoSpin()
        {
            Point minoPos = currentMino.GetMinoPos();
            Point[] mino = new Point[4];
            Point[] minoShape = currentMino.GetMinoShape();
            bool move = true;

            minoShape.CopyTo(mino, 0);

            DeleteMino();

            for (int i = 0; i < mino.Length; i++)
            {
                double x = mino[i].X;
                mino[i].X = mino[i].Y * -1;
                mino[i].Y = x;
                if (((int)((mino[i].Y + minoPos.Y) + 2)) >= rows) 
                {
                    move = false;
                }
                else if (((int)(mino[i].X + minoPos.X) + ((columns / 2) - 1)) < 0) 
                {
                    move = false;
                }
                else if (((int)(mino[i].X + minoPos.X) + ((columns / 2) - 1)) >= columns)
                {
                    move = false;
                }
                else if (controllers[((int)(mino[i].X + minoPos.X) + ((columns / 2) - 1)), (int)(mino[i].Y + minoPos.Y) + 2].Background != nothing)
                {
                    move = false;
                }
            }
            if (move)
            {
                currentMino.Spin();
                DrawCurrMino();
            }
            else
            {
                DrawCurrMino();
            }
        }
    }
}
