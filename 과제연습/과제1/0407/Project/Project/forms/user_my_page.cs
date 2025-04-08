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
    public partial class user_my_page : Form
    {
        public user_my_page()
        {
            InitializeComponent();
            this.FormClosing += (s, e) =>
            {
                Hide();
                new user_main().ShowDialog();
            };
        }
    }
}
