using SBMS.Presenters.SuppliersPres;
using System;
using System.Windows.Forms;

namespace SBMS.Views.Suppliers
{
    public partial class SuppliersHV : Form, ISuppliersHV, ISuppliersV, ISupCategoriesV
    {
        private SuppliersHV()
        {
            InitializeComponent();
            InitProp();
            SbsSuppliersHVEvents();
            SbsSuppliersVEvents();
            SbsSuppCategoriesHVEvents();
        }
        /// <summary>
        /// 
        /// </summary>
        //Singleton pattern (Open a single form instance)
        private static SuppliersHV instance;
        public static SuppliersHV GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new SuppliersHV();
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

        public Panel PnlSuppliersView { get => this.pnlSuppliersView; set => this.pnlSuppliersView = value; }
        public Panel PnlSCategoriesView { get => this.pnlSuppCategoriesView; set => this.pnlSuppCategoriesView = value; }
        public string HeaderTitle { get => this.lblHeaderTitle.Text; set => this.lblHeaderTitle.Text = value; }
        ///
        public string SupplierName { get => this.tbSupplierName.Text; set => this.tbSupplierName.Text = value; }
        public string SupplierPhone { get => this.tbSupplierPhone.Text; set => this.tbSupplierPhone.Text = value; }
        public string SupplierAddress { get => this.tbSupplierAddress.Text; set => this.tbSupplierAddress.Text = value; }
        public string SearchValue { get => this.tbSearchSuppliers.Text; set => this.tbSearchSuppliers.Text = value; }
        public ComboBox CBXSupplierCategory { get => this.cbxCatagorySelects; set => this.cbxCatagorySelects = value; }
        public ComboBox CBXCategoryFilter { get => this.cbxCategoryFilter; set => this.cbxCategoryFilter = value; }
        public bool IsAESupplierFormVisable { get => this.fpnlAESupplierForm.Visible; set => this.fpnlAESupplierForm.Visible = value; }
        public DataGridView DGVSuppliers { get => this.dgvSuppliers; set => this.dgvSuppliers = value; }
        ///
        public bool IsAECtegoryFormVisable { get => this.fpnlAECategoryForm.Visible; set => this.fpnlAECategoryForm.Visible = value; }
        public string SCategoryName { get => this.tbCategoryName.Text; set => this.tbCategoryName.Text = value; }
        public string SCateDescription { get => this.tbCategoryDescription.Text; set => this.tbCategoryDescription.Text = value; }
        public DataGridView DGVPSuppCategories { get => this.dgvCategories; set => this.dgvCategories = value; }

        public event EventHandler ShowSuppliersView;
        public event EventHandler ShowSuppCategoriesView;
        public event EventHandler ShowAddSupplierForm;
        public event EventHandler ShowEditSupplierForm;
        public event EventHandler DeleteSelectedSupplier;
        public event EventHandler OnCategoryFilterChanged;
        public event EventHandler OnSearchButtonClicked;
        public event EventHandler OnSelectSupplier;
        public event EventHandler OnAESupplierSave;
        public event EventHandler OnAESupplierCancel;
        public event EventHandler OnVRefresh;
        public event EventHandler ShowAddSuppCategoryForm;
        public event EventHandler ShowEditSuppCategoryForm;
        public event EventHandler DeleteSelectedSuppCategory;
        public event EventHandler OnAECategorySave;
        public event EventHandler OnAECategoryCancel;
        public event EventHandler OnSelectCategory;
        public event EventHandler OnDisposed;

        private void SbsSuppliersHVEvents()
        {
            this.btnShowSuppliersView.Click += delegate { this.ShowSuppliersView?.Invoke(this,EventArgs.Empty); };
            this.btnShowSuppCategoriesView.Click += delegate { this.ShowSuppCategoriesView?.Invoke(this, EventArgs.Empty); };
            this.Disposed += delegate { this.OnDisposed?.Invoke(this, EventArgs.Empty); };
        }
        private void SbsSuppliersVEvents()
        {
            this.btnAddSupplier.Click += delegate { this.ShowAddSupplierForm?.Invoke(this, EventArgs.Empty); };
            this.btnEditSupplier.Click += delegate { this.ShowEditSupplierForm?.Invoke(this, EventArgs.Empty); };
            this.btnDeleteSupplier.Click += delegate { this.DeleteSelectedSupplier?.Invoke(this, EventArgs.Empty); };
            this.btnAESupplierSave.Click += delegate { this.OnAESupplierSave?.Invoke(this, EventArgs.Empty); };
            this.btnAESupplierCancel.Click += delegate { this.OnAESupplierCancel?.Invoke(this, EventArgs.Empty); };
            this.btnSearch.Click += delegate { this.OnSearchButtonClicked?.Invoke(this, EventArgs.Empty); };
            this.btnSuppVRefresh.Click += delegate { this.OnVRefresh?.Invoke(this, EventArgs.Empty); };
            this.dgvSuppliers.SelectionChanged += delegate { this.OnSelectSupplier?.Invoke(this, EventArgs.Empty); };
            this.cbxCategoryFilter.SelectedIndexChanged += delegate { this.OnCategoryFilterChanged?.Invoke(this, EventArgs.Empty); };
        }
        private void SbsSuppCategoriesHVEvents()
        {
            this.btnAddCategory.Click += delegate { this.ShowAddSuppCategoryForm?.Invoke(this, EventArgs.Empty); };
            this.btnEditCategory.Click += delegate { this.ShowEditSuppCategoryForm?.Invoke(this, EventArgs.Empty); };
            this.btnDeleteCategory.Click += delegate { this.DeleteSelectedSuppCategory?.Invoke(this, EventArgs.Empty); };
            this.btnAECategorySave.Click += delegate { this.OnAECategorySave?.Invoke(this, EventArgs.Empty); };
            this.btnAECategoryCancel.Click += delegate { this.OnAECategoryCancel?.Invoke(this, EventArgs.Empty); };
            this.dgvCategories.SelectionChanged += delegate { this.OnSelectCategory?.Invoke(this, EventArgs.Empty); };
        }
        private void InitProp()
        {
            this.fpnlAESupplierForm.Visible = false;
            this.fpnlAECategoryForm.Visible = false;
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
