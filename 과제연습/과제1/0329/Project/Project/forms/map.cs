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
    public partial class map : Form
    {
        public map()
        {
            InitializeComponent();
            dUp();
        }

        private void dUp()
        {
            Text = (vq.move == 0) ? "출발지 선택" : "도착지 선택";
            
            foreach (var l in vq.db.location)
            {
                int x = (int)l.lx, y = (int)l.ly;
                Label jl = new Label()
                {
                    Font = new Font("맑은고딕", 10),
                    Text = l.lname,
                    Tag = l.lno,
                    Size = new Size(35, 20),
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Color.White,
                    BackColor = (vq.move == 0) ? Color.Blue : Color.Red,
                    Location = new Point(x, y),
                };

                jl.MouseClick += (o, e) =>
                {
                    if (vq.move == 0)
                    {
                        if (vq.start == (int)jl.Tag)
                        {
                            vq.wmsg("이미 출발지에 선택되었습니다.");
                            return;
                        }
                        if (vq.end == (int)jl.Tag)
                        {
                            vq.wmsg("출발지는 도착지와 같은 지역을 선택할 수 없습니다.");
                            return;
                        }
                    }
                    else if(vq.move == 1)
                    {
                        if (vq.end == (int)jl.Tag)
                        {
                            vq.wmsg("이미 도착지에 선택되었습니다.");
                            return;
                        }
                        if (vq.start == (int)jl.Tag)
                        {
                            vq.wmsg("도착지는 출발지와 같은 지역을 선택할 수 없습니다.");
                            return;
                        }
                    }

                    if (vq.move == 0)
                    {
                        vq.start = (int)jl.Tag;
                        vq.start_nm = vq.db.location.Single(xx => xx.lno == vq.start).lname;
                    }
                    else if(vq.move == 1)
                    {
                        vq.end = (int)jl.Tag;
                        vq.end_nm = vq.db.location.Single(xx => xx.lno == vq.end).lname;
                    }
                    Close();
                };

                pictureBox1.Controls.Add(jl);
            }
        }
    }
}
