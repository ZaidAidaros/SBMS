using SBMS.Presenters.PurchasesPres;
using SBMS.Views.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS.Presenters.SalesPres
{
    class SalesHVPres
    {
        ISalesHomeV salesHomeV;
        private static SalesHVPres instance;
        public static SalesHVPres GetInstance()
        {
            if (instance == null) instance = new SalesHVPres();
            return instance;
        }
        public int EmpId { get; set; }
        private SalesHVPres()
        {
            this.salesHomeV = SalesHomeV.GetInstance();
            this.EmpId = 1;
            ShowSalesView();
            this.salesHomeV.ShowSalesView += delegate { ShowSalesView(); };
            this.salesHomeV.ShowNewSalesInvView += delegate { ShowNewSalesInvView(); };
            this.salesHomeV.ShowNewRetSalesInvView += delegate { ShowNewRetSalesInvView(); };
        }
        private void ShowSalesView()
        {
            //SaleInvoicesVPres.GetInstance();
            SaleInvoicesV.GetInstance().Dock = System.Windows.Forms.DockStyle.Fill;
            //SaleInvoicesV.GetInstance().IsInvItemsVisable = false;
            SaleInvoicesV.GetInstance().Show();
            this.salesHomeV.HeaderTitle = "Purchases";
        }
        private void ShowNewSalesInvView()
        {
            NewRetSaleInvVPres.Dispose();
            NewSaleInvoiceVPres.GetInstance();
            NewSaleInvoiceV.GetInstance().Dock = System.Windows.Forms.DockStyle.Fill;
            this.salesHomeV.HeaderTitle = "New Purchases";
            NewSaleInvoiceV.GetInstance().Show();
        }
        private void ShowNewRetSalesInvView()
        {
            NewSaleInvoiceVPres.Dispose();
            NewRetPurchaseInvVPres.GetInstance();
            NewRetSaleInvoiceV.GetInstance().Dock = System.Windows.Forms.DockStyle.Fill;
            NewRetSaleInvoiceV.GetInstance().Show();
            this.salesHomeV.HeaderTitle = "Return Purchases";
        }
        
    }
}
