using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;

namespace ClassicRPS_Re_programmed_
{
    public partial class LeaderBoard : Telerik.WinControls.UI.RadForm
    {
        public LeaderBoard()
        {
            InitializeComponent();
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            DialogResult ans = MessageBox.Show("Application will exit. Continue?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans.ToString() == "Yes")
            {
                Application.Exit();
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form = new RadForm1();
            form.Show();
        }

        private void LeaderBoard_Load(object sender, EventArgs e)
        {
            try
            {
                string[] names = { };
                int[] scores = { };
                double[] rate = { };
                int[] all = { };
                int len = 0;
                string path = Application.LocalUserAppDataPath + "\\save.txt";
                List<string> datas = File.ReadAllLines(path).ToList();
                foreach (var data in datas)
                {
                    var i = data.Split(',');
                    Array.Resize(ref scores, len + 1);
                    Array.Resize(ref names, len + 1);
                    Array.Resize(ref rate, len + 1);
                    Array.Resize(ref all, len + 1);
                    names[len] = i[0];
                    scores[len] = int.Parse(i[1]);
                    rate[len] = double.Parse(i[3]);
                    len++;
                }
                for (int i = 0; i < rate.Length; i++)
                {
                    for (int j = i + 1; j < rate.Length; j++)
                    {
                        if (rate[i] < rate[j])
                        {
                            double temp = rate[i];
                            rate[i] = rate[j];
                            rate[j] = temp;
                            string tem = names[i];
                            names[i] = names[j];
                            names[j] = tem;
                            int te = scores[i];
                            scores[i] = scores[j];
                            scores[j] = te;
                        }
                    }
                }
                foreach (int i in scores)
                {
                    lbScore.Items.Add(i);
                }
                foreach (string i in names)
                {
                    lbName.Items.Add(i);
                }
                foreach (double i in rate)
                {
                    lbWinRate.Items.Add(i+"%");
                }

            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Save file not found.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbName_SelectedValueChanged(object sender, EventArgs e)
        {
            var xx = lbName.Items.IndexOf(lbName.SelectedItem);
            lbScore.SelectedIndex = xx;
            lbWinRate.SelectedIndex = xx;
        }
    }
}
