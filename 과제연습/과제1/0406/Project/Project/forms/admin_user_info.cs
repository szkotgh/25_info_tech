using Project.src;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.forms
{
    public partial class admin_user_info : Form
    {
        public admin_user_info()
        {
            InitializeComponent();
            dUp();

            FormClosing += (s, e) =>
            {
                Hide();
                new admin_main().ShowDialog();
            };
        }

        private void dUp()
        {
            string filter_type = comboBox1.Text;

            panel1.Controls.Clear();
            foreach(user user in vq.db.user)
            {
                string user_type = vq.age_cal((DateTime)user.birth);
                if (filter_type != "전체" && filter_type != user_type)
                    continue;

                Panel u_panel = new Panel()
                {
                    Size = new Size(304, 100),
                    Location = new Point(17, (120 * panel1.Controls.Count)+17),
                    BorderStyle = BorderStyle.FixedSingle
                };

                Color user_color;
                if (user_type == "청소년")
                    user_color = Color.Red;
                else if (user_type == "성인")
                    user_color = Color.Orange;
                else if (user_type == "어린이")
                    user_color = Color.SteelBlue;
                else
                    user_color = Color.Yellow;

                Label u_type = new Label()
                {
                    Text = user_type,
                    Font = new Font("맑은고딕", 9, FontStyle.Regular),
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = user_color,
                    Size = new Size(62, 100),
                    Location = new Point(0, 0)
                };

                Label u_name = new Label()
                {
                    Text = user.name,
                    Font = new Font("맑은고딕", 14, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleLeft,
                    BackColor = Color.White,
                    Size = new Size(242, 30),
                    Padding = new Padding(10, 0, 0, 0),
                    Location = new Point(62, 0)
                };

                DateTime u_date = (DateTime)user.birth;
                Label u_desc = new Label()
                {
                    Text = user.id + "\n" + u_date.ToShortDateString() + "\n" + user.phone + "\n" + user.email,
                    Font = new Font("맑은고딕", 9, FontStyle.Regular),
                    TextAlign = ContentAlignment.TopLeft,
                    BackColor = Color.White,
                    Size = new Size(242, 70),
                    Padding = new Padding(10, 0, 0, 0),
                    Location = new Point(62, 30)
                };

                u_panel.Controls.Add(u_type);
                u_panel.Controls.Add(u_name);
                u_panel.Controls.Add(u_desc);

                void del_user()
                {
                    if (vq.qmsg("회원을 삭제하시겠습니까?"))
                    {
                        user rm_user = vq.db.user.SingleOrDefault(x => x.id == user.id);
                        List<reservation> rm_user_resers = vq.db.reservation.Where(e => e.uno == rm_user.uno).ToList();
                        vq.db.user.Remove(rm_user);
                        foreach (reservation rm_user_reser in rm_user_resers)
                            vq.db.reservation.Remove(rm_user_reser);
                        vq.db.SaveChanges();
                        dUp();
                    }
                }

                u_type.DoubleClick += (s, e) => del_user();
                u_name.DoubleClick += (s, e) => del_user();
                u_desc.DoubleClick += (s, e) => del_user();

                panel1.Controls.Add(u_panel);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dUp();
        }
    }
}
