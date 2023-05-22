using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SBMS.Views.Purchases
{
    interface ICustomersHV
    {
        Panel PnlCustomersView { get; set; }
        Panel PnlCCategoriesView { get; set; }

        string HeaderTitle { get; set; }

        // View Header
        event EventHandler ShowCustomersView;
        event EventHandler ShowCustCategoriesView;

    }
}
