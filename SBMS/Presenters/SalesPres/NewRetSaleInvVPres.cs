using SBMS.Models.Customers;
using SBMS.Models.General;
using SBMS.Models.Stores;
using SBMS.Repositories;
using SBMS.Repositories.CustomersRepo;
using SBMS.Repositories.SalesRepo;
using SBMS.Repositories.StoresRepo;
using SBMS.Views.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS.Presenters.SalesPres
{
    class NewRetSaleInvVPres
    {
        INewSaleInvoiceV newSaleInvoiceV;
        CustomerM selectedCustomer;
        ProductM selectedProduct;
        InvoiceItemM selectedInvoiceItem;
        private List<InvoiceItemM> InvItems = new List<InvoiceItemM>();

        private static NewRetSaleInvVPres instance;
        public static NewRetSaleInvVPres GetInstance()
        {
            if (instance == null) instance = new NewRetSaleInvVPres();
            return instance;
        }
        public static void Dispose()
        {
            instance = null;
        }
        private NewRetSaleInvVPres()
        {
            this.newSaleInvoiceV = NewRetSaleInvoiceV.GetInstance();
            this.OnInitAsync();
        }
        private async Task OnInitAsync()
        {
            await this.LoadProductsAsync(0);
            await this.LoadCustomersAsync();
            await this.LoadProdCategoiesAsync();
            await this.LoadOffersAsync();
            this.LoadMonyStates();
            this.newSaleInvoiceV.DGVProducts.ClearSelection();
            this.newSaleInvoiceV.DGVInvItems.ClearSelection();
            this.newSaleInvoiceV.OnInvSave += async delegate { await OnSaveInvAsync(); };
            this.newSaleInvoiceV.OnInvCancel += delegate { OnInCancel(); };
            this.newSaleInvoiceV.OnInvItemIncOne += delegate { OnInvItemIncOne(); };
            this.newSaleInvoiceV.OnInvItemDecOne += delegate { OnInvItemDecOne(); };
            this.newSaleInvoiceV.OnAEInvItem += delegate { OnAEInvItem(); };
            this.newSaleInvoiceV.OnInvItemRemove += delegate { OnRemoveInvItem(); };
            this.newSaleInvoiceV.OnPSearchBClicked += async delegate { await OnPSearchBClickedAsync(); };
            this.newSaleInvoiceV.CBXPCategoryFilter.SelectedIndexChanged += async delegate { await OnCategoryFilterChangeAsync(); };
            this.newSaleInvoiceV.CBXCustomers.SelectedIndexChanged += delegate { OnSelectCustomer(); };
            this.newSaleInvoiceV.DGVInvItems.CellClick += delegate { OnSelectInvItem(); };
            this.newSaleInvoiceV.DGVProducts.SelectionChanged += delegate { OnSelectProduct(); };
            this.newSaleInvoiceV.OnClose += delegate { OnClose(); };

        }
        private void OnSelectProduct()
        {
            if (this.newSaleInvoiceV.DGVProducts.SelectedRows.Count == 1)
            {
                this.newSaleInvoiceV.AEButtonText = "Add";
                this.selectedProduct = (ProductM)this.newSaleInvoiceV.DGVProducts.SelectedRows[0].DataBoundItem;
                this.newSaleInvoiceV.PPrice = this.selectedProduct.DefPrice.ToString();
            }
        }
        private void OnSelectCustomer()
        {
            this.selectedCustomer = (CustomerM)this.newSaleInvoiceV.CBXCustomers.SelectedItem;
            newSaleInvoiceV.InvCustomerName = selectedCustomer.Name;
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

                this.newSaleInvoiceV.DGVProducts.DataSource = null;
                List<ProductM> ProductsList = new List<ProductM>();
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    ProductsList.Add((ProductM)res.ResData[i]);
                }
                if (ProductsList.Count > 0)
                {
                    this.newSaleInvoiceV.DGVProducts.DataSource = ProductsList;
                    this.newSaleInvoiceV.DGVProducts.ClearSelection();
                }

            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    this.newSaleInvoiceV.ShowMsgBox("The Products List Is Empty", "Note:", false);
                    return;
                }
                this.newSaleInvoiceV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
        }
        private async Task LoadCustomersAsync()
        {
            RepoResultM res = await CustomersRepo.GetCustomersAsync();
            if (res.IsSucess)
            {
                this.newSaleInvoiceV.CBXCustomers.Items.Clear();
                this.newSaleInvoiceV.CBXCustomers.DisplayMember = "Name";
                this.newSaleInvoiceV.CBXCustomers.ValueMember = "Id";
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    this.newSaleInvoiceV.CBXCustomers.Items.Add((CustomerM)res.ResData[i]);
                }

            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    this.newSaleInvoiceV.ShowMsgBox("The Supplier List Is Empty", "Note:", false);
                    return;
                }
                this.newSaleInvoiceV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
        }
        private async Task LoadProdCategoiesAsync()
        {
            RepoResultM res = await ProdCategoriesRepo.GetProdCategoriesAsync();
            if (res.IsSucess)
            {
                this.newSaleInvoiceV.CBXPCategoryFilter.Items.Clear();
                this.newSaleInvoiceV.CBXPCategoryFilter.DisplayMember = "Name";
                this.newSaleInvoiceV.CBXPCategoryFilter.ValueMember = "Id";
                ProdCategoryM prodCategoryM = new ProdCategoryM();
                prodCategoryM.Id = 0;
                prodCategoryM.Name = "All";
                this.newSaleInvoiceV.CBXPCategoryFilter.Items.Add(prodCategoryM);
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    this.newSaleInvoiceV.CBXPCategoryFilter.Items.Add((ProdCategoryM)res.ResData[i]);
                }
                this.newSaleInvoiceV.CBXPCategoryFilter.SelectedIndex = 0;

            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    this.newSaleInvoiceV.ShowMsgBox("The Product Categories List Is Empty", "Note:", false);
                    return;
                }
                this.newSaleInvoiceV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
        }
        private async Task LoadOffersAsync()
        {
            MonyStateM monyState1 = new MonyStateM();
            this.newSaleInvoiceV.CBXMonyState.Items.Clear();
            this.newSaleInvoiceV.CBXMonyState.DisplayMember = "Name";
            this.newSaleInvoiceV.CBXMonyState.ValueMember = "Id";
            monyState1.Id = 1;
            monyState1.Name = "No Offer";
            this.newSaleInvoiceV.CBXMonyState.Items.Add(monyState1);
            //RepoResultM res = await ProdCategoriesRepo.GetProdCategoriesAsync();
            //if (res.IsSucess)
            //{
            //    this.newSaleInvoiceV.CBXPCategoryFilter.Items.Clear();
            //    this.newSaleInvoiceV.CBXPCategoryFilter.DisplayMember = "Name";
            //    this.newSaleInvoiceV.CBXPCategoryFilter.ValueMember = "Id";
            //    ProdCategoryM prodCategoryM = new ProdCategoryM();
            //    prodCategoryM.Id = 0;
            //    prodCategoryM.Name = "All";
            //    this.newSaleInvoiceV.CBXPCategoryFilter.Items.Add(prodCategoryM);
            //    for (int i = 0; i < res.ResData.Count; i++)
            //    {
            //        this.newSaleInvoiceV.CBXPCategoryFilter.Items.Add((ProdCategoryM)res.ResData[i]);
            //    }
            //    this.newSaleInvoiceV.CBXPCategoryFilter.SelectedIndex = 0;

            //}
            //else
            //{
            //    if (res.ErrorMsg == "No Result")
            //    {
            //        this.newSaleInvoiceV.ShowMsgBox("The Product Categories List Is Empty", "Note:", false);
            //        return;
            //    }
            //    this.newSaleInvoiceV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            //}
        }
        private void LoadMonyStates()
        {
            MonyStateM monyState1 = new MonyStateM();
            MonyStateM monyState2 = new MonyStateM();
            MonyStateM monyState3 = new MonyStateM();

            this.newSaleInvoiceV.CBXMonyState.Items.Clear();
            this.newSaleInvoiceV.CBXMonyState.DisplayMember = "Name";
            this.newSaleInvoiceV.CBXMonyState.ValueMember = "Id";
            monyState1.Id = 1;
            monyState1.Name = "Cash";
            this.newSaleInvoiceV.CBXMonyState.Items.Add(monyState1);
            monyState2.Id = 2;
            monyState2.Name = "Later";
            this.newSaleInvoiceV.CBXMonyState.Items.Add(monyState2);
            monyState3.Id = 3;
            monyState3.Name = "Pay";
            this.newSaleInvoiceV.CBXMonyState.Items.Add(monyState3);
            this.newSaleInvoiceV.CBXMonyState.SelectedIndex = 0;


        }
        private async Task OnSaveInvAsync()
        {
            if (this.InvItems.Count > 0)
            {
                if (((CustomerM)this.newSaleInvoiceV.CBXCustomers.SelectedItem) == null)
                {
                    this.newSaleInvoiceV.ShowMsgBox("Select Supplier", "Note:", false);
                }
                else if (string.IsNullOrEmpty(this.newSaleInvoiceV.InvCustomerName))
                {
                    this.newSaleInvoiceV.ShowMsgBox("Enter Supplier Name", "Note:", false);
                }
                else
                {
                    InvoiceM invoiceM = new InvoiceM();
                    invoiceM.EmpId = SalesHVPres.GetInstance().EmpId;
                    invoiceM.CustomerId = ((CustomerM)this.newSaleInvoiceV.CBXCustomers.SelectedItem).Id;
                    invoiceM.MonyStateId = ((MonyStateM)this.newSaleInvoiceV.CBXMonyState.SelectedItem).Id;
                    invoiceM.InvoiceTypeId = 2;
                    invoiceM.Note = this.newSaleInvoiceV.InvNote;
                    invoiceM.NameOnInvoice = this.newSaleInvoiceV.InvCustomerName;
                    invoiceM.Date = DateTime.Now;
                    invoiceM.Total = GetInvTotalPrice();
                    RepoResultM res = await SalesRepo.AddSaleInvAsync(invoiceM);
                    if (res.IsSucess)
                    {
                        for (int i = 0; i < this.InvItems.Count; i++)
                        {
                            this.InvItems[i].InvoiceId = res.ReturnNewRowId;
                            RepoResultM itemRes = await SalesItemsRepo.AddSaleItemAsync(this.InvItems[i], 1);
                            if (!itemRes.IsSucess) this.newSaleInvoiceV.ShowMsgBox(itemRes.ErrorMsg + "\n" + res.ResData[0], "Error:", false);

                        }
                        this.RestAll();
                        this.newSaleInvoiceV.ShowMsgBox("The Invoice Saved Successfuly", "Success:", false);
                    }
                    else
                    {
                        this.newSaleInvoiceV.ShowMsgBox(res.ErrorMsg, "Error:", false);
                    }
                }
            }
            else
            {
                this.newSaleInvoiceV.ShowMsgBox("Invoice has No Items\nAdd Some Items First", "Error:", false);
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
            this.newSaleInvoiceV.InvItemQuantity = (decimal.Parse(this.newSaleInvoiceV.InvItemQuantity) + 1).ToString();
        }
        private void OnInvItemDecOne()
        {
            if (decimal.Parse(this.newSaleInvoiceV.InvItemQuantity) > 0)
                this.newSaleInvoiceV.InvItemQuantity = (decimal.Parse(this.newSaleInvoiceV.InvItemQuantity) - 1).ToString();
        }
        private void OnAEInvItem()
        {
            if (this.newSaleInvoiceV.DGVProducts.SelectedRows.Count == 1 && ValidateFields() && this.newSaleInvoiceV.AEButtonText == "Add")
            {
                this.AddInvItem();
            }
            else if (this.newSaleInvoiceV.DGVInvItems.SelectedRows.Count == 1 && ValidateFields())
            {
                this.EditInvItem();
            }
            else
            {
                this.newSaleInvoiceV.ShowMsgBox("Select Product", "Note:", false);
                return;
            }
            this.RestItemFields();
            this.newSaleInvoiceV.DGVInvItems.DataSource = null;
            this.newSaleInvoiceV.DGVInvItems.DataSource = this.InvItems;
            this.newSaleInvoiceV.InvTotlPrice = GetInvTotalPrice().ToString();

        }
        private bool ValidateFields()
        {
            if (string.IsNullOrEmpty(this.newSaleInvoiceV.PPrice))
            {
                this.newSaleInvoiceV.ShowMsgBox("Enter Product Cost ", "Note:", false);
            }
            else if (string.IsNullOrEmpty(this.newSaleInvoiceV.InvItemQuantity))
            {
                this.newSaleInvoiceV.ShowMsgBox("Enter Product Quantity ", "Note:", false);
            }
            else
            {
                return true;
            }
            return false;
        }
        private void AddInvItem()
        {

            InvoiceItemM invoiceItemM = new InvoiceItemM();

            invoiceItemM.ProductId = this.selectedProduct.Id;
            invoiceItemM.ProductDId = this.selectedProduct.DId;
            invoiceItemM.Name = this.selectedProduct.Name;
            invoiceItemM.Unit = this.selectedProduct.Unit;
            invoiceItemM.Price = decimal.Parse(this.newSaleInvoiceV.PPrice);
            invoiceItemM.Quantity = decimal.Parse(this.newSaleInvoiceV.InvItemQuantity);
            invoiceItemM.ExpireDate = this.newSaleInvoiceV.ExpireDate.Value.ToShortDateString();
            invoiceItemM.OfferId = 1;

            for (int i = 0; i < this.InvItems.Count; i++)
            {
                if (this.InvItems[i].IsEqualTo(invoiceItemM))
                {
                    if (this.newSaleInvoiceV.ShowMsgBox("This Product is Alredy Exist\nDo You Want To Update It", "Note:", true))
                    {
                        this.InvItems[i] = invoiceItemM;

                    }
                    else
                    {
                        return;
                    }
                    return;
                }
            }

            this.InvItems.Add(invoiceItemM);

        }
        private void EditInvItem()
        {
            InvoiceItemM invoiceItemM = this.selectedInvoiceItem;
            invoiceItemM.Price = decimal.Parse(this.newSaleInvoiceV.PPrice);
            invoiceItemM.Quantity = decimal.Parse(this.newSaleInvoiceV.InvItemQuantity);
            invoiceItemM.ExpireDate = this.newSaleInvoiceV.ExpireDate.Value.ToShortDateString();

            for (int i = 0; i < this.InvItems.Count; i++)
            {
                if (this.InvItems[i].IsEqualTo(invoiceItemM))
                {
                    this.InvItems[i] = invoiceItemM;
                }
            }
        }
        private void OnRemoveInvItem()
        {
            if (this.newSaleInvoiceV.DGVInvItems.SelectedRows.Count > 0)
            {
                this.InvItems.Remove((InvoiceItemM)this.newSaleInvoiceV.DGVInvItems.SelectedRows[0].DataBoundItem);
                this.newSaleInvoiceV.DGVInvItems.DataSource = null;
                this.newSaleInvoiceV.DGVInvItems.DataSource = this.InvItems;
            }

        }
        private async Task OnPSearchBClickedAsync()
        {
            if (string.IsNullOrWhiteSpace(this.newSaleInvoiceV.PSearvhField) || string.IsNullOrEmpty(this.newSaleInvoiceV.PSearvhField)) return;
            RepoResultM res = await ProductsRepo.SearchProductAsync(this.newSaleInvoiceV.PSearvhField);
            if (res.IsSucess)
            {
                List<ProductM> productsList = new List<ProductM>();
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    productsList.Add((ProductM)res.ResData[i]);
                }
                if (productsList.Count > 0)
                {
                    this.newSaleInvoiceV.DGVProducts.DataSource = null;
                    this.newSaleInvoiceV.DGVProducts.DataSource = productsList;
                    this.newSaleInvoiceV.DGVProducts.ClearSelection();
                }
            }
            else
            {
                await this.LoadProductsAsync(0);
                this.RestAll();
                this.newSaleInvoiceV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
        }
        private void OnSelectInvItem()
        {
            if (this.newSaleInvoiceV.DGVInvItems.SelectedRows.Count == 1)
            {
                this.selectedInvoiceItem = (InvoiceItemM)this.newSaleInvoiceV.DGVInvItems.SelectedRows[0].DataBoundItem;
                this.newSaleInvoiceV.InvItemQuantity = this.selectedInvoiceItem.Quantity.ToString();
                this.newSaleInvoiceV.PPrice = this.selectedInvoiceItem.Price.ToString();
                this.newSaleInvoiceV.ExpireDate.Value = DateTime.Parse(this.selectedInvoiceItem.ExpireDate);
                this.newSaleInvoiceV.AEButtonText = "Update";
            }
        }
        private async Task OnCategoryFilterChangeAsync()
        {
            await this.LoadProductsAsync(((ProdCategoryM)this.newSaleInvoiceV.CBXPCategoryFilter.SelectedItem).Id);
        }
        private void RestAll()
        {
            this.newSaleInvoiceV.CBXMonyState.SelectedIndex = 0;
            this.newSaleInvoiceV.InvCustomerName = null;
            this.RestItemFields();
            this.newSaleInvoiceV.DGVInvItems.DataSource = null;
            this.InvItems.Clear();
        }
        private void RestItemFields()
        {

            this.newSaleInvoiceV.InvItemQuantity = "1";
            this.newSaleInvoiceV.PPrice = null;
            this.newSaleInvoiceV.PSearvhField = null;
            this.selectedCustomer = null;
            this.selectedProduct = null;
            this.selectedInvoiceItem = null;
            this.newSaleInvoiceV.CBXPCategoryFilter.SelectedIndex = 0;
            this.newSaleInvoiceV.DGVProducts.ClearSelection();
            this.newSaleInvoiceV.DGVInvItems.ClearSelection();

        }
        private void OnClose()
        {

        }
    }
}
