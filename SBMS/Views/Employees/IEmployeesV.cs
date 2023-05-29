using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SBMS.Views.Employees
{
    interface IEmployeesV
    {
        string EmployeeName { get; set; }
        string EmployeeNIC { get; set; }
        string EmployeePhone { get; set; }
        string EmployeeAddress { get; set; }
        string SearchValue { get; set; }
        string EmployeeSalary { get; set; }
        string EmployeeNote { get; set; }
        ComboBox CBXEmployeeJob { get;  }
        ComboBox CBXEmployeeGender { get;}
        ComboBox CBXJobFilter { get; }
        DateTime DTEmployeeBirthDay { get; set; }
        bool IsAEEmployeeFormVisable { get; set; }
        DataGridView DGVEmployees { get;  }

        event EventHandler ShowAddEmployeeForm;
        event EventHandler ShowEditEmployeeForm;
        event EventHandler DeleteSelectedEmployee;
        event EventHandler OnJobFilterChanged;
        event EventHandler OnSearchButtonClicked;
        event EventHandler OnSelectEmployee;
        event EventHandler OnAEEmployeeSave;
        event EventHandler OnAEEmployeeCancel;
        event EventHandler OnVRefresh;
        event EventHandler OnDisposed;




        bool ShowMsgBox(string msg, string title, bool isYesNo);
    }
}
