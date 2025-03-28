using Project.aframe;
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
    public partial class 예매 : Form1
    {
        public 예매()
        {
            InitializeComponent();
        }

        private void dup()
        {
            foreach (var l in vq.db.location)
            {
                if (l.lno == vq.start)
                {
                    start.Text = l.lname;
                }
                if (l.lno == vq.end)
                {
                    end.Text = l.lname;
                }
            }
            date.Text = vq.date;
        }

        private void start_Click(object sender, EventArgs e)
        {
            vq.move = 0;
            new 지도().ShowDialog();
            dup();
        }

        private void end_Click(object sender, EventArgs e)
        {
            vq.move = 1;
            new 지도().ShowDialog();
            dup();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new 달력().ShowDialog();
            dup(); 
        }
    }
}
