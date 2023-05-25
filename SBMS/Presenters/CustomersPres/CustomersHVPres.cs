using SBMS.Views.Customers;

namespace SBMS.Presenters.CustomersPres
{
    class CustomersHVPres
    {
        ICustomersHV customersHV;
        private CustomersHVPres()
        {
            this.customersHV = CustomersHV.GetInstance();
            ShowCustomersView();
            this.customersHV.ShowCustomersView += delegate { ShowCustomersView(); };
            this.customersHV.ShowCustCategoriesView += delegate { ShowCustCategoriesView(); };
        }
        /// <summary>
        /// 
        /// </summary>
        private static CustomersHVPres instance;
        public static CustomersHVPres GetInstance()
        {
            if (instance == null) instance = new CustomersHVPres();
            return instance;
        }
        /// <summary>
        /// 
        /// </summary>

        private void ShowCustomersView()
        {
            CustomersVPres.GetInstance();
            this.customersHV.HeaderTitle = "Customers";
            this.customersHV.PnlCustomersView.BringToFront();
        }

        private void ShowCustCategoriesView()
        {
            CustCategoriesVPres.GetInstance();
            this.customersHV.HeaderTitle = "Customer Categories";
            this.customersHV.PnlCCategoriesView.BringToFront();
        }

    }
}
