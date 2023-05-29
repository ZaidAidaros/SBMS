using SBMS.Models.Stores;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SBMS.Views.StoresV
{
    interface IProductsV
    {
        bool IsAEProductFormVisable { get; set; }
        string SearchTextValue { get; set; }
        string Product_Name { get; set; }
        string ProductBarCode { get; set; }
        string ProdDefPrice { get; set; }
        string ProductDescription { get; set; }
        ComboBox PCategroySelectList { get; set; }
        ComboBox PUnitSelectList { get; set; }
        ComboBox CategoryFilter { get; set; }
        DataGridView DGVProducts { get; set; }
        DataGridView DGVProductInfo { get; set; }
        Panel PnlProdInfo { get; set; }
        //Events Products View
        event EventHandler ShowAddProductForm;
        event EventHandler ShowEditProductForm;
        event EventHandler DeleteSelectedProduct;
        event EventHandler OnCategoryFilterChanged;
        event EventHandler OnSearchButtonClicked;
        event EventHandler OnSearchFieldChanged;
        event EventHandler OnSelectProduct;
        event EventHandler OnAEProductSave;
        event EventHandler OnAEProductCancel;
        event EventHandler ShowSelectedProductInfo;
        event EventHandler OnProductsVRefresh;
        event EventHandler OnDisposed;




        bool ShowMsgBox(string msg, string title, bool isYesNo);

        
        //void SetProductsList(BindingSource products);
        //void SetCategoryLists(List<ProdCategoryM> categories);
        //void SetUnitList(List<object> selectedUnits);

        //ProdCategoryM SelectedCategory();
        //ProdCategoryM SelectedFilterCategory();
        //ProdUnitM SelectedUnit();
        //ProductM SelectedProduct();
    }
}
