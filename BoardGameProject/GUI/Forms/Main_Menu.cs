using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BoardGameProject
{
    public partial class Main_Menu : Form
    {
        Player SecondPlayer;
        private bool OnePlayer;
        public Main_Menu()
        {
            InitializeComponent();
            OnePlayer = true;
        }

        public void setSecoundPlayer(string _name, int _ID)
        {
            SecondPlayer = new Human (_name);
        }

        public void ChangePlayerMode(bool One)
        {
            OnePlayer = One;
            if (One)
            {
                pic_chess.BackgroundImage = Properties.Resources.Chess_looked2;
                pic_checkers.BackgroundImage = Properties.Resources.Checkers_looked2;
                pic_reversi.BackgroundImage = Properties.Resources.reversi_looked2;
                pic_player_mode.BackgroundImage = Properties.Resources.Player_mode_1;
            }
            else
            {
                pic_chess.BackgroundImage = Properties.Resources.game_btn_Chess;
                pic_checkers.BackgroundImage = Properties.Resources.game_btn_Checkers;
                pic_reversi.BackgroundImage = Properties.Resources.game_btn_reversi;
                pic_player_mode.BackgroundImage = Properties.Resources.Player_mode_2;
            }
        }

        private void pic_checkers_MouseHover(object sender, EventArgs e)
        {
            Sound.playHover();
            GUI.MakeBigger(((PictureBox)sender).Width, ((PictureBox)sender).Height, (PictureBox)sender);
        }

        private void pic_checkers_MouseLeave(object sender, EventArgs e)
        {
            GUI.MakeSmaller(((PictureBox)sender).Width, ((PictureBox)sender).Height, (PictureBox)sender);
        }

        private void pic_exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void pic_connect4_Click(object sender, EventArgs e)
        {
            GUI.GamesForm.Show();
            GUI.SetCtrlBG(GUI.GamesForm);
            if (!OnePlayer)
            {
                Program.Controller.SetCurrentGame(new Connect4(Program.Controller.GetMainPlayer(), SecondPlayer, GUI.GamesForm));
            }
            else
            {
                SecondPlayer = new Computer();
                Program.Controller.SetCurrentGame(new Connect4(Program.Controller.getFirstPlayer(),SecondPlayer,GUI.GamesForm));
                SecondPlayer.Set_Strategy(new Connect4Strategy(2,Program.Controller.getCurrentgame().getGameState()));
            }
            GUI.GamesForm.SetPlayersName();
            this.Hide();
        }

        private void pic_chess_Click(object sender, EventArgs e)
        {
            if (!OnePlayer)
            {
                Program.Controller.SetCurrentGame(new Chess(Program.Controller.GetMainPlayer(), SecondPlayer, GUI.GamesForm));
                GUI.GamesForm.SetPlayersName();
                this.Hide();
                GUI.GamesForm.Show();
                GUI.SetCtrlBG(GUI.GamesForm);
            }
        }

        private void pic_Xo_Click(object sender, EventArgs e)
        {
            GUI.GamesForm.Show();
            GUI.SetCtrlBG(GUI.GamesForm);
            if (!OnePlayer)
            {
                Program.Controller.SetCurrentGame(new XOBoardGame(Program.Controller.GetMainPlayer(), SecondPlayer, GUI.GamesForm));
            }
            else
            {
                SecondPlayer = new Computer();
                Program.Controller.SetCurrentGame(new XOBoardGame(Program.Controller.GetMainPlayer(), SecondPlayer, GUI.GamesForm));
                SecondPlayer.Set_Strategy(new XOStrategy(4, Program.Controller.getCurrentgame().getGameState()));
            }
            GUI.GamesForm.SetPlayersName();
            this.Hide();
        }

        private void pic_checkers_Click(object sender, EventArgs e)
        {
            if (!OnePlayer)
            {
                Program.Controller.SetCurrentGame(new Checkers(Program.Controller.GetMainPlayer(), SecondPlayer, GUI.GamesForm));
                GUI.GamesForm.SetPlayersName();
                GUI.GamesForm.Show();
                GUI.SetCtrlBG(GUI.GamesForm);
                this.Hide();
            }
        }

        private void pic_reversi_Click(object sender, EventArgs e)
        {
            
            if (!OnePlayer)
            {
                GUI.GamesForm.Show();
                Program.Controller.SetCurrentGame(new Reversi(Program.Controller.GetMainPlayer(), SecondPlayer, GUI.GamesForm));
                GUI.GamesForm.SetPlayersName();
                this.Hide();
                GUI.SetCtrlBG(GUI.GamesForm);
            }

            
        }

        private void pic_player_mode_Click(object sender, EventArgs e)
        {
            GUI.PlayerModeForm.Show();
            GUI.SetCtrlBG(GUI.PlayerModeForm);
        }

    }
}
