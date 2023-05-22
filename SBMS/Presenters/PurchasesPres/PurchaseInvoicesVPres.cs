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
        private PurchaseInvoicesVPres()
        {
            this.purchaseInvoicesV = PurchaseInvoicesV.GetInstance();
            OnInitAsync();
        }
        private async Task OnInitAsync()
        {
            this.LoadInvoiceTypesAsync();
            await this.LoadInvoicesAsync(null);
            
            this.purchaseInvoicesV.OnInvSearchBClicked += async delegate { await OnSearchAsync(); };
            this.purchaseInvoicesV.CBXInvFilter.SelectedIndexChanged += async delegate { await this.OnFilterAsync(); };
            this.purchaseInvoicesV.DGVInvoices.SelectionChanged += async delegate { await this.OnSelectInvAsync(); };
        }
        private async Task OnSelectInvAsync()
        {
            InvoiceM purchaseInvM = this.GetSelectedInvoice();
            if (purchaseInvM == null) return;
            await this.LoadInvoiceItemsAsync(purchaseInvM.Id);
            
        }
        private InvoiceM GetSelectedInvoice()
        {
            if (this.purchaseInvoicesV.DGVInvoices.SelectedRows.Count == 1) return this.purchaseInvoicesV.DGVInvoices.SelectedRows[0].DataBoundItem as InvoiceM;
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
                this.purchaseInvoicesV.DGVInvoices.DataSource = null;
                List<InvoiceM> Invoices = new List<InvoiceM>();
                for (int i = 0; i < res.ResData.Count; i++)
                {

                    Invoices.Add((InvoiceM)res.ResData[i]);
                }
                if (Invoices.Count > 0)
                {
                    this.purchaseInvoicesV.DGVInvoices.DataSource = Invoices;
                }

            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    this.purchaseInvoicesV.ShowMsgBox("The Invoices List Is Empty", "Note:", false);
                    return;
                }
                this.purchaseInvoicesV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
        }
        private async Task LoadInvoiceItemsAsync(int invId)
        {
            RepoResultM res = await PurchasesItemsRepo.GetPurchaseItemsAsync(invId);
            
            if (res.IsSucess)
            {

                this.purchaseInvoicesV.DGVInvItems.DataSource = null;
                List<InvoiceItemM> InvItems = new List<InvoiceItemM>();
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    InvItems.Add((InvoiceItemM)res.ResData[i]);
                }
                if (InvItems.Count > 0)
                {
                    this.purchaseInvoicesV.DGVInvItems.DataSource = InvItems;
                    this.purchaseInvoicesV.IsInvItemsVisable = true;
                }

            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    this.purchaseInvoicesV.IsInvItemsVisable = false;
                    this.purchaseInvoicesV.ShowMsgBox("The Invoice Items List Is Empty", "Note:", false);
                    return;
                }
                this.purchaseInvoicesV.ShowMsgBox(res.ErrorMsg, "Error:", false);
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
            this.purchaseInvoicesV.CBXInvFilter.ValueMember = "Id";
            this.purchaseInvoicesV.CBXInvFilter.DisplayMember = "Name";
            this.purchaseInvoicesV.CBXInvFilter.Items.Add((InvoiceTypeM)invoiceTypeM);
            this.purchaseInvoicesV.CBXInvFilter.Items.Add((InvoiceTypeM)invoiceTypeM1);
            this.purchaseInvoicesV.CBXInvFilter.Items.Add((InvoiceTypeM)invoiceTypeM2);
            this.purchaseInvoicesV.CBXInvFilter.SelectedIndex=0;
        }
        private async Task OnSearchAsync()
        {
            await LoadInvoicesAsync(this.purchaseInvoicesV.InvSearchField);
        }
        private async Task OnFilterAsync()
        {
            if (this.purchaseInvoicesV.CBXInvFilter.SelectedIndex == 0)
            {
                await LoadInvoicesAsync(null);
            }
            else
            {
                await LoadInvoicesAsync(((InvoiceTypeM)this.purchaseInvoicesV.CBXInvFilter.SelectedItem).Id.ToString());
            }
            
        }
        private void RestAll()
        {
            this.purchaseInvoicesV.CBXInvFilter.SelectedIndex = 0;
            this.purchaseInvoicesV.InvSearchField = null;
            this.purchaseInvoicesV.IsInvItemsVisable = false;
            this.LoadInvoicesAsync(null);
        }

    }
}
