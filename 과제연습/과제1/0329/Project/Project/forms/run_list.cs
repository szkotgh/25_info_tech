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
    public partial class run_list : mother
    {
        public static DateTime user_date;
        public run_list()
        {
            InitializeComponent();
            dUp();
        }

        List<schedule> schedules = new List<schedule>();
        private void dUp()
        {
            run_text.Text = "출발지: " + vq.start_nm + " → " + "도착지: " + vq.end_nm;

            int cost = 5000;
            cost += (Convert.ToInt32(vq.start - vq.end) < 0 ? Convert.ToInt32(vq.start - vq.end) * -1 : Convert.ToInt32(vq.start - vq.end)) * 1000;
            vq.price = cost;
            cost_text.Text = "금액: " + cost.ToString("N0") + "원";

            DateTime now_date = DateTime.Now;
            TimeSpan now_time = DateTime.Now.TimeOfDay;
            
            foreach(var s in vq.db.schedule)
            {
                if (s.date != user_date.Date)
                    continue;

                if (s.starting != vq.start || s.destination != vq.end)
                    continue;

                schedules.Add(s);
            }

            if (schedules.Count == 0)
            {
                Close();
                vq.wmsg("데이터가 없습니다. 다른 일정을 선택하세요.");
                return;
            }

            foreach(var s in schedules)
            {
                int diff = Convert.ToInt32(s.starting - s.destination); 
                diff = (diff < 0) ? diff * -1 : diff;
                diff = diff * 10;

                TimeSpan? ariv_time = s.time + TimeSpan.FromMinutes(diff);

                DateTime run_date = (DateTime)s.date;
                vq.start_date = new DateTime() + s.time;
                vq.end_date = new DateTime() + ariv_time;

                dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, run_date.ToShortDateString(), s.time.ToString(), ariv_time.ToString());
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int data_index = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            
            vq.run_schedule = schedules[data_index - 1];
            vq.date = user_date;

            Close();
            new train_seat().ShowDialog();
            return;
        }
    }

}
