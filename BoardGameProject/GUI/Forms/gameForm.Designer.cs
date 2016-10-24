namespace BoardGameProject
{
    partial class gameForm
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
            this.pic_MainMenu = new System.Windows.Forms.PictureBox();
            this.pic_NewGame = new System.Windows.Forms.PictureBox();
            this.pic_pause_small = new System.Windows.Forms.PictureBox();
            this.lbl_Player_2_timer = new System.Windows.Forms.Label();
            this.pictureBox_timer_2 = new System.Windows.Forms.PictureBox();
            this.pic_player_1_pic = new System.Windows.Forms.PictureBox();
            this.lbl_Player_2_name = new System.Windows.Forms.Label();
            this.lbl_Player_1_timer = new System.Windows.Forms.Label();
            this.pictureBox_timer_1 = new System.Windows.Forms.PictureBox();
            this.pic_player_2_pic = new System.Windows.Forms.PictureBox();
            this.lbl_Player_1_name = new System.Windows.Forms.Label();
            this.pic_player = new System.Windows.Forms.PictureBox();
            this.pic_eff = new System.Windows.Forms.PictureBox();
            this.pic_music = new System.Windows.Forms.PictureBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.pic_board_cells_reversi = new System.Windows.Forms.PictureBox();
            this.pic_back_board = new System.Windows.Forms.PictureBox();
            this.pic_history = new System.Windows.Forms.PictureBox();
            this.pic_player_1 = new System.Windows.Forms.PictureBox();
            this.pic_player_2 = new System.Windows.Forms.PictureBox();
            this.pic_board_cells_C4 = new System.Windows.Forms.PictureBox();
            this.pic_board_cells_XO = new System.Windows.Forms.PictureBox();
            this.pic_board_cells_Checkers = new System.Windows.Forms.PictureBox();
            this.pic_board_cells_Chess = new System.Windows.Forms.PictureBox();
            this.Pause_panel = new System.Windows.Forms.Panel();
            this.Pause_ptn_2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_MainMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_NewGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_pause_small)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_timer_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_player_1_pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_timer_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_player_2_pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_eff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_music)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_board_cells_reversi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_back_board)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_history)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_player_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_player_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_board_cells_C4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_board_cells_XO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_board_cells_Checkers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_board_cells_Chess)).BeginInit();
            this.Pause_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pause_ptn_2)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_MainMenu
            // 
            this.pic_MainMenu.BackColor = System.Drawing.Color.Transparent;
            this.pic_MainMenu.BackgroundImage = global::BoardGameProject.Properties.Resources.btn_Main_Menu;
            this.pic_MainMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic_MainMenu.Location = new System.Drawing.Point(767, 148);
            this.pic_MainMenu.Name = "pic_MainMenu";
            this.pic_MainMenu.Size = new System.Drawing.Size(187, 78);
            this.pic_MainMenu.TabIndex = 0;
            this.pic_MainMenu.TabStop = false;
            this.pic_MainMenu.Click += new System.EventHandler(this.pic_MainMenu_Click);
            this.pic_MainMenu.MouseLeave += new System.EventHandler(this.pic_MainMenu_MouseLeave);
            this.pic_MainMenu.MouseHover += new System.EventHandler(this.pic_MainMenu_MouseHover);
            // 
            // pic_NewGame
            // 
            this.pic_NewGame.BackColor = System.Drawing.Color.Transparent;
            this.pic_NewGame.BackgroundImage = global::BoardGameProject.Properties.Resources.btn_New_game;
            this.pic_NewGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic_NewGame.Location = new System.Drawing.Point(767, 237);
            this.pic_NewGame.Name = "pic_NewGame";
            this.pic_NewGame.Size = new System.Drawing.Size(187, 78);
            this.pic_NewGame.TabIndex = 1;
            this.pic_NewGame.TabStop = false;
            this.pic_NewGame.Click += new System.EventHandler(this.pic_NewGame_Click);
            this.pic_NewGame.MouseLeave += new System.EventHandler(this.pic_MainMenu_MouseLeave);
            this.pic_NewGame.MouseHover += new System.EventHandler(this.pic_MainMenu_MouseHover);
            // 
            // pic_pause_small
            // 
            this.pic_pause_small.BackColor = System.Drawing.Color.Transparent;
            this.pic_pause_small.BackgroundImage = global::BoardGameProject.Properties.Resources.btn_pause;
            this.pic_pause_small.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic_pause_small.Location = new System.Drawing.Point(767, 348);
            this.pic_pause_small.Name = "pic_pause_small";
            this.pic_pause_small.Size = new System.Drawing.Size(187, 52);
            this.pic_pause_small.TabIndex = 3;
            this.pic_pause_small.TabStop = false;
            this.pic_pause_small.Click += new System.EventHandler(this.pic_pause_small_Click);
            this.pic_pause_small.MouseLeave += new System.EventHandler(this.pic_MainMenu_MouseLeave);
            this.pic_pause_small.MouseHover += new System.EventHandler(this.pic_MainMenu_MouseHover);
            // 
            // lbl_Player_2_timer
            // 
            this.lbl_Player_2_timer.AutoSize = true;
            this.lbl_Player_2_timer.Font = new System.Drawing.Font("Digital-7", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Player_2_timer.Location = new System.Drawing.Point(505, 31);
            this.lbl_Player_2_timer.Name = "lbl_Player_2_timer";
            this.lbl_Player_2_timer.Size = new System.Drawing.Size(68, 28);
            this.lbl_Player_2_timer.TabIndex = 4;
            this.lbl_Player_2_timer.Text = "00:00";
            // 
            // pictureBox_timer_2
            // 
            this.pictureBox_timer_2.BackgroundImage = global::BoardGameProject.Properties.Resources.counter_panel;
            this.pictureBox_timer_2.Location = new System.Drawing.Point(460, 27);
            this.pictureBox_timer_2.Name = "pictureBox_timer_2";
            this.pictureBox_timer_2.Size = new System.Drawing.Size(184, 40);
            this.pictureBox_timer_2.TabIndex = 3;
            this.pictureBox_timer_2.TabStop = false;
            // 
            // pic_player_1_pic
            // 
            this.pic_player_1_pic.BackColor = System.Drawing.Color.Transparent;
            this.pic_player_1_pic.BackgroundImage = global::BoardGameProject.Properties.Resources.Icon_player;
            this.pic_player_1_pic.Location = new System.Drawing.Point(143, 34);
            this.pic_player_1_pic.Name = "pic_player_1_pic";
            this.pic_player_1_pic.Size = new System.Drawing.Size(91, 91);
            this.pic_player_1_pic.TabIndex = 2;
            this.pic_player_1_pic.TabStop = false;
            // 
            // lbl_Player_2_name
            // 
            this.lbl_Player_2_name.AutoSize = true;
            this.lbl_Player_2_name.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Player_2_name.Font = new System.Drawing.Font("Bahamas", 20F);
            this.lbl_Player_2_name.Location = new System.Drawing.Point(471, 82);
            this.lbl_Player_2_name.Name = "lbl_Player_2_name";
            this.lbl_Player_2_name.Size = new System.Drawing.Size(29, 31);
            this.lbl_Player_2_name.TabIndex = 0;
            this.lbl_Player_2_name.Text = "a";
            // 
            // lbl_Player_1_timer
            // 
            this.lbl_Player_1_timer.AutoSize = true;
            this.lbl_Player_1_timer.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Player_1_timer.Font = new System.Drawing.Font("Digital-7", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Player_1_timer.Location = new System.Drawing.Point(276, 32);
            this.lbl_Player_1_timer.Name = "lbl_Player_1_timer";
            this.lbl_Player_1_timer.Size = new System.Drawing.Size(68, 28);
            this.lbl_Player_1_timer.TabIndex = 5;
            this.lbl_Player_1_timer.Text = "00:00";
            // 
            // pictureBox_timer_1
            // 
            this.pictureBox_timer_1.BackgroundImage = global::BoardGameProject.Properties.Resources.counter_panel;
            this.pictureBox_timer_1.Location = new System.Drawing.Point(236, 29);
            this.pictureBox_timer_1.Name = "pictureBox_timer_1";
            this.pictureBox_timer_1.Size = new System.Drawing.Size(184, 40);
            this.pictureBox_timer_1.TabIndex = 7;
            this.pictureBox_timer_1.TabStop = false;
            // 
            // pic_player_2_pic
            // 
            this.pic_player_2_pic.BackColor = System.Drawing.Color.Transparent;
            this.pic_player_2_pic.BackgroundImage = global::BoardGameProject.Properties.Resources.Icon_PC;
            this.pic_player_2_pic.Location = new System.Drawing.Point(647, 32);
            this.pic_player_2_pic.Name = "pic_player_2_pic";
            this.pic_player_2_pic.Size = new System.Drawing.Size(89, 90);
            this.pic_player_2_pic.TabIndex = 2;
            this.pic_player_2_pic.TabStop = false;
            // 
            // lbl_Player_1_name
            // 
            this.lbl_Player_1_name.AutoSize = true;
            this.lbl_Player_1_name.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Player_1_name.Font = new System.Drawing.Font("Bahamas", 20F);
            this.lbl_Player_1_name.Location = new System.Drawing.Point(240, 82);
            this.lbl_Player_1_name.Name = "lbl_Player_1_name";
            this.lbl_Player_1_name.Size = new System.Drawing.Size(78, 31);
            this.lbl_Player_1_name.TabIndex = 0;
            this.lbl_Player_1_name.Text = "name";
            // 
            // pic_player
            // 
            this.pic_player.BackColor = System.Drawing.Color.Transparent;
            this.pic_player.BackgroundImage = global::BoardGameProject.Properties.Resources.player_selector_left;
            this.pic_player.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic_player.Location = new System.Drawing.Point(424, 81);
            this.pic_player.Name = "pic_player";
            this.pic_player.Size = new System.Drawing.Size(32, 32);
            this.pic_player.TabIndex = 6;
            this.pic_player.TabStop = false;
            // 
            // pic_eff
            // 
            this.pic_eff.BackColor = System.Drawing.Color.Transparent;
            this.pic_eff.BackgroundImage = global::BoardGameProject.Properties.Resources.SoundEffects;
            this.pic_eff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic_eff.Location = new System.Drawing.Point(767, 583);
            this.pic_eff.Name = "pic_eff";
            this.pic_eff.Size = new System.Drawing.Size(87, 82);
            this.pic_eff.TabIndex = 7;
            this.pic_eff.TabStop = false;
            this.pic_eff.Click += new System.EventHandler(this.pic_eff_Click);
            this.pic_eff.MouseLeave += new System.EventHandler(this.pic_MainMenu_MouseLeave);
            this.pic_eff.MouseHover += new System.EventHandler(this.pic_MainMenu_MouseHover);
            // 
            // pic_music
            // 
            this.pic_music.BackColor = System.Drawing.Color.Transparent;
            this.pic_music.BackgroundImage = global::BoardGameProject.Properties.Resources.Music;
            this.pic_music.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic_music.Location = new System.Drawing.Point(867, 583);
            this.pic_music.Name = "pic_music";
            this.pic_music.Size = new System.Drawing.Size(87, 82);
            this.pic_music.TabIndex = 8;
            this.pic_music.TabStop = false;
            this.pic_music.Click += new System.EventHandler(this.pic_music_Click);
            this.pic_music.MouseLeave += new System.EventHandler(this.pic_MainMenu_MouseLeave);
            this.pic_music.MouseHover += new System.EventHandler(this.pic_MainMenu_MouseHover);
            // 
            // listBox1
            // 
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.Font = new System.Drawing.Font("Bahamas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.ForeColor = System.Drawing.Color.Navy;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Location = new System.Drawing.Point(999, 201);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(205, 350);
            this.listBox1.TabIndex = 0;
            // 
            // pictureBox11
            // 
            this.pictureBox11.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox11.BackgroundImage = global::BoardGameProject.Properties.Resources.logos;
            this.pictureBox11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox11.Location = new System.Drawing.Point(981, 689);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(249, 50);
            this.pictureBox11.TabIndex = 10;
            this.pictureBox11.TabStop = false;
            // 
            // pic_board_cells_reversi
            // 
            this.pic_board_cells_reversi.BackColor = System.Drawing.Color.Transparent;
            this.pic_board_cells_reversi.Location = new System.Drawing.Point(165, 161);
            this.pic_board_cells_reversi.Name = "pic_board_cells_reversi";
            this.pic_board_cells_reversi.Size = new System.Drawing.Size(545, 545);
            this.pic_board_cells_reversi.TabIndex = 12;
            this.pic_board_cells_reversi.TabStop = false;
            this.pic_board_cells_reversi.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pic_board_cells_reversi_MouseClick);
            // 
            // pic_back_board
            // 
            this.pic_back_board.BackgroundImage = global::BoardGameProject.Properties.Resources.Board_C4;
            this.pic_back_board.Location = new System.Drawing.Point(137, 133);
            this.pic_back_board.Name = "pic_back_board";
            this.pic_back_board.Size = new System.Drawing.Size(604, 605);
            this.pic_back_board.TabIndex = 13;
            this.pic_back_board.TabStop = false;
            // 
            // pic_history
            // 
            this.pic_history.BackColor = System.Drawing.Color.Transparent;
            this.pic_history.BackgroundImage = global::BoardGameProject.Properties.Resources.List_History;
            this.pic_history.Location = new System.Drawing.Point(976, 135);
            this.pic_history.Name = "pic_history";
            this.pic_history.Size = new System.Drawing.Size(252, 529);
            this.pic_history.TabIndex = 14;
            this.pic_history.TabStop = false;
            // 
            // pic_player_1
            // 
            this.pic_player_1.BackgroundImage = global::BoardGameProject.Properties.Resources.panel_left;
            this.pic_player_1.Location = new System.Drawing.Point(137, 28);
            this.pic_player_1.Name = "pic_player_1";
            this.pic_player_1.Size = new System.Drawing.Size(283, 102);
            this.pic_player_1.TabIndex = 15;
            this.pic_player_1.TabStop = false;
            // 
            // pic_player_2
            // 
            this.pic_player_2.BackColor = System.Drawing.Color.Transparent;
            this.pic_player_2.BackgroundImage = global::BoardGameProject.Properties.Resources.panel_right;
            this.pic_player_2.Location = new System.Drawing.Point(460, 27);
            this.pic_player_2.Name = "pic_player_2";
            this.pic_player_2.Size = new System.Drawing.Size(281, 101);
            this.pic_player_2.TabIndex = 16;
            this.pic_player_2.TabStop = false;
            // 
            // pic_board_cells_C4
            // 
            this.pic_board_cells_C4.BackColor = System.Drawing.Color.Transparent;
            this.pic_board_cells_C4.Location = new System.Drawing.Point(175, 170);
            this.pic_board_cells_C4.Name = "pic_board_cells_C4";
            this.pic_board_cells_C4.Size = new System.Drawing.Size(545, 545);
            this.pic_board_cells_C4.TabIndex = 17;
            this.pic_board_cells_C4.TabStop = false;
            this.pic_board_cells_C4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pic_board_cells_C4_MouseClick);
            // 
            // pic_board_cells_XO
            // 
            this.pic_board_cells_XO.BackColor = System.Drawing.Color.Transparent;
            this.pic_board_cells_XO.Location = new System.Drawing.Point(187, 181);
            this.pic_board_cells_XO.Name = "pic_board_cells_XO";
            this.pic_board_cells_XO.Size = new System.Drawing.Size(545, 545);
            this.pic_board_cells_XO.TabIndex = 18;
            this.pic_board_cells_XO.TabStop = false;
            this.pic_board_cells_XO.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pic_board_cells_XO_MouseClick);
            // 
            // pic_board_cells_Checkers
            // 
            this.pic_board_cells_Checkers.BackColor = System.Drawing.Color.Transparent;
            this.pic_board_cells_Checkers.Location = new System.Drawing.Point(198, 193);
            this.pic_board_cells_Checkers.Name = "pic_board_cells_Checkers";
            this.pic_board_cells_Checkers.Size = new System.Drawing.Size(545, 545);
            this.pic_board_cells_Checkers.TabIndex = 19;
            this.pic_board_cells_Checkers.TabStop = false;
            this.pic_board_cells_Checkers.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pic_board_cells_Checkers_MouseClick);
            // 
            // pic_board_cells_Chess
            // 
            this.pic_board_cells_Chess.BackColor = System.Drawing.Color.Transparent;
            this.pic_board_cells_Chess.Location = new System.Drawing.Point(213, 207);
            this.pic_board_cells_Chess.Name = "pic_board_cells_Chess";
            this.pic_board_cells_Chess.Size = new System.Drawing.Size(545, 545);
            this.pic_board_cells_Chess.TabIndex = 21;
            this.pic_board_cells_Chess.TabStop = false;
            this.pic_board_cells_Chess.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pic_board_cells_Chess_MouseClick);
            // 
            // Pause_panel
            // 
            this.Pause_panel.BackColor = System.Drawing.Color.Transparent;
            this.Pause_panel.Controls.Add(this.Pause_ptn_2);
            this.Pause_panel.Location = new System.Drawing.Point(42, 401);
            this.Pause_panel.Name = "Pause_panel";
            this.Pause_panel.Size = new System.Drawing.Size(45, 100);
            this.Pause_panel.TabIndex = 22;
            // 
            // Pause_ptn_2
            // 
            this.Pause_ptn_2.BackgroundImage = global::BoardGameProject.Properties.Resources.btn_pause_game;
            this.Pause_ptn_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Pause_ptn_2.Location = new System.Drawing.Point(14, -5);
            this.Pause_ptn_2.Name = "Pause_ptn_2";
            this.Pause_ptn_2.Size = new System.Drawing.Size(100, 50);
            this.Pause_ptn_2.TabIndex = 0;
            this.Pause_ptn_2.TabStop = false;
            this.Pause_ptn_2.Click += new System.EventHandler(this.Pause_ptn_2_Click);
            this.Pause_ptn_2.MouseLeave += new System.EventHandler(this.pic_MainMenu_MouseLeave);
            this.Pause_ptn_2.MouseHover += new System.EventHandler(this.pic_MainMenu_MouseHover);
            // 
            // gameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 776);
            this.ControlBox = false;
            this.Controls.Add(this.Pause_panel);
            this.Controls.Add(this.pic_board_cells_Chess);
            this.Controls.Add(this.pic_board_cells_Checkers);
            this.Controls.Add(this.pic_board_cells_XO);
            this.Controls.Add(this.pic_board_cells_C4);
            this.Controls.Add(this.lbl_Player_2_name);
            this.Controls.Add(this.pic_player_2_pic);
            this.Controls.Add(this.lbl_Player_2_timer);
            this.Controls.Add(this.pictureBox_timer_2);
            this.Controls.Add(this.lbl_Player_1_timer);
            this.Controls.Add(this.pic_player_1_pic);
            this.Controls.Add(this.lbl_Player_1_name);
            this.Controls.Add(this.pictureBox_timer_1);
            this.Controls.Add(this.pic_board_cells_reversi);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.pic_back_board);
            this.Controls.Add(this.pictureBox11);
            this.Controls.Add(this.pic_music);
            this.Controls.Add(this.pic_eff);
            this.Controls.Add(this.pic_player);
            this.Controls.Add(this.pic_pause_small);
            this.Controls.Add(this.pic_NewGame);
            this.Controls.Add(this.pic_MainMenu);
            this.Controls.Add(this.pic_history);
            this.Controls.Add(this.pic_player_1);
            this.Controls.Add(this.pic_player_2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "gameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pic_MainMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_NewGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_pause_small)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_timer_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_player_1_pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_timer_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_player_2_pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_eff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_music)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_board_cells_reversi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_back_board)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_history)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_player_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_player_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_board_cells_C4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_board_cells_XO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_board_cells_Checkers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_board_cells_Chess)).EndInit();
            this.Pause_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Pause_ptn_2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_MainMenu;
        private System.Windows.Forms.PictureBox pic_NewGame;
        private System.Windows.Forms.PictureBox pic_pause_small;
        private System.Windows.Forms.PictureBox pic_player_1_pic;
        private System.Windows.Forms.Label lbl_Player_2_name;
        private System.Windows.Forms.PictureBox pic_player_2_pic;
        private System.Windows.Forms.Label lbl_Player_1_name;
        private System.Windows.Forms.PictureBox pictureBox_timer_2;
        private System.Windows.Forms.PictureBox pictureBox_timer_1;
        private System.Windows.Forms.PictureBox pic_player;
        private System.Windows.Forms.Label lbl_Player_2_timer;
        private System.Windows.Forms.Label lbl_Player_1_timer;
        private System.Windows.Forms.PictureBox pic_eff;
        private System.Windows.Forms.PictureBox pic_music;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.PictureBox pic_board_cells_reversi;
        private System.Windows.Forms.PictureBox pic_back_board;
        private System.Windows.Forms.PictureBox pic_history;
        private System.Windows.Forms.PictureBox pic_player_1;
        private System.Windows.Forms.PictureBox pic_player_2;
		private System.Windows.Forms.PictureBox pic_board_cells_C4;
        private System.Windows.Forms.PictureBox pic_board_cells_XO;
        private System.Windows.Forms.PictureBox pic_board_cells_Checkers;
        private System.Windows.Forms.PictureBox pic_board_cells_Chess;
        private System.Windows.Forms.Panel Pause_panel;
        private System.Windows.Forms.PictureBox Pause_ptn_2;
    }
}