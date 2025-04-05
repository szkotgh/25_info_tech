using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.src
{
    internal class vq
    {
        public static void wmsg(string msg)
        {
            MessageBox.Show(msg, "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void imsg(string msg)
        {
            MessageBox.Show(msg, "정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool qmsg(string msg)
        {
            DialogResult result = MessageBox.Show(msg, "질문", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }

        public static void cal_age_and_save()
        {
            DateTime now_date = DateTime.Now;
            DateTime user_date = (DateTime)vq.user.birth;
            TimeSpan diff_date = now_date - user_date;
            int years = (int)(diff_date.TotalDays / 365);
            vq.user_age = years;

            if (vq.user_age < 5)
                user_type = "유아";
            else if (vq.user_age < 13)
                user_type = "어린이";
            else if (vq.user_age < 19)
                user_type = "청소년";
            else
                user_type = "성인";
        }

        public static string cal_age_and_return(user u)
        {
            string user_type;
            DateTime now_date = DateTime.Now;
            DateTime user_date = (DateTime)u.birth;
            TimeSpan diff_date = now_date - user_date;
            int years = (int)(diff_date.TotalDays / 365);

            if (years <= 5)
                user_type = "유아";
            else if (years <= 13)
                user_type = "어린이";
            else if (years <= 19)
                user_type = "청소년";
            else
                user_type = "성인";

            return user_type;
        }

        public static DatarailEntities db = new DatarailEntities();
        public static user user = null;
        public static int user_age = default;
        public static string user_type = null;
        public static int move;

        // ticket_reservation
        public static int? start=null, end=null;
        public static string start_nm=null, end_nm=null;

        public static int? price = null;                    
        public static DateTime? date = null;
        public static DateTime? start_date = null, end_date = null;
        public static schedule run_schedule = null;

        public static int? car = null;
        public static string seat = null;
        
        public static float discount = default;
    }
}
