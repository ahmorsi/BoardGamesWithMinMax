using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;

namespace BoardGameProject
{
    static class GUI
    {
        #region variables

        private static Control CtrlBG;
        private static List<PictureBox> Hovered = new List<PictureBox>();

        // Fourms
        public static PlayerSelect PlayerSelectForm;
        public static Main_Menu GamesMenu;
        public static gameForm GamesForm;
        public static PlayerMode PlayerModeForm;

        #endregion

        public static void SetGUI()
        {
            PlayerModeForm = new PlayerMode();
            GamesForm = new gameForm();
            GamesMenu = new Main_Menu();
            PlayerSelectForm = new PlayerSelect();

            CtrlBG = PlayerModeForm;

            new Thread(() =>
                {
                    backColor();
                }).Start();
        }

        public static void SetCtrlBG(Control _CtrlBG)
        {
            CtrlBG = _CtrlBG;
        }

        public static void Toggle(Control C , Bitmap B)
        {
            new Thread(() =>
                {
                    int X = C.Width;
                    while (C.Width > 0)
                    {
                        C.Top++;
                        C.Left++;
                        C.Width-=2;
                        C.Height-=2;
                    }
                    C.BackgroundImage = B;
                    while (C.Width < X)
                    {
                        C.Top--;
                        C.Left--;
                        C.Width+=2;
                        C.Height+=2;
                    }
                }).Start();
        }

        public static void MakeBigger(int Width, int Height, PictureBox P)
        {
            if (!Hovered.Contains(P))
            {
                double HR = (double)Height / (double)Width, WR = (double)Width / (double)Height;
                int HI, WI;

                if (HR < WR)
                {
                    HI = 2;
                    WI = Convert.ToInt32(2 * WR);
                }
                else
                {
                    WI = 2;
                    HI = Convert.ToInt32(2 * HR);
                }

                while (P.Width < Width + 10)
                {
                    P.Width += WI;
                    P.Height += HI;
                    P.Top -= HI / 2;
                    P.Left -= WI / 2;
                }
                Hovered.Add(P);
            }
        }


        public static void MakeSmaller(int Width, int Height, PictureBox P)
        {
            if (Hovered.Contains(P))
            {
                double HR = (double)Height / (double)Width, WR = (double)Width / (double)Height;
                int HI, WI;

                if (HR < WR)
                {
                    HI = 2;
                    WI = Convert.ToInt32(2 * WR);
                }
                else
                {
                    WI = 2;
                    HI = Convert.ToInt32(2 * HR);
                }

                while (P.Width > Width - 10)
                {
                    P.Width -= WI;
                    P.Height -= HI;
                    P.Top += HI / 2;
                    P.Left += WI / 2;
                }
                Hovered.Remove(P);
            }
        }

        public static void backColor()
        {
            while (true)
            {
                int X = 3;
                int delay = 100;
                for (int i = 180; i < 255; i += X)
                {
                    CtrlBG.BackColor = Color.FromArgb(255, 180, i);
                    CtrlBG.Refresh();
                    Thread.Sleep(delay);
                }

                for (int i = 255; i >= 180; i -= X)
                {
                    CtrlBG.BackColor = Color.FromArgb(i, 180, 255);
                    CtrlBG.Refresh();
                    Thread.Sleep(delay);
                }

                for (int i = 180; i < 255; i += X)
                {
                    CtrlBG.BackColor = Color.FromArgb(180, i, 255);
                    CtrlBG.Refresh();
                    Thread.Sleep(delay);
                }

                for (int i = 255; i >= 180; i -= X)
                {
                    CtrlBG.BackColor = Color.FromArgb(180, 255, i);
                    CtrlBG.Refresh();
                    Thread.Sleep(delay);
                }

                for (int i = 180; i < 255; i += X)
                {
                    CtrlBG.BackColor = Color.FromArgb(i, 255, 180);
                    CtrlBG.Refresh();
                    Thread.Sleep(delay);
                }

                for (int i = 255; i >= 180; i -= X)
                {
                    CtrlBG.BackColor = Color.FromArgb(255, i, 180);
                    CtrlBG.Refresh();
                    Thread.Sleep(delay);
                }
            }
        }

        
    }
}
