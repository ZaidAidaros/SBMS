using SBMS.Models.Stores;
using SBMS.Repositories;
using SBMS.Repositories.StoresRepo;
using SBMS.Views.StoresV;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SBMS.Presenters.StoresPres
{
    class ProductsVPres
    {
        private IProductsV ProductsV;
        private bool IsEdit = false;
        ProductM SelectedProduct;

        // Singletone
        private static ProductsVPres instance;
        public static ProductsVPres GetInstance()
        {
            if (instance == null) instance = new ProductsVPres();
            return instance;
        }
        private ProductsVPres()
        {
            this.ProductsV = StoresV.GetInstance();
            this.OnInitAsync();
        }
        private async Task OnInitAsync()
        {
            await this.LoadUnitsAsync();
            await this.LoadCategoryListAsync();
            await this.LoadProductsAsync();
            this.ProductsV.ShowAddProductForm += delegate { this.ShowAddProductForm(); };
            this.ProductsV.ShowEditProductForm += delegate { this.ShowEditProductForm(); };
            this.ProductsV.DeleteSelectedProduct += async delegate { await this.DeleteSelectedProductAsync(); };
            this.ProductsV.OnAEProductSave += delegate { this.OnAEProductSaveAsync(); };
            this.ProductsV.OnAEProductCancel += delegate { OnAEProductCancel(); };
            this.ProductsV.OnSelectProduct += delegate { this.OnSelectProduct(); };
            this.ProductsV.OnCategoryFilterChanged += async delegate { await OnCategoryFilterChangedAsync(); };
            this.ProductsV.OnSearchButtonClicked += async delegate { await OnSearchButtonClickedAsync(); };
            //this.ProductsV.OnSearchFieldChanged += async delegate { await OnSearchButtonClickedAsync(); };
            this.ProductsV.OnProductsVRefresh += async delegate { await OnRefreshPVAsync(); };
            this.ProductsV.ShowSelectedProductInfo += async delegate { await ShowProdInfoAsync(); };
        }
        private async Task ShowProdInfoAsync()
        {
            RepoResultM res = await ProductsRepo.GetProdDetailsAsync(this.SelectedProduct.Id);
            this.ProductsV.DGVProductInfo.DataSource = null;
            if (res.IsSucess)
            {
                List<ProdExtraInfoM> productD = new List<ProdExtraInfoM>();
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    productD.Add((ProdExtraInfoM)res.ResData[i]);
                }
                if (productD.Count > 0)
                {
                    this.ProductsV.DGVProductInfo.DataSource = productD;
                    this.ProductsV.PnlProdInfo.BringToFront();
                }
            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    this.ProductsV.ShowMsgBox("No Info For This Product Until Now.", "Note:", false);
                    return;
                }
                this.ProductsV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
            
        }
        private async Task OnRefreshPVAsync()
        {
            await this.LoadUnitsAsync();
            await this.LoadCategoryListAsync();
            await this.LoadProductsAsync();
            this.ResetAll();
        }
        private async Task OnSearchButtonClickedAsync()
        {
            if (string.IsNullOrWhiteSpace(this.ProductsV.SearchTextValue) || string.IsNullOrEmpty(this.ProductsV.SearchTextValue)) return;
            RepoResultM res = await ProductsRepo.SearchProductAsync(this.ProductsV.SearchTextValue);
            if (res.IsSucess)
            {
                List<ProductM> productsList = new List<ProductM>();
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    productsList.Add((ProductM)res.ResData[i]);
                }
                if (productsList.Count > 0)
                {
                    this.ProductsV.DGVProducts.DataSource = null;
                    this.ProductsV.DGVProducts.DataSource = productsList;
                    this.ProductsV.DGVProducts.ClearSelection();
                }
            }
            else
            {
                await this.LoadProductsAsync();
                this.ProductsV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
        }
        private async Task OnCategoryFilterChangedAsync()
        {
            RepoResultM res = await ProductsRepo.FilterProductsAsync(((ProdCategoryM)this.ProductsV.CategoryFilter.SelectedItem).Id);
                
                if (res.IsSucess)
                {
                    List<ProductM> productsList = new List<ProductM>();
                    for (int i = 0; i < res.ResData.Count; i++)
                    {
                        productsList.Add((ProductM)res.ResData[i]);
                    }
                    if (productsList.Count > 0)
                    {
                        this.ProductsV.DGVProducts.DataSource = null;
                        this.ProductsV.DGVProducts.DataSource = productsList;
                        this.ProductsV.DGVProducts.ClearSelection();
                    }
                }
                else
                {
                    if (res.ErrorMsg == "No Result")
                    {
                    await this.LoadProductsAsync();
                    if (this.ProductsV.CategoryFilter.SelectedIndex == 0) return;
                    this.ProductsV.ShowMsgBox("No Products In This Category", "Note:", false);
                    return;
                    }
                    this.ProductsV.ShowMsgBox(res.ErrorMsg, "Error:", false);
                }
            
            
        }
        private void OnAEProductCancel()
        {
            this.ResetAll();
        }
        private void OnSelectProduct()
        {
            if (this.ProductsV.DGVProducts.SelectedRows.Count == 1)
                this.SelectedProduct = (ProductM)this.ProductsV.DGVProducts.SelectedRows[0].DataBoundItem;
        }
        /// <summary>
        /// Fetch fun
        /// </summary>
        private async Task LoadProductsAsync()
        {
            RepoResultM res = await ProductsRepo.GetProductsAsync();
            this.ProductsV.DGVProducts.DataSource = null;
            if (res.IsSucess)
            {
                List<ProductM> productsList = new List<ProductM>();
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    productsList.Add((ProductM)res.ResData[i]);
                }
                if (productsList.Count > 0)
                {
                    this.ProductsV.DGVProducts.DataSource = productsList;
                    this.ProductsV.DGVProducts.ClearSelection();
                }
            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    this.ProductsV.ShowMsgBox("The Products List Is Empty", "Note:", false);
                    return;
                }
                this.ProductsV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }

        }
        private async Task LoadCategoryListAsync()
        {
            ProdCategoryM prodCategoryM = new ProdCategoryM();
            prodCategoryM.Id = 0;
            prodCategoryM.Name = "All";
            this.ProductsV.CategoryFilter.Items.Clear();
            this.ProductsV.PCategroySelectList.Items.Clear();
            this.ProductsV.CategoryFilter.Items.Add(prodCategoryM);
            RepoResultM res = await ProdCategoriesRepo.GetProdCategoriesAsync();
            if (res.IsSucess)
            {
                this.ProductsV.CategoryFilter.DisplayMember = "Name";
                this.ProductsV.CategoryFilter.ValueMember = "Id";
                this.ProductsV.PCategroySelectList.DisplayMember = "Name";
                this.ProductsV.PCategroySelectList.ValueMember = "Id";
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    this.ProductsV.CategoryFilter.Items.Add((ProdCategoryM)res.ResData[i]);
                    this.ProductsV.PCategroySelectList.Items.Add((ProdCategoryM)res.ResData[i]);
                    this.ProductsV.CategoryFilter.SelectedIndex = 0;
                }
                
            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    this.ProductsV.ShowMsgBox("The Category List Is Empty", "Note:", false);
                    return;
                }
                this.ProductsV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
        }
        private async Task LoadUnitsAsync()
        {
            RepoResultM res = await ProdUnitsRepo.GetProdUnitsAsync();
            if (res.IsSucess)
            {
                this.ProductsV.PUnitSelectList.Items.Clear();
                this.ProductsV.PUnitSelectList.DisplayMember = "Name";
                this.ProductsV.PUnitSelectList.ValueMember = "Id";
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    this.ProductsV.PUnitSelectList.Items.Add((ProdUnitM)res.ResData[i]);
                }
                
            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    this.ProductsV.ShowMsgBox("The Uint List Is Empty", "Note:", false);
                    return;
                }
                this.ProductsV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
        }
        /// <summary>
        /// Fetch fun
        /// </summary> 
        private void ShowAddProductForm()
        {
            this.IsEdit = false;
            this.ProductsV.IsAEProductFormVisable = true;
        }
        private void ShowEditProductForm()
        {
            if (this.SelectedProduct == null)
            {
                this.ProductsV.ShowMsgBox("Must Select Product To Edit From List.", "Error:", false);
                return;
            }
            this.IsEdit = true;
            this.SetFields();
            this.ProductsV.IsAEProductFormVisable = true;
        }
        private void SetFields()
        {
            this.ProductsV.Product_Name = this.SelectedProduct.Name;
            this.ProductsV.ProductBarCode = this.SelectedProduct.BarCode.ToString();
            this.ProductsV.ProdDefPrice = this.SelectedProduct.DefPrice.ToString();
            this.ProductsV.ProductDescription = this.SelectedProduct.Description;
            for (int i = 0; i < this.ProductsV.PCategroySelectList.Items.Count; i++)
            {
                if (((ProdCategoryM)this.ProductsV.PCategroySelectList.Items[i]).Name == this.SelectedProduct.Category)
                {
                    this.ProductsV.PCategroySelectList.SelectedIndex = i;
                    break;
                }
            }
            for (int i = 0; i < this.ProductsV.PUnitSelectList.Items.Count; i++)
            {
                if (((ProdUnitM)this.ProductsV.PUnitSelectList.Items[i]).Name == this.SelectedProduct.Unit)
                {
                    this.ProductsV.PUnitSelectList.SelectedIndex = i;
                    break;
                }
            }
        }
        private async Task OnAEProductSaveAsync()
        {
            if (this.IsEdit)
            {
                await this.EditProductAsync();
            }
            else
            {
                await this.AddProductAsync();
            }
        }
        private async Task AddProductAsync()
        {
            if (this.ProductsV.ShowMsgBox("Are You Sure?\nYou Want To Save", "Confirm:", true))
            {
                RepoResultM res = await ProductsRepo.AddProductAsync(SetProductM(null));
                if (res.IsSucess)
                {
                    await this.LoadProductsAsync();
                    this.ResetAll();
                    this.ProductsV.ShowMsgBox("Save Sucessful", "Sucess:", false);
                }
                else
                {
                    this.ProductsV.ShowMsgBox(res.ErrorMsg, "Error:", false);
                }
            }
        }
        private ProductM SetProductM(ProductM selectedProduct)
        {
            if (selectedProduct == null) selectedProduct = new ProductM();
            selectedProduct.Name = this.ProductsV.Product_Name;
            selectedProduct.BarCode = int.Parse(this.ProductsV.ProductBarCode);
            selectedProduct.DefPrice = decimal.Parse(this.ProductsV.ProdDefPrice);
            selectedProduct.Description = this.ProductsV.ProductDescription;
            selectedProduct.PCategory = (ProdCategoryM)this.ProductsV.PCategroySelectList.SelectedItem;
            selectedProduct.PUnit = (ProdUnitM)this.ProductsV.PUnitSelectList.SelectedItem;
            return selectedProduct;
        }
        private async Task EditProductAsync()
        {
            if (this.ProductsV.ShowMsgBox("Are You Sure?\nYou Want To Save Changes", "Confirm:", true))
            {
                RepoResultM res = await ProductsRepo.UpdateProductAsync(SetProductM(this.SelectedProduct));
                if (res.IsSucess)
                {
                    await this.LoadProductsAsync();
                    this.ResetAll();
                    this.ProductsV.ShowMsgBox("Save Changes Sucessful", "Sucess:", false);
                }
                else
                {
                    this.ProductsV.ShowMsgBox(res.ErrorMsg, "Error:", false);
                }
            }
        }
        private async Task DeleteSelectedProductAsync()
        {
            if (this.SelectedProduct == null)
            {
                this.ProductsV.ShowMsgBox("Must Select Unit To Delete From List", "Error:", false);
                return;
            }
            if (this.ProductsV.ShowMsgBox("Are You Sure?\n You Want To Delete It", "Confirm:", true))
            {
                RepoResultM res = await ProductsRepo.DeleteProductAsync(this.SelectedProduct.Id);
                if (res.IsSucess)
                {
                    await this.LoadProductsAsync();
                    this.ResetAll();
                }
                else
                {
                    this.ProductsV.ShowMsgBox(res.ErrorMsg, "Error:", false);
                }
            }
        }
        private void ResetAll()
        {
            this.IsEdit = false;
            this.ProductsV.IsAEProductFormVisable = false;
            this.ProductsV.Product_Name = null;
            this.ProductsV.ProdDefPrice = null;
            this.ProductsV.ProductBarCode = null;
            this.ProductsV.ProductDescription = null;
            this.ProductsV.DGVProducts.ClearSelection();
            this.ProductsV.CategoryFilter.SelectedIndex = 0;
            this.ProductsV.PCategroySelectList.SelectedItem = null;
            this.ProductsV.PUnitSelectList.SelectedItem = null;
            //this.ProductsV.ProductUnitsList.Items.Clear();
            //this.ProductsV.ProductCategroiesList.Items.Clear();
        }
    }
}
