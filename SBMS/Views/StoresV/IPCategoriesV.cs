using System;
using System.Windows.Forms;

namespace SBMS.Views.StoresV
{
    interface IPCategoriesV
    {
        bool IsAECtegoryFormVisable { get; set; }
        string PCategoryName { get; set; }
        string PCateDescription { get; set; }
        DataGridView DGVPCategories { get; set; }


        //Events Product Categories View
        event EventHandler ShowAddProdCategoryForm;
        event EventHandler ShowEditProdCategoryForm;
        event EventHandler DeleteSelectedProdCategory;
        event EventHandler OnAECategorySave;
        event EventHandler OnAECategoryCancel;
        event EventHandler OnSelectCategory;
        event EventHandler OnClickCategoriesView;
        event EventHandler OnDisposed;

        bool ShowMsgBox(string msg, string title, bool isYesNo);
    }
}
