using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SBMS.Views.Sales
{
    interface ISaleInvoicesV
    {
        string InvSearchField { get; set; }
        bool IsInvItemsVisable { get; set; }
        ComboBox CBXInvFilter { get; }
        DataGridView DGVInvoices { get; }
        DataGridView DGVInvItems { get; }

        event EventHandler OnInvSearchBClicked;

        bool ShowMsgBox(string msg, string title, bool isYesNo);
    }
}
