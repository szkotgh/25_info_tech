using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Project.aframe
{
    internal class vq
    {
        public static void wmsg(string message)
        {
            MessageBox.Show(message, "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void imsg(string message)
        {
            MessageBox.Show(message, "정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DatarailEntities db = new DatarailEntities();
        public static int uno, move;
        public static string uname, pw;

        public static int start, end;
        public static string start_nm, end_nm;
        public static string date;
    }
}
