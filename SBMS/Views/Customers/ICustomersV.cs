using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SBMS.Views.Customers
{
    interface ICustomersV
    {
        string CustomerName { get; set; }
        string CustomerNIC { get; set; }
        string CustomerPhone { get; set; }
        string CustomerAddress { get; set; }
        string SearchValue { get; set; }
        ComboBox CBXCustomerCategory { get; set; }
        ComboBox CBXCustomerGender { get; set; }
        ComboBox CBXCategoryFilter { get; set; }
        DateTime DTCustomerBirthDay { get; set; }
        bool IsAECustomerFormVisable { get; set; }
        DataGridView DGVCustomers { get; set; }

        event EventHandler ShowAddCustomerForm;
        event EventHandler ShowEditCustomerForm;
        event EventHandler DeleteSelectedCustomer;
        event EventHandler OnCategoryFilterChanged;
        event EventHandler OnSearchButtonClicked;
        event EventHandler OnSelectCustomer;
        event EventHandler OnAECustomerSave;
        event EventHandler OnAECustomerCancel;
        event EventHandler OnVRefresh;




        bool ShowMsgBox(string msg, string title, bool isYesNo);
    }
}
