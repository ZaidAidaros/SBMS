using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SBMS.Views.Purchases
{
    interface ISuppliersV
    {
        string SupplierName { get; set; }
        string SupplierPhone { get; set; }
        string SupplierAddress { get; set; }
        string SearchValue { get; set; }
        ComboBox CBXSupplierCategory { get; set; }
        ComboBox CBXCategoryFilter { get; set; }
        bool IsAESupplierFormVisable { get; set; }
        DataGridView DGVSuppliers { get; set; }

        event EventHandler ShowAddSupplierForm;
        event EventHandler ShowEditSupplierForm;
        event EventHandler DeleteSelectedSupplier;
        event EventHandler OnCategoryFilterChanged;
        event EventHandler OnSearchButtonClicked;
        event EventHandler OnSelectSupplier;
        event EventHandler OnAESupplierSave;
        event EventHandler OnAESupplierCancel;
        event EventHandler OnVRefresh;




        bool ShowMsgBox(string msg, string title, bool isYesNo);
    }
}
