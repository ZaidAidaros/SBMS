using SBMS.Models.Users;
using SBMS.Views.Purchases;

namespace SBMS.Presenters.PurchasesPres
{
    class PurchasesHVPres
    {
        IPurchasesHV PurchaseHv;
        public UserM user;
        private static PurchasesHVPres instance;
        public static PurchasesHVPres GetInstance(UserM userM)
        {
            if (instance == null) instance = new PurchasesHVPres(userM);
            return instance;
        }
        private PurchasesHVPres(UserM userM)
        {
            if (userM != null) user = userM;
            this.PurchaseHv = PurchaseHomeV.GetInstance();
            PurchaseHomeV.GetInstance().Show();
            ShowPurchasesView();
            this.PurchaseHv.ShowPurchasesView += delegate { ShowPurchasesView(); };
            this.PurchaseHv.ShowNewPurchaseView += delegate { ShowNewPurchaseView(); };
            this.PurchaseHv.ShowNewRePurchaseView += delegate { ShowRetPurchasesView(); };
        }
        private void ShowPurchasesView()
        {
            this.PurchaseHv.HeaderTitle = "Purchases";
            this.PurchaseHv.UserName = user.Name;
            this.PurchaseHv.StuffName = user.Employee;
            PurchaseInvoicesVPres.GetInstance();
            PurchaseInvoicesV.GetInstance().Dock = System.Windows.Forms.DockStyle.Fill;
            PurchaseInvoicesV.GetInstance().IsInvItemsVisable = false;
            PurchaseInvoicesV.GetInstance().Show();
        }
        private void ShowNewPurchaseView()
        {

            this.PurchaseHv.HeaderTitle = "New Purchases";
            NewRetPurchaseInvVPres.Dispose();
            NewPurchaseInvVPres.GetInstance();
            NewPurchaseInvV.GetInstance().Dock = System.Windows.Forms.DockStyle.Fill;
            NewPurchaseInvV.GetInstance().Show();
        }
        private void ShowRetPurchasesView()
        {
            this.PurchaseHv.HeaderTitle = "Return Purchases";
            NewPurchaseInvVPres.Dispose();
            NewRetPurchaseInvVPres.GetInstance();
            NewRetPurchaseInvV.GetInstance().Dock = System.Windows.Forms.DockStyle.Fill;
            NewRetPurchaseInvV.GetInstance().Show();
        }
        

    }
}
