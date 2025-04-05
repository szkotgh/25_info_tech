using Project.src;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.forms
{
    public partial class train_seat : mother
    {
        int carno = 1;
        List<string> rows = new List<string>() { "A", "B", "C", "D", "E" };
        List<string> cols = new List<string>() { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10" };

        public train_seat()
        {
            InitializeComponent();
            dUp();
        }

        private void dUp()
        {
            train_title.Text = carno + "호차";
            l_train_index.Text = (carno - 1) + "";
            label3.Text = (carno + 1) + "";

            groupBox1.Visible = (carno == 1) ? false : true;
            groupBox2.Visible = (carno == 5) ? false : true;

            seat.Controls.Clear();
            for (int i = 0; i < rows.Count; i++)
            {
                for (int j = 0; j < cols.Count; j++)
                {
                    var jl = new Label()
                    {
                        Name = rows[i] + cols[j],
                        Size = new Size(53, 47),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Text = rows[i] + cols[j],
                        BorderStyle = BorderStyle.FixedSingle,
                        BackColor = Color.White
                    };

                    bool is_reserved = false;
                    foreach (var r in vq.db.reservation)
                    {
                        if (r.sno == vq.run_schedule.sno && r.carno == carno && r.seat == rows[i] + cols[j])
                            is_reserved = true;
                    }

                    if (is_reserved)
                    {
                        jl.BackColor = Color.Gray;
                        jl.Click += (sender, e) =>
                        {
                            vq.wmsg("이미 예약된 좌석입니다.");
                            return;
                        };
                    }
                    else
                    {
                        jl.Click += (sender, e) =>
                        {
                            vq.seat = jl.Text;
                            vq.car = carno;
                            form_close();
                            return;
                        };
                    }

                    seat.Controls.Add(jl, j, i);
                }
            }
        }

        private void form_close()
        {
            this.Close();
        }

        private void l_train_index_Click(object sender, EventArgs e)
        {
            carno -= 1;
            dUp();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            carno += 1;
            dUp();
        }
    }
}
