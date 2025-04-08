using Project.src;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.forms
{
    public partial class main : frame
    {
        public main()
        {
            InitializeComponent();
            dUp();

            Thread lt = new Thread(this.loca_dUp);
            lt.IsBackground = true;
            lt.Start();

            this.Click += (s, e) => {
                Close();
                Environment.Exit(0);
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            if (vq.login_user == null)
            {
                using (user_login loginForm = new user_login())
                {
                    loginForm.ShowDialog();
                }
            }
            else
            {
                using (user_main userMain = new user_main())
                {
                    userMain.ShowDialog();
                }
            }

            this.Show();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (vq.login_user == null)
            {
                Hide();
                using (admin_login adminLogin = new admin_login())
                {
                    adminLogin.ShowDialog();
                }
                this.Show();
            }
            else
            {
                vq.login_user = null;
                vq.imsg("로그아웃 되었습니다.");
                dUp();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Environment.Exit(0);
            }
            catch(Exception e2)
            {
            }
        }

        private void dUp()
        {
            bool isLogin = vq.login_user != null;

            if (isLogin)
            {
                button1.Text = "회원 메뉴";
                button2.Text = "로그아웃";
            }
            else
            {
                button1.Text = "로그인";
                button2.Text = "관리자";
            }
        }

        private void loca_dUp()
        {
            Dictionary<int, int> top_list = new Dictionary<int, int>()
            {
                {1, 0},
                {2, 0},
                {3, 0},
                {4, 0},
                {5, 0},
                {6, 0},
                {7, 0},
                {8, 0},
                {9, 0},
                {10, 0},
                {11, 0},
                {12, 0},
                {13, 0},
                {14, 0},
                {15, 0},
                {16, 0},
            };

            int total_count = 0;
            foreach(reservation rs in vq.db.reservation)
            {
                schedule sc = vq.db.schedule.Single(x => x.sno == rs.sno);
                top_list[(int)sc.destination] += 1;
                total_count++;
            }

            var top_list_order = top_list.OrderByDescending(x => x.Value).ToList();

            try
            {
                while (true)
                {
                    for (int i=0; i<5; i++)
                    {
                        int lno = Convert.ToInt32(top_list_order[i].Key);
                        location _s = vq.db.location.Single(x => x.lno == lno);

                        Invoke(new Action(() =>
                        {
                            List<Label> labels = new List<Label>() { t1, t2, t3, t4, t5 };
                            foreach (Label label in labels)
                                label.ForeColor = Color.Black;
                            labels[i].ForeColor = Color.Red;

                            pictureBox1.Image = Image.FromFile("./지급자료/지역/" + lno + ".jpg");
                            city.Text = _s.lname + "\n" + top_list_order[i].Value + "건/총" + total_count + "건";
                        }));

                        Thread.Sleep(1000);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
