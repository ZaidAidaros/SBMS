using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SBMS.Views.Purchases
{
    public partial class NewRetPurchaseInvV : Form, INewPurchaseInvV
    {
        private NewRetPurchaseInvV()
        {
            InitializeComponent();
            InitProp();
            SubsEvents();
        }
        private static NewRetPurchaseInvV instance;
        public static NewRetPurchaseInvV GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new NewRetPurchaseInvV();
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }
            return instance;
        }
        public string InvSuppName { get => this.tbSuppNameOnInv.Text; set => this.tbSuppNameOnInv.Text = value; }
        public string PSearvhField { get => this.tbPSearch.Text; set => this.tbPSearch.Text = value; }
        public string InvItemQuantity { get => this.tbInvItemQuanSet.Text; set => this.tbInvItemQuanSet.Text = value; }
        public string Cost { get => this.tbProdCost.Text; set => this.tbProdCost.Text = value; }
        public string InvNote { get => this.tbInvNote.Text; set => this.tbInvNote.Text = value; }
        public string InvTotlPrice { get => this.lblInvFinalTotal.Text; set => this.lblInvFinalTotal.Text = value; }
        public string AEButtonText { get => this.btnAddInvItem.Text; set => this.btnAddInvItem.Text = value; }
        public ComboBox CBXSuppliers  => this.cbxSuppliers; 
        public ComboBox CBXMonyState => this.cbxMonyState; 
        public ComboBox CBXPCategoryFilter => this.cbxPCategoryFilter; 
        public DataGridView DGVProducts => this.dgvProducts;
        public DataGridView DGVInvItems => this.dgvInvoiceItems;
        public DateTimePicker ExpireDate => this.dpProdExpireDate;


        public event EventHandler OnClose;
        public event EventHandler OnInvSave;
        public event EventHandler OnInvCancel;
        public event EventHandler OnAEInvItem;
        public event EventHandler OnInvItemIncOne;
        public event EventHandler OnInvItemDecOne;
        public event EventHandler OnInvItemRemove;
        public event EventHandler OnPSearchBClicked;
        public event EventHandler OnDisposed;

        private void SubsEvents()
        {
            //this.Disposed += delegate { NewPurchaseInvVPres.Dispose();};
            this.btnCloseNewInv.Click += delegate { this.OnClose?.Invoke(this, EventArgs.Empty); this.Close(); };
            this.btnInvSave.Click += delegate { this.OnInvSave?.Invoke(this, EventArgs.Empty); };
            this.btnInvCancel.Click += delegate { this.OnInvCancel?.Invoke(this, EventArgs.Empty); };
            this.btnAddInvItem.Click += delegate { this.OnAEInvItem?.Invoke(this, EventArgs.Empty); };
            this.btnInvItemIncOne.Click += delegate { this.OnInvItemIncOne?.Invoke(this, EventArgs.Empty); };
            this.btnInvItemDecOne.Click += delegate { this.OnInvItemDecOne?.Invoke(this, EventArgs.Empty); };
            this.btnRemoveItem.Click += delegate { this.OnInvItemRemove?.Invoke(this, EventArgs.Empty); };
            this.btnPSearch.Click += delegate { this.OnPSearchBClicked?.Invoke(this, EventArgs.Empty); };
            this.Disposed += delegate { this.OnPSearchBClicked?.Invoke(this, EventArgs.Empty); };
        }
        private void InitProp()
        {
            this.dgvProducts.ClearSelection();
            this.dgvInvoiceItems.ClearSelection();
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
