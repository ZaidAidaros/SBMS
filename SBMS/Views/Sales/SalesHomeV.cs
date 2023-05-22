using SBMS.Presenters.SalesPres;
using System;
using System.Windows.Forms;

namespace SBMS.Views.Sales
{
    public partial class SalesHomeV : Form, ISalesHomeV
    {
        private static SalesHomeV instance;
        public static SalesHomeV GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new SalesHomeV();
                SalesHVPres.GetInstance();
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }
            return instance;
        }

        private SalesHomeV()
        {
            InitializeComponent();

            this.btnNewSaleInv.Click += delegate { this.ShowNewSalesInvView?.Invoke(this, EventArgs.Empty); };
            this.btnNewReSaleInv.Click += delegate { this.ShowNewRetSalesInvView?.Invoke(this, EventArgs.Empty); };
            this.btnSales.Click += delegate { this.ShowSalesView?.Invoke(this, EventArgs.Empty); };
            this.btnClose.Click += delegate { this.Close(); this.OnClose?.Invoke(this, EventArgs.Empty); };

            SaleInvoicesV.GetInstance().MdiParent = this;
            NewSaleInvoiceV.GetInstance().MdiParent = this;
            NewRetSaleInvoiceV.GetInstance().MdiParent = this;
        }

        public string HeaderTitle { get => this.lblHeader.Text; set => this.lblHeader.Text = value; }
        public string UserName { get => this.lblUName.Text; set => this.lblUName.Text = value; }
        public string StuffName { get => this.lblSName.Text; set => this.lblSName.Text = value; }

        public event EventHandler ShowNewSalesInvView;
        public event EventHandler ShowNewRetSalesInvView;
        public event EventHandler ShowSalesView;
        public event EventHandler OnClose;
    }
}
