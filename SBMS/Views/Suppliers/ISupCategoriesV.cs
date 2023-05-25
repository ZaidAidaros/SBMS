using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SBMS.Views.Suppliers
{
    interface ISupCategoriesV
    {
        bool IsAECtegoryFormVisable { get; set; }
        string SCategoryName { get; set; }
        string SCateDescription { get; set; }
        DataGridView DGVPSuppCategories { get; set; }
        

        //Events Product Categories View
        event EventHandler ShowAddSuppCategoryForm;
        event EventHandler ShowEditSuppCategoryForm;
        event EventHandler DeleteSelectedSuppCategory;
        event EventHandler OnAECategorySave;
        event EventHandler OnAECategoryCancel;
        event EventHandler OnSelectCategory;
        //event EventHandler OnClickCategoriesView;

        bool ShowMsgBox(string msg, string title, bool isYesNo);
    }
}
