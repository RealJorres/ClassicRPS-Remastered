using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;

namespace ClassicRPS_Re_programmed_
{
    public partial class MainGame : Telerik.WinControls.UI.RadForm
    {
        int sec = 1;
        int playerMove;
        int comMove;
        int W = 0;
        int L = 0;
        int A = 0;
        public MainGame(string name, int win, int lose, double wr, int a)
        {
            InitializeComponent();
            lblPlayerName.Text = name;
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            string profile = lblPlayerName.Text;
            DialogResult ans = MessageBox.Show("You will be redirected to \"Main Menu\". Continue?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans.ToString() == "Yes")
            {
                string newData = String.Empty;
                int count = -1;
                string path = Application.LocalUserAppDataPath + "\\save.txt";
                List<string> datas = File.ReadAllLines(path).ToList();
                foreach (var i in datas)
                {
                    count++;
                    var ii = i.Split(',');
                    if (ii[0] == profile)
                    {
                        int w = int.Parse(ii[1]);
                        int l = int.Parse(ii[2]);
                        int a = int.Parse(ii[4]);
                        W += w;
                        L += l;
                        A += a;
                        double WW = Convert.ToDouble(W);
                        double AA = Convert.ToDouble(A);
                        double WR = Math.Round((WW / AA) * 100);
                        newData = profile + "," + W.ToString() + "," + L.ToString() + "," + WR.ToString() + "," + A.ToString();
                        break;
                    }
                }
                datas.RemoveAt(count);
                datas.Add(newData);
                File.WriteAllLines(path, datas);
                MessageBox.Show("Record has been updated. Press \"OK\" to continue.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Form form = new RadForm1();
                form.Show();
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            string profile = lblPlayerName.Text;
            DialogResult ans = MessageBox.Show("Application will exit. Continue?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans.ToString() == "Yes")
            {
                string newData = String.Empty;
                int count = -1;
                string path = Application.LocalUserAppDataPath + "\\save.txt";
                List<string> datas = File.ReadAllLines(path).ToList();
                foreach (var i in datas)
                {
                    count++;
                    var ii = i.Split(',');
                    if (ii[0] == profile)
                    {
                        int w = int.Parse(ii[1]);
                        int l = int.Parse(ii[2]);
                        int a = int.Parse(ii[4]);
                        W += w;
                        L += l;
                        A += a;
                        double WW = Convert.ToDouble(W);
                        double AA = Convert.ToDouble(A);
                        double WR = Math.Round((WW / AA) * 100);
                        newData = profile + "," + W.ToString() + "," + L.ToString() + "," + WR.ToString() + "," + A.ToString();
                        break;
                    }
                }
                datas.RemoveAt(count);
                datas.Add(newData);
                File.WriteAllLines(path, datas);
                MessageBox.Show("Record has been updated. Press \"OK\" to exit.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            string profile = lblPlayerName.Text;
            string path = Application.LocalUserAppDataPath + "\\save.txt";
            List<string> datas = File.ReadAllLines(path).ToList();
            foreach (var i in datas)
            {
                var ii = i.Split(',');
                if (ii[0] == profile)
                {
                    MessageBox.Show("All-Time-Record\nWins: " + ii[1] + "\nLoses: " + ii[2] + "\nWin Rate: " + ii[3] + "%", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            A++;
            pbPlayer.BackgroundImage = imageList1.Images[0];
            playerMove = 1;
            button1.Enabled = button2.Enabled = button3.Enabled = false;
            timer1.Start();
            Random ran = new Random();
            var num = ran.Next(1, 4);
            if (num == 1)
            {
                pbComputer.BackgroundImage = imageList1.Images[0];
                comMove = 1;
            }
            else if (num == 2)
            {
                pbComputer.BackgroundImage = imageList1.Images[1];
                comMove = 2;
            }
            else
            {
                pbComputer.BackgroundImage = imageList1.Images[2];
                comMove = 3;
            }

            if ((playerMove == 1) && (comMove == 1))
            {
                pnlResult.Visible = true;
                lbResult.Text = "Result: Draw";
            }
            else if ((playerMove == 1) && (comMove == 2))
            {
                pnlResult.Visible = true;
                lbResult.Text = "Result: Com Wins";
                L++;
            }
            else if ((playerMove == 1) && (comMove == 3))
            {
                pnlResult.Visible = true;
                lbResult.Text = "Result: " + lblPlayerName.Text + " Wins";
                W++;
            }
            else if ((playerMove == 2) && (comMove == 1))
            {
                pnlResult.Visible = true;
                lbResult.Text = "Result: " + lblPlayerName.Text + " Wins";
                W++;
            }
            else if ((playerMove == 2) && (comMove == 2))
            {
                pnlResult.Visible = true;
                lbResult.Text = "Result: Draw";
            }
            else if ((playerMove == 2) && (comMove == 3))
            {
                pnlResult.Visible = true;
                lbResult.Text = "Result: Com Wins";
                L++;
            }
            else if ((playerMove == 3) && (comMove == 1))
            {
                pnlResult.Visible = true;
                lbResult.Text = "Result: Com Wins";
                L++;
            }
            else if ((playerMove == 3) && (comMove == 2))
            {
                pnlResult.Visible = true;
                lbResult.Text = "Result: " + lblPlayerName.Text + " Wins";
                W++;
            }
            else
            {
                pnlResult.Visible = true;
                lbResult.Text = "Result: Draw";
            }
            lblRecord.Text = W + "W/ " + L + "L /" + A + " Turns This Session";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            A++;
            pbPlayer.BackgroundImage = imageList1.Images[1];
            playerMove = 2;
            button1.Enabled = button2.Enabled = button3.Enabled = false;
            timer1.Start();
            Random ran = new Random();
            var num = ran.Next(1, 4);
            if (num == 1)
            {
                pbComputer.BackgroundImage = imageList1.Images[0];
                comMove = 1;
            }
            else if (num == 2)
            {
                pbComputer.BackgroundImage = imageList1.Images[1];
                comMove = 2;
            }
            else
            {
                pbComputer.BackgroundImage = imageList1.Images[2];
                comMove = 3;
            }

            if ((playerMove == 1) && (comMove == 1))
            {
                pnlResult.Visible = true;
                lbResult.Text = "Result: Draw";
            }
            else if ((playerMove == 1) && (comMove == 2))
            {
                pnlResult.Visible = true;
                lbResult.Text = "Result: Com Wins";
                L++;
            }
            else if ((playerMove == 1) && (comMove == 3))
            {
                pnlResult.Visible = true;
                lbResult.Text = "Result: " + lblPlayerName.Text + " Wins";
                W++;
            }
            else if ((playerMove == 2) && (comMove == 1))
            {
                pnlResult.Visible = true;
                lbResult.Text = "Result: " + lblPlayerName.Text + " Wins";
                W++;
            }
            else if ((playerMove == 2) && (comMove == 2))
            {
                pnlResult.Visible = true;
                lbResult.Text = "Result: Draw";
            }
            else if ((playerMove == 2) && (comMove == 3))
            {
                pnlResult.Visible = true;
                lbResult.Text = "Result: Com Wins";
                L++;
            }
            else if ((playerMove == 3) && (comMove == 1))
            {
                pnlResult.Visible = true;
                lbResult.Text = "Result: Com Wins";
                L++;
            }
            else if ((playerMove == 3) && (comMove == 2))
            {
                pnlResult.Visible = true;
                lbResult.Text = "Result: " + lblPlayerName.Text + " Wins";
                W++;
            }
            else
            {
                pnlResult.Visible = true;
                lbResult.Text = "Result: Draw";
            }
            lblRecord.Text = W + "W/ " + L + "L /" + A + " Turns This Session";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            A++;
            pbPlayer.BackgroundImage = imageList1.Images[2];
            playerMove = 3;
            button1.Enabled = button2.Enabled = button3.Enabled = false;
            timer1.Start();
            Random ran = new Random();
            var num = ran.Next(1, 4);
            if (num == 1)
            {
                pbComputer.BackgroundImage = imageList1.Images[0];
                comMove = 1;
            }
            else if (num == 2)
            {
                pbComputer.BackgroundImage = imageList1.Images[1];
                comMove = 2;
            }
            else
            {
                pbComputer.BackgroundImage = imageList1.Images[2];
                comMove = 3;
            }

            if ((playerMove == 1) && (comMove == 1))
            {
                pnlResult.Visible = true;
                lbResult.Text = "Result: Draw";
            }
            else if ((playerMove == 1) && (comMove == 2))
            {
                pnlResult.Visible = true;
                lbResult.Text = "Result: Com Wins";
                L++;
            }
            else if ((playerMove == 1) && (comMove == 3))
            {
                pnlResult.Visible = true;
                lbResult.Text = "Result: " + lblPlayerName.Text + " Wins";
                W++;
            }
            else if ((playerMove == 2) && (comMove == 1))
            {
                pnlResult.Visible = true;
                lbResult.Text = "Result: " + lblPlayerName.Text + " Wins";
                W++;
            }
            else if ((playerMove == 2) && (comMove == 2))
            {
                pnlResult.Visible = true;
                lbResult.Text = "Result: Draw";
            }
            else if ((playerMove == 2) && (comMove == 3))
            {
                pnlResult.Visible = true;
                lbResult.Text = "Result: Com Wins";
                L++;
            }
            else if ((playerMove == 3) && (comMove == 1))
            {
                pnlResult.Visible = true;
                lbResult.Text = "Result: Com Wins";
                L++;
            }
            else if ((playerMove == 3) && (comMove == 2))
            {
                pnlResult.Visible = true;
                lbResult.Text = "Result: " + lblPlayerName.Text + " Wins";
                W++;
            }
            else
            {
                pnlResult.Visible = true;
                lbResult.Text = "Result: Draw";
            }
            lblRecord.Text = W + "W/ " + L + "L /" + A + " Turns This Session";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sec != 0)
            {
                sec--;
            }
            else
            {
                pnlResult.Visible = false;
                timer1.Stop();
                button1.Enabled = button2.Enabled = button3.Enabled = true;
                pbComputer.BackgroundImage = pbPlayer.BackgroundImage = null;
                sec = 1;
            }
        }
    }
}
