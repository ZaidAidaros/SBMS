using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS.Views.Home
{
    public interface IAdminHomeV
    {
        string UName { get; set; }
        string SName { get; set; }
        string TodayDate { get; set; }

        //Events
        event EventHandler ShowHome;
        event EventHandler ShowEmployeesMV;
        event EventHandler ShowStoresMV;
        event EventHandler ShowSalesMV;
        event EventHandler ShowPurchaseMV;
        event EventHandler ShowReportsMV;
        event EventHandler ShowUsersMV;
        event EventHandler ShowCustomersMV;
        event EventHandler ShowSuppliersMV;
        event EventHandler ShowSettingsMV;
        event EventHandler ShowAboutV;
        event EventHandler OnDisposed;

    }
}
