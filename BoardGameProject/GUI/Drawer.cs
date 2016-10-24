using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace BoardGameProject
{
    static class Drawer
    {
        public static Dictionary<char, Bitmap> ChessUnitPicture = new Dictionary<char, Bitmap>();
        private static Graphics G;
        private static Bitmap BoardBackground;

        public static void setDrawer()
        {
            //Capital For White
            ChessUnitPicture['K'] = Properties.Resources.KingW;
            ChessUnitPicture['Q'] = Properties.Resources.QuenW;
            ChessUnitPicture['B'] = Properties.Resources.BishopW;
            ChessUnitPicture['N'] = Properties.Resources.KnightW;
            ChessUnitPicture['R'] = Properties.Resources.RookW;
            ChessUnitPicture['P'] = Properties.Resources.PawnW;
            //Small For Balck
            ChessUnitPicture['k'] = Properties.Resources.KingB;
            ChessUnitPicture['q'] = Properties.Resources.QuenB;
            ChessUnitPicture['b'] = Properties.Resources.BishopB;
            ChessUnitPicture['n'] = Properties.Resources.KnightB;
            ChessUnitPicture['r'] = Properties.Resources.RookB;
            ChessUnitPicture['p'] = Properties.Resources.PawnB;
        }

        public static void setBackGround(Bitmap Bit)
        {
            BoardBackground = Bit;
            G = Graphics.FromImage(Bit);
        }

        private static void MainDrawer(Bitmap BITX, int i, int j, int cellSize)
        {
            G.DrawImage(BITX, i , j, cellSize, cellSize);
        }

        public static void DrawImg(Bitmap BITX, int i, int j, int cellSize, Control C)
        {
            MainDrawer(BITX, i * cellSize, j * cellSize, cellSize);
            C.BackgroundImage = BoardBackground;
            C.Refresh();
        }

        public static void ClearImg(Bitmap White, Bitmap Black, int i, int j, int cellSize, Control C)
        {
            if ((i + j) % 2 == 0)
                MainDrawer(White, i * cellSize, j * cellSize, cellSize);
            else
                MainDrawer(Black, i * cellSize, j * cellSize, cellSize);
            C.BackgroundImage = BoardBackground;
            C.Refresh();
        }

        public static void DrawBoard(Bitmap White, Bitmap Black, int X, int Y, int cellSize, Control C)
        {
            Bitmap tempBitmap = White;
            G.Clear(Color.Transparent);

            for (int i = X; i < 500; i += cellSize)
            {
                for (int j = Y; j < 500; j += cellSize)
                {
                    MainDrawer(tempBitmap, i, j , cellSize);

                    if (tempBitmap == White)
                        tempBitmap = Black;
                    else
                        tempBitmap = White;
                }
                if (tempBitmap == White)
                    tempBitmap = Black;
                else
                    tempBitmap = White;
            }
            C.BackgroundImage = BoardBackground;
            C.Refresh();
        }

        public static void DrawImgWithShift(Bitmap BITX, int i, int shiftI, int j, int shiftJ, int cellSize, Control C)
        {
            MainDrawer(BITX, i * cellSize + shiftI, j * cellSize + shiftJ, cellSize);
            C.BackgroundImage = BoardBackground;
            C.Refresh();
        }

        public static void ClearImgWithShift(Bitmap BITX1, Bitmap BITX2, int i, int shiftI, int j, int shiftJ, int cellSize, Control C)
        {
            ClearImg(BITX1, BITX2, i * cellSize + shiftI, j * cellSize + shiftJ, cellSize , C);
            C.BackgroundImage = BoardBackground;
            C.Refresh();
        }

        public static void DrawImgHoverListChess(List<KeyValuePair<Point, char>> pntList, int cellSize, Control C)
        {
            foreach (KeyValuePair<Point, char> K in pntList)
            {
                if (K.Value == '\0')
                    MainDrawer(Properties.Resources.hover, K.Key.Y * cellSize, K.Key.X * cellSize, cellSize);
                else
                {
                    MainDrawer(Properties.Resources.attack, K.Key.Y * cellSize, K.Key.X * cellSize, cellSize);
                    MainDrawer(Drawer.ChessUnitPicture[K.Value], K.Key.Y * cellSize, K.Key.X * cellSize, cellSize);
                }
            }
            C.BackgroundImage = BoardBackground;
            C.Refresh();
        }

        public static void ClearImgHoverListChess(List<KeyValuePair<Point, char>> pntList, int cellSize, Control C)
        {
            foreach (KeyValuePair<Point, char> K in pntList)
            {
                if ((K.Key.X + K.Key.Y) % 2 == 0)
                    MainDrawer(Properties.Resources.ChessWhite, K.Key.Y * cellSize, K.Key.X * cellSize, cellSize);
                else
                    MainDrawer(Properties.Resources.ChessBlack, K.Key.Y * cellSize, K.Key.X * cellSize, cellSize);

                if (K.Value != '\0')
                    DrawImg(Drawer.ChessUnitPicture[K.Value], K.Key.Y, K.Key.X, cellSize, C);
            }
        }

    }
}
