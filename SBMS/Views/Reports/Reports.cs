using Microsoft.Reporting.WinForms;
using SBMS.Presenters.ReportsPres;
using System;
using System.Windows.Forms;

namespace SBMS.Views.Reports
{
    public partial class ReportsHV : Form, IReportsHV
    {
        private static ReportsHV instance;


        public static ReportsHV GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new ReportsHV();
                ReportsHVPres.GetInstance();
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }
            return instance;
        }
        private ReportsHV()
        {
            InitializeComponent();
            EventsSubs();
        }

        public event EventHandler ShowSalesReportView;
        public event EventHandler ShowPurchasesReportView;
        public event EventHandler ShowProductsReportView;
        public event EventHandler ShowEmployeesReportView;
        public event EventHandler ShowUsersReportView;
        public ReportViewer ReportsViewer => reportViewer;

        public string InvName => this.tbInvName.Text;

        public string InvTotal => this.tbInvTotal.Text;

        public string FromDate => this.dtpFromDate.Value.ToShortDateString();

        public string ToDate => this.dtpToDate.Value.ToShortDateString();

        public Panel invContorolPanel => this.pnlInvReportControl;

        private void EventsSubs()
        {
            this.btnShowSalesReportView.Click += delegate { ShowSalesReportView?.Invoke(this, EventArgs.Empty); };
            this.btnShowPurchasesReportView.Click += delegate { ShowPurchasesReportView?.Invoke(this, EventArgs.Empty); };
            this.btnShowProductsReportView.Click += delegate { ShowProductsReportView?.Invoke(this, EventArgs.Empty); };
            this.btnShowEmployeesReportView.Click += delegate { ShowEmployeesReportView?.Invoke(this, EventArgs.Empty); };
            this.btnShowUsersReportView.Click += delegate { ShowUsersReportView?.Invoke(this, EventArgs.Empty); };
        }
        public bool ShowMsgBox(string msg, string title, bool isYesNo)
        {
            DialogResult res = MessageBox.Show(msg, title, isYesNo ? MessageBoxButtons.YesNo : MessageBoxButtons.OK);
            if (res == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        private void ReportsHV_Load(object sender, EventArgs e)
        {

        }

    }
}
