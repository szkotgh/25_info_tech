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
    public partial class user_login : frame
    {
        public user_login()
        {
            InitializeComponent();

            this.FormClosing += (s, ev) =>
            {
                Hide();
                new main().Show();
            };
        }

        private int type = 1;

        private void radioButton1_Click(object sender, EventArgs e)
        {
            type = 1;
            login_type_lb.Text = "ID";
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            type = 2;
            login_type_lb.Text = "Email";
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            type = 3;
            login_type_lb.Text = "휴대폰";
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            string input_id = login_type_txt.Text;
            string input_pw = login_pw_txt.Text;

            if (input_id.Equals("") || input_pw.Equals(""))
            {
                vq.wmsg("빈칸이 있습니다.");
                return;
            }

            user u = null;
            if (type == 1)
                u = vq.db.user.SingleOrDefault(x => x.id == input_id && x.pw == input_pw);
            else if (type == 2)
                u = vq.db.user.SingleOrDefault(x => x.email == input_id && x.pw == input_pw);
            else
                u = vq.db.user.SingleOrDefault(x => x.phone == input_id && x.pw == input_pw);


            if (u == default)
            {
                vq.wmsg("일치하는 회원 정보가 없습니다.");
                return;
            }
            else
            {
                vq.login_user = u;
                vq.imsg(vq.login_user.name + "회원님 환영합니다.");
                Hide();
                new user_main().Show();
            }
        }
    }
}
