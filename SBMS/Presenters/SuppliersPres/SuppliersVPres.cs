using SBMS.Models.Suppliers;
using SBMS.Repositories;
using SBMS.Repositories.SuppliersRepo;
using SBMS.Views.Suppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBMS.Presenters.SuppliersPres
{
    class SuppliersVPres
    {
        ISuppliersV SuppliersV;
        private bool IsEdit = false;
        private SupplierM SelectedSupplier;
        /// <summary>
        /// 
        /// </summary>
        private static SuppliersVPres instance;
        public static SuppliersVPres GetInstance()
        {
            if (instance == null) instance = new SuppliersVPres();
            return instance;
        }
        public static void Dispose()
        {
            instance = null;
        }
        private SuppliersVPres()
        {
            SuppliersV = SuppliersHV.GetInstance();
            OnInitAsync();
            
        }

        private async Task OnInitAsync()
        {
            await LoadSuppliersAsync();
            await LoadCategoryListAsync();
            SuppliersV.ShowAddSupplierForm += delegate { ShowAddSupplierForm(); };
            SuppliersV.ShowEditSupplierForm += delegate { ShowEditSupplierForm(); };
            SuppliersV.DeleteSelectedSupplier += async delegate { await DeleteSelectedSupplierAsync(); };
            SuppliersV.OnAESupplierSave += async delegate { await OnAESupplierSaveAsync(); };
            SuppliersV.OnAESupplierCancel += delegate { OnAESupplierCancel(); };
            SuppliersV.OnSelectSupplier += delegate { OnSelectSupplier(); };
            SuppliersV.OnCategoryFilterChanged += async delegate { await OnCategoryFilterChangedAsync(); };
            SuppliersV.OnSearchButtonClicked += async delegate { await OnSearchButtonClickedAsync(); };
            SuppliersV.OnVRefresh += delegate { OnRefreshSVAsync(); };
            SuppliersV.OnDisposed += delegate { Dispose(); };
        }

        private void ShowAddSupplierForm()
        {
            IsEdit = false;
            SuppliersV.IsAESupplierFormVisable = true;
        }

        private void ShowEditSupplierForm()
        {
            if ( SelectedSupplier == null)
            {
                SuppliersV.ShowMsgBox("Must Select Product To Edit From List.", "Error:", false);
                return;
            }
            IsEdit = true;
            SetFields();
            SuppliersV.IsAESupplierFormVisable = true;
        }

        private void SetFields()
        {
            SuppliersV.SupplierName = SelectedSupplier.Name;
            SuppliersV.SupplierPhone = SelectedSupplier.Phone;
            SuppliersV.SupplierAddress = SelectedSupplier.Address;
            for (int i = 0; i < SuppliersV.CBXSupplierCategory.Items.Count; i++)
            {
                if (((SuppCategory) SuppliersV.CBXSupplierCategory.Items[i]).Name ==  SelectedSupplier.Category)
                {
                    SuppliersV.CBXSupplierCategory.SelectedIndex = i;
                    break;
                }
            }
        }

        private async Task DeleteSelectedSupplierAsync()
        {
            if ( SelectedSupplier == null)
            {
                SuppliersV.ShowMsgBox("Must Select Unit To Delete From List", "Error:", false);
                return;
            }
            if ( SuppliersV.ShowMsgBox("Are You Sure?\n You Want To Delete It", "Confirm:", true))
            {
                RepoResultM res = await SuppliersRepo.DeleteCustomerAsync( SelectedSupplier.Id);
                if (res.IsSucess)
                {
                    await LoadSuppliersAsync();
                    ResetAll();
                }
                else
                {
                    SuppliersV.ShowMsgBox(res.ErrorMsg, "Error:", false);
                }
            }
        }

        private async Task OnAESupplierSaveAsync()
        {

            if ( IsEdit)
            {
                await EditSupplierAsync();
            }
            else
            {
                await AddSupplierAsync();
            }
        }

        private async Task AddSupplierAsync()
        {

            if (SuppliersV.ShowMsgBox("Are You Sure?\nYou Want To Save", "Confirm:", true))
            {
                RepoResultM res = await SuppliersRepo.AddCustomerAsync(SetCustomerM(null));
                if (res.IsSucess)
                {
                    await LoadSuppliersAsync();
                    ResetAll();
                    SuppliersV.ShowMsgBox("Save Sucessful", "Sucess:", false);
                }
                else
                {
                    SuppliersV.ShowMsgBox(res.ErrorMsg, "Error:", false);
                }
            }
        }

        private SupplierM SetCustomerM(SupplierM supplier)
        {
            if (supplier == null) supplier = new SupplierM();
            supplier.Name = SuppliersV.SupplierName;
            supplier.Phone = SuppliersV.SupplierPhone;
            supplier.Address = SuppliersV.SupplierAddress;
            supplier.CategoryId = ((SuppCategory) SuppliersV.CBXSupplierCategory.SelectedItem).Id;
            supplier.Category = ((SuppCategory) SuppliersV.CBXSupplierCategory.SelectedItem).Name;
            return supplier;
        }

        private async Task EditSupplierAsync()
        {

            if (SuppliersV.ShowMsgBox("Are You Sure?\nYou Want To Save Changes", "Confirm:", true))
            {
                RepoResultM res = await SuppliersRepo.UpdateCustomerAsync(SetCustomerM(SelectedSupplier));
                if (res.IsSucess)
                {
                    await LoadSuppliersAsync();
                    ResetAll();
                    SuppliersV.ShowMsgBox("Save Changes Sucessful", "Sucess:", false);
                }
                else
                {
                    SuppliersV.ShowMsgBox(res.ErrorMsg, "Error:", false);
                }
            }
        }

        private void OnAESupplierCancel()
        {
             ResetAll();
        }

        private void OnSelectSupplier()
        {
            if ( SuppliersV.DGVSuppliers.SelectedRows.Count == 1)
                SelectedSupplier = (SupplierM)this.SuppliersV.DGVSuppliers.SelectedRows[0].DataBoundItem;
        }

        private async Task OnSearchButtonClickedAsync()
        {
            if (string.IsNullOrWhiteSpace( SuppliersV.SearchValue) || string.IsNullOrEmpty( SuppliersV.SearchValue)) return;
            RepoResultM res = await SuppliersRepo.SearchSupplierAsync( SuppliersV.SearchValue);
            if (res.IsSucess)
            {
                List<SupplierM> customers = new List<SupplierM>();
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    customers.Add((SupplierM)res.ResData[i]);
                }
                if (customers.Count > 0)
                {
                    SuppliersV.DGVSuppliers.DataSource = null;
                    SuppliersV.DGVSuppliers.DataSource = customers;
                    SuppliersV.DGVSuppliers.ClearSelection();
                }
            }
            else
            {
                await LoadSuppliersAsync();
                SuppliersV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
        }

        private async Task OnRefreshSVAsync()
        {
            this.ResetAll();
            await LoadSuppliersAsync();
            await LoadCategoryListAsync();
        }

        private async Task LoadCategoryListAsync()
        {
            SuppCategory prodCategoryM = new SuppCategory();
            prodCategoryM.Id = 0;
            prodCategoryM.Name = "All";
            SuppliersV.CBXCategoryFilter.Items.Clear();
            SuppliersV.CBXSupplierCategory.Items.Clear();
            SuppliersV.CBXCategoryFilter.Items.Add(prodCategoryM);
            RepoResultM res = await SuppCategoriesRepo.GetSuppCategoriesAsync();
            if (res.IsSucess)
            {
                SuppliersV.CBXCategoryFilter.DisplayMember = "Name";
                SuppliersV.CBXCategoryFilter.ValueMember = "Id";
                SuppliersV.CBXSupplierCategory.DisplayMember = "Name";
                SuppliersV.CBXSupplierCategory.ValueMember = "Id";
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    SuppliersV.CBXCategoryFilter.Items.Add((SuppCategory)res.ResData[i]);
                    SuppliersV.CBXSupplierCategory.Items.Add((SuppCategory)res.ResData[i]);
                    SuppliersV.CBXCategoryFilter.SelectedIndex = 0;
                }

            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    SuppliersV.ShowMsgBox("The Category List Is Empty", "Note:", false);
                    return;
                }
                SuppliersV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
        }

        private async Task LoadSuppliersAsync()
        {
            RepoResultM res = await SuppliersRepo.GetSuppliersAsync();
            SuppliersV.DGVSuppliers.DataSource = null;
            if (res.IsSucess)
            {
                List<SupplierM> Suppliers = new List<SupplierM>();
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    Suppliers.Add((SupplierM)res.ResData[i]);
                }
                if (Suppliers.Count > 0)
                {
                    SuppliersV.DGVSuppliers.DataSource = Suppliers;
                    SuppliersV.DGVSuppliers.ClearSelection();
                }
            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    SuppliersV.ShowMsgBox("The Suppliers List Is Empty", "Note:", false);
                    return;
                }
                SuppliersV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
        }
        private async Task OnCategoryFilterChangedAsync()
        {
            RepoResultM res = await SuppliersRepo.FilterSuppliersByCategoryAsync(((SuppCategory) SuppliersV.CBXCategoryFilter.SelectedItem).Id);

            if (res.IsSucess)
            {
                List<SupplierM> productsList = new List<SupplierM>();
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    productsList.Add((SupplierM)res.ResData[i]);
                }
                if (productsList.Count > 0)
                {
                    SuppliersV.DGVSuppliers.DataSource = null;
                    SuppliersV.DGVSuppliers.DataSource = productsList;
                    SuppliersV.DGVSuppliers.ClearSelection();
                }
            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    await LoadSuppliersAsync();
                    if ( SuppliersV.CBXCategoryFilter.SelectedIndex == 0) return;
                    SuppliersV.ShowMsgBox("No Supplier In This Category", "Note:", false);
                    return;
                }
                SuppliersV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }


        }

        private void ResetAll()
        {
            IsEdit = false;
            SuppliersV.IsAESupplierFormVisable = false;
            SuppliersV.SupplierName = null;
            SuppliersV.SupplierPhone = null;
            SuppliersV.SupplierAddress = null;
        }
    }
}
