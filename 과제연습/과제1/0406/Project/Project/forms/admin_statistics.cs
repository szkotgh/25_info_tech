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
    public partial class admin_statistics : Form
    {
        public admin_statistics()
        {
            InitializeComponent();

            this.FormClosing += (s, e) =>
            {
                Hide();
                new admin_main().ShowDialog();
            };
        }
    }
}
