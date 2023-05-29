using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SBMS.Views.StoresV
{
    interface IPUnitsV
    {
        bool IsAEUnitFormVisable { get; set; }
        string PUnitName { get; set; }
        string PSubUnitName { get; set; }
        string PUnitSymbol { get; set; }
        string PSubUnitSymbol { get; set; }
        string PSubUnitRate { get; set; }
        string PUnitDescription { get; set; }
        DataGridView DGVPUnits { get; set; }


        //Events Product Categories View
        event EventHandler ShowAddProdUnitForm;
        event EventHandler ShowEditProdUnitForm;
        event EventHandler DeleteSelectedProdUnit;
        event EventHandler OnAEUnitSave;
        event EventHandler OnAEUnitCancel;
        event EventHandler OnSelectUnit;
        event EventHandler OnClickUnitView;
        event EventHandler OnDisposed;

        bool ShowMsgBox(string msg, string title, bool isYesNo);
    }
}
