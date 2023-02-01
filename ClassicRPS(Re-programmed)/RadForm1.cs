using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassicRPS_Re_programmed_
{
    public partial class RadForm1 : Telerik.WinControls.UI.RadForm
    {
        int sec2 = 10;
        int sec = 10;
        public RadForm1()
        {
            InitializeComponent();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sec != 0)
            {
                this.Opacity -= 0.10;
                sec--;
            }
            else
            {
                timer1.Stop();
                this.Hide();
                Form form = new LoadProfile();
                form.Show();
            }
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            DialogResult ans = MessageBox.Show("Application will exit. Continue?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans.ToString() == "Yes")
            {
                Application.Exit();
            }
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (sec2 != 0)
            {
                this.Opacity -= 0.10;
                sec2--;
            }
            else
            {
                timer2.Stop();
                this.Hide();
                Form form = new LeaderBoard();
                form.Show();
            }
        }
    }
}
