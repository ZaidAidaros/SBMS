using SBMS.Models.Stores;
using SBMS.Presenters.StoresPres;
using SBMS.Repositories;
using SBMS.Repositories.StoresRepo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SBMS.Views.StoresV
{
    public partial class StoresV : Form, IStoresV, IProductsV, IPCategoriesV, IPUnitsV
    {
        private StoresV()
        {
            InitializeComponent();
            this.SubStoresVEvents();
            this.SubProductsViewEvents();
            this.SubProdCategoriesViewEvents();
            this.SubProdUnitsEvents();
            InitProp();
        }

        /// <summary>
        /// 
        /// </summary>
        //Singleton pattern (Open a single form instance)
        private static StoresV instance;
        public static StoresV GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new StoresV();
                StoresVPres.GetInstance();
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


        public event EventHandler ShowProductsView;
        public event EventHandler ShowProdCategoriesView;
        public event EventHandler ShowProdUnitsView;
        public event EventHandler ShowAddProdCategoryForm;
        public event EventHandler ShowEditProdCategoryForm;
        public event EventHandler DeleteSelectedProdCategory;
        public event EventHandler OnAECategorySave;
        public event EventHandler OnAECategoryCancel;
        public event EventHandler OnSelectCategory;
        public event EventHandler OnClickCategoriesView;
        public event EventHandler ShowAddProdUnitForm;
        public event EventHandler ShowEditProdUnitForm;
        public event EventHandler DeleteSelectedProdUnit;
        public event EventHandler OnAEUnitSave;
        public event EventHandler OnAEUnitCancel;
        public event EventHandler OnSelectUnit;
        public event EventHandler OnClickUnitView;
        public event EventHandler ShowAddProductForm;
        public event EventHandler ShowEditProductForm;
        public event EventHandler DeleteSelectedProduct;
        public event EventHandler OnCategoryFilterChanged;
        public event EventHandler OnSearchButtonClicked;
        public event EventHandler OnSearchFieldChanged;
        public event EventHandler OnAEProductSave;
        public event EventHandler OnAEProductCancel;
        public event EventHandler ShowSelectedProductInfo;
        public event EventHandler OnSelectProduct;
        public event EventHandler OnProductsVRefresh;

        // Stores View Elements
        public Panel PnlProductsView { get => this.pnlProductsView; set => this.pnlProductsView=value; }
        public Panel PnlPCategoriesView { get => this.pnlProdCategoriesView; set => this.pnlProdCategoriesView=value; }
        public Panel PnlPUnitsView { get => this.pnlProdUnitsView; set => this.pnlProdUnitsView=value; }
        public string HeaderTitle { get => this.lblHeaderTitle.Text; set => this.lblHeaderTitle.Text=value; }

        // Categories View Elements
        public bool IsAECtegoryFormVisable { get => this.fpnlAECategoryForms.Visible; set => this.fpnlAECategoryForms.Visible=value; }
        public string PCategoryName { get => this.tbCategoryName.Text; set => tbCategoryName.Text=value; }
        public string PCateDescription { get => this.tbCategoryDescription.Text; set => this.tbCategoryDescription.Text=value; }
        public DataGridView DGVPCategories { get => this.dgvCategories; set => this.dgvCategories = value; }

        // Units View Elements
        public bool IsAEUnitFormVisable { get => this.fpnlAEUnitForms.Visible; set => this.fpnlAEUnitForms.Visible=value; }
        public string PUnitName { get =>this.tbUnitName.Text; set => this.tbUnitName.Text=value; }
        public string PSubUnitName { get => this.tbSubUnitName.Text; set => this.tbSubUnitName.Text = value; }
        public string PUnitSymbol { get => this.tbUnitSymbol.Text; set => this.tbUnitSymbol.Text=value; }
        public string PSubUnitSymbol { get => this.tbSubUnitSymbol.Text; set => this.tbSubUnitSymbol.Text=value; }
        public string PSubUnitRate { get => this.tbSubUintRate.Text; set => this.tbSubUintRate.Text=value; }
        public string PUnitDescription { get => this.tbUnitDescription.Text; set => this.tbUnitDescription.Text=value; }
        public DataGridView DGVPUnits { get => this.dgvUnits; set => this.dgvUnits = value; }

        // Products View Elements
        public bool IsAEProductFormVisable { get => this.fpnlAEProductForms.Visible; set => fpnlAEProductForms.Visible=value; }
        public string SearchTextValue { get => this.tbSearchProduct.Text; set => this.tbSearchProduct.Text=value; }
        public string Product_Name { get => this.tbProductName.Text; set => this.tbProductName.Text=value; }
        public string ProductBarCode { get => this.tbProductBarCode.Text; set => this.tbProductBarCode.Text=value; }
        public string ProdDefPrice { get => this.tbProdDefPrice.Text; set => this.tbProdDefPrice.Text = value; }
        public string ProductDescription { get => this.tbProductDescription.Text; set => this.tbProductDescription.Text=value; }
        public ComboBox PCategroySelectList { get => this.cbxCatagorySelect; set => this.cbxCatagorySelect=value; }
        public ComboBox PUnitSelectList { get => this.cbxUnitSelect; set => this.cbxUnitSelect=value; }
        public ComboBox CategoryFilter { get => this.cbxCategoryFilter;  set => this.cbxCategoryFilter = value; }
        public DataGridView DGVProducts { get => this.dgvProducts; set => this.dgvProducts = value; }
        public DataGridView DGVProductInfo { get => this.dgvProdInfo; set => this.dgvProdInfo = value; }
        public Panel PnlProdInfo { get => this.pnlProductInfoView; set => this.pnlProductInfoView = value; }

        private void SubStoresVEvents()
        {
            this.btnShowProductsView.Click += delegate { ShowProductsView?.Invoke(this, EventArgs.Empty); };
            this.btnShowProdCategoriesView.Click += delegate { ShowProdCategoriesView?.Invoke(this, EventArgs.Empty); };
            this.btnShowProdUnitsView.Click += delegate { ShowProdUnitsView?.Invoke(this, EventArgs.Empty); };
        }

        private void SubProductsViewEvents()
        {
            this.btnAddProduct.Click += delegate { this.ShowAddProductForm?.Invoke(this, EventArgs.Empty); };
            this.btnEditProduct.Click += delegate { this.ShowEditProductForm?.Invoke(this, EventArgs.Empty); };
            this.btnDeleteProduct.Click += delegate { this.DeleteSelectedProduct?.Invoke(this, EventArgs.Empty); };
            this.btnAEProductSubmit.Click += delegate { this.OnAEProductSave?.Invoke(this, EventArgs.Empty); };
            this.btnAEProductCancel.Click += delegate { this.OnAEProductCancel?.Invoke(this, EventArgs.Empty); };
            this.btnSearch.Click += delegate { this.OnSearchButtonClicked?.Invoke(this, EventArgs.Empty); };
            this.tbSearchProduct.Validated += delegate { this.OnSearchFieldChanged?.Invoke(this, EventArgs.Empty); };
            this.cbxCategoryFilter.SelectedValueChanged += delegate { this.OnCategoryFilterChanged?.Invoke(this, EventArgs.Empty); };
            this.cbxUnitSelect.SelectedValueChanged += delegate { this.OnSelectUnit?.Invoke(this, EventArgs.Empty); };
            this.cbxCatagorySelect.SelectedValueChanged += delegate { this.OnSelectCategory?.Invoke(this, EventArgs.Empty); };
            this.dgvProducts.SelectionChanged += delegate { this.OnSelectProduct?.Invoke(this, EventArgs.Empty); };
            this.btnProdVRefresh.Click += delegate { this.OnProductsVRefresh?.Invoke(this, EventArgs.Empty); };
            this.tbSearchProduct.Validated += delegate { this.OnSearchFieldChanged?.Invoke(this, EventArgs.Empty); };
            this.dgvProducts.CellDoubleClick += delegate { this.ShowSelectedProductInfo?.Invoke(this, EventArgs.Empty); };
        }

        private void SubProdCategoriesViewEvents()
        {
            this.btnAddCategory.Click += delegate { this.ShowAddProdCategoryForm?.Invoke(this, EventArgs.Empty); };
            this.btnEditCategory.Click += delegate { this.ShowEditProdCategoryForm?.Invoke(this, EventArgs.Empty); };
            this.btnDeleteCategory.Click += delegate {this.DeleteSelectedProdCategory?.Invoke(this, EventArgs.Empty); };
            this.btnAECategorySave.Click += delegate { this.OnAECategorySave?.Invoke(this, EventArgs.Empty); };
            this.btnAECategoryCancel.Click += delegate { this.OnAECategoryCancel?.Invoke(this, EventArgs.Empty); };
            this.DGVPCategories.SelectionChanged += delegate { this.OnSelectCategory?.Invoke(this, EventArgs.Empty); };
            this.pnlProdCategoriesView.Click += delegate { this.OnClickCategoriesView?.Invoke(this, EventArgs.Empty); };
        }

        private void SubProdUnitsEvents()
        {
            this.btnAddProdUnit.Click += delegate { this.ShowAddProdUnitForm?.Invoke(this, EventArgs.Empty); };
            this.btnEditProdUnit.Click += delegate { this.ShowEditProdUnitForm?.Invoke(this, EventArgs.Empty); };
            this.btnDeleteProdUnit.Click += delegate { this.DeleteSelectedProdUnit?.Invoke(this, EventArgs.Empty); };
            this.btnAEUnitSubmit.Click += delegate { this.OnAEUnitSave?.Invoke(this, EventArgs.Empty); };
            this.btnAEUnitCancel.Click += delegate { this.OnAEUnitCancel?.Invoke(this, EventArgs.Empty); };
            this.dgvUnits.SelectionChanged += delegate { this.OnSelectUnit?.Invoke(this, EventArgs.Empty); };
            this.pnlProdUnitsView.Click += delegate { this.OnClickUnitView?.Invoke(this, EventArgs.Empty); };
        }
        void InitProp()
        {
            

            this.fpnlAEProductForms.Visible = false;
            this.fpnlAECategoryForms.Visible = false;
            this.fpnlAEUnitForms.Visible = false;
        }

        public bool ShowMsgBox(string msg,string title,bool isYesNo)
        {
           DialogResult res =  MessageBox.Show(msg,title,isYesNo?MessageBoxButtons.YesNo:MessageBoxButtons.OK);
            if (res == DialogResult.Yes) 
            { 
                return true; 
            }
            else
            {
                return false;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.pnlProductInfoView.SendToBack();
        }
    }
}
