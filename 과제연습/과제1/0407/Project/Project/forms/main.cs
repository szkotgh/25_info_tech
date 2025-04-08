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
    public partial class main : frame
    {
        public main()
        {
            InitializeComponent();

            Thread th = new Thread(ldUp);
            th.IsBackground = true;
            th.Start();

            dUp();

            this.FormClosing += (s, e) =>
            {
                Environment.Exit(0);
            };
        }

        private void dUp()
        {
            if (vq.login_user == null)
            {
                button1.Text = "로그인";
                button2.Text = "관리자";
            }
            else
            {
                button1.Text = "회원 메뉴";
                button2.Text = "로그아웃";
            }
        }

        private void ldUp()
        {
            Dictionary<int, int> ranking = new Dictionary<int, int>()
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
            int all_count = 0;

            foreach (reservation r in vq.db.reservation)
            {
                schedule s = vq.db.schedule.Single(x => x.sno == r.sno);
                ranking[(int)s.destination]++;
                all_count++;
            }

            var ranking_order = ranking.OrderByDescending(x => x.Value).ToList();

            while (true)
            {
                for (int i=0; i<5; i++)
                {
                    var sel_rank = ranking_order[i];
                    string sel_l_name = vq.db.location.Single(x => x.lno == sel_rank.Key).lname;

                    Invoke(new Action(() =>
                    {
                        List<Label> labels = new List<Label>() { t1, t2, t3, t4, t5 };
                        foreach (Label label in labels)
                            label.ForeColor = Color.Black;
                        labels[i].ForeColor = Color.Red;

                        pictureBox1.Image = Image.FromFile("./지급자료/지역/" + sel_rank.Key + ".jpg");
                        l_title.Text = sel_l_name + "\n" + sel_rank.Value + "건/총" + all_count + "건";
                    }));

                    Thread.Sleep(1000);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (vq.login_user == null)
            {
                this.Hide();
                using (user_login al = new user_login())
                {
                    al.ShowDialog();
                }
            }
            else
            {
                this.Hide();
                using (user_main al = new user_main())
                {
                    al.ShowDialog();
                }
            }
            dUp();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (vq.login_user == null)
            {
                this.Hide();
                using (admin_login al = new admin_login())
                {
                    al.ShowDialog();
                }
            }
            else
            {
                vq.login_user = null;
                vq.imsg("로그아웃 되었습니다.");
            }
            dUp();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
