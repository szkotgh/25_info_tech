using Project.src;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.forms
{
    public partial class ticket : frame
    {
        public ticket()
        {
            InitializeComponent();
            dUp();

            this.FormClosing += (s, e) =>
            {
                Hide();
                new user_main().ShowDialog();
            };
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            vq.move = 1;
            new ticket_map().ShowDialog();
            dUp();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (vq.start == default)
            {
                vq.wmsg("먼저 출발지를 선택해주세요.");
                return;
            }
            vq.move = 2;
            new ticket_map().ShowDialog();
            dUp();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (vq.start == default || vq.end == default)
            {
                vq.wmsg("먼저 출발지와 도착지를 모두 선택해주세요.");
                return;
            }

            new ticket_calender().ShowDialog();
            dUp();
        }

        private void dUp()
        {
            textBox1.Text = (vq.start == default) ? "출발지 선택>" : vq.start_txt;
            textBox2.Text = (vq.end == default) ? "도착지 선택>" : vq.end_txt;

            textBox3.Text = (vq.sel_date == default) ? "" : vq.sel_date.ToShortDateString();
            textBox4.Text = (vq.start_time == default) ? "" : vq.start_time.ToString();
            textBox5.Text = (vq.end_time == default) ? "" : vq.end_time.ToString();

        }
    }
}
