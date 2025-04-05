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
        public ticket_run_list()
        {
            InitializeComponent();
            dUp();
        }

        private void dUp()
        {
            foreach (schedule item in vq.db.schedule)
            {
                if ((item.starting == vq.start && item.destination == vq.end && (DateTime)item.date == vq.sel_date.Date) == false)
                    return;

                DateTime st_date = (DateTime)item.date;
                TimeSpan st_time = (TimeSpan)item.time;
                TimeSpan ed_time = st_time;
                dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, st_date.ToShortDateString(), st_time.ToString(), ed_time.ToString());
            }
        }
    }
}
