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
    public partial class 지도 : Form1
    {
        public 지도()
        {
            InitializeComponent();
            dup();
        }

        int lno; // 지역번호
        String lname; //지역명

        private void dup()
        {
            String aa = vq.move == 1 ? "도착지" : "출발지";
            this.Text = aa + " 선택"; // 제목
            foreach (var l in vq.db.location)
            {
                int x = l.lx.Value, y = l.ly.Value;
                Label jl = new Label()
                {
                    Font = new Font("돋움", 10),
                    Text = l.lname,
                    Tag = l.lno,
                    Size = new Size(40, 20),
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Color.White,
                    BackColor = vq.move == 1 ? Color.Red : Color.Blue,
                    Location = new Point(x, y),
                };
                jl.MouseClick += locationMousedown;
                pictureBox1.Controls.Add(jl);
            }
        }

        private void locationMousedown(object sender, MouseEventArgs e)
        {
            lno = (int)(sender as Label).Tag;
            lname = (String)(sender as Label).Text;
            if (lno == vq.start)
            {
                vq.wmsg("도착지는 출발지와 같은 지역을\r\n선택할 수 없습니다.");
                return;
            }
            if (vq.move == 0)
            {
                vq.start = lno;
                vq.start_nm = lname;
            } else
            {
                vq.end = lno;
                vq.end_nm = lname;
            }
            Close();
        }
    }
}
