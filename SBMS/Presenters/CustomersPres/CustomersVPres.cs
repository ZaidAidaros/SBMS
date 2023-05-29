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
            CustomersV = CustomersHV.GetInstance();
            OnInitAsync();
        }

        private async Task OnInitAsync()
        {
            await LoadCustomersAsync();
            await LoadCategoryListAsync();
            LoadGenderList();
            CustomersV.ShowAddCustomerForm += delegate { ShowAddCustomerForm(); };
            CustomersV.ShowEditCustomerForm += delegate { ShowEditCustomerForm(); };
            CustomersV.DeleteSelectedCustomer += async delegate { await DeleteSelectedCustomerAsync(); };
            CustomersV.OnAECustomerSave += async delegate { await OnAECustomerSaveAsync(); };
            CustomersV.OnAECustomerCancel += delegate { OnAECustomerCancel(); };
            CustomersV.OnSelectCustomer += delegate { OnSelectCustomer(); };
            CustomersV.OnCategoryFilterChanged += async delegate { await OnCategoryFilterChangedAsync(); };
            CustomersV.OnSearchButtonClicked += async delegate { await OnSearchButtonClickedAsync(); };
            CustomersV.OnVRefresh += async delegate { await OnRefreshPVAsync(); };
        }

        private void ShowAddCustomerForm()
        {
            IsEdit = false;
            CustomersV.IsAECustomerFormVisable = true;
        }

        private void ShowEditCustomerForm()
        {
            if (SelectedCustomer == null)
            {
                CustomersV.ShowMsgBox("Must Select Product To Edit From List.", "Error:", false);
                return;
            }
            IsEdit = true;
            SetFields();
            CustomersV.IsAECustomerFormVisable = true;
        }

        private void SetFields()
        {
            CustomersV.CustomerName = SelectedCustomer.Name;
            CustomersV.CustomerNIC = SelectedCustomer.NIC.ToString();
            CustomersV.CustomerPhone = SelectedCustomer.Phone;
            CustomersV.CustomerAddress = SelectedCustomer.Address;
            CustomersV.DTCustomerBirthDay = DateTime.Parse(SelectedCustomer.BirthDate);
            for (int i = 0; i < CustomersV.CBXCustomerCategory.Items.Count; i++)
            {
                if (((CustCategoryM)CustomersV.CBXCustomerCategory.Items[i]).Name == SelectedCustomer.Category)
                {
                    CustomersV.CBXCustomerCategory.SelectedIndex = i;
                    break;
                }
            }
            for (int i = 0; i < CustomersV.CBXCustomerGender.Items.Count; i++)
            {
                if (((GenderM) CustomersV.CBXCustomerGender.Items[i]).Name == SelectedCustomer.Gender)
                {
                    CustomersV.CBXCustomerGender.SelectedIndex = i;
                    break;
                }
            }
        }

        private async Task DeleteSelectedCustomerAsync()
        {
            if ( SelectedCustomer == null)
            {
                CustomersV.ShowMsgBox("Must Select Unit To Delete From List", "Error:", false);
                return;
            }
            if ( CustomersV.ShowMsgBox("Are You Sure?\n You Want To Delete It", "Confirm:", true))
            {
                RepoResultM res = await CustomersRepo.DeleteCustomerAsync( SelectedCustomer.Id);
                if (res.IsSucess)
                {
                    await LoadCustomersAsync();
                    ResetAll();
                }
                else
                {
                    CustomersV.ShowMsgBox(res.ErrorMsg, "Error:", false);
                }
            }
        }

        private async Task OnAECustomerSaveAsync()
        {
            
            if ( IsEdit)
            {
                await  EditCustomerAsync();
            }
            else
            {
                await  AddCustomerAsync();
            }
        }

        private async Task AddCustomerAsync()
        {

            if ( CustomersV.ShowMsgBox("Are You Sure?\nYou Want To Save", "Confirm:", true))
            {
                RepoResultM res = await CustomersRepo.AddCustomerAsync(SetCustomerM(null));
                if (res.IsSucess)
                {
                    await LoadCustomersAsync();
                    ResetAll();
                    CustomersV.ShowMsgBox("Save Sucessful", "Sucess:", false);
                }
                else
                {
                    CustomersV.ShowMsgBox(res.ErrorMsg, "Error:", false);
                }
            }
        }

        private CustomerM SetCustomerM(CustomerM customer)
        {
            if (customer == null) customer = new CustomerM();
            customer.Name = CustomersV.CustomerName;
            customer.NIC = int.Parse( CustomersV.CustomerNIC);
            customer.Phone = CustomersV.CustomerPhone;
            customer.Address = CustomersV.CustomerAddress;
            customer.CategoryId = ((CustCategoryM)CustomersV.CBXCustomerCategory.SelectedItem).Id;
            customer.Category = ((CustCategoryM)CustomersV.CBXCustomerCategory.SelectedItem).Name;
            customer.GenderId = ((GenderM)CustomersV.CBXCustomerGender.SelectedItem).Id;
            customer.Gender = ((GenderM)CustomersV.CBXCustomerGender.SelectedItem).Name;
            customer.BirthDate =  CustomersV.DTCustomerBirthDay.ToShortDateString();
            return customer;
        }

        private async Task EditCustomerAsync()
        {

            if ( CustomersV.ShowMsgBox("Are You Sure?\nYou Want To Save Changes", "Confirm:", true))
            {
                RepoResultM res = await CustomersRepo.UpdateCustomerAsync(SetCustomerM( SelectedCustomer));
                if (res.IsSucess)
                {
                    await  LoadCustomersAsync();
                     ResetAll();
                     CustomersV.ShowMsgBox("Save Changes Sucessful", "Sucess:", false);
                }
                else
                {
                     CustomersV.ShowMsgBox(res.ErrorMsg, "Error:", false);
                }
            }
        }

        private void OnAECustomerCancel()
        {
             ResetAll();
        }

        private void OnSelectCustomer()
        {
            if ( CustomersV.DGVCustomers.SelectedRows.Count == 1)
                 SelectedCustomer = (CustomerM) CustomersV.DGVCustomers.SelectedRows[0].DataBoundItem;
        }

        private async Task OnSearchButtonClickedAsync()
        {
            if (string.IsNullOrWhiteSpace( CustomersV.SearchValue) || string.IsNullOrEmpty( CustomersV.SearchValue)) return;
            RepoResultM res = await CustomersRepo.SearchCustomerAsync( CustomersV.SearchValue);
            if (res.IsSucess)
            {
                List<CustomerM> customers = new List<CustomerM>();
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    customers.Add((CustomerM)res.ResData[i]);
                }
                if (customers.Count > 0)
                {
                    CustomersV.DGVCustomers.DataSource = null;
                    CustomersV.DGVCustomers.DataSource = customers;
                    CustomersV.DGVCustomers.ClearSelection();
                }
            }
            else
            {
                await LoadCustomersAsync();
                CustomersV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
        }

        private async Task OnRefreshPVAsync()
        {
            ResetAll();
            await LoadCustomersAsync();
            await LoadCategoryListAsync();
        }

        private async Task LoadCategoryListAsync()
        {
            CustCategoryM prodCategoryM = new CustCategoryM();
            prodCategoryM.Id = 0;
            prodCategoryM.Name = "All";
            CustomersV.CBXCategoryFilter.Items.Clear();
            CustomersV.CBXCustomerCategory.Items.Clear();
            CustomersV.CBXCategoryFilter.Items.Add(prodCategoryM);
            RepoResultM res = await CustCategoriesRepo.GetCustCategoriesAsync();
            if (res.IsSucess)
            {
                CustomersV.CBXCategoryFilter.DisplayMember = "Name";
                CustomersV.CBXCategoryFilter.ValueMember = "Id";
                CustomersV.CBXCustomerCategory.DisplayMember = "Name";
                CustomersV.CBXCustomerCategory.ValueMember = "Id";
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    CustomersV.CBXCategoryFilter.Items.Add((CustCategoryM)res.ResData[i]);
                    CustomersV.CBXCustomerCategory.Items.Add((CustCategoryM)res.ResData[i]);
                    CustomersV.CBXCategoryFilter.SelectedIndex = 0;
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
            CustomersV.CBXCustomerGender.Items.Clear();
            GenderM gender1 = new GenderM();
            gender1.Id = 1;
            gender1.Name = "Male";
            CustomersV.CBXCustomerGender.Items.Add(gender1);
            GenderM gender2 = new GenderM();
            gender2.Id = 2;
            gender2.Name = "Fmale";
            CustomersV.CBXCustomerGender.Items.Add(gender2);
            CustomersV.CBXCustomerGender.DisplayMember = "Name";
            CustomersV.CBXCustomerGender.ValueMember = "Id";
            


        }
        private async Task LoadCustomersAsync()
        {
            RepoResultM res = await CustomersRepo.GetCustomersAsync();
            CustomersV.DGVCustomers.DataSource = null;
            if (res.IsSucess)
            {
                List<CustomerM> Customers = new List<CustomerM>();
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    Customers.Add((CustomerM)res.ResData[i]);
                }
                if (Customers.Count > 0)
                {
                    CustomersV.DGVCustomers.DataSource = Customers;
                    CustomersV.DGVCustomers.ClearSelection();
                }
            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    CustomersV.ShowMsgBox("The Customers List Is Empty", "Note:", false);
                    return;
                }
                CustomersV.ShowMsgBox(res.ErrorMsg, "Error:", false);
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
                    CustomersV.DGVCustomers.DataSource = null;
                    CustomersV.DGVCustomers.DataSource = productsList;
                    CustomersV.DGVCustomers.ClearSelection();
                }
            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    await  LoadCustomersAsync();
                    if ( CustomersV.CBXCategoryFilter.SelectedIndex == 0) return;
                    CustomersV.ShowMsgBox("No Customers In This Category", "Note:", false);
                    return;
                }
                CustomersV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }


        }

        private void ResetAll()
        {
            IsEdit = false;
            SelectedCustomer = null;
            CustomersV.IsAECustomerFormVisable = false;
            CustomersV.CustomerName = null;
            CustomersV.CustomerNIC = null;
        }
    }

}
