using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SBMS.Views.Suppliers
{
    interface ISuppliersHV
    {
        Panel PnlSuppliersView { get; set; }
        Panel PnlSCategoriesView { get; set; }

        string HeaderTitle { get; set; }

        // View Header
        event EventHandler ShowSuppliersView;
        event EventHandler ShowSuppCategoriesView;
        event EventHandler OnDisposed;
    }
}
