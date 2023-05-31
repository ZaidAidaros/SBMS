using System;
using System.Windows.Forms;

namespace SBMS.Views.Sales
{
    public partial class NewSaleInvoiceV : Form, INewSaleInvoiceV
    {
        private static NewSaleInvoiceV instance;
        public static NewSaleInvoiceV GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new NewSaleInvoiceV();
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }
            return instance;
        }
        private NewSaleInvoiceV()
        {
            InitializeComponent();
            this.EventsSubscrib();
        }

        

        public event EventHandler OnClose;
        public event EventHandler OnInvSave;
        public event EventHandler OnInvCancel;
        public event EventHandler OnAEInvItem;
        public event EventHandler OnInvItemIncOne;
        public event EventHandler OnInvItemDecOne;
        public event EventHandler OnInvItemRemove;
        public event EventHandler OnPSearchBClicked;
        public event EventHandler OnDisposed;

        public string InvCustomerName { get => this.tbCustomerInvName.Text; set => this.tbCustomerInvName.Text = value; }
        public string AEButtonText { get => this.btnAddInvItem.Text; set => this.btnAddInvItem.Text = value; }
        public string PSearvhField { get => this.tbPSearch.Text; set => this.tbPSearch.Text = value; }
        public string InvItemQuantity { get => this.tbInvItemQuanSet.Text; set => this.tbInvItemQuanSet.Text = value; }
        public string PPrice { get => this.tbProdPrice.Text; set => this.tbProdPrice.Text = value; }
        public string InvTotlPrice { get => this.lblInvFinalTotal.Text; set => this.lblInvFinalTotal.Text = value; }
        public string InvNote { get => this.tbInvNote.Text; set => this.tbInvNote.Text = value; }
        public string InvDiscount { get => this.tbInvDiscount.Text; set => this.tbInvDiscount.Text = value; }
        public DateTimePicker ExpireDate => this.dpProdExpireDate;
        public ComboBox CBXCustomers => this.cbxCustomers;
        public ComboBox CBXMonyState => this.cbxMonyState;
        public ComboBox CBXPCategoryFilter => this.cbxCategoryFilter;
        public DataGridView DGVProducts => this.dgvProducts;
        public DataGridView DGVInvItems => this.dgvInvoiceItems;


        private void EventsSubscrib()
        {
            //this.btnClose.Click += delegate { this.OnClose?.Invoke(this, EventArgs.Empty); };
            this.btnInvSave.Click += delegate { this.OnInvSave?.Invoke(this, EventArgs.Empty); };
            this.btnInvCancel.Click += delegate { this.OnInvCancel?.Invoke(this, EventArgs.Empty); };
            this.btnAddInvItem.Click += delegate { this.OnAEInvItem?.Invoke(this, EventArgs.Empty); };
            this.btnInvItemIncOne.Click += delegate { this.OnInvItemIncOne?.Invoke(this, EventArgs.Empty); };
            this.btnInvItemDecOne.Click += delegate { this.OnInvItemDecOne?.Invoke(this, EventArgs.Empty); };
            this.btnRemoveItem.Click += delegate { this.OnInvItemRemove?.Invoke(this, EventArgs.Empty); };
            this.btnSearch.Click += delegate { this.OnPSearchBClicked?.Invoke(this, EventArgs.Empty); };
            this.Disposed += delegate { this.OnDisposed?.Invoke(this, EventArgs.Empty); };
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

        
    }
}
