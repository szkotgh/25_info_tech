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
    public partial class calender : Form
    {
        public calender()
        {
            InitializeComponent();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            DateTime date = monthCalendar1.SelectionStart;
            if (date < DateTime.Now.Date)
            {
                vq.wmsg("이전 날짜는 선택할 수 없습니다.");
                return;
            }

            List<schedule> schedules = new List<schedule>();
            foreach (var s in vq.db.schedule)
            {
                if (s.date != date.Date)
                    continue;

                if (s.starting != vq.start || s.destination != vq.end)
                    continue;

                schedules.Add(s);
            }

            if (schedules.Count == 0)
            {
                vq.wmsg("운행리스트가 없습니다. 다른 일정을 선택하세요.");
                return;
            }

            Hide();
            run_list.user_date = date;
            new run_list().ShowDialog();
        }
    }
}
