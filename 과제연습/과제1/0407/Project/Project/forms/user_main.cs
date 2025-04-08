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
    public partial class user_main : frame
    {
        public user_main()
        {
            InitializeComponent();
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
            this.Hide();
            new main().Close();
        }
    }
}
