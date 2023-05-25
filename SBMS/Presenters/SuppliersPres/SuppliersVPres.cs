using SBMS.Models.Suppliers;
using SBMS.Repositories;
using SBMS.Repositories.SuppliersRepo;
using SBMS.Views.Suppliers;
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
        /// <summary>
        /// 
        /// </summary>
        /// 
        private SuppliersVPres()
        {
            this.SuppliersV = SuppliersHV.GetInstance();
            this.LoadSuppliersAsync();
            this.LoadCategoryListAsync();
            this.SuppliersV.ShowAddSupplierForm += delegate { this.ShowAddSupplierForm(); };
            this.SuppliersV.ShowEditSupplierForm += delegate { this.ShowEditSupplierForm(); };
            this.SuppliersV.DeleteSelectedSupplier += delegate { this.DeleteSelectedSupplierAsync(); };
            this.SuppliersV.OnAESupplierSave += delegate { this.OnAESupplierSave(); };
            this.SuppliersV.OnAESupplierCancel += delegate { OnAESupplierCancel(); };
            this.SuppliersV.OnSelectSupplier += delegate { this.OnSelectSupplier(); };
            this.SuppliersV.OnCategoryFilterChanged += delegate { OnCategoryFilterChangedAsync(); };
            this.SuppliersV.OnSearchButtonClicked += delegate { OnSearchButtonClickedAsync(); };
            this.SuppliersV.OnVRefresh += delegate { OnRefreshSV(); };
        }

        private void ShowAddSupplierForm()
        {
            this.IsEdit = false;
            this.SuppliersV.IsAESupplierFormVisable = true;
        }

        private void ShowEditSupplierForm()
        {
            if (this.SelectedSupplier == null)
            {
                this.SuppliersV.ShowMsgBox("Must Select Product To Edit From List.", "Error:", false);
                return;
            }
            this.IsEdit = true;
            this.SetFields();
            this.SuppliersV.IsAESupplierFormVisable = true;
        }

        private void SetFields()
        {
            this.SuppliersV.SupplierName = this.SelectedSupplier.Name;
            this.SuppliersV.SupplierPhone = this.SelectedSupplier.Phone;
            this.SuppliersV.SupplierAddress = this.SelectedSupplier.Address;
            for (int i = 0; i < this.SuppliersV.CBXSupplierCategory.Items.Count; i++)
            {
                if (((SuppCategory)this.SuppliersV.CBXSupplierCategory.Items[i]).Name == this.SelectedSupplier.Category)
                {
                    this.SuppliersV.CBXSupplierCategory.SelectedIndex = i;
                    break;
                }
            }
        }

        private async Task DeleteSelectedSupplierAsync()
        {
            if (this.SelectedSupplier == null)
            {
                this.SuppliersV.ShowMsgBox("Must Select Unit To Delete From List", "Error:", false);
                return;
            }
            if (this.SuppliersV.ShowMsgBox("Are You Sure?\n You Want To Delete It", "Confirm:", true))
            {
                RepoResultM res = await SuppliersRepo.DeleteCustomerAsync(this.SelectedSupplier.Id);
                if (res.IsSucess)
                {
                    this.LoadSuppliersAsync();
                    this.ResetAll();
                }
                else
                {
                    this.SuppliersV.ShowMsgBox(res.ErrorMsg, "Error:", false);
                }
            }
        }

        private void OnAESupplierSave()
        {

            if (this.IsEdit)
            {
                this.EditSupplierAsync();
            }
            else
            {
                this.AddSupplierAsync();
            }
        }

        private async Task AddSupplierAsync()
        {

            if (this.SuppliersV.ShowMsgBox("Are You Sure?\nYou Want To Save", "Confirm:", true))
            {
                RepoResultM res = await SuppliersRepo.AddCustomerAsync(SetCustomerM(null));
                if (res.IsSucess)
                {
                    this.LoadSuppliersAsync();
                    this.ResetAll();
                    this.SuppliersV.ShowMsgBox("Save Sucessful", "Sucess:", false);
                }
                else
                {
                    this.SuppliersV.ShowMsgBox(res.ErrorMsg, "Error:", false);
                }
            }
        }

        private SupplierM SetCustomerM(SupplierM supplier)
        {
            if (supplier == null) supplier = new SupplierM();
            supplier.Name = this.SuppliersV.SupplierName;
            supplier.Phone = this.SuppliersV.SupplierPhone;
            supplier.Address = this.SuppliersV.SupplierAddress;
            supplier.CategoryM = (SuppCategory)this.SuppliersV.CBXSupplierCategory.SelectedItem;
            return supplier;
        }

        private async Task EditSupplierAsync()
        {

            if (this.SuppliersV.ShowMsgBox("Are You Sure?\nYou Want To Save Changes", "Confirm:", true))
            {
                RepoResultM res = await SuppliersRepo.UpdateCustomerAsync(SetCustomerM(this.SelectedSupplier));
                if (res.IsSucess)
                {
                    this.LoadSuppliersAsync();
                    this.ResetAll();
                    this.SuppliersV.ShowMsgBox("Save Changes Sucessful", "Sucess:", false);
                }
                else
                {
                    this.SuppliersV.ShowMsgBox(res.ErrorMsg, "Error:", false);
                }
            }
        }

        private void OnAESupplierCancel()
        {
            this.ResetAll();
        }

        private void OnSelectSupplier()
        {
            if (this.SuppliersV.DGVSuppliers.SelectedRows.Count == 1)
                this.SelectedSupplier = (SupplierM)this.SuppliersV.DGVSuppliers.SelectedRows[0].DataBoundItem;
        }

        private async Task OnSearchButtonClickedAsync()
        {
            if (string.IsNullOrWhiteSpace(this.SuppliersV.SearchValue) || string.IsNullOrEmpty(this.SuppliersV.SearchValue)) return;
            RepoResultM res = await SuppliersRepo.SearchSupplierAsync(this.SuppliersV.SearchValue);
            if (res.IsSucess)
            {
                List<ISupplierM> customers = new List<ISupplierM>();
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    customers.Add((ISupplierM)res.ResData[i]);
                }
                if (customers.Count > 0)
                {
                    this.SuppliersV.DGVSuppliers.DataSource = null;
                    this.SuppliersV.DGVSuppliers.DataSource = customers;
                    this.SuppliersV.DGVSuppliers.ClearSelection();
                }
            }
            else
            {
                this.LoadSuppliersAsync();
                this.SuppliersV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
        }

        private void OnRefreshSV()
        {
            this.ResetAll();
            this.LoadSuppliersAsync();
            this.LoadCategoryListAsync();
        }

        private async Task LoadCategoryListAsync()
        {
            SuppCategory prodCategoryM = new SuppCategory();
            prodCategoryM.Id = 0;
            prodCategoryM.Name = "All";
            this.SuppliersV.CBXCategoryFilter.Items.Clear();
            this.SuppliersV.CBXSupplierCategory.Items.Clear();
            this.SuppliersV.CBXCategoryFilter.Items.Add(prodCategoryM);
            RepoResultM res = await SuppCategoriesRepo.GetSuppCategoriesAsync();
            if (res.IsSucess)
            {
                this.SuppliersV.CBXCategoryFilter.DisplayMember = "Name";
                this.SuppliersV.CBXCategoryFilter.ValueMember = "Id";
                this.SuppliersV.CBXSupplierCategory.DisplayMember = "Name";
                this.SuppliersV.CBXSupplierCategory.ValueMember = "Id";
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    this.SuppliersV.CBXCategoryFilter.Items.Add((SuppCategory)res.ResData[i]);
                    this.SuppliersV.CBXSupplierCategory.Items.Add((SuppCategory)res.ResData[i]);
                    this.SuppliersV.CBXCategoryFilter.SelectedIndex = 0;
                }

            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    this.SuppliersV.ShowMsgBox("The Category List Is Empty", "Note:", false);
                    return;
                }
                this.SuppliersV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
        }


        private async Task LoadSuppliersAsync()
        {
            RepoResultM res = await SuppliersRepo.GetSuppliersAsync();
            this.SuppliersV.DGVSuppliers.DataSource = null;
            if (res.IsSucess)
            {
                List<ISupplierM> Suppliers = new List<ISupplierM>();
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    Suppliers.Add((ISupplierM)res.ResData[i]);
                }
                if (Suppliers.Count > 0)
                {
                    this.SuppliersV.DGVSuppliers.DataSource = Suppliers;
                    this.SuppliersV.DGVSuppliers.ClearSelection();
                }
            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    this.SuppliersV.ShowMsgBox("The Suppliers List Is Empty", "Note:", false);
                    return;
                }
                this.SuppliersV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
        }
        private async Task OnCategoryFilterChangedAsync()
        {
            RepoResultM res = await SuppliersRepo.FilterSuppliersByCategoryAsync(((SuppCategory)this.SuppliersV.CBXCategoryFilter.SelectedItem).Id);

            if (res.IsSucess)
            {
                List<ISupplierM> productsList = new List<ISupplierM>();
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    productsList.Add((ISupplierM)res.ResData[i]);
                }
                if (productsList.Count > 0)
                {
                    this.SuppliersV.DGVSuppliers.DataSource = null;
                    this.SuppliersV.DGVSuppliers.DataSource = productsList;
                    this.SuppliersV.DGVSuppliers.ClearSelection();
                }
            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    this.LoadSuppliersAsync();
                    if (this.SuppliersV.CBXCategoryFilter.SelectedIndex == 0) return;
                    this.SuppliersV.ShowMsgBox("No Supplier In This Category", "Note:", false);
                    return;
                }
                this.SuppliersV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }


        }

        private void ResetAll()
        {
            this.IsEdit = false;
            this.SuppliersV.IsAESupplierFormVisable = false;
            this.SuppliersV.SupplierName = null;
            this.SuppliersV.SupplierPhone = null;
            this.SuppliersV.SupplierAddress = null;
        }
    }
}
