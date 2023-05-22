using SBMS.Models.Employees;
using SBMS.Models.General;
using SBMS.Repositories;
using SBMS.Repositories.EmployeesRepo;
using SBMS.Views.Purchases;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SBMS.Presenters.EmployeesPres
{
    class EmployeesVPres
    {
        IEmployeesV employeesV;
        private bool IsEdit = false;
        private EmployeeM SelectedEmployee;
        /// <summary>
        /// 
        /// </summary>
        private static EmployeesVPres instance;
        public static EmployeesVPres GetInstance()
        {
            if (instance == null) instance = new EmployeesVPres();
            return instance;
        }
        /// <summary>
        /// 
        /// </summary>
        /// 
        private EmployeesVPres()
        {
            this.employeesV = EmployeesHV.GetInstance();
            this.LoadEmployeesAsync();
            this.LoadJobListAsync();
            this.LoadGenderList();
            this.employeesV.ShowAddEmployeeForm += delegate { this.ShowAddCustomerForm(); };
            this.employeesV.ShowEditEmployeeForm += delegate { this.ShowEditCustomerForm(); };
            this.employeesV.DeleteSelectedEmployee += delegate { this.DeleteSelectedCustomerAsync(); };
            this.employeesV.OnAEEmployeeSave += delegate { this.OnAEEmployeeSave(); };
            this.employeesV.OnAEEmployeeCancel += delegate { OnAEEmployeeCancel(); };
            this.employeesV.OnSelectEmployee += delegate { this.OnSelectEmployee(); };
            this.employeesV.OnJobFilterChanged += delegate { OnCategoryFilterChangedAsync(); };
            this.employeesV.OnSearchButtonClicked += delegate { OnSearchButtonClickedAsync(); };
            this.employeesV.OnVRefresh += delegate { OnRefreshPV(); };
        }

        private void ShowAddCustomerForm()
        {
            this.IsEdit = false;
            this.employeesV.IsAEEmployeeFormVisable = true;
        }

        private void ShowEditCustomerForm()
        {
            if (this.SelectedEmployee == null)
            {
                this.employeesV.ShowMsgBox("Must Select Employee To Edit From List.", "Error:", false);
                return;
            }
            this.IsEdit = true;
            this.SetFields();
            this.employeesV.IsAEEmployeeFormVisable = true;
        }

        private void SetFields()
        {
            this.employeesV.EmployeeName = this.SelectedEmployee.Name;
            this.employeesV.EmployeeNIC = this.SelectedEmployee.NIC.ToString();
            this.employeesV.EmployeeSalary = this.SelectedEmployee.Salary.ToString();
            this.employeesV.EmployeePhone = this.SelectedEmployee.Phone;
            this.employeesV.EmployeeAddress = this.SelectedEmployee.Address;
            this.employeesV.EmployeeNote = this.SelectedEmployee.Note;
            this.employeesV.DTEmployeeBirthDay = this.SelectedEmployee.BirthDate;
            for (int i = 0; i < this.employeesV.CBXEmployeeGender.Items.Count; i++)
            {
                if (((GenderM)this.employeesV.CBXEmployeeGender.Items[i]).Name == this.SelectedEmployee.Gender)
                {
                    this.employeesV.CBXEmployeeGender.SelectedIndex = i;
                    break;
                }
            }
            for (int i = 0; i < this.employeesV.CBXEmployeeJob.Items.Count; i++)
            {
                if (((JobM)this.employeesV.CBXEmployeeJob.Items[i]).Name == this.SelectedEmployee.Job)
                {
                    this.employeesV.CBXEmployeeJob.SelectedIndex = i;
                    break;
                }
            }
        }

        private async Task DeleteSelectedCustomerAsync()
        {
            if (this.SelectedEmployee == null)
            {
                this.employeesV.ShowMsgBox("Must Select Unit To Delete From List", "Error:", false);
                return;
            }
            if (this.employeesV.ShowMsgBox("Are You Sure?\n You Want To Delete It", "Confirm:", true))
            {
                RepoResultM res = await EmployeesRepo.DeleteEmployeeAsync(this.SelectedEmployee.Id);
                if (res.IsSucess)
                {
                    this.LoadEmployeesAsync();
                    this.ResetAll();
                }
                else
                {
                    this.employeesV.ShowMsgBox(res.ErrorMsg, "Error:", false);
                }
            }
        }

        private void OnAEEmployeeSave()
        {

            if (this.IsEdit)
            {
                this.EditEmployeeAsync();
            }
            else
            {
                this.AddEmployeeAsync();
            }
        }

        private async Task AddEmployeeAsync()
        {

            if (this.employeesV.ShowMsgBox("Are You Sure?\nYou Want To Save", "Confirm:", true))
            {
                RepoResultM res = await EmployeesRepo.AddEmployeeAsync(SetCustomerM(null));
                if (res.IsSucess)
                {
                    this.LoadEmployeesAsync();
                    this.ResetAll();
                    this.employeesV.ShowMsgBox("Save Sucessful", "Sucess:", false);
                }
                else
                {
                    this.employeesV.ShowMsgBox(res.ErrorMsg, "Error:", false);
                }
            }
        }

        private EmployeeM SetCustomerM(EmployeeM employee)
        {
            if (employee == null) employee = new EmployeeM();
            employee.Name = this.employeesV.EmployeeName;
            employee.NIC = int.Parse(this.employeesV.EmployeeNIC);
            employee.Salary = decimal.Parse(this.employeesV.EmployeeSalary);
            employee.Phone = this.employeesV.EmployeePhone;
            employee.Address = this.employeesV.EmployeeAddress;
            employee.Note = this.employeesV.EmployeeNote;
            employee.Jobm = (JobM)this.employeesV.CBXEmployeeJob.SelectedItem;
            employee.Genderm = (GenderM)this.employeesV.CBXEmployeeGender.SelectedItem;
            employee.BirthDate = this.employeesV.DTEmployeeBirthDay;
            return employee;
        }

        private async Task EditEmployeeAsync()
        {

            if (this.employeesV.ShowMsgBox("Are You Sure?\nYou Want To Save Changes", "Confirm:", true))
            {
                RepoResultM res = await EmployeesRepo.UpdateEmployeeAsync(SetCustomerM(this.SelectedEmployee));
                if (res.IsSucess)
                {
                    this.LoadEmployeesAsync();
                    this.ResetAll();
                    this.employeesV.ShowMsgBox("Save Changes Sucessful", "Sucess:", false);
                }
                else
                {
                    this.employeesV.ShowMsgBox(res.ErrorMsg, "Error:", false);
                }
            }
        }

        private void OnAEEmployeeCancel()
        {
            this.ResetAll();
        }

        private void OnSelectEmployee()
        {
            if (this.employeesV.DGVEmployees.SelectedRows.Count == 1)
                this.SelectedEmployee = (EmployeeM)this.employeesV.DGVEmployees.SelectedRows[0].DataBoundItem;
        }

        private async Task OnSearchButtonClickedAsync()
        {
            if (string.IsNullOrWhiteSpace(this.employeesV.SearchValue) || string.IsNullOrEmpty(this.employeesV.SearchValue)) return;
            RepoResultM res = await EmployeesRepo.SearchEmployeeAsync(this.employeesV.SearchValue);
            if (res.IsSucess)
            {
                List<IEmployeeM> customers = new List<IEmployeeM>();
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    customers.Add((IEmployeeM)res.ResData[i]);
                }
                if (customers.Count > 0)
                {
                    this.employeesV.DGVEmployees.DataSource = null;
                    this.employeesV.DGVEmployees.DataSource = customers;
                    this.employeesV.DGVEmployees.ClearSelection();
                }
            }
            else
            {
                this.LoadEmployeesAsync();
                this.employeesV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
        }

        private void OnRefreshPV()
        {
            this.ResetAll();
            this.LoadEmployeesAsync();
            this.LoadJobListAsync();
        }

        private async Task LoadJobListAsync()
        {
            JobM jobM = new JobM();
            jobM.Id = 0;
            jobM.Name = "All";
            this.employeesV.CBXEmployeeJob.Items.Clear();
            this.employeesV.CBXJobFilter.Items.Clear();
            this.employeesV.CBXJobFilter.Items.Add(jobM);
            RepoResultM res = await JobsRepo.GetJobsAsync();
            if (res.IsSucess)
            {
                this.employeesV.CBXJobFilter.DisplayMember = "Name";
                this.employeesV.CBXJobFilter.ValueMember = "Id";
                this.employeesV.CBXEmployeeJob.DisplayMember = "Name";
                this.employeesV.CBXEmployeeJob.ValueMember = "Id";
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    this.employeesV.CBXJobFilter.Items.Add((JobM)res.ResData[i]);
                    this.employeesV.CBXEmployeeJob.Items.Add((JobM)res.ResData[i]);
                    this.employeesV.CBXJobFilter.SelectedIndex = 0;
                }

            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    this.employeesV.ShowMsgBox("The Job List Is Empty", "Note:", false);
                    return;
                }
                this.employeesV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
        }
        private void LoadGenderList()
        {
            this.employeesV.CBXEmployeeGender.Items.Clear();
            GenderM gender1 = new GenderM();
            gender1.Id = 1;
            gender1.Name = "Male";
            this.employeesV.CBXEmployeeGender.Items.Add(gender1);
            GenderM gender2 = new GenderM();
            gender2.Id = 2;
            gender2.Name = "Fmale";
            this.employeesV.CBXEmployeeGender.Items.Add(gender2);
            this.employeesV.CBXEmployeeGender.DisplayMember = "Name";
            this.employeesV.CBXEmployeeGender.ValueMember = "Id";



        }
        private async Task LoadEmployeesAsync()
        {
            RepoResultM res = await EmployeesRepo.GetEmployeesAsync();
            this.employeesV.DGVEmployees.DataSource = null;
            if (res.IsSucess)
            {
                List<IEmployeeM> Customers = new List<IEmployeeM>();
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    Customers.Add((IEmployeeM)res.ResData[i]);
                }
                if (Customers.Count > 0)
                {
                    this.employeesV.DGVEmployees.DataSource = Customers;
                    this.employeesV.DGVEmployees.ClearSelection();
                }
            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    this.employeesV.ShowMsgBox("The Employees List Is Empty", "Note:", false);
                    return;
                }
                this.employeesV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
        }
        private async Task OnCategoryFilterChangedAsync()
        {
            RepoResultM res = await EmployeesRepo.FilterEmployeesByJobTitleAsync(((JobM)this.employeesV.CBXJobFilter.SelectedItem).Id);

            if (res.IsSucess)
            {
                List<IEmployeeM> productsList = new List<IEmployeeM>();
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    productsList.Add((IEmployeeM)res.ResData[i]);
                }
                if (productsList.Count > 0)
                {
                    this.employeesV.DGVEmployees.DataSource = null;
                    this.employeesV.DGVEmployees.DataSource = productsList;
                    this.employeesV.DGVEmployees.ClearSelection();
                }
            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    this.LoadEmployeesAsync();
                    if (this.employeesV.CBXJobFilter.SelectedIndex == 0) return;
                    this.employeesV.ShowMsgBox("No Employees With This Job", "Note:", false);
                    return;
                }
                this.employeesV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }


        }

        private void ResetAll()
        {
            this.IsEdit = false;
            this.employeesV.IsAEEmployeeFormVisable = false;
            this.SelectedEmployee = null;
            this.employeesV.EmployeeName = null;
            this.employeesV.EmployeeNIC = null;
            this.employeesV.EmployeeSalary = null;
            this.employeesV.EmployeePhone = null;
            this.employeesV.EmployeeAddress = null;
            this.employeesV.EmployeeNote = null;
            this.employeesV.SearchValue = null;
            //this.employeesV.CBXJobFilter.SelectedIndex = 0;
        }
    }
}
