using SBMS.Models.General;
using SBMS.Models.General;
using SBMS.Repositories;
using SBMS.Repositories.SalesRepo;
using SBMS.Views.Sales;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SBMS.Presenters.SalesPres
{
    class SaleInvoicesVPres
    {
        ISaleInvoicesV saleInvoicesV;
        InvoiceM selectedSaleInvM;

        private static SaleInvoicesVPres instance;
        public static SaleInvoicesVPres GetInstance()
        {
            if (instance == null) instance = new SaleInvoicesVPres();
            return instance;
        }
        private SaleInvoicesVPres()
        {
            this.saleInvoicesV = SaleInvoicesV.GetInstance();
            OnInitAsync();
        }
        private async Task OnInitAsync()
        {
            this.LoadInvoiceTypesAsync();
            await this.LoadInvoicesAsync(null);

            this.saleInvoicesV.OnInvSearchBClicked += async delegate { await OnSearchAsync(); };
            this.saleInvoicesV.CBXInvFilter.SelectedIndexChanged += async delegate { await this.OnFilterAsync(); };
            this.saleInvoicesV.DGVInvoices.SelectionChanged += async delegate { await this.OnSelectInvAsync(); };
        }
        private async Task OnSelectInvAsync()
        {
            if (this.saleInvoicesV.DGVInvoices.SelectedRows.Count == 1)
            {
                selectedSaleInvM = (InvoiceM)this.saleInvoicesV.DGVInvoices.SelectedRows[0].DataBoundItem;
                await this.LoadInvoiceItemsAsync(selectedSaleInvM.Id);
            }

        }
        private async Task LoadInvoicesAsync(string searchValue)
        {
            RepoResultM res;
            if (searchValue == null)
            {
                res = await SalesRepo.GetSaleInvoicesAsync();
            }
            else
            {
                res = await SalesRepo.SearchSaleInvAsync(searchValue);
            }
            if (res.IsSucess)
            {
                this.saleInvoicesV.DGVInvoices.DataSource = null;
                List<InvoiceM> Invoices = new List<InvoiceM>();
                for (int i = 0; i < res.ResData.Count; i++)
                {

                    Invoices.Add((InvoiceM)res.ResData[i]);
                }
                if (Invoices.Count > 0)
                {
                    this.saleInvoicesV.DGVInvoices.DataSource = Invoices;
                }

            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    this.saleInvoicesV.ShowMsgBox("The Invoices List Is Empty", "Note:", false);
                    return;
                }
                this.saleInvoicesV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
        }
        private async Task LoadInvoiceItemsAsync(int invId)
        {
            RepoResultM res = await SalesItemsRepo.GetSaleItemsAsync(invId);

            if (res.IsSucess)
            {

                this.saleInvoicesV.DGVInvItems.DataSource = null;
                List<InvoiceItemM> InvItems = new List<InvoiceItemM>();
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    InvItems.Add((InvoiceItemM)res.ResData[i]);
                }
                if (InvItems.Count > 0)
                {
                    this.saleInvoicesV.DGVInvItems.DataSource = InvItems;
                    this.saleInvoicesV.IsInvItemsVisable = true;
                }

            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    this.saleInvoicesV.IsInvItemsVisable = false;
                    this.saleInvoicesV.ShowMsgBox("The Invoice Items List Is Empty", "Note:", false);
                    return;
                }
                this.saleInvoicesV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
        }
        private void LoadInvoiceTypesAsync()
        {
            InvoiceTypeM invoiceTypeM = new InvoiceTypeM();
            invoiceTypeM.Id = 0;
            invoiceTypeM.Name = "All Invoice";
            InvoiceTypeM invoiceTypeM1 = new InvoiceTypeM();
            invoiceTypeM1.Id = 1;
            invoiceTypeM1.Name = "Normal Invoice";
            InvoiceTypeM invoiceTypeM2 = new InvoiceTypeM();
            invoiceTypeM2.Id = 2;
            invoiceTypeM2.Name = "Return Invoice";
            this.saleInvoicesV.CBXInvFilter.ValueMember = "Id";
            this.saleInvoicesV.CBXInvFilter.DisplayMember = "Name";
            this.saleInvoicesV.CBXInvFilter.Items.Add((InvoiceTypeM)invoiceTypeM);
            this.saleInvoicesV.CBXInvFilter.Items.Add((InvoiceTypeM)invoiceTypeM1);
            this.saleInvoicesV.CBXInvFilter.Items.Add((InvoiceTypeM)invoiceTypeM2);
            this.saleInvoicesV.CBXInvFilter.SelectedIndex = 0;
        }
        private async Task OnSearchAsync()
        {
            await LoadInvoicesAsync(this.saleInvoicesV.InvSearchField);
        }
        private async Task OnFilterAsync()
        {
            if (this.saleInvoicesV.CBXInvFilter.SelectedIndex == 0)
            {
                await LoadInvoicesAsync(null);
            }
            else
            {
                await LoadInvoicesAsync(((InvoiceTypeM)this.saleInvoicesV.CBXInvFilter.SelectedItem).Id.ToString());
            }

        }
        private void RestAll()
        {
            this.saleInvoicesV.CBXInvFilter.SelectedIndex = 0;
            this.saleInvoicesV.InvSearchField = null;
            this.saleInvoicesV.IsInvItemsVisable = false;
            this.LoadInvoicesAsync(null);
        }
    }
}
