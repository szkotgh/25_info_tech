using Project.src;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.forms
{
    public partial class ticket_reservation : mother
    {
        public ticket_reservation()
        {
            InitializeComponent();

            vq.start = null;
            vq.end = null;
            vq.start_nm = null;
            vq.end_nm = null;
            vq.price = null;
            vq.date = null;
            vq.start_date = null;
            vq.end_date = null;
            vq.run_schedule = null;
            vq.car = null;
            vq.seat = null;
            vq.discount = default;
        }

        private void start_Click(object sender, EventArgs e)
        {
            vq.move = 0;
            new map().ShowDialog();

            vq.price = null;
            vq.date = null;
            vq.start_date = null;
            vq.end_date = null;
            vq.run_schedule = null;
            vq.car = null;
            vq.seat = null;
            vq.discount = default;
            dUp();
        }

        private void end_Click(object sender, EventArgs e)
        {
            if (vq.start == null)
            {
                vq.wmsg("먼저 출발지를 선택해주세요.");
                return;
            }

            vq.move = 1;
            new map().ShowDialog();

            vq.price = null;
            vq.date = null;
            vq.start_date = null;
            vq.end_date = null;
            vq.run_schedule = null;
            vq.car = null;
            vq.seat = null;
            vq.discount = default;
            dUp();
        }

        private void dUp()
        {
            // update start
            if (vq.start != null)
                start.Text = vq.start_nm;
            else
                start.Text = "출발지 선택>";
            if (vq.end != null)
                end.Text = vq.end_nm;
            else
                end.Text = "도착지 선택>";

            // update run
            if (vq.date != null || vq.start_date != null || vq.end_date != null)
            {
                DateTime run_date = (DateTime)vq.date;
                run_time.Text = run_date.ToShortDateString();
                DateTime start_date = (DateTime)vq.start_date;
                textBox3.Text = start_date.ToShortTimeString();
                DateTime end_date = (DateTime)vq.end_date;
                textBox2.Text = end_date.ToShortTimeString();
            }
            else
            {
                run_time.Text = "";
                textBox3.Text = "";
                textBox2.Text = "";
            }

            // update train
            if (vq.car != null || vq.seat != null)
            {
                textBox4.Text = vq.car.ToString();
                textBox5.Text = vq.seat;
            }
            else
            {
                textBox4.Text = "";
                textBox5.Text = "";
            }

            // update price
            if (vq.car != null || vq.seat != null)
            {
                int total_price = Convert.ToInt32(vq.price);

                if (vq.user_type == "유아")
                    vq.discount = 1;
                else if (vq.user_type == "어린이")
                    vq.discount = (float)0.4;
                else if (vq.user_type == "청소년")
                    vq.discount = (float)0.2;
                else if (vq.user_type == "성인")
                    vq.discount = 0;
                else
                    vq.discount = 0;

                textBox6.Text = "-" + Convert.ToString((int)((float)vq.price * vq.discount)) + "원";
                textBox7.Text = vq.price + "원";
            }
            else
            {
                textBox6.Text = "";
                textBox7.Text = "";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (vq.start == null || vq.end == null)
            {
                vq.wmsg("먼저 출발지와 도착지를 모두 선택해주세요.");
                return;
            }
            new calender().ShowDialog();
            dUp();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (vq.start == null || vq.end == null)
            {
                vq.wmsg("먼저 출발지와 도착지를 모두 선택해주세요.");
                return;
            }
            else if (vq.run_schedule == null)
            {
                vq.wmsg("먼저 운행스케줄을 조회해주세요.");
                return;
            }
                new train_seat().ShowDialog();
            dUp();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (vq.car == null || vq.seat == null)
            {
                vq.wmsg("선택하지 않은 항목이 있습니다.");
                return;
            }

            vq.imsg("예매가 완료되었습니다.");
            reservation r = new reservation();
            r.rno = vq.db.reservation.Count() + 1;
            r.uno = vq.user.uno;
            r.sno = vq.run_schedule.sno;
            r.carno = vq.car;
            r.seat = vq.seat;
            vq.db.reservation.Add(r);
            vq.db.SaveChanges();
            Hide();
            new user_main().ShowDialog();
        }
    }
}
