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
    public partial class ticket_map : Form
    {
        public ticket_map()
        {
            InitializeComponent();
            dUp();
        }

        private void dUp()
        {
            if (vq.move == 1)
                Text = "출발지 선택";
            else
                Text = "도착지 선택";

            foreach(location loca in vq.db.location)
            {
                Label jl = new Label()
                {
                    Text = loca.lname,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(35, 20),
                    Location = new Point((int)loca.lx, (int)loca.ly),
                    BackColor = (vq.move == 1) ? Color.Blue : Color.Red,
                    ForeColor = Color.White,
                    Cursor = Cursors.Hand,
                    Tag = loca.lno
                };

                jl.Click += (s, e) =>
                {
                    if (vq.move == 1)
                    {
                        vq.start = Convert.ToInt32(jl.Tag);
                        vq.start_txt = jl.Text;
                    }
                    else
                    {
                        if (vq.start == Convert.ToInt32(jl.Tag))
                        {
                            vq.wmsg("도착지는 출발지와 같은 지역을 선택할 수 없습니다.");
                            return;
                        }
                        vq.end = Convert.ToInt32(jl.Tag);
                        vq.end_txt = jl.Text;
                    }
                    Hide();
                };

                pictureBox1.Controls.Add(jl);
            }
        }
    }
}
