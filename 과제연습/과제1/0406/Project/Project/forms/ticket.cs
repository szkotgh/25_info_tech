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

            vq.start = default; vq.end = default;
            vq.start_txt = default; vq.end_txt = default;
            vq.sel_date = default;
            vq.start_time = default; vq.end_time = default;
            vq.ticket_cost = default;
            vq.sel_schedule = default;
            vq.sel_car = default;
            vq.sel_seat = default;

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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (vq.start == default || vq.end == default)
            {
                vq.wmsg("먼저 출발지와 도착지를 모두 선택해주세요.");
                return;
            }

            if (vq.sel_date == default || vq.start_time == default || vq.end_time == default)
            {
                vq.wmsg("먼저 운행스케줄을 조회해주세요.");
                return;
            }

            new ticket_train_seat().ShowDialog();
            dUp();
        }

        private void dUp()
        {
            textBox1.Text = (vq.start == default) ? "출발지 선택>" : vq.start_txt;
            textBox2.Text = (vq.end == default) ? "도착지 선택>" : vq.end_txt;

            textBox3.Text = (vq.sel_date == default || vq.start_time == default || vq.end_time == default) ? "" : vq.sel_date.ToShortDateString();
            textBox4.Text = (vq.sel_date == default || vq.start_time == default || vq.end_time == default) ? "" : vq.start_time.ToString();
            textBox5.Text = (vq.sel_date == default || vq.start_time == default || vq.end_time == default) ? "" : vq.end_time.ToString();

            textBox6.Text = (vq.sel_car == default || vq.sel_seat == default) ? "" : vq.sel_car.ToString();
            textBox7.Text = (vq.sel_car == default || vq.sel_seat == default) ? "" : vq.sel_seat;

            textBox8.Text = (vq.sel_car == default || vq.sel_seat == default) ? "" : "-" + Convert.ToInt32(vq.ticket_cost * vq.discount_cal(vq.age_cal((DateTime)vq.login_user.birth)));
            textBox9.Text = (vq.sel_car == default || vq.sel_seat == default) ? "" : Convert.ToInt32(vq.ticket_cost - vq.ticket_cost * vq.discount_cal(vq.age_cal((DateTime)vq.login_user.birth))).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (vq.sel_car == default || vq.sel_seat == default)
            {
                vq.wmsg("선택하지 않은 항목이 있습니다.");
                return;
            }

            vq.imsg("예매가 완료되었습니다.");

            reservation r = new reservation();
            r.rno = vq.db.reservation.Count() + 1;
            r.uno = vq.login_user.uno;
            r.sno = vq.sel_schedule.sno;
            r.carno = vq.sel_car;
            r.seat = vq.sel_seat;
            vq.db.reservation.Add(r);
            vq.db.SaveChanges();

            Hide();
        }
    }
}
