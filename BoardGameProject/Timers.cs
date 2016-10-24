using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BoardGameProject
{
    class Timers
    {
        private DateTime DT;
        Label lbl;
        Timer timer1;

        public Timers(Label _lpl)
        {
            lbl = _lpl;

            timer1 = new Timer();
            timer1.Enabled = false;
            timer1.Interval = 1000;
            timer1.Tick += new System.EventHandler(this.timer1_Tick);

            DT = new DateTime();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DT = DT.AddSeconds(1);
            string time_string = DT.ToLongTimeString();
            time_string = time_string.Substring(3, 5);
            lbl.Text = time_string;
        }

        public void Start()
        {
            timer1.Enabled = true;
        }

        public void Stop()
        {
            timer1.Enabled = false;
        }

        public void Reset()
        {
            lbl.Text = "00:00";
            DT = new DateTime();
        }

        public bool state()
        {
            return timer1.Enabled;
        }

    }
}
