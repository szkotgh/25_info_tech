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
    public partial class admin_login : frame
    {
        public admin_login()
        {
            InitializeComponent();

            this.FormClosing += (s, e) =>
            {
                Hide();
                new main().ShowDialog();
            };
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            if (login_type_txt.Text == "" || login_pw_txt.Text == "")
            {
                vq.wmsg("빈칸이 있습니다.");
                return;
            }

            if (login_type_txt.Text == "admin" || login_pw_txt.Text == "1234")
            {
                vq.imsg("관리자님 환영합니다.");
                Hide();
                new admin_main().ShowDialog();
                return;
            }
            else
            {
                vq.wmsg("올바른 관리자 정보가 아닙니다.");
                return;
            }
        }
    }
}
