using SBMS.Models.Users;
using SBMS.Presenters.CustomersPres;
using SBMS.Presenters.EmployeesPres;
using SBMS.Presenters.PurchasesPres;
using SBMS.Presenters.ReportsPres;
using SBMS.Presenters.SalesPres;
using SBMS.Presenters.StoresPres;
using SBMS.Presenters.SuppliersPres;
using SBMS.Presenters.UsersPres;
using SBMS.Views.Auth;
using SBMS.Views.Customers;
using SBMS.Views.Employees;
using SBMS.Views.Home;
using SBMS.Views.Purchases;
using SBMS.Views.Reports;
using SBMS.Views.Sales;
using SBMS.Views.StoresV;
using SBMS.Views.Suppliers;
using System;

namespace SBMS.Presenters
{
    public class AdminHomeVPres
    {
        IAdminHomeV adminHomeV;
         UserM user;
        private static AdminHomeVPres instance;
        public static AdminHomeVPres GetInstance(UserM userM)
        {
            if (instance == null) instance = new AdminHomeVPres(userM);
            return instance;
        }
        public static void Dispose()
        {
            instance = null;
        }
        private AdminHomeVPres(UserM userM)
        {
            user = userM;
            adminHomeV = AdminHomeV.GetInstance();
            OnInit();
            adminHomeV.UName = user.Name;
            adminHomeV.SName = user.Employee;
            HomeWelcomV.GetInstance().MdiParent = AdminHomeV.GetInstance();
            EmployeesHV.GetInstance().MdiParent = AdminHomeV.GetInstance();
            UsersV.GetInstance().MdiParent = AdminHomeV.GetInstance();
            StoresV.GetInstance().MdiParent = AdminHomeV.GetInstance();
            CustomersHV.GetInstance().MdiParent = AdminHomeV.GetInstance();
            SuppliersHV.GetInstance().MdiParent = AdminHomeV.GetInstance();
            ReportsHV.GetInstance().MdiParent = AdminHomeV.GetInstance();
            AdminHomeV.GetInstance().Show();
            ShowHome();
        }

        void OnInit()
        {
            adminHomeV.ShowEmployeesMV += delegate { ShowHome(); };
            adminHomeV.ShowEmployeesMV += delegate { ShowEmploeesMV(); };
            adminHomeV.ShowStoresMV += delegate { ShowStoresMV(); }; 
            adminHomeV.ShowSalesMV += delegate { ShowSalesMV(); };
            adminHomeV.ShowPurchaseMV += delegate { ShowPurchaseMV(); };
            adminHomeV.ShowReportsMV += delegate { ShowReportsMV(); };
            adminHomeV.ShowUsersMV += delegate { ShowUsersMV(); };
            adminHomeV.ShowCustomersMV += delegate { ShowCustomersMV(); };
            adminHomeV.ShowSuppliersMV += delegate { ShowSuppliersMV(); };
            adminHomeV.ShowSettingsMV += delegate { ShowSettingsMV(); };
            adminHomeV.ShowAboutV += delegate { ShowAboutV(); };

            adminHomeV.OnDisposed += delegate { Dispose(); };
           
        }

        

        private void ShowHome()
        {
            HomeWelcomV.GetInstance().Dock = System.Windows.Forms.DockStyle.Fill;
            HomeWelcomV.GetInstance().Show();
        }
        private void ShowAboutV()
        {
            
        }

        private void ShowSettingsMV()
        {
            
        }
        private void ShowEmploeesMV()
        {
            EmployeesHVPres.GetInstance();
            EmployeesHV.GetInstance().Dock = System.Windows.Forms.DockStyle.Fill;
            EmployeesHV.GetInstance().Show();
        }
        private void ShowUsersMV()
        {
            UsersVPres.GetInstance();
            UsersV.GetInstance().Dock = System.Windows.Forms.DockStyle.Fill;
            UsersV.GetInstance().Show();
        }

        private void ShowPurchaseMV()
        {
            PurchasesHVPres.GetInstance(user);
            PurchaseHomeV.GetInstance().Show();
        }

        private void ShowSalesMV()
        {
            SalesHVPres.GetInstance(user);
            SalesHomeV.GetInstance().Show();
        }

        private void ShowReportsMV()
        {
            ReportsHVPres.GetInstance();
            ReportsHV.GetInstance().Dock = System.Windows.Forms.DockStyle.Fill;
            ReportsHV.GetInstance().Show();
        }

        private void ShowStoresMV()
        {
            StoresVPres.GetInstance();
            StoresV.GetInstance().Dock = System.Windows.Forms.DockStyle.Fill;
            StoresV.GetInstance().Show();
        }
        private void ShowSuppliersMV()
        {
            SuppliersHVPres.GetInstance();
            SuppliersHV.GetInstance().Dock = System.Windows.Forms.DockStyle.Fill;
            SuppliersHV.GetInstance().Show();
        }

        private void ShowCustomersMV()
        {
            CustomersHVPres.GetInstance();
            CustomersHV.GetInstance().Dock = System.Windows.Forms.DockStyle.Fill;
            CustomersHV.GetInstance().Show();
        }

    }
}
