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
    public partial class user_main : mother
    {
        public user_main()
        {
            InitializeComponent();
            main_title.Text = vq.user.name + " [" + vq.user_type + "]";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            new ticket_reservation().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            vq.imsg(vq.user.name + " 마이페이지");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            new main().ShowDialog();
        }
    }
}
