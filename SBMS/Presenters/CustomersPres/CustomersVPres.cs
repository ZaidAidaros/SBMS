using SBMS.Models.Customers;
using SBMS.Models.General;
using SBMS.Repositories;
using SBMS.Repositories.CustomersRepo;
using SBMS.Views.Customers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SBMS.Presenters.CustomersPres
{
    class CustomersVPres
    {
        ICustomersV CustomersV;
        private bool IsEdit = false;
        private CustomerM SelectedCustomer;
        /// <summary>
        /// 
        /// </summary>
        private static CustomersVPres instance;
        public static CustomersVPres GetInstance()
        {
            if (instance == null) instance = new CustomersVPres();
            return instance;
        }
        /// <summary>
        /// 
        /// </summary>
        /// 
        private CustomersVPres()
        {
            this.CustomersV = CustomersHV.GetInstance();
            this.LoadCustomersAsync();
            this.LoadCategoryListAsync();
            this.LoadGenderList();
            this.CustomersV.ShowAddCustomerForm += delegate { this.ShowAddCustomerForm(); };
            this.CustomersV.ShowEditCustomerForm += delegate { this.ShowEditCustomerForm(); };
            this.CustomersV.DeleteSelectedCustomer += delegate { this.DeleteSelectedCustomerAsync(); };
            this.CustomersV.OnAECustomerSave += delegate { this.OnAECustomerSaveAsync(); };
            this.CustomersV.OnAECustomerCancel += delegate { OnAECustomerCancel(); };
            this.CustomersV.OnSelectCustomer += delegate { this.OnSelectCustomer(); };
            this.CustomersV.OnCategoryFilterChanged += delegate { OnCategoryFilterChangedAsync(); };
            this.CustomersV.OnSearchButtonClicked += delegate { OnSearchButtonClickedAsync(); };
            this.CustomersV.OnVRefresh += delegate { OnRefreshPVAsync(); };
        }

        private void ShowAddCustomerForm()
        {
            this.IsEdit = false;
            this.CustomersV.IsAECustomerFormVisable = true;
        }

        private void ShowEditCustomerForm()
        {
            if (this.SelectedCustomer == null)
            {
                this.CustomersV.ShowMsgBox("Must Select Product To Edit From List.", "Error:", false);
                return;
            }
            this.IsEdit = true;
            this.SetFields();
            this.CustomersV.IsAECustomerFormVisable = true;
        }

        private void SetFields()
        {
            this.CustomersV.CustomerName = this.SelectedCustomer.Name;
            this.CustomersV.CustomerNIC = this.SelectedCustomer.NIC.ToString();
            this.CustomersV.CustomerPhone = this.SelectedCustomer.Phone;
            this.CustomersV.CustomerAddress = this.SelectedCustomer.Address;
            this.CustomersV.DTCustomerBirthDay = DateTime.Parse(this.SelectedCustomer.BirthDate);
            for (int i = 0; i < this.CustomersV.CBXCustomerCategory.Items.Count; i++)
            {
                if (((CustCategoryM)this.CustomersV.CBXCustomerCategory.Items[i]).Name == this.SelectedCustomer.Category)
                {
                    this.CustomersV.CBXCustomerCategory.SelectedIndex = i;
                    break;
                }
            }
            for (int i = 0; i < this.CustomersV.CBXCustomerGender.Items.Count; i++)
            {
                if (((GenderM)this.CustomersV.CBXCustomerGender.Items[i]).Name == this.SelectedCustomer.Gender)
                {
                    this.CustomersV.CBXCustomerGender.SelectedIndex = i;
                    break;
                }
            }
        }

        private async Task DeleteSelectedCustomerAsync()
        {
            if (this.SelectedCustomer == null)
            {
                this.CustomersV.ShowMsgBox("Must Select Unit To Delete From List", "Error:", false);
                return;
            }
            if (this.CustomersV.ShowMsgBox("Are You Sure?\n You Want To Delete It", "Confirm:", true))
            {
                RepoResultM res = await CustomersRepo.DeleteCustomerAsync(this.SelectedCustomer.Id);
                if (res.IsSucess)
                {
                    await this.LoadCustomersAsync();
                    this.ResetAll();
                }
                else
                {
                    this.CustomersV.ShowMsgBox(res.ErrorMsg, "Error:", false);
                }
            }
        }

        private async Task OnAECustomerSaveAsync()
        {
            
            if (this.IsEdit)
            {
                await this.EditCustomerAsync();
            }
            else
            {
                await this.AddCustomerAsync();
            }
        }

        private async Task AddCustomerAsync()
        {

            if (this.CustomersV.ShowMsgBox("Are You Sure?\nYou Want To Save", "Confirm:", true))
            {
                RepoResultM res = await CustomersRepo.AddCustomerAsync(SetCustomerM(null));
                if (res.IsSucess)
                {
                    await this.LoadCustomersAsync();
                    this.ResetAll();
                    this.CustomersV.ShowMsgBox("Save Sucessful", "Sucess:", false);
                }
                else
                {
                    this.CustomersV.ShowMsgBox(res.ErrorMsg, "Error:", false);
                }
            }
        }

        private CustomerM SetCustomerM(CustomerM customer)
        {
            if (customer == null) customer = new CustomerM();
            customer.Name = this.CustomersV.CustomerName;
            customer.NIC = int.Parse(this.CustomersV.CustomerNIC);
            customer.Phone = this.CustomersV.CustomerPhone;
            customer.Address = this.CustomersV.CustomerAddress;
            customer.CategoryM = (CustCategoryM)this.CustomersV.CBXCustomerCategory.SelectedItem;
            customer.GenderM = (GenderM)this.CustomersV.CBXCustomerGender.SelectedItem;
            customer.BirthDate = this.CustomersV.DTCustomerBirthDay.ToShortDateString();
            return customer;
        }

        private async Task EditCustomerAsync()
        {

            if (this.CustomersV.ShowMsgBox("Are You Sure?\nYou Want To Save Changes", "Confirm:", true))
            {
                RepoResultM res = await CustomersRepo.UpdateCustomerAsync(SetCustomerM(this.SelectedCustomer));
                if (res.IsSucess)
                {
                    await this.LoadCustomersAsync();
                    this.ResetAll();
                    this.CustomersV.ShowMsgBox("Save Changes Sucessful", "Sucess:", false);
                }
                else
                {
                    this.CustomersV.ShowMsgBox(res.ErrorMsg, "Error:", false);
                }
            }
        }

        private void OnAECustomerCancel()
        {
            this.ResetAll();
        }

        private void OnSelectCustomer()
        {
            if (this.CustomersV.DGVCustomers.SelectedRows.Count == 1)
                this.SelectedCustomer = (CustomerM)this.CustomersV.DGVCustomers.SelectedRows[0].DataBoundItem;
        }

        private async Task OnSearchButtonClickedAsync()
        {
            if (string.IsNullOrWhiteSpace(this.CustomersV.SearchValue) || string.IsNullOrEmpty(this.CustomersV.SearchValue)) return;
            RepoResultM res = await CustomersRepo.SearchCustomerAsync(this.CustomersV.SearchValue);
            if (res.IsSucess)
            {
                List<CustomerM> customers = new List<CustomerM>();
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    customers.Add((CustomerM)res.ResData[i]);
                }
                if (customers.Count > 0)
                {
                    this.CustomersV.DGVCustomers.DataSource = null;
                    this.CustomersV.DGVCustomers.DataSource = customers;
                    this.CustomersV.DGVCustomers.ClearSelection();
                }
            }
            else
            {
                await this.LoadCustomersAsync();
                this.CustomersV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
        }

        private async Task OnRefreshPVAsync()
        {
            this.ResetAll();
            await this.LoadCustomersAsync();
            await this.LoadCategoryListAsync();
        }

        private async Task LoadCategoryListAsync()
        {
            CustCategoryM prodCategoryM = new CustCategoryM();
            prodCategoryM.Id = 0;
            prodCategoryM.Name = "All";
            this.CustomersV.CBXCategoryFilter.Items.Clear();
            this.CustomersV.CBXCustomerCategory.Items.Clear();
            this.CustomersV.CBXCategoryFilter.Items.Add(prodCategoryM);
            RepoResultM res = await CustCategoriesRepo.GetCustCategoriesAsync();
            if (res.IsSucess)
            {
                this.CustomersV.CBXCategoryFilter.DisplayMember = "Name";
                this.CustomersV.CBXCategoryFilter.ValueMember = "Id";
                this.CustomersV.CBXCustomerCategory.DisplayMember = "Name";
                this.CustomersV.CBXCustomerCategory.ValueMember = "Id";
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    this.CustomersV.CBXCategoryFilter.Items.Add((CustCategoryM)res.ResData[i]);
                    this.CustomersV.CBXCustomerCategory.Items.Add((CustCategoryM)res.ResData[i]);
                    this.CustomersV.CBXCategoryFilter.SelectedIndex = 0;
                }

            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    this.CustomersV.ShowMsgBox("The Category List Is Empty", "Note:", false);
                    return;
                }
                this.CustomersV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
        }
        private void LoadGenderList()
        {
            this.CustomersV.CBXCustomerGender.Items.Clear();
            GenderM gender1 = new GenderM();
            gender1.Id = 1;
            gender1.Name = "Male";
            this.CustomersV.CBXCustomerGender.Items.Add(gender1);
            GenderM gender2 = new GenderM();
            gender2.Id = 2;
            gender2.Name = "Fmale";
            this.CustomersV.CBXCustomerGender.Items.Add(gender2);
            this.CustomersV.CBXCustomerGender.DisplayMember = "Name";
            this.CustomersV.CBXCustomerGender.ValueMember = "Id";
            


        }
        private async Task LoadCustomersAsync()
        {
            RepoResultM res = await CustomersRepo.GetCustomersAsync();
            this.CustomersV.DGVCustomers.DataSource = null;
            if (res.IsSucess)
            {
                List<CustomerM> Customers = new List<CustomerM>();
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    Customers.Add((CustomerM)res.ResData[i]);
                }
                if (Customers.Count > 0)
                {
                    this.CustomersV.DGVCustomers.DataSource = Customers;
                    this.CustomersV.DGVCustomers.ClearSelection();
                }
            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    this.CustomersV.ShowMsgBox("The Customers List Is Empty", "Note:", false);
                    return;
                }
                this.CustomersV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
        }
        private async Task OnCategoryFilterChangedAsync()
        {
            RepoResultM res = await CustomersRepo.FilterCustomersByCategoryAsync(((CustCategoryM)this.CustomersV.CBXCategoryFilter.SelectedItem).Id);

            if (res.IsSucess)
            {
                List<CustomerM> productsList = new List<CustomerM>();
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    productsList.Add((CustomerM)res.ResData[i]);
                }
                if (productsList.Count > 0)
                {
                    this.CustomersV.DGVCustomers.DataSource = null;
                    this.CustomersV.DGVCustomers.DataSource = productsList;
                    this.CustomersV.DGVCustomers.ClearSelection();
                }
            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    await this.LoadCustomersAsync();
                    if (this.CustomersV.CBXCategoryFilter.SelectedIndex == 0) return;
                    this.CustomersV.ShowMsgBox("No Customers In This Category", "Note:", false);
                    return;
                }
                this.CustomersV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }


        }

        private void ResetAll()
        {
            this.IsEdit = false;
            this.SelectedCustomer = null;
            this.CustomersV.IsAECustomerFormVisable = false;
            this.CustomersV.CustomerName = null;
            this.CustomersV.CustomerNIC = null;
        }
    }

}
