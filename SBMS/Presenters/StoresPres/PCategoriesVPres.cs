using SBMS.Models.Stores;
using SBMS.Repositories;
using SBMS.Repositories.StoresRepo;
using SBMS.Views.StoresV;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SBMS.Presenters.StoresPres
{
    class PCategoriesVPres
    {
        IPCategoriesV PCategoriesV;

        private bool IsEdit = false;
        private ProdCategoryM SelectedCategory;


        // Singletone
        private static PCategoriesVPres instance;
        public static PCategoriesVPres GetInstance()
        {
            if (instance == null) instance = new PCategoriesVPres();
            return instance;
        }
        private PCategoriesVPres()
        {
            this.PCategoriesV = StoresV.GetInstance();
            LoadCategoriesAsync();
            this.PCategoriesV.ShowAddProdCategoryForm += delegate { ShowAddPCategoryForm(); };
            this.PCategoriesV.ShowEditProdCategoryForm += delegate { ShowEditPCategoryForm(); };
            this.PCategoriesV.OnAECategorySave += delegate { OnAECategorySave(); };
            this.PCategoriesV.OnAECategoryCancel += delegate { OnAECategoryCancel(); };
            this.PCategoriesV.DeleteSelectedProdCategory += delegate { OnDeleteSelectedCategoryAsync(); };
            this.PCategoriesV.OnSelectCategory += delegate { OnSelectCategory(); };
            this.PCategoriesV.OnClickCategoriesView += delegate { OnClicCategoriesView(); };
            
        }

        // Fetch Data
        private async Task LoadCategoriesAsync()
        {
            RepoResultM res = await ProdCategoriesRepo.GetProdCategoriesAsync();
            this.PCategoriesV.DGVPCategories.DataSource = null;
            if (res.IsSucess)
            {
                List<ProdCategoryM> categoriesList = new List<ProdCategoryM>();
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    categoriesList.Add((ProdCategoryM)res.ResData[i]);
                }
                
                if (categoriesList.Count > 0)
                {
                    this.PCategoriesV.DGVPCategories.DataSource = categoriesList;
                    this.PCategoriesV.DGVPCategories.ClearSelection();
                }                
            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    this.PCategoriesV.ShowMsgBox("The Category List Is Empty", "Note:", false);
                    return;
                }
                this.PCategoriesV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
        }

        private void ShowAddPCategoryForm()
        {
            IsEdit = false;
            this.PCategoriesV.IsAECtegoryFormVisable = true;
        }

        private void ShowEditPCategoryForm()
        {
            if (this.SelectedCategory == null)
            {
                this.PCategoriesV.ShowMsgBox("Must Select Categoty To Edit From List", "Error:",false);
                return;
            }
            IsEdit = true;
            SetAllFields(this.SelectedCategory);
            this.PCategoriesV.IsAECtegoryFormVisable = true;
        }

        private void SetAllFields(ProdCategoryM prodCategoryM)
        {
            this.PCategoriesV.PCategoryName = prodCategoryM.Name;
            this.PCategoriesV.PCateDescription = prodCategoryM.Description;
        }

        async Task AddProdCategoryAsync()
        {
            if (this.PCategoriesV.ShowMsgBox("Are You Sure?\nYou Want To Save", "Confirm:",true))
            {
                
                RepoResultM res = await ProdCategoriesRepo.AddProdCategoryAsync(SetProdCategoryM(null));
                if (res.IsSucess)
                {
                    LoadCategoriesAsync();
                    ResetAll();
                    this.PCategoriesV.ShowMsgBox("Save Sucessful", "Sucess:",false);
                }
                else
                {
                    this.PCategoriesV.ShowMsgBox(res.ErrorMsg, "Error:",false);
                }
            }
            
        }

        private ProdCategoryM SetProdCategoryM(ProdCategoryM prodCategoryM)
        {
            if(prodCategoryM==null) prodCategoryM = new ProdCategoryM();
            prodCategoryM.Name = this.PCategoriesV.PCategoryName;
            prodCategoryM.Description = this.PCategoriesV.PCateDescription;
            return prodCategoryM;
        }
        private async Task EditPCategoryAsync()
        {
            if (this.PCategoriesV.ShowMsgBox("Are You Sure?\nYou Want To Save Changes", "Confirm:",true))
            {
                RepoResultM res = await ProdCategoriesRepo.UpdateProdCategoryAsync(SetProdCategoryM(this.SelectedCategory));
                if (res.IsSucess)
                {
                    LoadCategoriesAsync();
                    ResetAll();
                    this.PCategoriesV.ShowMsgBox("Save Changes Sucessful", "Sucess:",false);
                    
                }
                else
                {

                    this.PCategoriesV.ShowMsgBox(res.ErrorMsg, "Error:",false);
                }
            }
        }
        private void OnAECategorySave()
        {
            if (IsEdit)
            {
                this.EditPCategoryAsync();
            }
            else
            {
                this.AddProdCategoryAsync();
            }

        }
        private void OnAECategoryCancel()
        {
            this.ResetAll();
        }

        private async Task OnDeleteSelectedCategoryAsync()
        {
            if (this.SelectedCategory == null)
            {
                this.PCategoriesV.ShowMsgBox("Must Select Categoty To Delete From List", "Error:",false);
                return;
            }
            if (this.PCategoriesV.ShowMsgBox("Are You Sure, You Want To Delete It","Confirm:",true))
            {
                RepoResultM res = await ProdCategoriesRepo.DeleteProdCategoryAsync(this.SelectedCategory.Id);
                if (res.IsSucess)
                {
                    this.LoadCategoriesAsync();
                    this.ResetAll();
                }
                else
                {
                    this.PCategoriesV.ShowMsgBox(res.ErrorMsg, "Error:", false);
                }
            }
        }

        void OnSelectCategory()
        {
            if(this.PCategoriesV.DGVPCategories.SelectedRows.Count==1)
                this.SelectedCategory = (ProdCategoryM)this.PCategoriesV.DGVPCategories.SelectedRows[0].DataBoundItem;
        }
        private void OnClicCategoriesView()
        {
            this.PCategoriesV.DGVPCategories.ClearSelection();
        }

        void ResetAll()
        {
            this.PCategoriesV.DGVPCategories.ClearSelection();
            this.SelectedCategory = null;
            this.PCategoriesV.PCategoryName = null;
            this.PCategoriesV.PCateDescription = null;
            this.PCategoriesV.IsAECtegoryFormVisable = false;
            this.IsEdit = false;
            
        }
    }
}
