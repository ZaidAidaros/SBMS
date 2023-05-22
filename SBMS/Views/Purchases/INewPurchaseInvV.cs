using System;
using System.Windows.Forms;

namespace SBMS.Views.Purchases
{
    interface INewPurchaseInvV
    {
        string InvSuppName { get; set; }
        string AEButtonText { get; set; }
        string PSearvhField { get; set; }
        string InvItemQuantity { get; set; }
        string Cost { get; set; }
        string InvTotlPrice { get; set; }
        string InvNote { get; set; }
        DateTimePicker ExpireDate { get; }
        ComboBox CBXSuppliers { get; }
        ComboBox CBXMonyState { get; }
        ComboBox CBXPCategoryFilter { get; }
        DataGridView DGVProducts { get;  }
        DataGridView DGVInvItems { get;  }

        event EventHandler OnClose;
        event EventHandler OnInvSave;
        event EventHandler OnInvCancel;
        event EventHandler OnAEInvItem;
        event EventHandler OnInvItemIncOne;
        event EventHandler OnInvItemDecOne;
        event EventHandler OnInvItemRemove;
        event EventHandler OnPSearchBClicked;


        bool ShowMsgBox(string msg, string title, bool isYesNo);


    }
}
