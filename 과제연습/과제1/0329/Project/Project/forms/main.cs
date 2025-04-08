using Project.src;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.forms 
{
    public partial class main : mother
    {
        public main()
        {
            InitializeComponent();
            Thread t = new Thread(slide_location_lanking);
            t.Start();
            if (vq.user != null)
            {
                button1.Text = "회원 메뉴";
                button2.Text = "로그아웃";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            if (vq.user != null)
            {
                new user_main().ShowDialog();
                return;
            }
            new login().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            if (vq.user != null)
            {
                vq.user = null;
                new main().ShowDialog();
                return;
            }
            new admin_login().ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
            //Application.Exit();
        }

        private void slide_location_lanking()
        {
            Dictionary<int, int> lanking = new Dictionary<int, int>()
            {
                { 1, 0 },
                { 2, 0 },
                { 3, 0 },
                { 4, 0 },
                { 5, 0 },
                { 6, 0 },
                { 7, 0 },
                { 8, 0 },
                { 9, 0 },
                { 10, 0 },
                { 11, 0 },
                { 12, 0 },
                { 13, 0 },
                { 14, 0 },
                { 15, 0 },
                { 16, 0 },
            };

            int total_reservation = 0;
            var db_r = vq.db.reservation;
            var db_s = vq.db.schedule;
            foreach (var r in db_r)
            {
                foreach (var s in db_s)
                {
                    if (s.sno == r.sno)
                        lanking[(int)s.destination]++;
                }
                total_reservation++;
            }
            var top_lanking = lanking.OrderByDescending(x => x.Value).ToList();

            try
            {
                while (true)
                {
                    for (int i=0; i<5; i++)
                    {
                        int dif_index = top_lanking[i].Key;
                        string location_str = vq.db.location.Single(x => x.lno == dif_index).lname + "\n" + Convert.ToString(top_lanking[i].Value) + "건/총" + Convert.ToString(total_reservation) + "건";

                        Invoke(new Action(() =>
                        {
                            List<Label> labels = new List<Label>() { label1, label2, label3, label4, label5 };
                            foreach (var label in labels)
                                label.ForeColor = Color.Black;
                            labels[i].ForeColor = Color.Red;

                            label6.Text = location_str;
                            pictureBox1.Image = Image.FromFile("./지급자료/지역/" + dif_index + ".jpg");

                        }));

                        Thread.Sleep(1000);
                    }
                }
            } catch
            {
            }
        }
    }
}
