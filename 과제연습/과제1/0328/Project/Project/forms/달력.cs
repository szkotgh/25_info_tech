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
    public partial class 달력 : Form
    {
        public 달력()
        {
            InitializeComponent();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            DateTime date = this.monthCalendar1.SelectionRange.Start.Date;
            if (date < DateTime.Now.Date)
            {
                vq.wmsg("이전 날짜는 선택할 수 없습니다.");
                return;
            }

            TimeSpan time = DateTime.Now.TimeOfDay;
            bool isToday = date == DateTime.Now.Date;

            if (!vq.db.schedule.Any(x => x.date == date && x.starting == vq.start && x.destination == vq.end && (!isToday ? true : x.time > time)))
            {
                vq.wmsg("존재하는 일정이 없습니다.");
                return;
            }

            Dispose();
            vq.date = date.ToLongDateString();
        }
    }
}
