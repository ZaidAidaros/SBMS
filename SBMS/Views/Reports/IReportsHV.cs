using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace SBMS.Views.Reports
{
    interface IReportsHV
    {
        ReportViewer ReportsViewer { get; }

        // View Header
        event EventHandler ShowSalesReportView;
        event EventHandler ShowPurchasesReportView;
        event EventHandler ShowProductsReportView;
        event EventHandler ShowEmployeesReportView;
        event EventHandler ShowUsersReportView;

        public bool ShowMsgBox(string msg, string title, bool isYesNo);
    }
}
