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
            LoadCategoriesAsync();
            this.CCategoriesV.ShowAddCustCategoryForm += delegate { ShowAddCustCategoryForm(); };
            this.CCategoriesV.ShowEditCustCategoryForm += delegate { ShowEditCustCategoryForm(); };
            this.CCategoriesV.OnAECategorySave += delegate { OnAECategorySave(); };
            this.CCategoriesV.OnAECategoryCancel += delegate { OnAECategoryCancel(); };
            this.CCategoriesV.DeleteSelectedCustCategory += delegate { OnDeleteSelectedCategoryAsync(); };
            this.CCategoriesV.OnSelectCategory += delegate { OnSelectCategory(); };
            this.ResetAll();
        }

        private void ShowAddCustCategoryForm()
        {
            this.IsEdit = false;
            this.CCategoriesV.IsAECtegoryFormVisable = true;
        }

        private void ShowEditCustCategoryForm()
        {
            if (this.SelectedCategory == null)
            {
                this.CCategoriesV.ShowMsgBox("Must Select Categoty To Edit From List", "Error:", false);
                return;
            }
            this.IsEdit = true;
            this.SetAllFields(this.SelectedCategory);
            this.CCategoriesV.IsAECtegoryFormVisable = true;
        }

        private void SetAllFields(CustCategoryM cCategory)
        {
            this.CCategoriesV.CCategoryName = cCategory.Name;
            this.CCategoriesV.CCateDescription = cCategory.Description;
        }

        private void OnAECategorySave()
        {
            if (IsEdit)
            {
                this.EditCustCategoryAsync();
            }
            else
            {
                this.AddCustCategoryAsync();
            }
        }

        private async Task AddCustCategoryAsync()
        {
            if (this.CCategoriesV.ShowMsgBox("Are You Sure?\nYou Want To Save", "Confirm:", true))
            {

                RepoResultM res = await CustCategoriesRepo.AddCustCategoryAsync(SetProdCategoryM(null));
                if (res.IsSucess)
                {
                    this.LoadCategoriesAsync();
                    this.ResetAll();
                    this.CCategoriesV.ShowMsgBox("Save Sucessful", "Sucess:", false);
                }
                else
                {
                    this.CCategoriesV.ShowMsgBox(res.ErrorMsg, "Error:", false);
                }
            }
        }

        private async Task EditCustCategoryAsync()
        {
            if (this.CCategoriesV.ShowMsgBox("Are You Sure?\nYou Want To Save Changes", "Confirm:", true))
            {
                RepoResultM res = await CustCategoriesRepo.UpdateCustCategoryAsync(SetProdCategoryM(this.SelectedCategory));
                if (res.IsSucess)
                {
                    LoadCategoriesAsync();
                    ResetAll();
                    this.CCategoriesV.ShowMsgBox("Save Changes Sucessful", "Sucess:", false);

                }
                else
                {

                    this.CCategoriesV.ShowMsgBox(res.ErrorMsg, "Error:", false);
                }
            }
        }

        private CustCategoryM SetProdCategoryM(CustCategoryM cCategory)
        {
            if (cCategory == null) cCategory = new CustCategoryM();
            cCategory.Name = this.CCategoriesV.CCategoryName;
            cCategory.Description = this.CCategoriesV.CCateDescription;
            return cCategory;
        }

        private void OnAECategoryCancel()
        {
            this.ResetAll();
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
            if (this.SelectedCategory == null)
            {
                this.CCategoriesV.ShowMsgBox("Must Select Categoty To Delete From List", "Error:", false);
                return;
            }
            if (this.CCategoriesV.ShowMsgBox("Are You Sure, You Want To Delete It", "Confirm:", true))
            {
                RepoResultM res = await CustCategoriesRepo.DeleteCustCategoryAsync(this.SelectedCategory.Id);
                if (res.IsSucess)
                {
                    this.LoadCategoriesAsync();
                    this.ResetAll();
                }
                else
                {
                    this.CCategoriesV.ShowMsgBox(res.ErrorMsg, "Error:", false);
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
                    this.CCategoriesV.DGVPCustCategories.DataSource = categoriesList;
                    this.CCategoriesV.DGVPCustCategories.ClearSelection();
                }
            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    this.CCategoriesV.ShowMsgBox("The Category List Is Empty", "Note:", false);
                    return;
                }
                this.CCategoriesV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
        }

        
    }

}
