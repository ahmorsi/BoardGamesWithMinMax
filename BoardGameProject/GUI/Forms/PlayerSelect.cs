using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace BoardGameProject
{
    public partial class PlayerSelect : Form
    {
        static bool First = true;
        FileStream FS;
        public PlayerSelect()
        {
            InitializeComponent();

            pictureBox1.Controls.Add(pic_Play);
            pic_Play.Top = 522;
            pic_Play.Left =27;
            pic_Play.BringToFront();

            pnl_NewPlayer.Hide();

            pnl_NewPlayer.Top = 0;
            pnl_NewPlayer.Left = 0;
            pnl_NewPlayer.Height = this.Height;
            pnl_NewPlayer.Width = this.Width;

            Pnl_name.Controls.Add(txt_name);
            txt_name.BringToFront();
            txt_name.Top = 67;
            txt_name.Left = Pnl_name.Width / 2 - txt_name.Width/2;

            Pnl_name.Top = this.Height/2 - Pnl_name.Height / 2;
            Pnl_name.Left = this.Width/2 - Pnl_name.Width / 2;

            pic_Add.Top = 110 + this.Height/2 - pic_Add.Height / 2;
            pic_Add.Left = this.Width/2 - pic_Add.Width / 2;
            pic_Add.Hide();

            pic_edit.Top = 110 + this.Height / 2 - pic_edit.Height / 2;
            pic_edit.Left = this.Width / 2 - pic_edit.Width / 2;
            pic_edit.Hide();

            Pic_close.Top = 12;
            Pic_close.Left = 1295;
        }

        private void pic_Play_Click(object sender, EventArgs e)
        {
            if (list_Players.SelectedIndex != -1)
            {
                if (First)
                {
                    Program.Controller.SetMainPlayer(list_Players.SelectedItem.ToString(), 0);
                    Program.Controller.GetMainPlayer().setMyTurn(true);
                    GUI.GamesMenu.Show();
                    list_Players.Items.RemoveAt(list_Players.SelectedIndex);
                    GUI.SetCtrlBG(GUI.GamesMenu);
                    this.Hide();
                    First = false;
                }
                else
                {
                    GUI.GamesMenu.setSecoundPlayer(list_Players.SelectedItem.ToString(), 1);

                    this.Hide();
                }
            }
        }

        private void pic_newPlayer_Click(object sender, EventArgs e)
        {
            pic_Add.Show();
            pnl_NewPlayer.Show();
        }

        private void pic_editPlayer_Click(object sender, EventArgs e)
        {
            if (list_Players.SelectedIndex != -1)
            {
                txt_name.Text = list_Players.SelectedItem.ToString();
                pnl_NewPlayer.Show();
                pic_edit.Show();
            }
        }

        private void pic_Add_Click(object sender, EventArgs e)
        {
            if (txt_name.Text != "")
            {
                list_Players.Items.Add(txt_name.Text);
                txt_name.Text = "";
                pnl_NewPlayer.Hide();
                pic_Add.Hide();
            }
        }

        private void pic_edit_Click(object sender, EventArgs e)
        {
            if (txt_name.Text != "")
            {
                list_Players.Items.RemoveAt(list_Players.SelectedIndex);
                list_Players.Items.Add(txt_name.Text);
                txt_name.Text = "";
                pnl_NewPlayer.Hide();
                pic_edit.Hide();
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

        private void pic_Play_MouseHover(object sender, EventArgs e)
        {
            Sound.playHover();
            GUI.MakeBigger(((PictureBox)sender).Width, ((PictureBox)sender).Height, (PictureBox)sender);
        }

        private void pic_Play_MouseLeave(object sender, EventArgs e)
        {
            GUI.MakeSmaller(((PictureBox)sender).Width, ((PictureBox)sender).Height, (PictureBox)sender);
        }

        private void Pic_close_Click(object sender, EventArgs e)
        {
            txt_name.Text = "";
            pnl_NewPlayer.Hide();
        }

        private void Pic_exit_Click(object sender, EventArgs e)
        {
            END();
            Environment.Exit(1);
        }

        private void END()
        {
            FS.Close();
            
        }

        private void PlayerSelect_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                FS = new FileStream("Players.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            }
            else
            {
                FS.Close();
            }
        }

        
    }
}
