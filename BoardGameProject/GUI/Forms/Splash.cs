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
    public partial class Splash : Form
    {
        int x;
        public Splash()
        {
            InitializeComponent();
            
            x = 0;
            GUI.SetGUI();
            Sound.setSound();
            Drawer.setDrawer();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            x++;
            if (x == 50)
            {
                timer1.Stop();
                this.Hide();
                GUI.PlayerSelectForm.Show();
                GUI.SetCtrlBG(GUI.PlayerSelectForm);
            }
        }
    }
}
