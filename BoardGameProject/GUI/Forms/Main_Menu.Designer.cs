namespace BoardGameProject
{
    partial class Main_Menu
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
            this.pic_chess = new System.Windows.Forms.PictureBox();
            this.pic_checkers = new System.Windows.Forms.PictureBox();
            this.pic_Xo = new System.Windows.Forms.PictureBox();
            this.pic_reversi = new System.Windows.Forms.PictureBox();
            this.pic_connect4 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pic_exit = new System.Windows.Forms.PictureBox();
            this.pic_player_mode = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_chess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_checkers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Xo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_reversi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_connect4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_exit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_player_mode)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_chess
            // 
            this.pic_chess.BackColor = System.Drawing.Color.Transparent;
            this.pic_chess.BackgroundImage = global::BoardGameProject.Properties.Resources.Chess_looked2;
            this.pic_chess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic_chess.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_chess.Location = new System.Drawing.Point(185, 98);
            this.pic_chess.Name = "pic_chess";
            this.pic_chess.Size = new System.Drawing.Size(253, 253);
            this.pic_chess.TabIndex = 0;
            this.pic_chess.TabStop = false;
            this.pic_chess.Click += new System.EventHandler(this.pic_chess_Click);
            this.pic_chess.MouseLeave += new System.EventHandler(this.pic_checkers_MouseLeave);
            this.pic_chess.MouseHover += new System.EventHandler(this.pic_checkers_MouseHover);
            // 
            // pic_checkers
            // 
            this.pic_checkers.BackColor = System.Drawing.Color.Transparent;
            this.pic_checkers.BackgroundImage = global::BoardGameProject.Properties.Resources.Checkers_looked2;
            this.pic_checkers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic_checkers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_checkers.Location = new System.Drawing.Point(557, 98);
            this.pic_checkers.Name = "pic_checkers";
            this.pic_checkers.Size = new System.Drawing.Size(253, 253);
            this.pic_checkers.TabIndex = 1;
            this.pic_checkers.TabStop = false;
            this.pic_checkers.Click += new System.EventHandler(this.pic_checkers_Click);
            this.pic_checkers.MouseLeave += new System.EventHandler(this.pic_checkers_MouseLeave);
            this.pic_checkers.MouseHover += new System.EventHandler(this.pic_checkers_MouseHover);
            // 
            // pic_Xo
            // 
            this.pic_Xo.BackColor = System.Drawing.Color.Transparent;
            this.pic_Xo.BackgroundImage = global::BoardGameProject.Properties.Resources.game_btn_XO;
            this.pic_Xo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic_Xo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_Xo.Location = new System.Drawing.Point(931, 98);
            this.pic_Xo.Name = "pic_Xo";
            this.pic_Xo.Size = new System.Drawing.Size(253, 253);
            this.pic_Xo.TabIndex = 2;
            this.pic_Xo.TabStop = false;
            this.pic_Xo.Click += new System.EventHandler(this.pic_Xo_Click);
            this.pic_Xo.MouseLeave += new System.EventHandler(this.pic_checkers_MouseLeave);
            this.pic_Xo.MouseHover += new System.EventHandler(this.pic_checkers_MouseHover);
            // 
            // pic_reversi
            // 
            this.pic_reversi.BackColor = System.Drawing.Color.Transparent;
            this.pic_reversi.BackgroundImage = global::BoardGameProject.Properties.Resources.reversi_looked2;
            this.pic_reversi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic_reversi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_reversi.Location = new System.Drawing.Point(371, 419);
            this.pic_reversi.Name = "pic_reversi";
            this.pic_reversi.Size = new System.Drawing.Size(253, 253);
            this.pic_reversi.TabIndex = 3;
            this.pic_reversi.TabStop = false;
            this.pic_reversi.Click += new System.EventHandler(this.pic_reversi_Click);
            this.pic_reversi.MouseLeave += new System.EventHandler(this.pic_checkers_MouseLeave);
            this.pic_reversi.MouseHover += new System.EventHandler(this.pic_checkers_MouseHover);
            // 
            // pic_connect4
            // 
            this.pic_connect4.BackColor = System.Drawing.Color.Transparent;
            this.pic_connect4.BackgroundImage = global::BoardGameProject.Properties.Resources.game_btn_Connect_4;
            this.pic_connect4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic_connect4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_connect4.Location = new System.Drawing.Point(748, 419);
            this.pic_connect4.Name = "pic_connect4";
            this.pic_connect4.Size = new System.Drawing.Size(253, 253);
            this.pic_connect4.TabIndex = 4;
            this.pic_connect4.TabStop = false;
            this.pic_connect4.Click += new System.EventHandler(this.pic_connect4_Click);
            this.pic_connect4.MouseLeave += new System.EventHandler(this.pic_checkers_MouseLeave);
            this.pic_connect4.MouseHover += new System.EventHandler(this.pic_checkers_MouseHover);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.BackgroundImage = global::BoardGameProject.Properties.Resources.Logo_Main;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox4.Location = new System.Drawing.Point(12, 681);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(199, 79);
            this.pictureBox4.TabIndex = 5;
            this.pictureBox4.TabStop = false;
            // 
            // pic_exit
            // 
            this.pic_exit.BackColor = System.Drawing.Color.Transparent;
            this.pic_exit.BackgroundImage = global::BoardGameProject.Properties.Resources.close;
            this.pic_exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic_exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_exit.Location = new System.Drawing.Point(12, 12);
            this.pic_exit.Name = "pic_exit";
            this.pic_exit.Size = new System.Drawing.Size(57, 52);
            this.pic_exit.TabIndex = 6;
            this.pic_exit.TabStop = false;
            this.pic_exit.Click += new System.EventHandler(this.pic_exit_Click);
            this.pic_exit.MouseLeave += new System.EventHandler(this.pic_checkers_MouseLeave);
            this.pic_exit.MouseHover += new System.EventHandler(this.pic_checkers_MouseHover);
            // 
            // pic_player_mode
            // 
            this.pic_player_mode.BackColor = System.Drawing.Color.Transparent;
            this.pic_player_mode.BackgroundImage = global::BoardGameProject.Properties.Resources.Player_mode_1;
            this.pic_player_mode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic_player_mode.Location = new System.Drawing.Point(78, 499);
            this.pic_player_mode.Name = "pic_player_mode";
            this.pic_player_mode.Size = new System.Drawing.Size(215, 94);
            this.pic_player_mode.TabIndex = 7;
            this.pic_player_mode.TabStop = false;
            this.pic_player_mode.Click += new System.EventHandler(this.pic_player_mode_Click);
            this.pic_player_mode.MouseLeave += new System.EventHandler(this.pic_checkers_MouseLeave);
            this.pic_player_mode.MouseHover += new System.EventHandler(this.pic_checkers_MouseHover);
            // 
            // Main_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1384, 786);
            this.ControlBox = false;
            this.Controls.Add(this.pic_player_mode);
            this.Controls.Add(this.pic_exit);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pic_connect4);
            this.Controls.Add(this.pic_reversi);
            this.Controls.Add(this.pic_Xo);
            this.Controls.Add(this.pic_checkers);
            this.Controls.Add(this.pic_chess);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Main_Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pic_chess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_checkers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Xo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_reversi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_connect4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_exit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_player_mode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_chess;
        private System.Windows.Forms.PictureBox pic_checkers;
        private System.Windows.Forms.PictureBox pic_Xo;
        private System.Windows.Forms.PictureBox pic_reversi;
        private System.Windows.Forms.PictureBox pic_connect4;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pic_exit;
        private System.Windows.Forms.PictureBox pic_player_mode;
    }
}