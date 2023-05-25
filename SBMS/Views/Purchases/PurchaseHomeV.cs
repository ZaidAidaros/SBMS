using SBMS.Presenters.PurchasesPres;
using System;
using System.Windows.Forms;

namespace SBMS.Views.Purchases
{
    public partial class PurchaseHomeV : Form, IPurchasesHV
    {
        private static PurchaseHomeV instance;
        public static PurchaseHomeV GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new PurchaseHomeV();
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }
            return instance;
        }

        private PurchaseHomeV()
        {
            InitializeComponent();
            
            this.btnNewPurchaseInv.Click += delegate { this.ShowNewPurchaseView?.Invoke(this, EventArgs.Empty); };
            this.btnNewRePurchaseInv.Click += delegate { this.ShowNewRePurchaseView?.Invoke(this, EventArgs.Empty); };
            this.btnPurchases.Click += delegate { this.ShowPurchasesView?.Invoke(this, EventArgs.Empty); };
            this.btnClose.Click += delegate { this.Close(); this.OnClose?.Invoke(this, EventArgs.Empty); };

            PurchaseInvoicesV.GetInstance().MdiParent = this;
            NewPurchaseInvV.GetInstance().MdiParent = this;
            NewRetPurchaseInvV.GetInstance().MdiParent = this;
            
        }
        public string HeaderTitle { get => this.lblHeader.Text; set => this.lblHeader.Text = value; }
        public string UserName { get => this.lblUName.Text; set => this.lblUName.Text = value; }
        public string StuffName { get => this.lblSName.Text; set => this.lblSName.Text = value; }
        

        public event EventHandler ShowNewPurchaseView;
        public event EventHandler ShowNewRePurchaseView;
        public event EventHandler ShowPurchasesView;
        public event EventHandler OnClose;
    }
}
