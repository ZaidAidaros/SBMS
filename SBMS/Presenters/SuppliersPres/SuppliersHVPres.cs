using SBMS.Views.Suppliers;

namespace SBMS.Presenters.SuppliersPres
{
    class SuppliersHVPres
    {
        ISuppliersHV suppliersHV;
        private SuppliersHVPres()
        {
            this.suppliersHV = SuppliersHV.GetInstance();
            ShowSuppliersView();
            this.suppliersHV.ShowSuppliersView += delegate { ShowSuppliersView(); };
            this.suppliersHV.ShowSuppCategoriesView += delegate { ShowSuppCategoriesView(); };
            this.suppliersHV.OnDisposed += delegate { Dispose(); };
        }
        /// <summary>
        /// 
        /// </summary>
        private static SuppliersHVPres instance;
        public static SuppliersHVPres GetInstance()
        {
            if (instance == null) instance = new SuppliersHVPres();
            return instance;
        }
        public static void Dispose()
        {
            instance = null;
        }

        private void ShowSuppliersView()
        {
            SuppliersVPres.GetInstance();
            this.suppliersHV.HeaderTitle = "Suppliers";
            this.suppliersHV.PnlSuppliersView.BringToFront();
        }

        private void ShowSuppCategoriesView()
        {
            SuppCategoriesVPres.GetInstance();
            this.suppliersHV.HeaderTitle = "Supplier Categories";
            this.suppliersHV.PnlSCategoriesView.BringToFront();
        }
    }
}
