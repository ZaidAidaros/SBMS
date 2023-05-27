using SBMS.Views.Auth;
using SBMS.Views.Sales;
using SBMS.Views.StoresV;
using System;
using System.Windows.Forms;

namespace SBMS
{
    static class Program
    {
        public static Form mainView;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            //Application.Run(LogInV.GetInstance());
            Application.Run(StoresV.GetInstance());
            
        }
    }
}
