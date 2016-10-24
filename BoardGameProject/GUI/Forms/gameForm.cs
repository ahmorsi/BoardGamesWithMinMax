using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace BoardGameProject
{
    public partial class gameForm : Form, TennoXO, TennoC4, TennoReversi, TennoCheckers, TennoChess
    {
        Timers T1, T2;
        bool ComputerPlay;
        private Bitmap BoardBackground, MY_BITMAB;
        private Point Current_Click;
        private const int reversiUnitSize = 68, C4UnitSize = 75, XOUnitSize = 181, CheckerUnitSize = 68, ChessUnitSize = 68;
        private List<PictureBox> CellBoards;

        public void SetPlayersName()
        {
            lbl_Player_1_name.Text = Program.Controller.getFirstPlayer().getName();
            lbl_Player_2_name.Text = Program.Controller.getSecondPlayer().getName();
        }

        public void StartGame()
        {
            listBox1.Items.Clear();
            T1.Reset();
            T2.Reset();
            T1.Start();
            T2.Stop();
        }

        public gameForm()
        {
            ComputerPlay = false;

            InitializeComponent();

            T1 = new Timers(lbl_Player_1_timer);
            T2 = new Timers(lbl_Player_2_timer);

            #region setting form

            CellBoards = new List<PictureBox>();
            CellBoards.Add(pic_board_cells_reversi);
            CellBoards.Add(pic_board_cells_C4);
            CellBoards.Add(pic_board_cells_XO);
            CellBoards.Add(pic_board_cells_Checkers);
            CellBoards.Add(pic_board_cells_Chess);

            BoardBackground = new Bitmap(545, 545);
            Drawer.setBackGround(BoardBackground);

            pic_board_cells_reversi.Top = 1 + pic_back_board.Height / 2 - pic_board_cells_reversi.Height / 2;
            pic_board_cells_reversi.Left = 1 + pic_back_board.Width / 2 - pic_board_cells_reversi.Width / 2;

            pic_board_cells_C4.Top = 1 + pic_back_board.Height / 2 - pic_board_cells_C4.Height / 2;
            pic_board_cells_C4.Left = 1 + pic_back_board.Width / 2 - pic_board_cells_C4.Width / 2;

            pic_board_cells_XO.Top = 1 + pic_back_board.Height / 2 - pic_board_cells_XO.Height / 2;
            pic_board_cells_XO.Left = 1 + pic_back_board.Width / 2 - pic_board_cells_XO.Width / 2;

            pic_board_cells_Checkers.Top = 1 + pic_back_board.Height / 2 - pic_board_cells_Checkers.Height / 2;
            pic_board_cells_Checkers.Left = 1 + pic_back_board.Width / 2 - pic_board_cells_Checkers.Width / 2;

            pic_board_cells_Chess.Top = 1 + pic_back_board.Height / 2 - pic_board_cells_Chess.Height / 2;
            pic_board_cells_Chess.Left = 1 + pic_back_board.Width / 2 - pic_board_cells_Chess.Width / 2;

            pic_back_board.Controls.Add(pic_board_cells_reversi);
            pic_back_board.Controls.Add(pic_board_cells_C4);
            pic_back_board.Controls.Add(pic_board_cells_XO);
            pic_back_board.Controls.Add(pic_board_cells_Checkers);
            pic_back_board.Controls.Add(pic_board_cells_Chess);

            pic_player_1.Controls.Add(pic_player_1_pic);
            pic_player_1_pic.BringToFront();
            pic_player_1_pic.Top = 6;
            pic_player_1_pic.Left = 6;

            pic_player_1.Controls.Add(lbl_Player_1_name);
            lbl_Player_1_name.BringToFront();
            lbl_Player_1_name.Top = 45;
            lbl_Player_1_name.Left = 100;

            pic_player_1.Controls.Add(pictureBox_timer_1);
            pictureBox_timer_1.BringToFront();
            pictureBox_timer_1.Top = 0;
            pictureBox_timer_1.Left = 97;

            pictureBox_timer_1.Controls.Add(lbl_Player_1_timer);
            lbl_Player_1_timer.BringToFront();
            lbl_Player_1_timer.Top = pictureBox_timer_1.Height / 2 - lbl_Player_1_timer.Height / 2;
            lbl_Player_1_timer.Left = pictureBox_timer_1.Width / 2 - lbl_Player_1_timer.Width / 2;

            pic_player_2.Controls.Add(pic_player_2_pic);
            pic_player_2_pic.BringToFront();
            pic_player_2_pic.Top = 6;
            pic_player_2_pic.Left = 186;

            pic_player_2.Controls.Add(lbl_Player_2_name);
            lbl_Player_2_name.BringToFront();
            lbl_Player_2_name.Top = 45;
            lbl_Player_2_name.Left = 10;

            pic_player_2.Controls.Add(pictureBox_timer_2);
            pictureBox_timer_2.BringToFront();
            pictureBox_timer_2.Top = 0;
            pictureBox_timer_2.Left = 0;

            pictureBox_timer_2.Controls.Add(lbl_Player_2_timer);
            lbl_Player_2_timer.BringToFront();
            lbl_Player_2_timer.Top = pictureBox_timer_2.Height / 2 - lbl_Player_2_timer.Height / 2;
            lbl_Player_2_timer.Left = pictureBox_timer_2.Width / 2 - lbl_Player_2_timer.Width / 2;

            Pause_panel.Hide();
            Pause_panel.Top = 0;
            Pause_panel.Left = 0;
            Pause_panel.Width = 1366;
            Pause_panel.Height = 800;

            Pause_ptn_2.Top = (788 - 343) / 2;
            Pause_ptn_2.Left = (1366 - 343) / 2;
            Pause_ptn_2.Width = 343;
            Pause_ptn_2.Height = 343;

            #endregion

        }

        private void pic_MainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();

            GUI.GamesMenu.Show();
            GUI.SetCtrlBG(GUI.GamesMenu);

            T1.Reset();
            T2.Reset();
            //  reset game
        }

        public void switchPlayer()
        {
            if (T1.state())
            {
                T1.Stop();
                T2.Start();
                pic_player.BackgroundImage = Properties.Resources.player_selector_right;
            }
            else
            {
                T2.Stop();
                T1.Start();
                pic_player.BackgroundImage = Properties.Resources.player_selector_left;
            }
        }

        private void pic_music_Click(object sender, EventArgs e)
        {
            if (Sound.getBackMusicStatus())
            {
                Sound.stopMusic();
                pic_music.BackgroundImage = Properties.Resources.NoMusic;
            }
            else
            {
                Sound.playMusic();
                pic_music.BackgroundImage = Properties.Resources.Music;
            }
        }

        private void pic_eff_Click(object sender, EventArgs e)
        {
            if (Sound.getEffectsStatus())
            {
                Sound.stopEffects();
                pic_eff.BackgroundImage = Properties.Resources.NoSoundEffects;
            }
            else
            {
                Sound.playEffects();
                pic_eff.BackgroundImage = Properties.Resources.SoundEffects;
            }
        }

        private void setForGame(PictureBox PicBox)
        {
            pic_player.BackgroundImage = Properties.Resources.player_selector_left;

            foreach (PictureBox PB in CellBoards)
                PB.Hide();
            PicBox.Show();
        }

        private void pic_NewGame_Click(object sender, EventArgs e)
        {
            Program.Controller.getCurrentGame().reSet();
        }

        // --------------------------- hover events ---------------------------
        private void pic_MainMenu_MouseHover(object sender, EventArgs e)
        {
            Sound.playHover();
            GUI.MakeBigger(((PictureBox)sender).Width, ((PictureBox)sender).Height, (PictureBox)sender);
        }

        private void pic_MainMenu_MouseLeave(object sender, EventArgs e)
        {
            GUI.MakeSmaller(((PictureBox)sender).Width, ((PictureBox)sender).Height, (PictureBox)sender);
        }

        // --------------------------- click events ---------------------------
        
        private void pic_board_cells_C4_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Y / C4UnitSize < 0 || e.Y / C4UnitSize > 6|| e.X / C4UnitSize < 0 || e.X / C4UnitSize > 6)
                return;
            Current_Click = new Point(e.Y / C4UnitSize, e.X / C4UnitSize);
            Program.Controller.Click(e.Y / C4UnitSize, e.X / C4UnitSize);

            if (ComputerPlay)
            {
                Point move = Program.Controller.getCurrentgame().getSecondPlayer().Apply_Strategy(Program.Controller.getCurrentgame().getGameState());
                Program.Controller.Click(move.X, move.Y);
                ComputerPlay = false;
            }
        }

        private void pic_board_cells_reversi_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Y / reversiUnitSize < 0 || e.Y / reversiUnitSize > 7 || e.X / reversiUnitSize < 0 || e.X / reversiUnitSize > 7)
                return;
            Current_Click = new Point(e.Y / reversiUnitSize, e.X / reversiUnitSize);
            Program.Controller.Click(e.Y / reversiUnitSize, e.X / reversiUnitSize);
            if (ComputerPlay)
            {
                Point move = Program.Controller.getCurrentgame().getSecondPlayer().Apply_Strategy(Program.Controller.getCurrentgame().getGameState());
                Program.Controller.Click(move.X, move.Y);
                ComputerPlay = false;
            }
        }
        
        private void pic_board_cells_XO_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Y / XOUnitSize < 0 || e.Y / XOUnitSize > 2 || e.X / XOUnitSize < 0 || e.X / XOUnitSize > 2)
                return;

            Current_Click = new Point(e.Y / XOUnitSize, e.X / XOUnitSize);
            Program.Controller.Click(e.Y / XOUnitSize, e.X / XOUnitSize);
            
            if (ComputerPlay)
            {
                Point move = Program.Controller.getCurrentgame().getSecondPlayer().Apply_Strategy(Program.Controller.getCurrentgame().getGameState());
                Program.Controller.Click(move.X, move.Y);
                ComputerPlay = false;
            }
                
        }

        private void pic_board_cells_Checkers_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Y / CheckerUnitSize < 0 || e.Y / CheckerUnitSize > 7 || e.X / CheckerUnitSize < 0 || e.X / CheckerUnitSize > 7)
                return;
            Current_Click = new Point(e.Y / CheckerUnitSize, e.X / CheckerUnitSize);
            Program.Controller.Click(e.Y / CheckerUnitSize, e.X / CheckerUnitSize);
        }

        private void pic_board_cells_Chess_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Y / ChessUnitSize < 0 || e.Y / ChessUnitSize > 7 || e.X / ChessUnitSize < 0 || e.X / ChessUnitSize > 7)
                return;
            Current_Click = new Point(e.Y / ChessUnitSize, e.X / ChessUnitSize);
            Program.Controller.Click(e.Y / ChessUnitSize, e.X / ChessUnitSize);
        }

        // --------------------------- interfaces imp ---------------------------

        #region Reverci interfaces

        public void UpdateReversi(List<Point> pnt)
        {
            Sound.playUnit();
            if (Program.Controller.GetMainPlayer().IsMyTurn())
            {
                MY_BITMAB = Properties.Resources.RedS;
                listBox1.Items.Add(lbl_Player_1_name.Text + ": " + (char)('A' + Current_Click.Y) + ", " + (8 - Current_Click.X));
            }
            else
            {
                MY_BITMAB = Properties.Resources.BlackS;
                listBox1.Items.Add(lbl_Player_2_name.Text + ": " + (char)('A' + Current_Click.Y) + ", " + (8 - Current_Click.X ));
            }

            foreach (Point P in pnt)
                Drawer.DrawImg(MY_BITMAB, P.Y, P.X, reversiUnitSize, pic_board_cells_reversi);

        }

        public void IntializeReversi()
        {
            StartGame();
            setForGame(pic_board_cells_reversi);

            int temp1 = (int)((pic_board_cells_reversi.Width - (reversiUnitSize * 8)) / 2);
            int temp2 = (int)((pic_board_cells_reversi.Width - (reversiUnitSize * 8)) / 2);

            Drawer.DrawBoard(Properties.Resources.ChessBlack, Properties.Resources.ChessBlack, temp1, temp2, reversiUnitSize, pic_board_cells_reversi);

            pic_back_board.BackgroundImage = Properties.Resources.Board_chess;

            Drawer.DrawImg(Properties.Resources.RedS, 3, 3, reversiUnitSize, pic_board_cells_reversi);
            Drawer.DrawImg(Properties.Resources.RedS, 4, 4, reversiUnitSize, pic_board_cells_reversi);
            Drawer.DrawImg(Properties.Resources.BlackS, 3, 4, reversiUnitSize, pic_board_cells_reversi);
            Drawer.DrawImg(Properties.Resources.BlackS, 4, 3, reversiUnitSize, pic_board_cells_reversi);
        }

        #endregion

        #region Connect4 interfaces

        public void IntializeConnect4()
        {
            StartGame();
            setForGame(pic_board_cells_C4);

            int temp1 = (int)((545 - (75 * 7)) / 2);
            int temp2 = (int)((545 - (75 * 5)) / 2);

            Drawer.DrawBoard(Properties.Resources.UNIT_BACK_C4, Properties.Resources.UNIT_BACK_C4, temp1, temp2, C4UnitSize, pic_board_cells_C4);

            Graphics.FromImage(BoardBackground).FillRectangle(new SolidBrush(Color.FromArgb(66, 33, 2)), 0, temp2, temp1, 545);
            Graphics.FromImage(BoardBackground).FillRectangle(new SolidBrush(Color.FromArgb(66, 33, 2)), 545 - temp1, temp2, temp1, 545);
            Graphics.FromImage(BoardBackground).FillRectangle(new SolidBrush(Color.FromArgb(66, 33, 2)), 0, 545 - temp1, 545, temp1 + 90);

            pic_back_board.BackgroundImage = Properties.Resources.Board_C4;
        }

        public void updateConnect4(Point pnt)
        {
            Sound.playUnit();
            if (Program.Controller.GetMainPlayer().IsMyTurn())
            {
                MY_BITMAB = Properties.Resources.RedB;
                listBox1.Items.Add(lbl_Player_1_name.Text + ": " + (char)('A' + pnt.Y) + ", " + (6 - pnt.X ));
            }
            else
            {
                MY_BITMAB = Properties.Resources.YellowB;
                listBox1.Items.Add(lbl_Player_2_name.Text + ": " + (char)('A' + pnt.Y) + ", " + (6 - pnt.X));
            }

            int temp1 = (int)((545 - (C4UnitSize * 7)) / 2);
            int temp2 = (int)((545 - (C4UnitSize * 5)) / 2);

            Drawer.DrawImgWithShift(MY_BITMAB, pnt.Y, temp1, pnt.X, temp2, C4UnitSize, pic_board_cells_C4);

            if (Program.Controller.getSecondPlayer().getName() == "Computer")
            {
                ComputerPlay = true;
            }
        }

        #endregion

        #region Checkers interface

        public void IntializeCheckers()
        {
            StartGame();
            setForGame(pic_board_cells_Checkers);

            int temp1 = (int)((pic_board_cells_Checkers.Width - (CheckerUnitSize * 8)) / 2);
            int temp2 = (int)((pic_board_cells_Checkers.Width - (CheckerUnitSize * 8)) / 2);
            Drawer.DrawBoard(Properties.Resources.ChessWhite, Properties.Resources.ChessBlack, temp1, temp2, CheckerUnitSize, pic_board_cells_Checkers);
            pic_back_board.BackgroundImage = Properties.Resources.Board_chess;
            
            for (int i = 0; i < 8; i++)
            {
                if (i % 2 == 0)
                {
                    Drawer.DrawImg(Properties.Resources.BlackS, i , 1 , CheckerUnitSize, pic_board_cells_Checkers);
                    Drawer.DrawImg(Properties.Resources.RedS, i , 5 , CheckerUnitSize, pic_board_cells_Checkers);
                    Drawer.DrawImg(Properties.Resources.RedS, i, 7, CheckerUnitSize, pic_board_cells_Checkers);
                }
                else
                {
                    Drawer.DrawImg(Properties.Resources.BlackS, i, 0, CheckerUnitSize, pic_board_cells_Checkers);
                    Drawer.DrawImg(Properties.Resources.BlackS, i, 2, CheckerUnitSize, pic_board_cells_Checkers);
                    Drawer.DrawImg(Properties.Resources.RedS, i, 6, CheckerUnitSize, pic_board_cells_Checkers);
                }
            }
        }

        public void DeleteChecker(Point Killed)
        {
            Drawer.DrawImg(Properties.Resources.ChessBlack, Killed.Y, Killed.X, CheckerUnitSize, pic_board_cells_Checkers);
        }

        public void MoveChecker(Point KillerFrom, Point KillerTo, bool King)
        {
            Sound.playUnit();
            DeleteChecker(KillerFrom);

            if (Program.Controller.GetMainPlayer().IsMyTurn())
            {
                if (King)
                    Drawer.DrawImg(Properties.Resources.RedSK, KillerTo.Y , KillerTo.X , CheckerUnitSize, pic_board_cells_Checkers);
                else
                    Drawer.DrawImg(Properties.Resources.RedS, KillerTo.Y , KillerTo.X , CheckerUnitSize, pic_board_cells_Checkers);
            }
            else
            {
                if (King)
                    Drawer.DrawImg(Properties.Resources.BlackSK, KillerTo.Y , KillerTo.X , CheckerUnitSize, pic_board_cells_Checkers);
                else
                    Drawer.DrawImg(Properties.Resources.BlackS, KillerTo.Y , KillerTo.X , CheckerUnitSize, pic_board_cells_Checkers);
            }
            listBox1.Items.Add(((Program.Controller.getFirstPlayer().IsMyTurn())? lbl_Player_1_name.Text : lbl_Player_2_name.Text) + ": " + (char)('A' + KillerFrom.Y) + ", " + (8 - KillerFrom.X) + "|" + (char)('A' + KillerTo.Y) + ", " + (8 - KillerTo.X));
        }

        public void ShadowSelectedChecker(Point Selected, bool King)
        {
            Drawer.DrawImg(Properties.Resources.selected, Selected.Y , Selected.X , CheckerUnitSize, pic_board_cells_Checkers);

            if (Program.Controller.GetMainPlayer().IsMyTurn())
            {
                if (King)
                    Drawer.DrawImg(Properties.Resources.RedSK, Selected.Y , Selected.X , CheckerUnitSize, pic_board_cells_Checkers);
                else
                    Drawer.DrawImg(Properties.Resources.RedS, Selected.Y , Selected.X , CheckerUnitSize, pic_board_cells_Checkers);
            }
            else
            {
                if (King)
                    Drawer.DrawImg(Properties.Resources.BlackSK, Selected.Y , Selected.X , CheckerUnitSize, pic_board_cells_Checkers);
                else
                    Drawer.DrawImg(Properties.Resources.BlackS, Selected.Y , Selected.X , CheckerUnitSize, pic_board_cells_Checkers);
            }
        }

        public void UnShadowSelectedChecker(Point UnSelected, bool King)
        {
            Drawer.ClearImg(Properties.Resources.ChessBlack, Properties.Resources.ChessBlack, UnSelected.Y , UnSelected.X , CheckerUnitSize, pic_board_cells_Checkers);

            if (Program.Controller.GetMainPlayer().IsMyTurn())
            {
                if (King)
                    Drawer.DrawImg(Properties.Resources.RedSK, UnSelected.Y , UnSelected.X, CheckerUnitSize, pic_board_cells_Checkers);
                else
                    Drawer.DrawImg(Properties.Resources.RedS, UnSelected.Y , UnSelected.X , CheckerUnitSize, pic_board_cells_Checkers);
            }
            else
            {
                if (King)
                    Drawer.DrawImg(Properties.Resources.BlackSK, UnSelected.Y , UnSelected.X , CheckerUnitSize, pic_board_cells_Checkers);
                else
                    Drawer.DrawImg(Properties.Resources.BlackS, UnSelected.Y , UnSelected.X , CheckerUnitSize, pic_board_cells_Checkers);
            }
        }

        public void HoverValidMoves(List<Point> Hover)
        {
            foreach (Point P in Hover)
                Drawer.DrawImg(Properties.Resources.hover, P.Y, P.X, CheckerUnitSize, pic_board_cells_Checkers);
        }

        public void UnHoverValidMoves(List<Point> UnHover)
        {
            foreach (Point P in UnHover)
                Drawer.ClearImg(Properties.Resources.ChessBlack, Properties.Resources.ChessBlack, P.Y, P.X, CheckerUnitSize, pic_board_cells_Checkers);
        }

        #endregion

        #region chess interface

        public void IntializeChess()
        {
            StartGame();
            setForGame(pic_board_cells_Chess);
            int temp1 = (int)((pic_board_cells_Chess.Width - (ChessUnitSize * 8)) / 2);
            int temp2 = (int)((pic_board_cells_Chess.Width - (ChessUnitSize * 8)) / 2);
            Drawer.DrawBoard(Properties.Resources.ChessWhite, Properties.Resources.ChessBlack, temp1, temp2, ChessUnitSize, pic_board_cells_Chess);
            pic_back_board.BackgroundImage = Properties.Resources.Board_chess;
            
            //White
            Drawer.DrawImg(Drawer.ChessUnitPicture['K'], 4 , 7 , ChessUnitSize, pic_board_cells_Chess);
            Drawer.DrawImg(Drawer.ChessUnitPicture['Q'], 3 , 7 , ChessUnitSize, pic_board_cells_Chess);
            Drawer.DrawImg(Drawer.ChessUnitPicture['B'], 2 , 7 , ChessUnitSize, pic_board_cells_Chess);
            Drawer.DrawImg(Drawer.ChessUnitPicture['B'], 5 , 7 , ChessUnitSize, pic_board_cells_Chess);
            Drawer.DrawImg(Drawer.ChessUnitPicture['N'], 1 , 7 , ChessUnitSize, pic_board_cells_Chess);
            Drawer.DrawImg(Drawer.ChessUnitPicture['N'], 6 , 7 , ChessUnitSize, pic_board_cells_Chess);
            Drawer.DrawImg(Drawer.ChessUnitPicture['R'], 0 , 7 , ChessUnitSize, pic_board_cells_Chess);
            Drawer.DrawImg(Drawer.ChessUnitPicture['R'], 7 , 7 , ChessUnitSize, pic_board_cells_Chess);

            for (int CurrentPawn = 0; CurrentPawn < 8; CurrentPawn++)
                Drawer.DrawImg(Drawer.ChessUnitPicture['P'], CurrentPawn , 6 , ChessUnitSize, pic_board_cells_Chess);

            //Black
            Drawer.DrawImg(Drawer.ChessUnitPicture['k'], 4 , 0 , ChessUnitSize, pic_board_cells_Chess);
            Drawer.DrawImg(Drawer.ChessUnitPicture['q'], 3 , 0 , ChessUnitSize, pic_board_cells_Chess);
            Drawer.DrawImg(Drawer.ChessUnitPicture['b'], 2 , 0 , ChessUnitSize, pic_board_cells_Chess);
            Drawer.DrawImg(Drawer.ChessUnitPicture['b'], 5 , 0 , ChessUnitSize, pic_board_cells_Chess);
            Drawer.DrawImg(Drawer.ChessUnitPicture['n'], 1 , 0 , ChessUnitSize, pic_board_cells_Chess);
            Drawer.DrawImg(Drawer.ChessUnitPicture['n'], 6 , 0 , ChessUnitSize, pic_board_cells_Chess);
            Drawer.DrawImg(Drawer.ChessUnitPicture['r'], 0 , 0 , ChessUnitSize, pic_board_cells_Chess);
            Drawer.DrawImg(Drawer.ChessUnitPicture['r'], 7 , 0 , ChessUnitSize, pic_board_cells_Chess);

            for (int CurrentPawn = 0; CurrentPawn < 8; CurrentPawn++)
                Drawer.DrawImg(Drawer.ChessUnitPicture['p'], CurrentPawn , 1 , ChessUnitSize, pic_board_cells_Chess);
        }

        public void ChessShadowSelected(Point pnt, char c)
        {
            Drawer.DrawImg(Properties.Resources.selected, pnt.Y , pnt.X , ChessUnitSize, pic_board_cells_Chess);
            Drawer.DrawImg(Drawer.ChessUnitPicture[c], pnt.Y , pnt.X , ChessUnitSize, pic_board_cells_Chess);
            pic_board_cells_Chess.Refresh();
        }

        public void ChessUnshadowSelected(Point pnt, char c)
        {
            Drawer.ClearImg(Properties.Resources.ChessWhite, Properties.Resources.ChessBlack, pnt.Y , pnt.X , ChessUnitSize, pic_board_cells_Chess);

            Drawer.DrawImg(Drawer.ChessUnitPicture[c], pnt.Y , pnt.X , ChessUnitSize, pic_board_cells_Chess);
            pic_board_cells_Chess.Refresh();
        }

        public void ChessHover(List<KeyValuePair<Point, char>> pntList)
        {
            Drawer.DrawImgHoverListChess(pntList, ChessUnitSize, pic_board_cells_Chess);
        }

        public void ChessUnhover(List<KeyValuePair<Point, char>> pntList)
        {
            Drawer.ClearImgHoverListChess(pntList, ChessUnitSize, pic_board_cells_Chess);
        }

        public void ChessMove(Point pntFrom, Point pntTo, char c)
        {
            Sound.playUnit();
            listBox1.Items.Add(((Program.Controller.getFirstPlayer().IsMyTurn())?lbl_Player_1_name.Text:lbl_Player_2_name.Text) + ": " + (char)('A' + pntFrom.Y) + ", " + (8 - pntFrom.X) + "|" + (char)('A' + pntTo.Y) + ", " + (8 - pntTo.X));
            Drawer.ClearImg(Properties.Resources.ChessWhite, Properties.Resources.ChessBlack, pntFrom.Y , pntFrom.X , ChessUnitSize, pic_board_cells_Chess);
            Drawer.ClearImg(Properties.Resources.ChessWhite, Properties.Resources.ChessBlack, pntTo.Y , pntTo.X , ChessUnitSize, pic_board_cells_Chess);

            Drawer.DrawImg(Drawer.ChessUnitPicture[c], pntTo.Y , pntTo.X , ChessUnitSize, pic_board_cells_Chess);
        }

        public void ChessRemove(Point pnt)
        {
            Drawer.ClearImg(Properties.Resources.ChessWhite, Properties.Resources.ChessBlack, pnt.Y , pnt.X , ChessUnitSize, pic_board_cells_Chess);

            pic_board_cells_Chess.Refresh();
        }

        #endregion

        #region XO interface

        public void IntializeXO()
        {
            StartGame();
            setForGame(pic_board_cells_XO);

            int temp1 = (int)((pic_board_cells_XO.Width - (XOUnitSize * 3)) / 2);
            int temp2 = (int)((pic_board_cells_XO.Width - (XOUnitSize * 3)) / 2);

            Drawer.DrawBoard(Properties.Resources.XO_Back, Properties.Resources.XO_Back, temp1, temp2, XOUnitSize, pic_board_cells_XO);
            pic_back_board.BackgroundImage = Properties.Resources.Board_XO;
        }

        public void UpdateXO(Point pnt)
        {
            Sound.playChalk();
            if (Program.Controller.GetMainPlayer().IsMyTurn())
            {
                listBox1.Items.Add(lbl_Player_1_name.Text + ": " + (char)('A' + Current_Click.Y) + ", " + (3 - Current_Click.X));
                MY_BITMAB = Properties.Resources.coin_Xo_X;
            }
            else
            {
                listBox1.Items.Add(lbl_Player_2_name.Text + ": " + (char)('A' + Current_Click.Y) + ", " + (3 - Current_Click.X));
                MY_BITMAB = Properties.Resources.coin_XO_O;
            }

            int temp1 = (int)((545 - (XOUnitSize * 3)) / 2);
            int temp2 = (int)((545 - (XOUnitSize * 3)) / 2);

            Drawer.DrawImgWithShift(MY_BITMAB, pnt.Y, temp1, pnt.X, temp2, XOUnitSize, pic_board_cells_XO);

            if (Program.Controller.getSecondPlayer().getName() == "Computer")
            {
                ComputerPlay = true;
            }
        }

        #endregion


        public void StopTimers()
        {
            T1.Reset();
            T2.Reset();
        }

        private void pic_pause_small_Click(object sender, EventArgs e)
        {
            GUI.SetCtrlBG(Pause_panel);
            Pause_panel.Show();

            T1.Stop();
            T2.Stop();
        }

        private void Pause_ptn_2_Click(object sender, EventArgs e)
        {
            GUI.SetCtrlBG(this);
            Pause_panel.Hide();
            if (Program.Controller.getFirstPlayer().IsMyTurn())
                T1.Start();
            else
                T2.Start();
        }
    }
}
