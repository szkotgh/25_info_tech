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
    public partial class ticket_calender : Form
    {
        public ticket_calender()
        {
            InitializeComponent();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            DateTime sel_date = monthCalendar1.SelectionStart;

            if (sel_date.Date < DateTime.Now.Date)
            {
                vq.wmsg("이전 날짜는 선택할 수 없습니다.");
                return;
            }

            List<schedule> qs = new List<schedule>();
            foreach (schedule s in vq.db.schedule)
            {
                DateTime s_date = (DateTime)s.date;
                s_date = s_date.Add((TimeSpan)s.time);
                if (s.starting == vq.start && s.destination == vq.end && (DateTime)s.date == sel_date.Date && s_date > DateTime.Now)
                    qs.Add(s);
            }

            if (qs.Count == 0)
            {
                vq.wmsg("운행 스케줄이 없습니다. 다른 일자를 선택하십시오.");
                return;
            }

            qs = qs.OrderBy(x => x.time).ToList();

            ticket_run_list.run_date = sel_date;
            ticket_run_list.run_list = qs;

            Hide();
            new ticket_run_list().ShowDialog();
        }
    }
}
