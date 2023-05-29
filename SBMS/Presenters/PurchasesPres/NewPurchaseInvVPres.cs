using SBMS.Models.General;
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
    class NewPurchaseInvVPres
    {
        INewPurchaseInvV newPurchaseInvV;

        private List<InvoiceItemM> InvItems = new List<InvoiceItemM>();
        private static NewPurchaseInvVPres instance;
        public static NewPurchaseInvVPres GetInstance()
        {
            if (instance == null) instance = new NewPurchaseInvVPres();
            return instance;
        }
        public static void Dispose()
        {
            instance = null;
        }
        private NewPurchaseInvVPres()
        {
            this.newPurchaseInvV = NewPurchaseInvV.GetInstance(); 
            
            this.OnInitAsync();
        }
        private async Task OnInitAsync()
        {
            await LoadProductsAsync(0);
            await LoadSuppliersAsync();
            await LoadProdCategoiesAsync();
            LoadMonyStates();
            
            newPurchaseInvV.OnInvSave += async delegate { await OnSaveInvAsync(); };
            newPurchaseInvV.OnInvCancel += delegate { OnInCancel(); };
            newPurchaseInvV.OnInvItemIncOne += delegate { OnInvItemIncOne(); };
            newPurchaseInvV.OnInvItemDecOne += delegate { OnInvItemDecOne(); };
            newPurchaseInvV.OnAEInvItem += delegate { OnAEInvItem(); };
            newPurchaseInvV.OnInvItemRemove += delegate { OnRemoveInvItem(); };
            newPurchaseInvV.OnPSearchBClicked += async delegate { await OnPSearchBClickedAsync(); };
            newPurchaseInvV.CBXPCategoryFilter.SelectedIndexChanged += async delegate { await OnCategoryFilterChangeAsync(); };
            newPurchaseInvV.CBXSuppliers.SelectedIndexChanged += delegate { OnSelectSupplier(); };
            newPurchaseInvV.DGVProducts.ClearSelection();
            newPurchaseInvV.DGVInvItems.ClearSelection();
            newPurchaseInvV.DGVInvItems.CellClick += delegate { OnSelectInvItem(); };
            newPurchaseInvV.DGVProducts.SelectionChanged += delegate { this.newPurchaseInvV.AEButtonText = "Add"; };
            newPurchaseInvV.OnClose += delegate { OnClose(); };
            newPurchaseInvV.OnDisposed += delegate { Dispose(); };
        }
        private void OnSelectSupplier()
        {
            this.newPurchaseInvV.InvSuppName = ((SupplierM)this.newPurchaseInvV.CBXSuppliers.SelectedItem).Name;
        }
        private async Task LoadProductsAsync(int cateId)
        {
            RepoResultM res;
            if (cateId == 0) {
                res = await ProductsRepo.GetProductsAsync();
            }
            else
            {
                res = await ProductsRepo.FilterProductsAsync(cateId);
            }

            if (res.IsSucess)
            {

                this.newPurchaseInvV.DGVProducts.DataSource = null; 
                List<ProductM> ProductsList = new List<ProductM>();
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    ProductsList.Add((ProductM)res.ResData[i]);
                }
                if (ProductsList.Count > 0)
                {
                    this.newPurchaseInvV.DGVProducts.DataSource = ProductsList;
                    this.newPurchaseInvV.DGVProducts.ClearSelection();
                }
                
            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    this.newPurchaseInvV.ShowMsgBox("The Products List Is Empty", "Note:", false);
                    return;
                }
                this.newPurchaseInvV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
        }
        private async Task LoadSuppliersAsync()
        {
            RepoResultM res = await SuppliersRepo.GetSuppliersAsync();
            if (res.IsSucess)
            {
                this.newPurchaseInvV.CBXSuppliers.Items.Clear();
                this.newPurchaseInvV.CBXSuppliers.DisplayMember = "Name";
                this.newPurchaseInvV.CBXSuppliers.ValueMember = "Id";
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    this.newPurchaseInvV.CBXSuppliers.Items.Add((SupplierM)res.ResData[i]);
                }

            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    this.newPurchaseInvV.ShowMsgBox("The Supplier List Is Empty", "Note:", false);
                    return;
                }
                this.newPurchaseInvV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
        }
        private async Task LoadProdCategoiesAsync()
        {
            RepoResultM res = await ProdCategoriesRepo.GetProdCategoriesAsync();
            if (res.IsSucess)
            {
                this.newPurchaseInvV.CBXPCategoryFilter.Items.Clear();
                this.newPurchaseInvV.CBXPCategoryFilter.DisplayMember = "Name";
                this.newPurchaseInvV.CBXPCategoryFilter.ValueMember = "Id";
                ProdCategoryM prodCategoryM = new ProdCategoryM();
                prodCategoryM.Id = 0;
                prodCategoryM.Name = "All";
                this.newPurchaseInvV.CBXPCategoryFilter.Items.Add(prodCategoryM);
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    this.newPurchaseInvV.CBXPCategoryFilter.Items.Add((ProdCategoryM)res.ResData[i]);
                }
                this.newPurchaseInvV.CBXPCategoryFilter.SelectedIndex = 0;

            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    this.newPurchaseInvV.ShowMsgBox("The Product Categories List Is Empty", "Note:", false);
                    return;
                }
                this.newPurchaseInvV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
        }
        private void LoadMonyStates()
        {
            MonyStateM monyState1 = new MonyStateM();
            MonyStateM monyState2 = new MonyStateM();
            MonyStateM monyState3 = new MonyStateM();
            
            this.newPurchaseInvV.CBXMonyState.Items.Clear();
            this.newPurchaseInvV.CBXMonyState.DisplayMember = "Name";
            this.newPurchaseInvV.CBXMonyState.ValueMember = "Id";
            monyState1.Id = 1;
            monyState1.Name = "Cash";
            this.newPurchaseInvV.CBXMonyState.Items.Add(monyState1);
            monyState2.Id = 2;
            monyState2.Name = "Later";
            this.newPurchaseInvV.CBXMonyState.Items.Add(monyState2);
            monyState3.Id = 3;
            monyState3.Name = "Pay";
            this.newPurchaseInvV.CBXMonyState.Items.Add(monyState3);
            this.newPurchaseInvV.CBXMonyState.SelectedIndex=0;


        }
        private async Task OnSaveInvAsync()
        {
            if (this.InvItems.Count > 0)
            {
                if (((SupplierM)this.newPurchaseInvV.CBXSuppliers.SelectedItem) == null)
                {
                    this.newPurchaseInvV.ShowMsgBox("Select Supplier", "Note:", false);
                }
                else if (string.IsNullOrEmpty(this.newPurchaseInvV.InvSuppName))
                {
                    this.newPurchaseInvV.ShowMsgBox("Enter Supplier Name", "Note:", false);
                }
                else
                {
                    InvoiceM purchaseInvM = new InvoiceM();
                    purchaseInvM.EmpId = PurchasesHVPres.GetInstance(null).user.EmployeeId;
                    purchaseInvM.SupplierId = ((SupplierM)this.newPurchaseInvV.CBXSuppliers.SelectedItem).Id;
                    purchaseInvM.MonyStateId = ((MonyStateM)this.newPurchaseInvV.CBXMonyState.SelectedItem).Id;
                    purchaseInvM.InvoiceTypeId = 1;
                    purchaseInvM.Note = this.newPurchaseInvV.InvNote;
                    purchaseInvM.NameOnInvoice = this.newPurchaseInvV.InvSuppName;
                    purchaseInvM.Date = DateTime.Now;
                    purchaseInvM.Total = GetInvTotalPrice();
                    RepoResultM res = await PurchasesRepo.AddPurchaseInvoiceAsync(purchaseInvM);
                    if (res.IsSucess)
                    {
                        for (int i = 0; i < this.InvItems.Count; i++)
                        {
                            this.InvItems[i].InvoiceId = (int)res.ResData[0];
                            RepoResultM itemRes = await PurchasesItemsRepo.AddPurchaseInvItemAsync(this.InvItems[i]);
                            if (!itemRes.IsSucess) this.newPurchaseInvV.ShowMsgBox(itemRes.ErrorMsg + "\n" + res.ResData[0], "Error:", false);

                        }
                        this.RestAll();
                        this.newPurchaseInvV.ShowMsgBox("The Invoice Saved Successfuly", "Success:", false);
                    }
                    else
                    {
                        this.newPurchaseInvV.ShowMsgBox(res.ErrorMsg, "Error:", false);
                    }
                }
            }
            else
            {
                this.newPurchaseInvV.ShowMsgBox("Invoice has No Items\nAdd Some Items First", "Error:", false);
            }
        }
        private decimal GetInvTotalPrice()
        {
            decimal total = 0;
            for(int i =0; i < this.InvItems.Count; i++)
            {
                total += this.InvItems[i].TotalPrice;
            }
            return total;
        }
        private void OnInCancel()
        {
            RestAll();
        }
        private void OnInvItemIncOne()
        {
            newPurchaseInvV.InvItemQuantity = (decimal.Parse(this.newPurchaseInvV.InvItemQuantity) + 1).ToString();
        }
        private void OnInvItemDecOne()
        {
            if(decimal.Parse(newPurchaseInvV.InvItemQuantity)>0)
                this.newPurchaseInvV.InvItemQuantity = (decimal.Parse(newPurchaseInvV.InvItemQuantity) - 1).ToString();
        }
        private void OnAEInvItem()
        {
            if (this.newPurchaseInvV.DGVProducts.SelectedRows.Count == 1 && ValidateFields() && this.newPurchaseInvV.AEButtonText == "Add")
            {
                 this.AddInvItem();
            }
            else if(this.newPurchaseInvV.DGVInvItems.SelectedRows.Count == 1 && ValidateFields())
            {
                 this.EditInvItem();
            }
            else
            {
                this.newPurchaseInvV.ShowMsgBox("Select Product", "Note:", false);
                return;
            }
            this.RestItemFields();
            this.newPurchaseInvV.DGVInvItems.DataSource = null;
            this.newPurchaseInvV.DGVInvItems.DataSource = this.InvItems;
            this.newPurchaseInvV.InvTotlPrice = GetInvTotalPrice().ToString();
            
        }
        private bool ValidateFields()
        {
            if (string.IsNullOrEmpty(this.newPurchaseInvV.Cost))
            {
                this.newPurchaseInvV.ShowMsgBox("Enter Product Cost ", "Note:", false);
            }
            else if (string.IsNullOrEmpty(this.newPurchaseInvV.InvItemQuantity))
            {
                this.newPurchaseInvV.ShowMsgBox("Enter Product Quantity ", "Note:", false);
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
            ProductM productM = (ProductM)this.newPurchaseInvV.DGVProducts.SelectedRows[0].DataBoundItem;

            purchaseInvItemM.ProductId = productM.Id;
            purchaseInvItemM.Name = productM.Name;
            purchaseInvItemM.Unit = productM.Unit;
            purchaseInvItemM.DefPrice = productM.DefPrice;
            purchaseInvItemM.Price = decimal.Parse(this.newPurchaseInvV.Cost);
            purchaseInvItemM.Quantity = decimal.Parse(this.newPurchaseInvV.InvItemQuantity);
            purchaseInvItemM.ExpireDate = this.newPurchaseInvV.ExpireDate.Value.ToShortDateString();

             for (int i = 0; i < this.InvItems.Count; i++)
             {
                if (this.InvItems[i].IsEqualTo(purchaseInvItemM))
                {
                    if (this.newPurchaseInvV.ShowMsgBox("This Product is Alredy Exist\nDo You Want To Update It", "Note:", true))
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
            InvoiceItemM purchaseInvItemM = (InvoiceItemM)this.newPurchaseInvV.DGVInvItems.SelectedRows[0].DataBoundItem;
            purchaseInvItemM.Price = decimal.Parse(this.newPurchaseInvV.Cost);
            purchaseInvItemM.Quantity = decimal.Parse(this.newPurchaseInvV.InvItemQuantity);
            purchaseInvItemM.ExpireDate = this.newPurchaseInvV.ExpireDate.Value.ToShortDateString();
            
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
            if (this.newPurchaseInvV.DGVInvItems.SelectedRows.Count > 0)
            {
                this.InvItems.Remove((InvoiceItemM)this.newPurchaseInvV.DGVInvItems.SelectedRows[0].DataBoundItem);
                this.newPurchaseInvV.DGVInvItems.DataSource = null;
                this.newPurchaseInvV.DGVInvItems.DataSource = this.InvItems;
            }
                
        }
        private async Task OnPSearchBClickedAsync()
        {
            if (string.IsNullOrWhiteSpace(this.newPurchaseInvV.PSearvhField) || string.IsNullOrEmpty(this.newPurchaseInvV.PSearvhField)) return;
            RepoResultM res = await ProductsRepo.SearchProductAsync(this.newPurchaseInvV.PSearvhField);
            if (res.IsSucess)
            {
                List<ProductM> productsList = new List<ProductM>();
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    productsList.Add((ProductM)res.ResData[i]);
                }
                if (productsList.Count > 0)
                {
                    this.newPurchaseInvV.DGVProducts.DataSource = null;
                    this.newPurchaseInvV.DGVProducts.DataSource = productsList;
                    this.newPurchaseInvV.DGVProducts.ClearSelection();
                }
            }
            else
            {
                await this.LoadProductsAsync(0); 
                this.RestAll();
                this.newPurchaseInvV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
        }
        private void OnSelectInvItem()
        {
            InvoiceItemM purInvItem = this.newPurchaseInvV.DGVInvItems.SelectedRows[0].DataBoundItem as InvoiceItemM;
            this.newPurchaseInvV.InvItemQuantity = purInvItem.Quantity.ToString();
            this.newPurchaseInvV.Cost = purInvItem.Price.ToString();
            this.newPurchaseInvV.ExpireDate.Value = DateTime.Parse(purInvItem.ExpireDate);
            this.newPurchaseInvV.AEButtonText = "Update";
        }
        private async Task OnCategoryFilterChangeAsync()
        {
           await this.LoadProductsAsync(((ProdCategoryM)this.newPurchaseInvV.CBXPCategoryFilter.SelectedItem).Id);
        }
        private void RestAll()
        {
            this.newPurchaseInvV.CBXMonyState.SelectedIndex = 0;
            this.newPurchaseInvV.InvSuppName = null;
            this.RestItemFields();
            this.newPurchaseInvV.DGVInvItems.DataSource = null;
            this.InvItems.Clear();
        }
        private void RestItemFields()
        {
            
            this.newPurchaseInvV.InvItemQuantity = "1";
            this.newPurchaseInvV.Cost = null;
            this.newPurchaseInvV.PSearvhField = null;
            this.newPurchaseInvV.CBXPCategoryFilter.SelectedIndex = 0;
            this.newPurchaseInvV.DGVProducts.ClearSelection();
            this.newPurchaseInvV.DGVInvItems.ClearSelection();
            
        }
        private void OnClose()
        {
            
        }
    }
}
