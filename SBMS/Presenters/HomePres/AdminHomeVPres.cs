using SBMS.Models.Users;
using SBMS.Presenters.UsersPres;
using SBMS.Views.Auth;
using SBMS.Views.Home;
using SBMS.Views.Employees;
using SBMS.Views.StoresV;
using System;
using SBMS.Views.Purchases;
using SBMS.Views.Sales;
using SBMS.Views.Customers;
using SBMS.Views.Suppliers;
using SBMS.Presenters.SalesPres;
using SBMS.Presenters.PurchasesPres;
using SBMS.Views.Reports;

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
        private AdminHomeVPres(UserM userM)
        {
            user = userM;
            adminHomeV = AdminHomeV.GetInstance();
            Subscribe();
            adminHomeV.UName = user.Name;
            adminHomeV.SName = user.Employee;
            EmployeesHV.GetInstance().MdiParent = AdminHomeV.GetInstance();
            UsersV.GetInstance().MdiParent = AdminHomeV.GetInstance();
            StoresV.GetInstance().MdiParent = AdminHomeV.GetInstance();
            CustomersHV.GetInstance().MdiParent = AdminHomeV.GetInstance();
            SuppliersHV.GetInstance().MdiParent = AdminHomeV.GetInstance();
            ReportsHV.GetInstance().MdiParent = AdminHomeV.GetInstance();
            AdminHomeV.GetInstance().Show();
        }

        void Subscribe()
        {
            adminHomeV.ShowAccountsMV += delegate { ShowEmploeesMV(); };
            adminHomeV.ShowStoresMV += delegate { ShowStoresMV(); }; 
            adminHomeV.ShowSalesMV += delegate { ShowSalesMV(); };
            adminHomeV.ShowPurchaseMV += delegate { ShowPurchaseMV(); };
            adminHomeV.ShowReportsMV += delegate { ShowReportsMV(); };
            adminHomeV.ShowUsersMV += delegate { ShowUsersMV(); };
            adminHomeV.ShowSettingsMV += delegate { ShowSettingsMV(); };
            adminHomeV.ShowAboutV += delegate { ShowAboutV(); };
           
        }

        private void ShowAboutV()
        {
            
        }

        private void ShowSettingsMV()
        {
            
        }
        private void ShowEmploeesMV()
        {
            EmployeesHV.GetInstance().Dock = System.Windows.Forms.DockStyle.Fill;
            EmployeesHV.GetInstance().Show();
        }
        private void ShowUsersMV()
        {
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
            ReportsHV.GetInstance().Dock = System.Windows.Forms.DockStyle.Fill;
            ReportsHV.GetInstance().Show();
        }

        private void ShowStoresMV()
        {
            StoresV.GetInstance().Dock = System.Windows.Forms.DockStyle.Fill;
            StoresV.GetInstance().Show();
        }

        
    }
}
