using SBMS.Models.Employees;
using SBMS.Models.Users;
using SBMS.Repositories;
using SBMS.Repositories.EmployeesRepo;
using SBMS.Views.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBMS.Presenters.UsersPres
{
    class UsersVPres
    {
        IUsersV usersV;
        private bool IsEdit = false;
        private UserM SelectedUser;
        /// <summary>
        /// 
        /// </summary>
        private static UsersVPres instance;
        public static UsersVPres GetInstance()
        {
            if (instance == null) instance = new UsersVPres();
            return instance;
        }
        public static void Dispose()
        {
            instance = null;
        }
        private UsersVPres()
        {
            this.usersV = UsersV.GetInstance();
            this.OnInitAsync();
        }

        private async Task OnInitAsync()
        {
            await this.LoadUsersAsync();
            await this.LoadPermissionListAsync();
            await this.LoadEmployeeListAsync();

            this.usersV.ShowAddUserForm += delegate { this.ShowAddUserForm(); };
            this.usersV.ShowEditUserForm += delegate { this.ShowEditUserForm(); };
            this.usersV.DeleteSelectedUser += async delegate { await this.DeleteSelectedUserAsync(); };
            this.usersV.OnAEUserSave += async delegate { await this.OnAEUserSaveAsync(); };
            this.usersV.OnAEUserCancel += delegate { OnAEUserCancel(); };
            this.usersV.OnSelectUser += delegate { this.OnSelectUser(); };
            this.usersV.OnPermmisionFilterChanged += async delegate { await OnPermissionFilterChangedAsync(); };
            this.usersV.OnSearchBClicked += async delegate { await OnSearchButtonClickedAsync(); };
            this.usersV.OnVRefresh += async delegate { await OnVRefreshAsync(); };
            this.usersV.OnDisposed += delegate { Dispose(); };
        }

        private void ShowAddUserForm()
        {
            this.IsEdit = false;
            this.usersV.IsAEUserFormVisable = true;
        }

        private void ShowEditUserForm()
        {
            if (this.SelectedUser == null)
            {
                this.usersV.ShowMsgBox("Must Select Product To Edit From List.", "Error:", false);
                return;
            }
            this.IsEdit = true;
            this.SetFields();
            this.usersV.IsAEUserFormVisable = true;
        }

        private void SetFields()
        {
            this.usersV.UserName = this.SelectedUser.Name;
            for (int i = 0; i < this.usersV.CBXPermmisions.Items.Count; i++)
            {
                if (((PermissionM)this.usersV.CBXPermmisions.Items[i]).Name == this.SelectedUser.Permission)
                {
                    this.usersV.CBXPermmisions.SelectedIndex = i;
                    break;
                }
            }
            for (int i = 0; i < this.usersV.CBXEmployees.Items.Count; i++)
            {
                if (((IEmployeeM)this.usersV.CBXEmployees.Items[i]).Name == this.SelectedUser.Employee)
                {
                    this.usersV.CBXEmployees.SelectedIndex = i;
                    break;
                }
            }
        }

        private async Task DeleteSelectedUserAsync()
        {
            if (this.SelectedUser == null)
            {
                this.usersV.ShowMsgBox("Must Select Unit To Delete From List", "Error:", false);
                return;
            }
            if (this.usersV.ShowMsgBox("Are You Sure?\n You Want To Delete It", "Confirm:", true))
            {
                RepoResultM res = await UsersRepo.DeleteUserAsync(this.SelectedUser.Id);
                if (res.IsSucess)
                {
                    this.LoadUsersAsync();
                    this.ResetAll();
                }
                else
                {
                    this.usersV.ShowMsgBox(res.ErrorMsg, "Error:", false);
                }
            }
        }

        private async Task OnAEUserSaveAsync()
        {

            if (this.IsEdit)
            {
                await this.EditUserAsync();
            }
            else
            {
                await this.AddUserAsync();
            }
        }

        private async Task AddUserAsync()
        {

            if (this.usersV.ShowMsgBox("Are You Sure?\nYou Want To Save", "Confirm:", true))
            {
                RepoResultM res = await UsersRepo.AddUserAsync(SetUserM(null));
                if (res.IsSucess)
                {
                    await this.LoadUsersAsync();
                    this.ResetAll();
                    this.usersV.ShowMsgBox("Save Sucessful", "Sucess:", false);
                }
                else
                {
                    this.usersV.ShowMsgBox(res.ErrorMsg, "Error:", false);
                }
            }
        }

        private UserM SetUserM(UserM user)
        {
            if (user == null) user = new UserM();
            user.Name = this.usersV.UserName;
            user.Password = this.usersV.UserPassword;
            user.PermissionId = ((PermissionM)this.usersV.CBXPermmisions.SelectedItem).Id;
            user.Permission = ((PermissionM)this.usersV.CBXPermmisions.SelectedItem).Name;
            user.EmployeeId = ((IEmployeeM)this.usersV.CBXEmployees.SelectedItem).Id;
            user.Employee = ((IEmployeeM)this.usersV.CBXEmployees.SelectedItem).Name;
            return user;
        }

        private async Task EditUserAsync()
        {

            if (this.usersV.ShowMsgBox("Are You Sure?\nYou Want To Save Changes", "Confirm:", true))
            {
                RepoResultM res = await UsersRepo.UpdateUserAsync(SetUserM(this.SelectedUser));
                if (res.IsSucess)
                {
                    this.LoadUsersAsync();
                    this.ResetAll();
                    this.usersV.ShowMsgBox("Save Changes Sucessful", "Sucess:", false);
                }
                else
                {
                    this.usersV.ShowMsgBox(res.ErrorMsg, "Error:", false);
                }
            }
        }

        private void OnAEUserCancel()
        {
            this.ResetAll();
        }

        private void OnSelectUser()
        {
            if (this.usersV.DGVUsers.SelectedRows.Count == 1)
                this.SelectedUser = (UserM)this.usersV.DGVUsers.SelectedRows[0].DataBoundItem;
        }

        private async Task OnSearchButtonClickedAsync()
        {
            if (string.IsNullOrWhiteSpace(this.usersV.SearchValue) || string.IsNullOrEmpty(this.usersV.SearchValue)) return;
            RepoResultM res = await UsersRepo.SearchUserAsync(this.usersV.SearchValue);
            if (res.IsSucess)
            {
                List<UserM> userList = new List<UserM>();
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    userList.Add((UserM)res.ResData[i]);
                }
                if (userList.Count > 0)
                {
                    this.usersV.DGVUsers.DataSource = null;
                    this.usersV.DGVUsers.DataSource = userList;
                    this.usersV.DGVUsers.ClearSelection();
                }
            }
            else
            {
                this.LoadUsersAsync();
                this.usersV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
        }

        private async Task OnVRefreshAsync()
        {
            ResetAll();
            await LoadUsersAsync();
            await LoadPermissionListAsync();
            await LoadEmployeeListAsync();
        }

        private async Task LoadPermissionListAsync()
        {
            PermissionM permM = new PermissionM();
            permM.Id = 0;
            permM.Name = "All";
            this.usersV.CBXPermmisionFilter.Items.Clear();
            this.usersV.CBXPermmisions.Items.Clear();
            this.usersV.CBXPermmisionFilter.Items.Add(permM);
            RepoResultM res = await UsersRepo.GetPermissionsAsync();
            if (res.IsSucess)
            {
                this.usersV.CBXPermmisionFilter.DisplayMember = "Name";
                this.usersV.CBXPermmisionFilter.ValueMember = "Id";
                this.usersV.CBXPermmisions.DisplayMember = "Name";
                this.usersV.CBXPermmisions.ValueMember = "Id";
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    this.usersV.CBXPermmisionFilter.Items.Add((PermissionM)res.ResData[i]);
                    this.usersV.CBXPermmisions.Items.Add((PermissionM)res.ResData[i]);
                    this.usersV.CBXPermmisionFilter.SelectedIndex = 0;
                }

            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    this.usersV.ShowMsgBox("The Permission List Is Empty", "Note:", false);
                    return;
                }
                this.usersV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
        }
        private async Task LoadEmployeeListAsync()
        {
            this.usersV.CBXEmployees.Items.Clear();
            RepoResultM res = await EmployeesRepo.GetEmployeesAsync();
            if (res.IsSucess)
            {
                this.usersV.CBXEmployees.DisplayMember = "Name";
                this.usersV.CBXEmployees.ValueMember = "Id";
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    this.usersV.CBXEmployees.Items.Add((IEmployeeM)res.ResData[i]);
                }

            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    this.usersV.ShowMsgBox("The Permission List Is Empty", "Note:", false);
                    return;
                }
                this.usersV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }

        }
        private async Task LoadUsersAsync()
        {
            RepoResultM res = await UsersRepo.GetUsersAsync();
            this.usersV.DGVUsers.DataSource = null;
            if (res.IsSucess)
            {
                List<UserM> users = new List<UserM>();
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    users.Add((UserM)res.ResData[i]);
                }
                if (users.Count > 0)
                {
                    this.usersV.DGVUsers.DataSource = users;
                    this.usersV.DGVUsers.ClearSelection();
                }
            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    this.usersV.ShowMsgBox("The Users List Is Empty", "Note:", false);
                    return;
                }
                this.usersV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
        }
        private async Task OnPermissionFilterChangedAsync()
        {
            RepoResultM res = await UsersRepo.SearchUserAsync(((PermissionM)this.usersV.CBXPermmisionFilter.SelectedItem).Id.ToString());

            if (res.IsSucess)
            {
                List<UserM> users = new List<UserM>();
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    users.Add((UserM)res.ResData[i]);
                }
                if (users.Count > 0)
                {
                    this.usersV.DGVUsers.DataSource = null;
                    this.usersV.DGVUsers.DataSource = users;
                    this.usersV.DGVUsers.ClearSelection();
                }
            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    this.LoadUsersAsync();
                    if (this.usersV.CBXPermmisionFilter.SelectedIndex == 0) return;
                    this.usersV.ShowMsgBox("No Customers In This Category", "Note:", false);
                    return;
                }
                this.usersV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }


        }

        private void ResetAll()
        {
            this.IsEdit = false;
            this.SelectedUser = null;
            this.usersV.IsAEUserFormVisable = false;
            this.usersV.UserName = null;
            this.usersV.UserPassword = null;
        }
    }
}
