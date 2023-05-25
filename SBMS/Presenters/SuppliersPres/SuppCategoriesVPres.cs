using SBMS.Models.Suppliers;
using SBMS.Repositories;
using SBMS.Repositories.SuppliersRepo;
using SBMS.Views.Suppliers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SBMS.Presenters.SuppliersPres
{
    class SuppCategoriesVPres
    {
        ISupCategoriesV SCategoriesV;
        private bool IsEdit = false;
        private SuppCategory SelectedCategory;
        /// <summary>
        /// 
        /// </summary>
        private static SuppCategoriesVPres instance;
        public static SuppCategoriesVPres GetInstance()
        {
            if (instance == null) instance = new SuppCategoriesVPres();
            return instance;
        }
        /// <summary>
        /// 
        private SuppCategoriesVPres()
        {
            this.SCategoriesV = SuppliersHV.GetInstance();
            LoadCategoriesAsync();
            this.SCategoriesV.ShowAddSuppCategoryForm += delegate { ShowAddSuppCategoryForm(); };
            this.SCategoriesV.ShowEditSuppCategoryForm += delegate { ShowEditSuppCategoryForm(); };
            this.SCategoriesV.OnAECategorySave += delegate { OnAECategorySave(); };
            this.SCategoriesV.OnAECategoryCancel += delegate { OnAECategoryCancel(); };
            this.SCategoriesV.DeleteSelectedSuppCategory += delegate { OnDeleteSelectedCategoryAsync(); };
            this.SCategoriesV.OnSelectCategory += delegate { OnSelectCategory(); };
            this.ResetAll();

        }

        private void ShowAddSuppCategoryForm()
        {
            this.IsEdit = false;
            this.SCategoriesV.IsAECtegoryFormVisable = true;
        }

        private void ShowEditSuppCategoryForm()
        {
            if (this.SelectedCategory == null)
            {
                this.SCategoriesV.ShowMsgBox("Must Select Categoty To Edit From List", "Error:", false);
                return;
            }
            this.IsEdit = true;
            this.SetAllFields(this.SelectedCategory);
            this.SCategoriesV.IsAECtegoryFormVisable = true;
        }

        private void SetAllFields(SuppCategory sCategory)
        {
            this.SCategoriesV.SCategoryName = sCategory.Name;
            this.SCategoriesV.SCateDescription = sCategory.Description;
        }

        private void OnAECategorySave()
        {
            if (IsEdit)
            {
                this.EditSuppCategoryAsync();
            }
            else
            {
                this.AddSuppCategoryAsync();
            }
        }

        private async Task AddSuppCategoryAsync()
        {
            if (this.SCategoriesV.ShowMsgBox("Are You Sure?\nYou Want To Save", "Confirm:", true))
            {

                RepoResultM res = await SuppCategoriesRepo.AddSuppCategoryAsync(SetSuppCategoryM(null));
                if (res.IsSucess)
                {
                    this.LoadCategoriesAsync();
                    this.ResetAll();
                    this.SCategoriesV.ShowMsgBox("Save Sucessful", "Sucess:", false);
                }
                else
                {
                    this.SCategoriesV.ShowMsgBox(res.ErrorMsg, "Error:", false);
                }
            }
        }

        private async Task EditSuppCategoryAsync()
        {
            if (this.SCategoriesV.ShowMsgBox("Are You Sure?\nYou Want To Save Changes", "Confirm:", true))
            {
                RepoResultM res = await SuppCategoriesRepo.UpdateSuppCategoryAsync(SetSuppCategoryM(this.SelectedCategory));
                if (res.IsSucess)
                {
                    LoadCategoriesAsync();
                    ResetAll();
                    this.SCategoriesV.ShowMsgBox("Save Changes Sucessful", "Sucess:", false);
                }
                else
                {
                    this.SCategoriesV.ShowMsgBox(res.ErrorMsg, "Error:", false);
                }
            }
        }

        private SuppCategory SetSuppCategoryM(SuppCategory sCategory)
        {
            if (sCategory == null) sCategory = new SuppCategory();
            sCategory.Name = this.SCategoriesV.SCategoryName;
            sCategory.Description = this.SCategoriesV.SCategoryName;
            return sCategory;
        }

        private void OnAECategoryCancel()
        {
            this.ResetAll();
        }

        private void ResetAll()
        {
            this.SCategoriesV.DGVPSuppCategories.ClearSelection();
            this.SelectedCategory = null;
            this.SCategoriesV.SCategoryName = null;
            this.SCategoriesV.SCateDescription = null;
            this.SCategoriesV.IsAECtegoryFormVisable = false;
            this.IsEdit = false;
        }

        private async Task OnDeleteSelectedCategoryAsync()
        {
            if (this.SelectedCategory == null)
            {
                this.SCategoriesV.ShowMsgBox("Must Select Categoty To Delete From List", "Error:", false);
                return;
            }
            if (this.SCategoriesV.ShowMsgBox("Are You Sure, You Want To Delete It", "Confirm:", true))
            {
                RepoResultM res = await SuppCategoriesRepo.DeleteSuppCategoryAsync(this.SelectedCategory.Id);
                if (res.IsSucess)
                {
                    this.LoadCategoriesAsync();
                    this.ResetAll();
                }
                else
                {
                    this.SCategoriesV.ShowMsgBox(res.ErrorMsg, "Error:", false);
                }
            }
        }

        private void OnSelectCategory()
        {
            if (this.SCategoriesV.DGVPSuppCategories.SelectedRows.Count == 1)
                this.SelectedCategory = (SuppCategory)this.SCategoriesV.DGVPSuppCategories.SelectedRows[0].DataBoundItem;
        }

        private async Task LoadCategoriesAsync()
        {
            RepoResultM res = await SuppCategoriesRepo.GetSuppCategoriesAsync();
            this.SCategoriesV.DGVPSuppCategories.DataSource = null;
            if (res.IsSucess)
            {
                List<SuppCategory> categoriesList = new List<SuppCategory>();
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    categoriesList.Add((SuppCategory)res.ResData[i]);
                }

                if (categoriesList.Count > 0)
                {
                    this.SCategoriesV.DGVPSuppCategories.DataSource = categoriesList;
                    this.SCategoriesV.DGVPSuppCategories.ClearSelection();
                }
            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    this.SCategoriesV.ShowMsgBox("The Category List Is Empty", "Note:", false);
                    return;
                }
                this.SCategoriesV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
        }

    }
}
