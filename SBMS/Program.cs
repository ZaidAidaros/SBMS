using SBMS.Views.Purchases;
using SBMS.Views.Sales;
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
            //LogInV.GetInstance().Show();
            Application.Run(SalesHomeV.GetInstance());
            
        }
    }
}
