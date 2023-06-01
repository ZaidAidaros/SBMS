using SBMS.Models.General;
using SBMS.Models.Stores;
using SBMS.Models.Suppliers;
using SBMS.Repositories;
using SBMS.Repositories.PurchasesRepo;
using SBMS.Repositories.StoresRepo;
using SBMS.Repositories.SuppliersRepo;
using SBMS.Views.Purchases;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SBMS.Presenters.PurchasesPres
{
    class NewRetPurchaseInvVPres
    {
        INewPurchaseInvV newRetPurchaseInvV;
        //private bool IsEdit = false;
        //private CustomerM SelectedCustomer;

        private List<InvoiceItemM> InvItems = new List<InvoiceItemM>();
        ProductM selectedProductM;
        private static NewRetPurchaseInvVPres instance;
        public static NewRetPurchaseInvVPres GetInstance()
        {
            if (instance == null) instance = new NewRetPurchaseInvVPres();
            return instance;
        }
        public static void Dispose()
        {
            instance = null;
        }
        private NewRetPurchaseInvVPres()
        {
            newRetPurchaseInvV = NewRetPurchaseInvV.GetInstance();

            OnInitAsync();
        }
        private async Task OnInitAsync()
        {
            
            LoadMonyStates();
            await LoadSuppliersAsync();
            await LoadProdCategoiesAsync();
            await LoadProductsAsync(0);
            newRetPurchaseInvV.OnInvSave += async delegate { await OnSaveInvAsync(); };
            newRetPurchaseInvV.OnInvCancel += delegate { OnInCancel(); };
            newRetPurchaseInvV.OnInvItemIncOne += delegate { OnInvItemIncOne(); };
            newRetPurchaseInvV.OnInvItemDecOne += delegate { OnInvItemDecOne(); };
            newRetPurchaseInvV.OnAEInvItem += delegate { OnAEInvItem(); };
            newRetPurchaseInvV.OnInvItemRemove += delegate { OnRemoveInvItem(); };
            newRetPurchaseInvV.OnPSearchBClicked += async delegate { await OnPSearchBClickedAsync(); };
            newRetPurchaseInvV.CBXPCategoryFilter.SelectedIndexChanged += async delegate { await OnCategoryFilterChangeAsync(); };
            newRetPurchaseInvV.CBXSuppliers.SelectedIndexChanged += delegate { OnSelectSupplier(); };
            newRetPurchaseInvV.DGVProducts.ClearSelection();
            newRetPurchaseInvV.DGVInvItems.ClearSelection();
            newRetPurchaseInvV.DGVInvItems.CellClick += delegate { OnSelectInvItem(); };
            newRetPurchaseInvV.OnClose += delegate { OnClose(); };
            newRetPurchaseInvV.DGVProducts.SelectionChanged += delegate { OnSelectProduct(); };
            newRetPurchaseInvV.OnDisposed += delegate { Dispose(); };
        }
        private void OnSelectProduct()
        {
            if (newRetPurchaseInvV.DGVProducts.SelectedRows.Count==1)
            {
                newRetPurchaseInvV.AEButtonText = "Add";
                selectedProductM = (ProductM)newRetPurchaseInvV.DGVProducts.SelectedRows[0].DataBoundItem;
                newRetPurchaseInvV.Cost = selectedProductM.Cost.ToString();
                newRetPurchaseInvV.InvItemQuantity = selectedProductM.Quantity.ToString();
            }
        }
        private void OnSelectSupplier()
        {
            this.newRetPurchaseInvV.InvSuppName = ((SupplierM)this.newRetPurchaseInvV.CBXSuppliers.SelectedItem).Name;
        }
        private async Task LoadProductsAsync(int cateId)
        {
            RepoResultM res;
            if (cateId == 0)
            {
                res = await ProductsRepo.GetFullProductsAsync();
            }
            else
            {
                res = await ProductsRepo.FilterFullProductsAsync(cateId);
            }

            if (res.IsSucess)
            {

                this.newRetPurchaseInvV.DGVProducts.DataSource = null;
                List<ProductM> ProductsList = new List<ProductM>();
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    ProductsList.Add((ProductM)res.ResData[i]);
                }
                if (ProductsList.Count > 0)
                {
                    this.newRetPurchaseInvV.DGVProducts.DataSource = ProductsList;
                    this.newRetPurchaseInvV.DGVProducts.ClearSelection();
                }

            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    this.newRetPurchaseInvV.ShowMsgBox("The Products List Is Empty", "Note:", false);
                    return;
                }
                this.newRetPurchaseInvV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
        }
        private async Task LoadSuppliersAsync()
        {
            RepoResultM res = await SuppliersRepo.GetSuppliersAsync();
            if (res.IsSucess)
            {
                this.newRetPurchaseInvV.CBXSuppliers.Items.Clear();
                this.newRetPurchaseInvV.CBXSuppliers.DisplayMember = "Name";
                this.newRetPurchaseInvV.CBXSuppliers.ValueMember = "Id";
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    this.newRetPurchaseInvV.CBXSuppliers.Items.Add((SupplierM)res.ResData[i]);
                }

            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    this.newRetPurchaseInvV.ShowMsgBox("The Supplier List Is Empty", "Note:", false);
                    return;
                }
                this.newRetPurchaseInvV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
        }
        private async Task LoadProdCategoiesAsync()
        {
            RepoResultM res = await ProdCategoriesRepo.GetProdCategoriesAsync();
            if (res.IsSucess)
            {
                this.newRetPurchaseInvV.CBXPCategoryFilter.Items.Clear();
                this.newRetPurchaseInvV.CBXPCategoryFilter.DisplayMember = "Name";
                this.newRetPurchaseInvV.CBXPCategoryFilter.ValueMember = "Id";
                ProdCategoryM prodCategoryM = new ProdCategoryM();
                prodCategoryM.Id = 0;
                prodCategoryM.Name = "All";
                this.newRetPurchaseInvV.CBXPCategoryFilter.Items.Add(prodCategoryM);
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    this.newRetPurchaseInvV.CBXPCategoryFilter.Items.Add((ProdCategoryM)res.ResData[i]);
                }
                this.newRetPurchaseInvV.CBXPCategoryFilter.SelectedIndex = 0;

            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    this.newRetPurchaseInvV.ShowMsgBox("The Product Categories List Is Empty", "Note:", false);
                    return;
                }
                this.newRetPurchaseInvV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
        }
        private void LoadMonyStates()
        {
            MonyStateM monyState1 = new MonyStateM();
            MonyStateM monyState2 = new MonyStateM(); 

            this.newRetPurchaseInvV.CBXMonyState.Items.Clear();
            this.newRetPurchaseInvV.CBXMonyState.DisplayMember = "Name";
            this.newRetPurchaseInvV.CBXMonyState.ValueMember = "Id";
            monyState1.Id = 1;
            monyState1.Name = "Cash";
            this.newRetPurchaseInvV.CBXMonyState.Items.Add(monyState1);
            monyState2.Id = 2;
            monyState2.Name = "Later";
            this.newRetPurchaseInvV.CBXMonyState.Items.Add(monyState2); 
            this.newRetPurchaseInvV.CBXMonyState.SelectedIndex = 0;


        }
        private async Task OnSaveInvAsync()
        {
            if (this.InvItems.Count > 0)
            {
                if (((SupplierM)this.newRetPurchaseInvV.CBXSuppliers.SelectedItem) == null)
                {
                    this.newRetPurchaseInvV.ShowMsgBox("Select Supplier", "Note:", false);
                }
                else if (string.IsNullOrEmpty(this.newRetPurchaseInvV.InvSuppName))
                {
                    this.newRetPurchaseInvV.ShowMsgBox("Enter Supplier Name", "Note:", false);
                }
                else
                {
                    InvoiceM purchaseInvM = new InvoiceM();
                    purchaseInvM.EmpId = PurchasesHVPres.GetInstance(null).user.EmployeeId;
                    purchaseInvM.SupplierId = ((SupplierM)this.newRetPurchaseInvV.CBXSuppliers.SelectedItem).Id;
                    purchaseInvM.MonyStateId = ((MonyStateM)this.newRetPurchaseInvV.CBXMonyState.SelectedItem).Id;
                    purchaseInvM.InvoiceTypeId = 2;
                    purchaseInvM.Note = this.newRetPurchaseInvV.InvNote;
                    purchaseInvM.NameOnInvoice = this.newRetPurchaseInvV.InvSuppName;
                    purchaseInvM.Date = DateTime.Now;
                    purchaseInvM.Total = GetInvTotalPrice();
                    RepoResultM res = await PurchasesRepo.AddPurchaseInvoiceAsync(purchaseInvM);
                    if (res.IsSucess)
                    {
                        for (int i = 0; i < this.InvItems.Count; i++)
                        {
                            this.InvItems[i].InvoiceId = (int)res.ResData[0];
                            RepoResultM itemRes = await PurchasesItemsRepo.AddRePurchaseInvItemAsync(this.InvItems[i]);
                            if (!itemRes.IsSucess) this.newRetPurchaseInvV.ShowMsgBox(itemRes.ErrorMsg + "\n" + res.ResData[0], "Error:", false);

                        }
                        this.RestAll();
                        this.newRetPurchaseInvV.ShowMsgBox("The Invoice Saved Successfuly", "Success:", false);
                    }
                    else
                    {
                        this.newRetPurchaseInvV.ShowMsgBox(res.ErrorMsg, "Error:", false);
                    }
                }
            }
            else
            {
                this.newRetPurchaseInvV.ShowMsgBox("Invoice has No Items\nAdd Some Items First", "Error:", false);
            }
        }
        private decimal GetInvTotalPrice()
        {
            decimal total = 0;
            for (int i = 0; i < this.InvItems.Count; i++)
            {
                total += this.InvItems[i].TotalPrice;
            }
            return total;
        }
        private void OnInCancel()
        {
            this.RestAll();
        }
        private void OnInvItemIncOne()
        {
            this.newRetPurchaseInvV.InvItemQuantity = (decimal.Parse(this.newRetPurchaseInvV.InvItemQuantity) + 1).ToString();
        }
        private void OnInvItemDecOne()
        {
            if (decimal.Parse(this.newRetPurchaseInvV.InvItemQuantity) > 0)
                this.newRetPurchaseInvV.InvItemQuantity = (decimal.Parse(this.newRetPurchaseInvV.InvItemQuantity) - 1).ToString();
        }
        private void OnAEInvItem()
        {
            if (this.newRetPurchaseInvV.DGVProducts.SelectedRows.Count == 1 && ValidateFields() && this.newRetPurchaseInvV.AEButtonText == "Add")
            {
                this.AddInvItem();
            }
            else if (this.newRetPurchaseInvV.DGVInvItems.SelectedRows.Count == 1 && ValidateFields())
            {
                this.EditInvItem();
            }
            else
            {
                this.newRetPurchaseInvV.ShowMsgBox("Select Product", "Note:", false);
                return;
            }
            this.RestItemFields();
            this.newRetPurchaseInvV.DGVInvItems.DataSource = null;
            this.newRetPurchaseInvV.DGVInvItems.DataSource = this.InvItems;
            this.newRetPurchaseInvV.InvTotlPrice = GetInvTotalPrice().ToString();

        }
        private bool ValidateFields()
        {
            if (string.IsNullOrEmpty(this.newRetPurchaseInvV.Cost))
            {
                this.newRetPurchaseInvV.ShowMsgBox("Enter Product Cost ", "Note:", false);
            }
            else if (string.IsNullOrEmpty(this.newRetPurchaseInvV.InvItemQuantity))
            {
                this.newRetPurchaseInvV.ShowMsgBox("Enter Product Quantity ", "Note:", false);
            }
            else
            {
                return true;
            }
            return false;
        }
        private void AddInvItem()
        {

            InvoiceItemM purchaseInvItemM = new InvoiceItemM();
            
            purchaseInvItemM.ProductId = selectedProductM.Id;
            purchaseInvItemM.ProductDId = selectedProductM.DId;
            purchaseInvItemM.Name = selectedProductM.Name;
            purchaseInvItemM.Unit = selectedProductM.Unit;
            purchaseInvItemM.DefPrice = selectedProductM.DefPrice;
            purchaseInvItemM.Price = decimal.Parse(this.newRetPurchaseInvV.Cost);
            purchaseInvItemM.ExpireDate = this.newRetPurchaseInvV.ExpireDate.Value.ToShortDateString();
            if (selectedProductM.Quantity >= decimal.Parse(this.newRetPurchaseInvV.InvItemQuantity))
            {
                purchaseInvItemM.Quantity = decimal.Parse(this.newRetPurchaseInvV.InvItemQuantity);
            }
            else
            {
                purchaseInvItemM.Quantity = selectedProductM.Quantity;
                
            }

            for (int i = 0; i < this.InvItems.Count; i++)
            {
                if (this.InvItems[i].IsEqualTo(purchaseInvItemM))
                {
                    if (this.newRetPurchaseInvV.ShowMsgBox("This Product is Alredy Exist\nDo You Want To Update It", "Note:", true))
                    {
                        this.InvItems[i] = purchaseInvItemM;

                    }
                    else
                    {
                        return;
                    }
                    return;
                }
            }

            this.InvItems.Add(purchaseInvItemM);

        }
        private void EditInvItem()
        {
            InvoiceItemM purchaseInvItemM = (InvoiceItemM)this.newRetPurchaseInvV.DGVInvItems.SelectedRows[0].DataBoundItem;
            purchaseInvItemM.Price = decimal.Parse(this.newRetPurchaseInvV.Cost);
            purchaseInvItemM.Quantity = decimal.Parse(this.newRetPurchaseInvV.InvItemQuantity);
            purchaseInvItemM.ExpireDate = this.newRetPurchaseInvV.ExpireDate.Value.ToShortDateString();

            for (int i = 0; i < this.InvItems.Count; i++)
            {
                if (this.InvItems[i].IsEqualTo(purchaseInvItemM))
                {
                    this.InvItems[i] = purchaseInvItemM;
                }
            }
        }
        private void OnRemoveInvItem()
        {
            if (this.newRetPurchaseInvV.DGVInvItems.SelectedRows.Count > 0)
            {
                this.InvItems.Remove((InvoiceItemM)this.newRetPurchaseInvV.DGVInvItems.SelectedRows[0].DataBoundItem);
                this.newRetPurchaseInvV.DGVInvItems.DataSource = null;
                this.newRetPurchaseInvV.DGVInvItems.DataSource = this.InvItems;
            }

        }
        private async Task OnPSearchBClickedAsync()
        {
            if (string.IsNullOrWhiteSpace(this.newRetPurchaseInvV.PSearvhField) || string.IsNullOrEmpty(this.newRetPurchaseInvV.PSearvhField)) return;
            RepoResultM res = await ProductsRepo.SearchProductAsync(this.newRetPurchaseInvV.PSearvhField);
            if (res.IsSucess)
            {
                List<ProductM> productsList = new List<ProductM>();
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    productsList.Add((ProductM)res.ResData[i]);
                }
                if (productsList.Count > 0)
                {
                    this.newRetPurchaseInvV.DGVProducts.DataSource = null;
                    this.newRetPurchaseInvV.DGVProducts.DataSource = productsList;
                    this.newRetPurchaseInvV.DGVProducts.ClearSelection();
                }
            }
            else
            {
                await this.LoadProductsAsync(0);
                this.RestAll();
                this.newRetPurchaseInvV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
        }
        private void OnSelectInvItem()
        {
            InvoiceItemM purInvItem = this.newRetPurchaseInvV.DGVInvItems.SelectedRows[0].DataBoundItem as InvoiceItemM;
            this.newRetPurchaseInvV.InvItemQuantity = purInvItem.Quantity.ToString();
            this.newRetPurchaseInvV.Cost = purInvItem.Price.ToString();
            this.newRetPurchaseInvV.ExpireDate.Value = DateTime.Parse(purInvItem.ExpireDate);
            this.newRetPurchaseInvV.AEButtonText = "Update";
        }
        private async Task OnCategoryFilterChangeAsync()
        {
            await this.LoadProductsAsync(((ProdCategoryM)this.newRetPurchaseInvV.CBXPCategoryFilter.SelectedItem).Id);
        }
        private void RestAll()
        {
            this.newRetPurchaseInvV.CBXMonyState.SelectedIndex = 0;
            this.newRetPurchaseInvV.InvSuppName = null;
            this.selectedProductM = null;
            this.RestItemFields();
            this.newRetPurchaseInvV.DGVInvItems.DataSource = null;
            this.InvItems.Clear();
        }
        private void RestItemFields()
        {

            this.newRetPurchaseInvV.InvItemQuantity = "1";
            this.newRetPurchaseInvV.Cost = null;
            this.newRetPurchaseInvV.PSearvhField = null;
            this.newRetPurchaseInvV.CBXPCategoryFilter.SelectedIndex = 0;
            this.newRetPurchaseInvV.DGVProducts.ClearSelection();
            this.newRetPurchaseInvV.DGVInvItems.ClearSelection();

        }
        private void OnClose()
        {

        }
    }
}
