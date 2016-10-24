namespace BoardGameProject
{
    partial class PlayerMode
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
            this.pic_one_player = new System.Windows.Forms.PictureBox();
            this.pic_two_players = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_one_player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_two_players)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_one_player
            // 
            this.pic_one_player.BackColor = System.Drawing.Color.Transparent;
            this.pic_one_player.BackgroundImage = global::BoardGameProject.Properties.Resources._1_player;
            this.pic_one_player.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic_one_player.Location = new System.Drawing.Point(328, 281);
            this.pic_one_player.Name = "pic_one_player";
            this.pic_one_player.Size = new System.Drawing.Size(267, 206);
            this.pic_one_player.TabIndex = 0;
            this.pic_one_player.TabStop = false;
            this.pic_one_player.Click += new System.EventHandler(this.pic_one_player_Click);
            // 
            // pic_two_players
            // 
            this.pic_two_players.BackColor = System.Drawing.Color.Transparent;
            this.pic_two_players.BackgroundImage = global::BoardGameProject.Properties.Resources._2_players;
            this.pic_two_players.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic_two_players.Location = new System.Drawing.Point(766, 281);
            this.pic_two_players.Name = "pic_two_players";
            this.pic_two_players.Size = new System.Drawing.Size(267, 206);
            this.pic_two_players.TabIndex = 1;
            this.pic_two_players.TabStop = false;
            this.pic_two_players.Click += new System.EventHandler(this.pic_two_players_Click);
            // 
            // PlayerMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 780);
            this.Controls.Add(this.pic_two_players);
            this.Controls.Add(this.pic_one_player);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PlayerMode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PlayerMode";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pic_one_player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_two_players)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_one_player;
        private System.Windows.Forms.PictureBox pic_two_players;
    }
}