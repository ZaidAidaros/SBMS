using SBMS.Models.Users;
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
        public UserM user;
        private static SalesHVPres instance;
        public static SalesHVPres GetInstance(UserM userM)
        {
            if (instance == null) instance = new SalesHVPres(userM);
            return instance;
        }
        private SalesHVPres(UserM userM)
        {
            if(userM != null) user = userM;

            this.salesHomeV = SalesHomeV.GetInstance();
            ShowSalesView();
            this.salesHomeV.ShowSalesView += delegate { ShowSalesView(); };
            this.salesHomeV.ShowNewSalesInvView += delegate { ShowNewSalesInvView(); };
            this.salesHomeV.ShowNewRetSalesInvView += delegate { ShowNewRetSalesInvView(); };
        }
        private void ShowSalesView()
        {
            this.salesHomeV.HeaderTitle = "Sales";
            this.salesHomeV.UserName = user.Name;
            this.salesHomeV.StuffName = user.Employee;
            SaleInvoicesVPres.GetInstance();
            SaleInvoicesV.GetInstance().Dock = System.Windows.Forms.DockStyle.Fill;
            SaleInvoicesV.GetInstance().IsInvItemsVisable = false;
            SaleInvoicesV.GetInstance().Show();
            

        }
        private void ShowNewSalesInvView()
        {
            NewRetSaleInvVPres.Dispose();
            NewSaleInvoiceVPres.GetInstance();
            NewSaleInvoiceV.GetInstance().Dock = System.Windows.Forms.DockStyle.Fill;
            this.salesHomeV.HeaderTitle = "New Sale Invoice";
            NewSaleInvoiceV.GetInstance().Show();
        }
        private void ShowNewRetSalesInvView()
        {
            NewSaleInvoiceVPres.Dispose();
            NewRetSaleInvVPres.GetInstance();
            NewRetSaleInvoiceV.GetInstance().Dock = System.Windows.Forms.DockStyle.Fill;
            NewRetSaleInvoiceV.GetInstance().Show();
            this.salesHomeV.HeaderTitle = "Return Sale Invoice";
        }
        
    }
}
