using SBMS.Models.Customers;
using SBMS.Repositories;
using SBMS.Repositories.CustomersRepo;
using SBMS.Views.Customers;
using SBMS.Views.Purchases;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SBMS.Presenters.CustomersPres
{
    class CustCategoriesVPres
    {
        ICustCategoriesV CCategoriesV;
        private bool IsEdit =false;
        private CustCategoryM SelectedCategory;
        /// <summary>
        /// 
        /// </summary>
        private static CustCategoriesVPres instance;
        public static CustCategoriesVPres GetInstance()
        {
            if (instance == null) instance = new CustCategoriesVPres();
            return instance;
        }
        /// <summary>
        /// 
        /// </summary>
        private CustCategoriesVPres()
        {
            this.CCategoriesV = CustomersHV.GetInstance();
            OnInitAsync();
        }

        private async Task OnInitAsync()
        {
            await LoadCategoriesAsync();
            CCategoriesV.ShowAddCustCategoryForm += delegate { ShowAddCustCategoryForm(); };
            CCategoriesV.ShowEditCustCategoryForm += delegate { ShowEditCustCategoryForm(); };
            CCategoriesV.OnAECategorySave += async delegate { await OnAECategorySaveAsync(); };
            CCategoriesV.OnAECategoryCancel += delegate { OnAECategoryCancel(); };
            CCategoriesV.DeleteSelectedCustCategory += async delegate {await OnDeleteSelectedCategoryAsync(); };
            CCategoriesV.OnSelectCategory += delegate { OnSelectCategory(); };
            ResetAll();
        }
        private void ShowAddCustCategoryForm()
        {
            IsEdit = false;
            CCategoriesV.IsAECtegoryFormVisable = true;
        }
        private void ShowEditCustCategoryForm()
        {
            if (SelectedCategory == null)
            {
                CCategoriesV.ShowMsgBox("Must Select Categoty To Edit From List", "Error:", false);
                return;
            }
            IsEdit = true;
            SetAllFields(this.SelectedCategory);
            CCategoriesV.IsAECtegoryFormVisable = true;
        }
        private void SetAllFields(CustCategoryM cCategory)
        {
            CCategoriesV.CCategoryName = cCategory.Name;
            CCategoriesV.CCateDescription = cCategory.Description;
        }
        private async Task OnAECategorySaveAsync()
        {
            if (IsEdit)
            {
                await EditCustCategoryAsync();
            }
            else
            {
                await AddCustCategoryAsync();
            }
        }
        private async Task AddCustCategoryAsync()
        {
            if (CCategoriesV.ShowMsgBox("Are You Sure?\nYou Want To Save", "Confirm:", true))
            {

                RepoResultM res = await CustCategoriesRepo.AddCustCategoryAsync(SetProdCategoryM(null));
                if (res.IsSucess)
                {
                    await LoadCategoriesAsync();
                    ResetAll();
                    CCategoriesV.ShowMsgBox("Save Sucessful", "Sucess:", false);
                }
                else
                {
                    CCategoriesV.ShowMsgBox(res.ErrorMsg, "Error:", false);
                }
            }
        }
        private async Task EditCustCategoryAsync()
        {
            if (CCategoriesV.ShowMsgBox("Are You Sure?\nYou Want To Save Changes", "Confirm:", true))
            {
                RepoResultM res = await CustCategoriesRepo.UpdateCustCategoryAsync(SetProdCategoryM(this.SelectedCategory));
                if (res.IsSucess)
                {
                    await LoadCategoriesAsync();
                    ResetAll();
                    CCategoriesV.ShowMsgBox("Save Changes Sucessful", "Sucess:", false);

                }
                else
                {

                    CCategoriesV.ShowMsgBox(res.ErrorMsg, "Error:", false);
                }
            }
        }
        private CustCategoryM SetProdCategoryM(CustCategoryM cCategory)
        {
            if (cCategory == null) cCategory = new CustCategoryM();
            cCategory.Name = CCategoriesV.CCategoryName;
            cCategory.Description = CCategoriesV.CCateDescription;
            return cCategory;
        }
        private void OnAECategoryCancel()
        {
            ResetAll();
        }
        private void ResetAll()
        {
            this.CCategoriesV.DGVPCustCategories.ClearSelection();
            this.SelectedCategory = null;
            this.CCategoriesV.CCategoryName = null;
            this.CCategoriesV.CCateDescription = null;
            this.CCategoriesV.IsAECtegoryFormVisable = false;
            this.IsEdit = false;
        }
        private async Task OnDeleteSelectedCategoryAsync()
        {
            if ( SelectedCategory == null)
            {
                CCategoriesV.ShowMsgBox("Must Select Categoty To Delete From List", "Error:", false);
                return;
            }
            if ( CCategoriesV.ShowMsgBox("Are You Sure, You Want To Delete It", "Confirm:", true))
            {
                RepoResultM res = await CustCategoriesRepo.DeleteCustCategoryAsync( SelectedCategory.Id);
                if (res.IsSucess)
                {
                    await LoadCategoriesAsync();
                    ResetAll();
                }
                else
                {
                    CCategoriesV.ShowMsgBox(res.ErrorMsg, "Error:", false);
                }
            }
        }
        private void OnSelectCategory()
        {
            if (this.CCategoriesV.DGVPCustCategories.SelectedRows.Count == 1)
                this.SelectedCategory = (CustCategoryM)this.CCategoriesV.DGVPCustCategories.SelectedRows[0].DataBoundItem;
        }
        private async Task LoadCategoriesAsync()
        {
            RepoResultM res = await CustCategoriesRepo.GetCustCategoriesAsync();
            this.CCategoriesV.DGVPCustCategories.DataSource = null;
            if (res.IsSucess)
            {
                List<CustCategoryM> categoriesList = new List<CustCategoryM>();
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    categoriesList.Add((CustCategoryM)res.ResData[i]);
                }

                if (categoriesList.Count > 0)
                {
                    CCategoriesV.DGVPCustCategories.DataSource = categoriesList;
                    CCategoriesV.DGVPCustCategories.ClearSelection();
                }
            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    CCategoriesV.ShowMsgBox("The Category List Is Empty", "Note:", false);
                    return;
                }
                CCategoriesV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
        }

        
    }

}
