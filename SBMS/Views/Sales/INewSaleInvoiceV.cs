using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SBMS.Views.Sales
{
    interface INewSaleInvoiceV
    {
        string InvCustomerName { get; set; }
        string AEButtonText { get; set; }
        string PSearvhField { get; set; }
        string InvItemQuantity { get; set; }
        string PPrice { get; set; }
        string InvTotlPrice { get; set; }
        string InvNote { get; set; }
        DateTimePicker ExpireDate { get; }
        ComboBox CBXCustomers { get; }
        ComboBox CBXMonyState { get; }
        ComboBox CBXPCategoryFilter { get; }
        DataGridView DGVProducts { get; }
        DataGridView DGVInvItems { get; }

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
