using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SBMS.Views.Purchases
{
    interface ICustCategoriesV
    {
        bool IsAECtegoryFormVisable { get; set; }
        string CCategoryName { get; set; }
        string CCateDescription { get; set; }
        DataGridView DGVPCustCategories { get; set; }


        //Events Product Categories View
        event EventHandler ShowAddCustCategoryForm;
        event EventHandler ShowEditCustCategoryForm;
        event EventHandler DeleteSelectedCustCategory;
        event EventHandler OnAECategorySave;
        event EventHandler OnAECategoryCancel;
        event EventHandler OnSelectCategory;
        //event EventHandler OnClickCategoriesView;

        bool ShowMsgBox(string msg, string title, bool isYesNo);
    }
}
