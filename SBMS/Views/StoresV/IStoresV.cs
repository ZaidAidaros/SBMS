using System;
using System.Windows.Forms;

namespace SBMS.Views.StoresV
{
    interface IStoresV
    {
        Panel PnlProductsView { get; set; }
        Panel PnlPCategoriesView { get; set; }
        Panel PnlPUnitsView { get; set; }
        
        string HeaderTitle { get; set; }

        // View Header
        event EventHandler ShowProductsView;
        event EventHandler ShowProdCategoriesView;
        event EventHandler ShowProdUnitsView;

        
    }
}
