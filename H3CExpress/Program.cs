using H3CExpress.UserControls;
using H3CExpress.Views;
using System;
using System.Windows.Forms;

namespace H3CExpress
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
            //Application.Run(new fUpadtePerson("Tea"));
            //Application.Run(new fUpdateKhoaHoc());
            //Application.Run(new QuanLyDiem());
            //Application.Run(new QuanLyBienLai());
            //Application.Run(new UpdateClass());
        }
    }
}
