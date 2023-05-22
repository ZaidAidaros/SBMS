using SBMS.Views.Purchases;

namespace SBMS.Presenters.PurchasesPres
{
    class PurchasesHVPres
    {
        IPurchasesHV PurchaseHv;
        private static PurchasesHVPres instance;
        public static PurchasesHVPres GetInstance()
        {
            if (instance == null) instance = new PurchasesHVPres();
            return instance;
        }
        public int EmpId { get; set; }
        private PurchasesHVPres()
        {
            this.PurchaseHv = PurchaseHomeV.GetInstance();
            this.EmpId = 1;
            ShowPurchasesView();
            this.PurchaseHv.ShowPurchasesView += delegate { ShowPurchasesView(); };
            this.PurchaseHv.ShowNewPurchaseView += delegate { ShowNewPurchaseView(); };
            this.PurchaseHv.ShowNewRePurchaseView += delegate { ShowRetPurchasesView(); };
        }
        private void ShowPurchasesView()
        {
            PurchaseInvoicesVPres.GetInstance();
            PurchaseInvoicesV.GetInstance().Dock = System.Windows.Forms.DockStyle.Fill;
            PurchaseInvoicesV.GetInstance().IsInvItemsVisable = false;
            PurchaseInvoicesV.GetInstance().Show();
            this.PurchaseHv.HeaderTitle = "Purchases";
        }
        private void ShowNewPurchaseView()
        {
            NewRetPurchaseInvVPres.Dispose();
            NewPurchaseInvVPres.GetInstance();
            NewPurchaseInvV.GetInstance().Dock = System.Windows.Forms.DockStyle.Fill;
            NewPurchaseInvV.GetInstance().Show();
            this.PurchaseHv.HeaderTitle = "New Purchases";
        }
        private void ShowRetPurchasesView()
        {
            NewPurchaseInvVPres.Dispose();
            NewRetPurchaseInvVPres.GetInstance();
            NewRetPurchaseInvV.GetInstance().Dock = System.Windows.Forms.DockStyle.Fill;
            NewRetPurchaseInvV.GetInstance().Show();
            this.PurchaseHv.HeaderTitle = "Return Purchases";
        }
        

    }
}
