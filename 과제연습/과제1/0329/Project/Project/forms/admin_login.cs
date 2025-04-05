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
    public partial class admin_login : mother
    {
        public admin_login()
        {
            InitializeComponent();
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            if (login_id.Text == "" || login_pw.Text == "")
            {
                vq.wmsg("빈칸이 있습니다.");
                return;
            }

            if ((login_id.Text == "admin" && login_pw.Text == "1234") == false)
            {
                vq.wmsg("올바른 관리자 정보가 아닙니다.");
                return;
            }

            vq.imsg("관리자님 환영합니다.");
            Hide();
            new admin_main().ShowDialog();
        }
    }
}
