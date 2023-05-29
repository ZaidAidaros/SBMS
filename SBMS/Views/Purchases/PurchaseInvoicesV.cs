using System;
using System.Windows.Forms;

namespace SBMS.Views.Purchases
{
    public partial class PurchaseInvoicesV : Form, IPurchaseInvoicesV
    {
        private static PurchaseInvoicesV instance;
        public static PurchaseInvoicesV GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new PurchaseInvoicesV();
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }
            return instance;
        }

        private PurchaseInvoicesV()
        {
            InitializeComponent();
            this.btnInvSearch.Click += delegate { this.OnInvSearchBClicked?.Invoke(this, EventArgs.Empty); };
            this.Disposed += delegate { this.OnDisposed?.Invoke(this, EventArgs.Empty); };
        }

        public string InvSearchField { get => this.tbInvSearch.Text; set => this.tbInvSearch.Text = value; }

        public ComboBox CBXInvFilter => this.cbxInvFilter;

        public DataGridView DGVInvoices => this.dgvInvoices;

        public DataGridView DGVInvItems => this.dgvInvItems;

        public bool IsInvItemsVisable { get => this.pnlInvItems.Visible; set => this.pnlInvItems.Visible=value; }


        public event EventHandler OnInvSearchBClicked;
        public event EventHandler OnDisposed;

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
    }
}
