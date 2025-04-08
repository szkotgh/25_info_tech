using Project.src;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.forms
{
    public partial class user_main : frame
    {
        public user_main()
        {
            InitializeComponent();
            title.Text = vq.login_user.name + " [" + vq.age_cal((DateTime)vq.login_user.birth) + "]";

            this.FormClosing += (s, e) =>
            {
                Hide();
                new user_login().ShowDialog();
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            new ticket().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            new user_my_page().ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            new main().ShowDialog();
        }
    }
}
