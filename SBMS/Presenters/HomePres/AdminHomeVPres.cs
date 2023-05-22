using SBMS.Models.Users;
using SBMS.Views.Home;
using System;

namespace SBMS.Presenters
{
    public class AdminHomeVPres
    {
        IAdminHomeV adminHomeV;
         UserM user;
        public AdminHomeVPres(UserM userM)
        {
            user = userM;
            adminHomeV = AdminHomeV.GetInstance();
            Subscribe();
            adminHomeV.UName = user.Name;
            adminHomeV.SName = user.Employee;
            AdminHomeV.GetInstance().Show();
        }

        void Subscribe()
        {
            adminHomeV.ShowAccountsMV += delegate { ShowAccountsMV(); };
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
            throw new NotImplementedException();
        }

        private void ShowSettingsMV()
        {
            throw new NotImplementedException();
        }

        private void ShowUsersMV()
        {
            throw new NotImplementedException();
        }

        private void ShowPurchaseMV()
        {
            throw new NotImplementedException();
        }

        private void ShowReportsMV()
        {
            throw new NotImplementedException();
        }

        private void ShowSalesMV()
        {

        }

        private void ShowStoresMV()
        {
            throw new NotImplementedException();
        }

        private void ShowAccountsMV()
        {
            throw new NotImplementedException();
        }
    }
}
