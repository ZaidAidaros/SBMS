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
        public static void Dispose()
        {
            instance = null;
        }
        private SalesHVPres(UserM userM)
        {
            user = userM; 
            salesHomeV = SalesHomeV.GetInstance();
            salesHomeV.HeaderTitle = "Sales";
            salesHomeV.UserName = user.Name;
            salesHomeV.StuffName = user.Employee;
            ShowSalesView();
            salesHomeV.ShowSalesView += delegate { ShowSalesView(); };
            salesHomeV.ShowNewSalesInvView += delegate { ShowNewSalesInvView(); };
            salesHomeV.ShowNewRetSalesInvView += delegate { ShowNewRetSalesInvView(); };
            salesHomeV.OnClose += delegate { Dispose(); };
            salesHomeV.OnDisposed += delegate { Dispose(); };
        }

        

        private void ShowSalesView()
        {
            
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
