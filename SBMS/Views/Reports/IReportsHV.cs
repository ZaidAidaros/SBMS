using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace SBMS.Views.Reports
{
    interface IReportsHV
    {
        string InvName { get; }
        string InvTotal { get; }
        string FromDate { get; }
        string ToDate { get; }
        ReportViewer ReportsViewer { get; }
        Panel invContorolPanel { get; }

        // View Header
        event EventHandler ShowSalesReportView;
        event EventHandler ShowPurchasesReportView;
        event EventHandler ShowProductsReportView;
        event EventHandler ShowEmployeesReportView;
        event EventHandler ShowUsersReportView;
        event EventHandler ShowCustomersReportView;
        event EventHandler ShowSuppliersReportView;
        event EventHandler OnReloadReport;
        event EventHandler OnDisposed;

        public bool ShowMsgBox(string msg, string title, bool isYesNo);
    }
}
