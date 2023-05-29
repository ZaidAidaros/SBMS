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
        public static void Dispose()
        {
            instance = null;
        }
        private PurchasesHVPres(UserM userM)
        {
            if (userM != null) user = userM;
            PurchaseHv = PurchaseHomeV.GetInstance();
            PurchaseHv.ShowPurchasesView += delegate { ShowPurchasesView(); };
            PurchaseHv.ShowNewPurchaseView += delegate { ShowNewPurchaseView(); };
            PurchaseHv.ShowNewRePurchaseView += delegate { ShowRetPurchasesView(); };
            PurchaseHv.OnClose += delegate { Dispose(); };
            PurchaseHv.OnDisposed += delegate { Dispose(); };

            ShowPurchasesView();
        }
        private void ShowPurchasesView()
        {
            PurchaseHv.HeaderTitle = "Purchases";
            PurchaseHv.UserName = user.Name;
            PurchaseHv.StuffName = user.Employee;
            PurchaseInvoicesVPres.GetInstance();
            PurchaseInvoicesV.GetInstance().Dock = System.Windows.Forms.DockStyle.Fill;
            PurchaseInvoicesV.GetInstance().IsInvItemsVisable = false;
            PurchaseInvoicesV.GetInstance().Show();
        }
        private void ShowNewPurchaseView()
        {

            PurchaseHv.HeaderTitle = "New Purchases";
            NewRetPurchaseInvVPres.Dispose();
            NewPurchaseInvVPres.GetInstance();
            NewPurchaseInvV.GetInstance().Dock = System.Windows.Forms.DockStyle.Fill;
            NewPurchaseInvV.GetInstance().Show();
        }
        private void ShowRetPurchasesView()
        {
            PurchaseHv.HeaderTitle = "Return Purchases";
            NewPurchaseInvVPres.Dispose();
            NewRetPurchaseInvVPres.GetInstance();
            NewRetPurchaseInvV.GetInstance().Dock = System.Windows.Forms.DockStyle.Fill;
            NewRetPurchaseInvV.GetInstance().Show();
        }
        

    }
}
