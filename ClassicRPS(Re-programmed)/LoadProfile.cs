using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Telerik.WinControls;
using System.IO;
using System.Linq;

namespace ClassicRPS_Re_programmed_
{
    public partial class LoadProfile : Telerik.WinControls.UI.RadForm
    {
        public LoadProfile()
        {
            InitializeComponent();
        }

        private void LoadProfile_Load(object sender, EventArgs e)
        {
            try
            {
                string path = Application.LocalUserAppDataPath + "\\save.txt";
                List<string> datas = File.ReadAllLines(path).ToList();
                foreach (var i in datas)
                {
                    var data = i.Split(',');
                    lbProfile.Items.Add(data[0]);
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Save file not found. Press \" OK\" and we'll create one for you.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string path = Application.LocalUserAppDataPath + "\\save.txt";
                File.Create(path).Close();
                MessageBox.Show("Save file successfully created. To start off, create a new player profile.");
            }
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            string path = Application.LocalUserAppDataPath + "\\save.txt";
            try
            {
                string profile = lbProfile.SelectedItem.ToString();
                List<string> datas = File.ReadAllLines(path).ToList();
                foreach (var i in datas)
                {
                    var ii = i.Split(',');
                    if (ii[0] == profile)
                    {
                        int w = int.Parse(ii[1]);
                        int l = int.Parse(ii[2]);
                        double wr = double.Parse(ii[3]);
                        int a = int.Parse(ii[4]);
                        this.Hide();
                        Form form = new MainGame(profile, w, l, wr, a);
                        form.Show();
                    }
                }

            }
            catch
            {
                MessageBox.Show("Please select existing profile or create a new one.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radButton4_Click(object sender, EventArgs e)
        {
            bool IsExisting = false;
            string path = Application.LocalUserAppDataPath + "\\save.txt";
            List<string> datas = File.ReadAllLines(path).ToList();
            foreach (var i in datas)
            {
                var ii = i.Split(',');
                if (ii[0] == txtNewProfile.Text)
                {
                    IsExisting = true;
                    break;
                }
            }

            if (IsExisting == true)
            {
                MessageBox.Show("Use different \"Username\".", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                datas.Add(txtNewProfile.Text + ",0,0,0.0,0");
                File.WriteAllLines(path, datas);
                MessageBox.Show("Profile has been successfully created.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Form form = new LoadProfile();
                form.Show();
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            radButton1.Enabled = false;
            txtNewProfile.Visible = radButton4.Visible = true;
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            DialogResult ans = MessageBox.Show("Application will exit. Continue?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans.ToString() == "Yes")
            {
                Application.Exit();
            }
        }
    }
}
