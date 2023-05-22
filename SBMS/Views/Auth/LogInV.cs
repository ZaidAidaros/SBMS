using SBMS.Models.Users;
using SBMS.Presenters;
using SBMS.Views.Home;
using System;
using System.Windows.Forms;

namespace SBMS.Views.Auth
{
    public partial class LogInV : Form, ILogInV
    {
        private LogInV()
        {
            InitializeComponent();
            btnLogIn.Click += delegate { LogIn?.Invoke(this, EventArgs.Empty); };
        }
        //Singleton pattern (Open a single form instance)
        private static LogInV instance;
        public static LogInV GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new LogInV();
                LogInVPres.GetInstance();
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }
            return instance;
        }
         
        public void onLoged() { 

        }

        public string UName
        {
            get { return txtboxUName.Text; } 
            set { txtboxUName.Text = value; }
        }
        public string UPassword
        {
            get { return txtboxUPass.Text; }
            set { txtboxUPass.Text = value; }
        }

        public string Message
        {
            get { return lblErrorMsg.Text; }
            set { lblErrorMsg.Text = value; }
        }

        public event EventHandler LogIn;



    }
}
