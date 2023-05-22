using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS.Views.Purchases
{
    interface IPurchasesHV
    {
        string HeaderTitle { get; set; }
        string UserName { get; set; }
        string StuffName { get; set; }
        // View Header
        event EventHandler ShowNewPurchaseView;
        event EventHandler ShowNewRePurchaseView;
        event EventHandler ShowPurchasesView;
        event EventHandler OnClose;
    }
}
