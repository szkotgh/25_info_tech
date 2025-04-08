using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.src
{
    internal class vq
    {
        public static void imsg(string msg)
        {
            MessageBox.Show(msg, "정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void wmsg(string msg)
        {
            MessageBox.Show(msg, "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool qmsg(string msg)
        {
            return MessageBox.Show(msg, "경고", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes;
        }

        // user_info
        public static user login_user = null;
        public static string user_type = null;
        public static string age_cal(DateTime user_age) {
            DateTime now_date = DateTime.Now;
            TimeSpan diff_date = now_date - user_age;
            int years = (int)(diff_date.TotalDays / 365);

            string type;
            if (years <= 5)
                type = "유아";
            else if (years <= 13)
                type = "어린이";
            else if (years <= 19)
                type = "청소년";
            else
                type = "성인";

            return type;
        }
        public static Double discount_cal(String user_type)
        {
            if (user_type == "유아")
                return 1.0;
            else if (user_type == "어린이")
                return 0.4;
            else if (user_type == "청소년")
                return 0.2;
            else
                return 0.0;
        }

        // ticket
        public static int start=default, end=default;
        public static string start_txt = default, end_txt = default;
        public static DateTime sel_date = default;
        public static TimeSpan start_time = default, end_time = default;
        public static int ticket_cost = default;
        public static schedule sel_schedule = default;
        public static int sel_car = default;
        public static string sel_seat = default;


        // etc..
        public static DatarailEntities db = new DatarailEntities();
        public static int move;


    }
}
