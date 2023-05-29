using System;
using System.Windows.Forms;

namespace SBMS.Views.Home
{
    public partial class AdminHomeV : Form, IAdminHomeV
    {
        private AdminHomeV()
        {
            InitializeComponent();
            TodayDate = DateTime.Now.ToShortDateString();
            Subscribe();



        }
        //Singleton pattern (Open a single form instance)
        private static AdminHomeV instance;
        public static AdminHomeV GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new AdminHomeV();
                
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }
            return instance;
        }

        public string UName 
        {
            get { return lblUName.Text; }
            set { lblUName.Text = value; }
        }
        public string SName
        {
            get { return lblSName.Text; }
            set { lblSName.Text = value; }
        }
        public string TodayDate
        {
            get { return lblTodayDate.Text; }
            set { lblTodayDate.Text = value; }
        }

        public event EventHandler ShowEmployeesMV;
        public event EventHandler ShowStoresMV;
        public event EventHandler ShowSalesMV;
        public event EventHandler ShowPurchaseMV;
        public event EventHandler ShowReportsMV;
        public event EventHandler ShowUsersMV;
        public event EventHandler ShowSettingsMV;
        public event EventHandler ShowAboutV;
        public event EventHandler ShowHome;
        public event EventHandler ShowCustomersMV;
        public event EventHandler ShowSuppliersMV;

        void Subscribe()
        {
            //btnClose.Click += delegate { this.Close(); };
            btnHome.Click += delegate { ShowHome?.Invoke(this, EventArgs.Empty); };
            btnEmployeesMV.Click += delegate { ShowEmployeesMV?.Invoke(this, EventArgs.Empty); };
            btnStoresV.Click += delegate { ShowStoresMV?.Invoke(this, EventArgs.Empty); };
            btnSalesV.Click += delegate { ShowSalesMV?.Invoke(this, EventArgs.Empty); };
            btnPurchaseV.Click += delegate { ShowPurchaseMV?.Invoke(this, EventArgs.Empty); };
            btnReportsV.Click += delegate { ShowReportsMV?.Invoke(this, EventArgs.Empty); };
            btnUsersV.Click += delegate { ShowUsersMV?.Invoke(this, EventArgs.Empty); };
            btnCustomers.Click += delegate { ShowCustomersMV?.Invoke(this, EventArgs.Empty); };
            btnSuppliers.Click += delegate { ShowSuppliersMV?.Invoke(this, EventArgs.Empty); };
            btnSettingsV.Click += delegate { ShowSettingsMV?.Invoke(this, EventArgs.Empty); };
            btnAboutV.Click += delegate { ShowAboutV?.Invoke(this, EventArgs.Empty); };
        }

        private void AdminHomeV_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
