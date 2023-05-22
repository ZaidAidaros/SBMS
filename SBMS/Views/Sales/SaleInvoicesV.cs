using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SBMS.Views.Sales
{
    public partial class SaleInvoicesV : Form, ISaleInvoicesV
    {
        private static SaleInvoicesV instance;
        public static SaleInvoicesV GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new SaleInvoicesV();
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }
            return instance;
        }
        private SaleInvoicesV()
        {
            InitializeComponent();
            this.btnInvSearch.Click += delegate { this.OnInvSearchBClicked?.Invoke(this, EventArgs.Empty); };
        }

        public event EventHandler OnInvSearchBClicked;
        public string InvSearchField { get => this.tbInvSearch.Text; set => this.tbInvSearch.Text = value; }
        public bool IsInvItemsVisable { get => this.pnlInvItems.Visible; set => this.pnlInvItems.Visible = value; }
        public ComboBox CBXInvFilter => this.cbxInvFilter;
        public DataGridView DGVInvoices => this.dgvInvoices;
        public DataGridView DGVInvItems => this.dgvInvItems;

        public bool ShowMsgBox(string msg, string title, bool isYesNo)
        {
            throw new NotImplementedException();
        }

        
    }
}
