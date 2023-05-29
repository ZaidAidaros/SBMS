using SBMS.Presenters.CustomersPres;
using System;
using System.Windows.Forms;

namespace SBMS.Views.Customers
{
    public partial class CustomersHV : Form, ICustomersHV, ICustCategoriesV, ICustomersV
    {
        private CustomersHV()
        {
            InitializeComponent();
            SbsCustomersHVEvents();
            SbsCustomersVEvents();
            SbsCustCategoriesVEvents();
            InitProp();
        }

        /// <summary>
        /// 
        /// </summary>
        //Singleton pattern (Open a single form instance)
        private static CustomersHV instance;
        public static CustomersHV GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new CustomersHV();
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }
            return instance;
        }
        /// <summary>
        /// 
        /// </summary>
        /// 

        // Customers Home
        public Panel PnlCustomersView { get => this.pnlCustomersView; set => this.pnlCustomersView = value; }
        public Panel PnlCCategoriesView { get => this.pnlCustCategoriesView; set => this.pnlCustCategoriesView = value; }
        public string HeaderTitle { get => lblHeaderTitle.Text; set => this.lblHeaderTitle.Text = value; }

        // Categories View
        public bool IsAECtegoryFormVisable { get => this.fpnlAECategoryForms.Visible; set => this.fpnlAECategoryForms.Visible = value; }
        public string CCategoryName { get => this.tbCategoryName.Text; set => this.tbCategoryName.Text = value; }
        public string CCateDescription { get => this.tbCategoryDescription.Text; set => this.tbCategoryDescription.Text = value; }
        public DataGridView DGVPCustCategories { get => this.dgvCategories; set => this.dgvCategories = value; }
        public string CustomerName { get => this.tbCustomerName.Text; set => this.tbCustomerName.Text = value; }
        public string CustomerNIC { get => this.tbCustomerNIC.Text; set => this.tbCustomerNIC.Text = value; }
        public string CustomerPhone { get => this.tbCustomerPhone.Text; set => this.tbCustomerPhone.Text = value; }
        public string CustomerAddress { get => this.tbCustomerAddress.Text; set => this.tbCustomerAddress.Text = value; }
        public string SearchValue { get => this.tbSearchCustomers.Text; set => this.tbSearchCustomers.Text = value; }
        public ComboBox CBXCustomerCategory { get => this.cbxCatagorySelects; set => this.cbxCatagorySelects = value; }
        public ComboBox CBXCustomerGender { get => this.cbxGenderSelects; set => this.cbxGenderSelects = value; }
        public ComboBox CBXCategoryFilter { get => this.cbxCategoryFilter; set => this.CBXCategoryFilter = value; }
        public DateTime DTCustomerBirthDay { get => this.dtpCustomerBDate.Value; set => this.dtpCustomerBDate.Value = value; }
        public bool IsAECustomerFormVisable { get => this.fpnlAECustomerForm.Visible; set => this.fpnlAECustomerForm.Visible = value; }
        public DataGridView DGVCustomers { get => this.dgvCustomers; set => this.dgvCustomers = value; }

        public event EventHandler ShowCustomersView;
        public event EventHandler ShowCustCategoriesView;
        public event EventHandler ShowAddCustCategoryForm;
        public event EventHandler ShowEditCustCategoryForm;
        public event EventHandler DeleteSelectedCustCategory;
        public event EventHandler OnAECategorySave;
        public event EventHandler OnAECategoryCancel;
        public event EventHandler OnSelectCategory;
        public event EventHandler ShowAddCustomerForm;
        public event EventHandler ShowEditCustomerForm;
        public event EventHandler DeleteSelectedCustomer;
        public event EventHandler OnCategoryFilterChanged;
        public event EventHandler OnSearchButtonClicked;
        public event EventHandler OnSelectCustomer;
        public event EventHandler OnAECustomerSave;
        public event EventHandler OnAECustomerCancel;
        public event EventHandler OnVRefresh;
        public event EventHandler OnDisposed;

        private void InitProp()
        {
            this.fpnlAECustomerForm.Visible = false;
            this.fpnlAECategoryForms.Visible = false;
        }
        private void SbsCustomersHVEvents()
        {
            this.btnShowCustomersView.Click += delegate { this.ShowCustomersView?.Invoke(this, EventArgs.Empty); };
            this.btnShowCustCategoriesView.Click += delegate { this.ShowCustCategoriesView?.Invoke(this, EventArgs.Empty); };
            this.Disposed += delegate { this.OnDisposed?.Invoke(this, EventArgs.Empty); };
            
        }

        private void SbsCustomersVEvents()
        {
            this.btnAddCustomer.Click += delegate { this.ShowAddCustomerForm?.Invoke(this, EventArgs.Empty); };
            this.btnEditCustomer.Click += delegate { this.ShowEditCustomerForm?.Invoke(this, EventArgs.Empty); };
            this.btnDeleteCustomer.Click += delegate { this.DeleteSelectedCustomer?.Invoke(this, EventArgs.Empty); };
            this.btnAECustomerSave.Click += delegate { this.OnAECustomerSave?.Invoke(this, EventArgs.Empty); };
            this.btnAECustomerCancel.Click += delegate { this.OnAECustomerCancel?.Invoke(this, EventArgs.Empty); };
            this.btnSearch.Click += delegate { this.OnSearchButtonClicked?.Invoke(this, EventArgs.Empty); };
            this.cbxCategoryFilter.SelectedIndexChanged += delegate { this.OnCategoryFilterChanged?.Invoke(this, EventArgs.Empty); };
            this.dgvCustomers.SelectionChanged += delegate { this.OnSelectCustomer?.Invoke(this, EventArgs.Empty); };
            this.btnCustVRefresh.Click += delegate { this.OnVRefresh?.Invoke(this, EventArgs.Empty); };

        }
        private void SbsCustCategoriesVEvents()
        {
            this.btnAddCategory.Click += delegate { this.ShowAddCustCategoryForm?.Invoke(this, EventArgs.Empty); };
            this.btnEditCategory.Click += delegate { this.ShowEditCustCategoryForm?.Invoke(this, EventArgs.Empty); };
            this.btnDeleteCategory.Click += delegate { this.DeleteSelectedCustCategory?.Invoke(this, EventArgs.Empty); };
            this.btnAECategorySave.Click += delegate { this.OnAECategorySave?.Invoke(this, EventArgs.Empty); };
            this.btnAECategoryCancel.Click += delegate { this.OnAECategoryCancel?.Invoke(this, EventArgs.Empty); };
            this.dgvCategories.SelectionChanged += delegate { this.OnSelectCategory?.Invoke(this, EventArgs.Empty); };

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
