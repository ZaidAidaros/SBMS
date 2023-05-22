using SBMS.Views.StoresV;
using System;

namespace SBMS.Presenters.StoresPres
{
    class StoresVPres
    {
        IStoresV storesV;
        private StoresVPres()
        {
            this.storesV = StoresV.GetInstance();
            ShowProductsView();
            this.storesV.ShowProductsView += delegate { ShowProductsView(); };
            this.storesV.ShowProdCategoriesView += delegate { ShowProdCategoriesView(); };
            this.storesV.ShowProdUnitsView += delegate { ShowProdUnitsView(); };
        }
        /// <summary>
        /// 
        /// </summary>
        private static StoresVPres instance;
        public static StoresVPres GetInstance()
        {
            if (instance == null) instance = new StoresVPres();
            return instance;
        }
        /// <summary>
        /// 
        /// </summary>

        private void ShowProductsView()
        {
            ProductsVPres.GetInstance();
            this.storesV.HeaderTitle = "Products";
            this.storesV.PnlProductsView.BringToFront();
        }

        private void ShowProdCategoriesView()
        {
            PCategoriesVPres.GetInstance();
            this.storesV.HeaderTitle = "Product Categories";
            this.storesV.PnlPCategoriesView.BringToFront();
        }

        private void ShowProdUnitsView()
        {
            PUnitsVPres.GetInstance();
            this.storesV.HeaderTitle = "Product Units";
            this.storesV.PnlPUnitsView.BringToFront();
        }


 
    }
}
