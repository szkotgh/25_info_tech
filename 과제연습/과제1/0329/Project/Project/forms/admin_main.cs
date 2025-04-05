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
    public partial class admin_main : mother
    {
        public admin_main()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Hide();
            new admin_user_info().ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            vq.imsg("분석");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Hide();
            new main().ShowDialog();
        }
    }
}
