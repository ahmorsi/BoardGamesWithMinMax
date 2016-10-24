namespace BoardGameProject
{
    partial class PlayerSelect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pic_newPlayer = new System.Windows.Forms.PictureBox();
            this.pic_editPlayer = new System.Windows.Forms.PictureBox();
            this.list_Players = new System.Windows.Forms.ListBox();
            this.pic_Play = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pnl_NewPlayer = new System.Windows.Forms.Panel();
            this.Pic_close = new System.Windows.Forms.PictureBox();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.Pnl_name = new System.Windows.Forms.PictureBox();
            this.pic_edit = new System.Windows.Forms.PictureBox();
            this.pic_Add = new System.Windows.Forms.PictureBox();
            this.pic_music = new System.Windows.Forms.PictureBox();
            this.pic_eff = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Pic_exit = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_newPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_editPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Play)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.pnl_NewPlayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pnl_name)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Add)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_music)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_eff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_exit)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_newPlayer
            // 
            this.pic_newPlayer.BackColor = System.Drawing.Color.Transparent;
            this.pic_newPlayer.BackgroundImage = global::BoardGameProject.Properties.Resources.btn_New_Player;
            this.pic_newPlayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic_newPlayer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_newPlayer.Location = new System.Drawing.Point(303, 116);
            this.pic_newPlayer.Name = "pic_newPlayer";
            this.pic_newPlayer.Size = new System.Drawing.Size(187, 52);
            this.pic_newPlayer.TabIndex = 0;
            this.pic_newPlayer.TabStop = false;
            this.pic_newPlayer.Click += new System.EventHandler(this.pic_newPlayer_Click);
            this.pic_newPlayer.MouseLeave += new System.EventHandler(this.pic_Play_MouseLeave);
            this.pic_newPlayer.MouseHover += new System.EventHandler(this.pic_Play_MouseHover);
            // 
            // pic_editPlayer
            // 
            this.pic_editPlayer.BackColor = System.Drawing.Color.Transparent;
            this.pic_editPlayer.BackgroundImage = global::BoardGameProject.Properties.Resources.btn_Edit_Player;
            this.pic_editPlayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic_editPlayer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_editPlayer.Location = new System.Drawing.Point(303, 185);
            this.pic_editPlayer.Name = "pic_editPlayer";
            this.pic_editPlayer.Size = new System.Drawing.Size(187, 52);
            this.pic_editPlayer.TabIndex = 1;
            this.pic_editPlayer.TabStop = false;
            this.pic_editPlayer.Click += new System.EventHandler(this.pic_editPlayer_Click);
            this.pic_editPlayer.MouseLeave += new System.EventHandler(this.pic_Play_MouseLeave);
            this.pic_editPlayer.MouseHover += new System.EventHandler(this.pic_Play_MouseHover);
            // 
            // list_Players
            // 
            this.list_Players.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.list_Players.Font = new System.Drawing.Font("Bahamas", 25F);
            this.list_Players.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.list_Players.FormattingEnabled = true;
            this.list_Players.ItemHeight = 39;
            this.list_Players.Items.AddRange(new object[] {
            "tenno"});
            this.list_Players.Location = new System.Drawing.Point(541, 172);
            this.list_Players.Name = "list_Players";
            this.list_Players.Size = new System.Drawing.Size(287, 390);
            this.list_Players.TabIndex = 1;
            // 
            // pic_Play
            // 
            this.pic_Play.BackColor = System.Drawing.Color.Transparent;
            this.pic_Play.BackgroundImage = global::BoardGameProject.Properties.Resources.btn_Play;
            this.pic_Play.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic_Play.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_Play.Location = new System.Drawing.Point(541, 611);
            this.pic_Play.Name = "pic_Play";
            this.pic_Play.Size = new System.Drawing.Size(287, 62);
            this.pic_Play.TabIndex = 0;
            this.pic_Play.TabStop = false;
            this.pic_Play.Click += new System.EventHandler(this.pic_Play_Click);
            this.pic_Play.MouseLeave += new System.EventHandler(this.pic_Play_MouseLeave);
            this.pic_Play.MouseHover += new System.EventHandler(this.pic_Play_MouseHover);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.BackgroundImage = global::BoardGameProject.Properties.Resources.Logo_Main;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox4.Location = new System.Drawing.Point(23, 668);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(199, 79);
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // pnl_NewPlayer
            // 
            this.pnl_NewPlayer.Controls.Add(this.Pic_close);
            this.pnl_NewPlayer.Controls.Add(this.txt_name);
            this.pnl_NewPlayer.Controls.Add(this.Pnl_name);
            this.pnl_NewPlayer.Controls.Add(this.pic_edit);
            this.pnl_NewPlayer.Controls.Add(this.pic_Add);
            this.pnl_NewPlayer.Location = new System.Drawing.Point(22, 293);
            this.pnl_NewPlayer.Name = "pnl_NewPlayer";
            this.pnl_NewPlayer.Size = new System.Drawing.Size(455, 295);
            this.pnl_NewPlayer.TabIndex = 4;
            // 
            // Pic_close
            // 
            this.Pic_close.BackColor = System.Drawing.Color.Transparent;
            this.Pic_close.BackgroundImage = global::BoardGameProject.Properties.Resources.close;
            this.Pic_close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Pic_close.Location = new System.Drawing.Point(260, 152);
            this.Pic_close.Name = "Pic_close";
            this.Pic_close.Size = new System.Drawing.Size(57, 52);
            this.Pic_close.TabIndex = 7;
            this.Pic_close.TabStop = false;
            this.Pic_close.Click += new System.EventHandler(this.Pic_close_Click);
            this.Pic_close.MouseLeave += new System.EventHandler(this.pic_Play_MouseLeave);
            this.Pic_close.MouseHover += new System.EventHandler(this.pic_Play_MouseHover);
            // 
            // txt_name
            // 
            this.txt_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_name.Font = new System.Drawing.Font("Bahamas", 20F);
            this.txt_name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.txt_name.Location = new System.Drawing.Point(88, 94);
            this.txt_name.MaxLength = 7;
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(268, 32);
            this.txt_name.TabIndex = 1;
            // 
            // Pnl_name
            // 
            this.Pnl_name.BackColor = System.Drawing.Color.Transparent;
            this.Pnl_name.BackgroundImage = global::BoardGameProject.Properties.Resources.Group_101;
            this.Pnl_name.Location = new System.Drawing.Point(3, 28);
            this.Pnl_name.Name = "Pnl_name";
            this.Pnl_name.Size = new System.Drawing.Size(437, 117);
            this.Pnl_name.TabIndex = 6;
            this.Pnl_name.TabStop = false;
            // 
            // pic_edit
            // 
            this.pic_edit.BackColor = System.Drawing.Color.Transparent;
            this.pic_edit.BackgroundImage = global::BoardGameProject.Properties.Resources.btn_Edit_player_name;
            this.pic_edit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic_edit.Location = new System.Drawing.Point(220, 219);
            this.pic_edit.Name = "pic_edit";
            this.pic_edit.Size = new System.Drawing.Size(187, 52);
            this.pic_edit.TabIndex = 5;
            this.pic_edit.TabStop = false;
            this.pic_edit.Click += new System.EventHandler(this.pic_edit_Click);
            this.pic_edit.MouseLeave += new System.EventHandler(this.pic_Play_MouseLeave);
            this.pic_edit.MouseHover += new System.EventHandler(this.pic_Play_MouseHover);
            // 
            // pic_Add
            // 
            this.pic_Add.BackColor = System.Drawing.Color.Transparent;
            this.pic_Add.BackgroundImage = global::BoardGameProject.Properties.Resources.btn_add;
            this.pic_Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic_Add.Location = new System.Drawing.Point(15, 219);
            this.pic_Add.Name = "pic_Add";
            this.pic_Add.Size = new System.Drawing.Size(187, 52);
            this.pic_Add.TabIndex = 4;
            this.pic_Add.TabStop = false;
            this.pic_Add.Click += new System.EventHandler(this.pic_Add_Click);
            this.pic_Add.MouseLeave += new System.EventHandler(this.pic_Play_MouseLeave);
            this.pic_Add.MouseHover += new System.EventHandler(this.pic_Play_MouseHover);
            // 
            // pic_music
            // 
            this.pic_music.BackColor = System.Drawing.Color.Transparent;
            this.pic_music.BackgroundImage = global::BoardGameProject.Properties.Resources.Music;
            this.pic_music.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic_music.Location = new System.Drawing.Point(1264, 664);
            this.pic_music.Name = "pic_music";
            this.pic_music.Size = new System.Drawing.Size(87, 82);
            this.pic_music.TabIndex = 10;
            this.pic_music.TabStop = false;
            this.pic_music.Click += new System.EventHandler(this.pic_music_Click);
            this.pic_music.MouseLeave += new System.EventHandler(this.pic_Play_MouseLeave);
            this.pic_music.MouseHover += new System.EventHandler(this.pic_Play_MouseHover);
            // 
            // pic_eff
            // 
            this.pic_eff.BackColor = System.Drawing.Color.Transparent;
            this.pic_eff.BackgroundImage = global::BoardGameProject.Properties.Resources.SoundEffects;
            this.pic_eff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic_eff.Location = new System.Drawing.Point(1164, 664);
            this.pic_eff.Name = "pic_eff";
            this.pic_eff.Size = new System.Drawing.Size(87, 82);
            this.pic_eff.TabIndex = 9;
            this.pic_eff.TabStop = false;
            this.pic_eff.Click += new System.EventHandler(this.pic_eff_Click);
            this.pic_eff.MouseLeave += new System.EventHandler(this.pic_Play_MouseLeave);
            this.pic_eff.MouseHover += new System.EventHandler(this.pic_Play_MouseHover);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::BoardGameProject.Properties.Resources.List_Players;
            this.pictureBox1.Location = new System.Drawing.Point(515, 90);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(346, 595);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::BoardGameProject.Properties.Resources.Back_shade;
            this.pictureBox2.Location = new System.Drawing.Point(869, -2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(518, 515);
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // Pic_exit
            // 
            this.Pic_exit.BackColor = System.Drawing.Color.Transparent;
            this.Pic_exit.BackgroundImage = global::BoardGameProject.Properties.Resources.close;
            this.Pic_exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Pic_exit.Location = new System.Drawing.Point(1295, 12);
            this.Pic_exit.Name = "Pic_exit";
            this.Pic_exit.Size = new System.Drawing.Size(57, 52);
            this.Pic_exit.TabIndex = 8;
            this.Pic_exit.TabStop = false;
            this.Pic_exit.Click += new System.EventHandler(this.Pic_exit_Click);
            this.Pic_exit.MouseLeave += new System.EventHandler(this.pic_Play_MouseLeave);
            this.Pic_exit.MouseHover += new System.EventHandler(this.pic_Play_MouseHover);
            // 
            // PlayerSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1364, 766);
            this.ControlBox = false;
            this.Controls.Add(this.pnl_NewPlayer);
            this.Controls.Add(this.Pic_exit);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.list_Players);
            this.Controls.Add(this.pic_Play);
            this.Controls.Add(this.pic_music);
            this.Controls.Add(this.pic_eff);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pic_editPlayer);
            this.Controls.Add(this.pic_newPlayer);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PlayerSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.VisibleChanged += new System.EventHandler(this.PlayerSelect_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pic_newPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_editPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Play)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.pnl_NewPlayer.ResumeLayout(false);
            this.pnl_NewPlayer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pnl_name)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Add)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_music)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_eff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_exit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_newPlayer;
        private System.Windows.Forms.PictureBox pic_editPlayer;
        private System.Windows.Forms.PictureBox pic_Play;
        private System.Windows.Forms.ListBox list_Players;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel pnl_NewPlayer;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.PictureBox pic_Add;
        private System.Windows.Forms.PictureBox pic_edit;
        private System.Windows.Forms.PictureBox pic_music;
        private System.Windows.Forms.PictureBox pic_eff;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox Pnl_name;
        private System.Windows.Forms.PictureBox Pic_close;
        private System.Windows.Forms.PictureBox Pic_exit;
    }
}

