using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SBMS.Views.Auth
{
    interface IUsersV
    {
        bool IsAEUserFormVisable { get; set; }
        string UserName { get; set; }
        string UserPassword { get; set; }
        string SearchValue { get; set; }
        ComboBox CBXPermmisions { get; }
        ComboBox CBXPermmisionFilter { get; }
        ComboBox CBXEmployees { get; }
        DataGridView DGVUsers { get; }


        //Events Product Categories View
        event EventHandler ShowAddUserForm;
        event EventHandler ShowEditUserForm;
        event EventHandler DeleteSelectedUser;
        event EventHandler OnAEUserSave;
        event EventHandler OnAEUserCancel;
        event EventHandler OnSelectUser;
        event EventHandler OnVRefresh;
        event EventHandler OnPermmisionFilterChanged;
        event EventHandler OnSearchBClicked;
        //event EventHandler OnClickCategoriesView;

        bool ShowMsgBox(string msg, string title, bool isYesNo);
    }
}
