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
    public partial class login : mother
    {
        public login()
        {
            InitializeComponent();
        }

        int type = 0;
        user u;
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            login_label.Text = "ID";
            type = 0;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            login_label.Text = "Email";
            type = 1;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            login_label.Text = "휴대폰";
            type = 2;
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            // empty check
            if (login_type_txtbox.Text == "" || login_pw_txtbox.Text == "")
            {
                vq.wmsg("빈칸이 있습니다.");
                return;
            }

            // login
            if (type == 0)
            {
                u = vq.db.user.SingleOrDefault(x => x.id == login_type_txtbox.Text);
            }
            else if (type == 1)
            {
                u = vq.db.user.SingleOrDefault(x => x.email == login_type_txtbox.Text);
            }
            else if (type == 2)
            {
                u = vq.db.user.SingleOrDefault(x => x.phone == login_type_txtbox.Text);
            }

            if (u == default || u.pw != login_pw_txtbox.Text)
            {
                vq.wmsg("일치하는 회원 정보가 없습니다.");
                return;
            }

            vq.imsg(u.name + "회원님 환영합니다.");
            vq.user = u;
            vq.cal_age_and_save();
            Hide();
            new user_main().ShowDialog();
            return;
        }
    }
}
