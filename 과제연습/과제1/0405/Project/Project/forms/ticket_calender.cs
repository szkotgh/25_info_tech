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

            var qs = vq.db.schedule.SingleOrDefault(x => x.starting == vq.start &&
                                                         x.destination == vq.end &&
                                                         x.date == sel_date.Date);
            if (qs == default)
            {
                vq.wmsg("운행 스케줄이 없습니다. 다른 일자를 선택하십시오.");
                return;
            }
            vq.sel_date = sel_date;
            Hide();
            new ticket_run_list().ShowDialog();
        }
    }
}
