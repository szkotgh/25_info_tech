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
    public partial class user_login : frame
    {
        public user_login()
        {
            InitializeComponent();
        }

        private int type = 1;
        private void radioButton1_Click(object sender, EventArgs e)
        {
            login_id_label.Text = "ID";
            type = 1;
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            login_id_label.Text = "Email";
            type = 2;
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            login_id_label.Text = "휴대폰";
            type = 3;
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            string login_id = textBox1.Text;
            string login_pw = textBox2.Text;

            if (login_id == "" || login_pw == "")
            {
                vq.wmsg("빈칸이 있습니다.");
                return;
            }

            user u = default;
            if (type == 1)
                u = vq.db.user.SingleOrDefault(x => x.id == login_id && x.pw == login_pw);
            else if (type == 2)
                u = vq.db.user.SingleOrDefault(x => x.email == login_id && x.pw == login_pw);
            else
                u = vq.db.user.SingleOrDefault(x => x.phone == login_id && x.pw == login_pw);

            if (u == default)
            {
                vq.wmsg("일치하는 회원 정보가 없습니다.");
                return;
            }

            vq.login_user = u;
            vq.imsg(u.name + "회원님 환영합니다.");

            this.Hide();
            new user_main().ShowDialog();
        }
    }
}
