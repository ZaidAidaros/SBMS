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
        public static void Dispose()
        {
            instance = null;
        }
        private SaleInvoicesVPres()
        {
            saleInvoicesV = SaleInvoicesV.GetInstance();
            OnInitAsync();
        }
        private async Task OnInitAsync()
        {
            LoadInvoiceTypesAsync();
            await LoadInvoicesAsync(null);
            saleInvoicesV.DGVInvoices.ClearSelection();
            saleInvoicesV.DGVInvItems.ClearSelection();
            saleInvoicesV.OnInvSearchBClicked += async delegate { await OnSearchAsync(); };
            saleInvoicesV.CBXInvFilter.SelectedIndexChanged += async delegate { await OnFilterAsync(); };
            saleInvoicesV.DGVInvoices.SelectionChanged += async delegate { await OnSelectInvAsync(); };
            saleInvoicesV.OnDisposed += delegate { Dispose(); };
            
            
        }
        private async Task OnSelectInvAsync()
        {
            if ( saleInvoicesV.DGVInvoices.SelectedRows.Count == 1)
            {
                selectedSaleInvM = (InvoiceM) saleInvoicesV.DGVInvoices.SelectedRows[0].DataBoundItem;
                await LoadInvoiceItemsAsync(selectedSaleInvM.Id);
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
                saleInvoicesV.DGVInvoices.DataSource = null;
                List<InvoiceM> Invoices = new List<InvoiceM>();
                for (int i = 0; i < res.ResData.Count; i++)
                {

                    Invoices.Add((InvoiceM)res.ResData[i]);
                }
                if (Invoices.Count > 0)
                {
                    saleInvoicesV.DGVInvoices.DataSource = Invoices;
                }

            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    saleInvoicesV.ShowMsgBox("The Invoices List Is Empty", "Note:", false);
                    return;
                }
                saleInvoicesV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
        }
        private async Task LoadInvoiceItemsAsync(int invId)
        {
            RepoResultM res = await SalesItemsRepo.GetSaleItemsAsync(invId);

            if (res.IsSucess)
            {

                saleInvoicesV.DGVInvItems.DataSource = null;
                List<InvoiceItemM> InvItems = new List<InvoiceItemM>();
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    InvItems.Add((InvoiceItemM)res.ResData[i]);
                }
                if (InvItems.Count > 0)
                {
                    saleInvoicesV.DGVInvItems.DataSource = InvItems;
                    saleInvoicesV.IsInvItemsVisable = true;
                }

            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    saleInvoicesV.IsInvItemsVisable = false;
                    saleInvoicesV.ShowMsgBox("The Invoice Items List Is Empty", "Note:", false);
                    return;
                }
                saleInvoicesV.ShowMsgBox(res.ErrorMsg, "Error:", false);
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
            saleInvoicesV.CBXInvFilter.ValueMember = "Id";
            saleInvoicesV.CBXInvFilter.DisplayMember = "Name";
            saleInvoicesV.CBXInvFilter.Items.Add((InvoiceTypeM)invoiceTypeM);
            saleInvoicesV.CBXInvFilter.Items.Add((InvoiceTypeM)invoiceTypeM1);
            saleInvoicesV.CBXInvFilter.Items.Add((InvoiceTypeM)invoiceTypeM2);
            saleInvoicesV.CBXInvFilter.SelectedIndex = 0;
        }
        private async Task OnSearchAsync()
        {
            await LoadInvoicesAsync(saleInvoicesV.InvSearchField);
        }
        private async Task OnFilterAsync()
        {
            if (saleInvoicesV.CBXInvFilter.SelectedIndex == 0)
            {
                await LoadInvoicesAsync(null);
            }
            else
            {
                await LoadInvoicesAsync(((InvoiceTypeM)this.saleInvoicesV.CBXInvFilter.SelectedItem).Id.ToString());
            }

        }
        private async Task RestAllAsync()
        {
            saleInvoicesV.CBXInvFilter.SelectedIndex = 0;
            saleInvoicesV.InvSearchField = null;
            saleInvoicesV.IsInvItemsVisable = false;
            await LoadInvoicesAsync(null);
        }
    }
}
