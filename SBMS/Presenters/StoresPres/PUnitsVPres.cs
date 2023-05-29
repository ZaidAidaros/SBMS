using SBMS.Models.Stores;
using SBMS.Repositories;
using SBMS.Repositories.StoresRepo;
using SBMS.Views.StoresV;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SBMS.Presenters.StoresPres
{
    class PUnitsVPres
    {
        IPUnitsV PUnitsV;
        private ProdUnitM SelectedUnit;
        private bool IsEdit;

        // Singletone
        private static PUnitsVPres instance;
        public static PUnitsVPres GetInstance()
        {
            if (instance == null) instance = new PUnitsVPres();
            return instance;
        }
        public static void Dispose()
        {
            instance = null;
        }
        private PUnitsVPres()
        {
            PUnitsV = StoresV.GetInstance();
            OnInitAsync();
            
        }

        private async Task OnInitAsync()
        {
            await LoadUnitsAsync();
            this.PUnitsV.ShowAddProdUnitForm += delegate { ShowAddUnitForm(); };
            this.PUnitsV.ShowEditProdUnitForm += delegate { ShowEditUnitForm(); };
            this.PUnitsV.DeleteSelectedProdUnit +=async delegate { await OnDeleteSelectedUnitAsync(); };
            this.PUnitsV.OnAEUnitSave += delegate { OnAEUintSave(); };
            this.PUnitsV.OnAEUnitCancel += delegate { OnAEUnitCancel(); };
            this.PUnitsV.OnSelectUnit += delegate { OnSelectUnit(); };
            this.PUnitsV.OnClickUnitView += delegate { OnClickUnitView(); };
            this.PUnitsV.OnDisposed += delegate { Dispose(); };
        }

        private async Task LoadUnitsAsync()
        {
            RepoResultM res = await ProdUnitsRepo.GetProdUnitsAsync();
            this.PUnitsV.DGVPUnits.DataSource = null;
            if (res.IsSucess)
            {
                List<ProdUnitM> unitsList = new List<ProdUnitM>();
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    unitsList.Add((ProdUnitM)res.ResData[i]);
                }
                
                if (unitsList.Count > 0)
                {
                    this.PUnitsV.DGVPUnits.DataSource = unitsList;
                    this.PUnitsV.DGVPUnits.ClearSelection();
                }
            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    this.PUnitsV.ShowMsgBox("The Unit List Is Empty", "Note:", false);
                    return;
                }
                this.PUnitsV.ShowMsgBox(res.ErrorMsg, "Error:",false);
            }
        }


        private void OnClickUnitView()
        {
            this.PUnitsV.DGVPUnits.ClearSelection();
        }

        private void OnSelectUnit()
        {
            if (this.PUnitsV.DGVPUnits.SelectedRows.Count == 1)
                this.SelectedUnit = (ProdUnitM) this.PUnitsV.DGVPUnits.SelectedRows[0].DataBoundItem;
        }

        private void OnAEUintSave()
        {
            if (this.IsEdit)
            {
                this.EditUnitAsync();
            }
            else
            {
                this.AddUnitAsync();
            }
        }

        private async Task AddUnitAsync()
        {
            if (this.PUnitsV.ShowMsgBox("Are You Sure?\nYou Want To Save", "Confirm:",true))
            {
                RepoResultM res = await ProdUnitsRepo.AddProdUnitAsync(this.SetPUnitM(null));
                if (res.IsSucess)
                {
                    this.LoadUnitsAsync();
                    this.ResetAll();
                    this.PUnitsV.ShowMsgBox("Save Sucessful", "Sucess:", false);
                }
                else
                {
                    this.PUnitsV.ShowMsgBox(res.ErrorMsg, "Error:",false);
                }
            }
        }

        private ProdUnitM SetPUnitM(ProdUnitM prodUnitM)
        {
            if(prodUnitM==null) prodUnitM = new ProdUnitM();
            prodUnitM.Name = this.PUnitsV.PUnitName;
            prodUnitM.SubUnitName = this.PUnitsV.PSubUnitName;
            prodUnitM.Symbole = this.PUnitsV.PUnitSymbol;
            prodUnitM.SubUnitSymbole = this.PUnitsV.PSubUnitSymbol;
            prodUnitM.Description = this.PUnitsV.PUnitDescription;
            prodUnitM.RateMainBranch = int.Parse(this.PUnitsV.PSubUnitRate);

            return prodUnitM;
            
        }

        private async Task EditUnitAsync()
        {
            if (this.PUnitsV.ShowMsgBox("Are You Sure?\nYou Want To Save Changes", "Confirm:",true))
            {
                RepoResultM res = await ProdUnitsRepo.UpdateProdUnitAsync(this.SetPUnitM(this.SelectedUnit));
                if (res.IsSucess)
                {
                    this.LoadUnitsAsync();
                    this.ResetAll();
                    this.PUnitsV.ShowMsgBox("Save Changes Sucessful", "Sucess:", false);
                }
                else
                {
                    this.PUnitsV.ShowMsgBox(res.ErrorMsg, "Error:", false);
                }
            }
        }

        private void OnAEUnitCancel()
        {
            this.ResetAll();
        }

        private async Task OnDeleteSelectedUnitAsync()
        {
            if (this.SelectedUnit == null)
            {
                this.PUnitsV.ShowMsgBox("Must Select Unit To Delete From List", "Error:", false);
                return;
            }
            if (this.PUnitsV.ShowMsgBox("Are You Sure?\n You Want To Delete It", "Confirm:",true))
            {
                RepoResultM res = await ProdUnitsRepo.DeleteProdUnitAsync(this.SelectedUnit.Id);
                if (res.IsSucess)
                {
                    this.LoadUnitsAsync();
                    this.ResetAll();
                }
                else
                {
                    this.PUnitsV.ShowMsgBox(res.ErrorMsg, "Error:", false);
                }
            }
        }



        private void ShowAddUnitForm()
        {
            this.IsEdit = false;
            this.PUnitsV.IsAEUnitFormVisable = true;
        }
        private void ShowEditUnitForm()
        {
            if (this.SelectedUnit == null)
            {
                this.PUnitsV.ShowMsgBox("Must Select Unit To Edit..", "Error:", false);
                return;
            }
            this.IsEdit = true;
            this.SetAllFields(this.SelectedUnit);
            this.PUnitsV.IsAEUnitFormVisable = true;
        }

        private void SetAllFields(ProdUnitM prodUnitM)
        {
            this.PUnitsV.PUnitName = prodUnitM.Name;
            this.PUnitsV.PSubUnitName = prodUnitM.SubUnitName;
            this.PUnitsV.PUnitSymbol = prodUnitM.Symbole;
            this.PUnitsV.PSubUnitSymbol = prodUnitM.SubUnitSymbole;
            this.PUnitsV.PUnitDescription = prodUnitM.Description;
            this.PUnitsV.PSubUnitRate = prodUnitM.RateMainBranch.ToString();
        }

        private void ResetAll()
        {
            this.PUnitsV.IsAEUnitFormVisable = false;
            this.SelectedUnit = null;
            this.PUnitsV.DGVPUnits.ClearSelection();
            this.PUnitsV.PUnitName = null;
            this.PUnitsV.PSubUnitName = null;
            this.PUnitsV.PUnitSymbol = null;
            this.PUnitsV.PSubUnitSymbol = null;
            this.PUnitsV.PUnitDescription = null;
            this.PUnitsV.PSubUnitRate = null;
            this.IsEdit = false;
        }

    }
}
