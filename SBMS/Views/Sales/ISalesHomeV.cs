using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SBMS.Views.Sales
{
    interface ISalesHomeV
    {
        string HeaderTitle { get; set; }
        string UserName { get; set; }
        string StuffName { get; set; }
        // View Header
        event EventHandler ShowNewSalesInvView;
        event EventHandler ShowNewRetSalesInvView;
        event EventHandler ShowSalesView;
        event EventHandler OnClose;
    }


}
