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
    public partial class PlayerMode : Form
    {
        public PlayerMode()
        {
            InitializeComponent();
        }

        private void pic_one_player_Click(object sender, EventArgs e)
        {
            GUI.GamesMenu.ChangePlayerMode(true);
            this.Hide();
        }

        private void pic_two_players_Click(object sender, EventArgs e)
        {
            GUI.PlayerSelectForm.Show();
            GUI.SetCtrlBG(GUI.PlayerSelectForm);
            this.Hide();
            GUI.GamesMenu.ChangePlayerMode(false);
        }
    }
}
