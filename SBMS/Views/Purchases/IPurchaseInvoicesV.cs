using System;
using System.Windows.Forms;

namespace SBMS.Views.Purchases
{
    interface IPurchaseInvoicesV
    {
        string InvSearchField { get; set; }
        bool IsInvItemsVisable { get; set; }
        ComboBox CBXInvFilter { get; }
        DataGridView DGVInvoices { get; }
        DataGridView DGVInvItems { get; }


        event EventHandler OnInvSearchBClicked;
        event EventHandler OnDisposed;


        bool ShowMsgBox(string msg, string title, bool isYesNo);
    }
}
