using SBMS.Models.General;
using SBMS.Models.General;
using SBMS.Models.Stores;
using SBMS.Repositories;
using SBMS.Repositories.PurchasesRepo;
using SBMS.Views.Purchases;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SBMS.Presenters.PurchasesPres
{
    class PurchaseInvoicesVPres
    {
        IPurchaseInvoicesV purchaseInvoicesV;
        

        private static PurchaseInvoicesVPres instance;
        public static PurchaseInvoicesVPres GetInstance()
        {
            if (instance == null) instance = new PurchaseInvoicesVPres();
            return instance;
        }
        public static void Dispose()
        {
            instance = null;
        }
        private PurchaseInvoicesVPres()
        {
            purchaseInvoicesV = PurchaseInvoicesV.GetInstance();
            OnInitAsync();
        }
        private async Task OnInitAsync()
        {
            LoadInvoiceTypesAsync();
            await LoadInvoicesAsync(null);
            purchaseInvoicesV.DGVInvoices.ClearSelection();
            purchaseInvoicesV.OnInvSearchBClicked += async delegate { await OnSearchAsync(); };
            purchaseInvoicesV.CBXInvFilter.SelectedIndexChanged += async delegate { await this.OnFilterAsync(); };
            purchaseInvoicesV.DGVInvoices.SelectionChanged += async delegate { await this.OnSelectInvAsync(); };
            purchaseInvoicesV.OnDisposed += delegate { Dispose(); };

        }
        private async Task OnSelectInvAsync()
        {
            InvoiceM purchaseInvM = GetSelectedInvoice();
            if (purchaseInvM == null) return;
            await LoadInvoiceItemsAsync(purchaseInvM.Id);
            
        }
        private InvoiceM GetSelectedInvoice()
        {
            if (purchaseInvoicesV.DGVInvoices.SelectedRows.Count == 1) return purchaseInvoicesV.DGVInvoices.SelectedRows[0].DataBoundItem as InvoiceM;
            return null;
        }
        private async Task LoadInvoicesAsync(string searchValue)
        {
            RepoResultM res;
            if (searchValue == null)
            {
                res = await PurchasesRepo.GetPurchasInvoicesAsync();
            }
            else
            {
                res = await PurchasesRepo.SearchPurchaseInvAsync(searchValue);
            }
            if (res.IsSucess)
            {
                purchaseInvoicesV.DGVInvoices.DataSource = null;
                List<InvoiceM> Invoices = new List<InvoiceM>();
                for (int i = 0; i < res.ResData.Count; i++)
                {

                    Invoices.Add((InvoiceM)res.ResData[i]);
                }
                if (Invoices.Count > 0)
                {
                    purchaseInvoicesV.DGVInvoices.DataSource = Invoices;
                }

            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    purchaseInvoicesV.ShowMsgBox("The Invoices List Is Empty", "Note:", false);
                    return;
                }
                purchaseInvoicesV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
        }
        private async Task LoadInvoiceItemsAsync(int invId)
        {
            RepoResultM res = await PurchasesItemsRepo.GetPurchaseItemsAsync(invId);
            
            if (res.IsSucess)
            {

                purchaseInvoicesV.DGVInvItems.DataSource = null;
                List<InvoiceItemM> InvItems = new List<InvoiceItemM>();
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    InvItems.Add((InvoiceItemM)res.ResData[i]);
                }
                if (InvItems.Count > 0)
                {
                    purchaseInvoicesV.DGVInvItems.DataSource = InvItems;
                    purchaseInvoicesV.IsInvItemsVisable = true;
                }

            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    purchaseInvoicesV.IsInvItemsVisable = false;
                    purchaseInvoicesV.ShowMsgBox("The Invoice Items List Is Empty", "Note:", false);
                    return;
                }
                purchaseInvoicesV.ShowMsgBox(res.ErrorMsg, "Error:", false);
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
            purchaseInvoicesV.CBXInvFilter.ValueMember = "Id";
            purchaseInvoicesV.CBXInvFilter.DisplayMember = "Name";
            purchaseInvoicesV.CBXInvFilter.Items.Add((InvoiceTypeM)invoiceTypeM);
            purchaseInvoicesV.CBXInvFilter.Items.Add((InvoiceTypeM)invoiceTypeM1);
            purchaseInvoicesV.CBXInvFilter.Items.Add((InvoiceTypeM)invoiceTypeM2);
            purchaseInvoicesV.CBXInvFilter.SelectedIndex=0;
        }
        private async Task OnSearchAsync()
        {
            await LoadInvoicesAsync(purchaseInvoicesV.InvSearchField);
        }
        private async Task OnFilterAsync()
        {
            if (purchaseInvoicesV.CBXInvFilter.SelectedIndex == 0)
            {
                await LoadInvoicesAsync(null);
            }
            else
            {
                await LoadInvoicesAsync(((InvoiceTypeM)purchaseInvoicesV.CBXInvFilter.SelectedItem).Id.ToString());
            }
            
        }
        private async Task RestAllAsync()
        {
            purchaseInvoicesV.CBXInvFilter.SelectedIndex = 0;
            purchaseInvoicesV.InvSearchField = null;
            purchaseInvoicesV.IsInvItemsVisable = false;
            await LoadInvoicesAsync(null);
        }

        

    }
}
