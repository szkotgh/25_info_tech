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
    public partial class ticket_run_list : frame
    {
        public static DateTime run_date;
        public static List<schedule> run_list;
        public ticket_run_list()
        {
            InitializeComponent();
            dUp();
        }

        private void dUp()
        {
            title1.Text = "출발지: " + vq.start_txt + " → 도착지: " + vq.end_txt;
            vq.ticket_cost = 5000 + Math.Abs(vq.start - vq.end) * 1000;
            title2.Text = "금액: " + vq.ticket_cost.ToString("N0") + "원";

            foreach (schedule item in run_list)
            {
                DateTime st_date = (DateTime)item.date;
                TimeSpan st_time = (TimeSpan)item.time;
                TimeSpan ed_time = st_time.Add(TimeSpan.FromMinutes(Math.Abs(vq.start - vq.end) * 10));
                dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, st_date.ToShortDateString(), st_time.ToString(), ed_time.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int sel_index = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            schedule sel_s = run_list[sel_index - 1];
            vq.sel_schedule = sel_s;

            vq.sel_date = run_date;
            vq.start_time = (TimeSpan)sel_s.time;
            vq.end_time = vq.start_time.Add(TimeSpan.FromMinutes(Math.Abs(vq.start - vq.end) * 10));

            vq.sel_car = default;
            vq.sel_seat = default;

            Hide();
        }
    }
}
