using Microsoft.Reporting.WinForms;
using SBMS.Models.Customers;
using SBMS.Models.Employees;
using SBMS.Models.General;
using SBMS.Models.Stores;
using SBMS.Models.Suppliers;
using SBMS.Models.Users;
using SBMS.Repositories;
using SBMS.Repositories.CustomersRepo;
using SBMS.Repositories.EmployeesRepo;
using SBMS.Repositories.PurchasesRepo;
using SBMS.Repositories.SalesRepo;
using SBMS.Repositories.StoresRepo;
using SBMS.Repositories.SuppliersRepo;
using SBMS.Views.Reports;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SBMS.Presenters.ReportsPres
{
    class ReportsHVPres
    {
        IReportsHV reportsHV;
        ReportDataSource reportDataSource;

        const string EmployeesDataSet = "EmployeesDataSet";
        const string UsersDataSet = "UsersDataSet";
        const string ProductsDataSet = "ProductsDataSet";
        const string SalesDataSet = "SalesDataSet";
        const string PurchasesDataSet = "PurchasesDataSet";
        const string CustomersDataSet = "CustomersDataSet";
        const string SuppliersDataSet = "SuppliersDataSet";

        const string EmployeesReport = "SBMS.Views.Reports.EmployeesReport.rdlc";
        const string UsersReport = "SBMS.Views.Reports.UsersReport.rdlc";
        const string ProductsReport = "SBMS.Views.Reports.ProductsReport.rdlc";
        const string SalesReport = "SBMS.Views.Reports.SalesReport.rdlc";
        const string PurchasesReport = "SBMS.Views.Reports.PurchasesReport.rdlc";
        const string CustomersReport = "SBMS.Views.Reports.CustomersReport.rdlc";
        const string SuppliersReport = "SBMS.Views.Reports.SuppliersReport.rdlc";


        private ReportsHVPres()
        {
            reportsHV = ReportsHV.GetInstance();
            reportDataSource = new ReportDataSource();
            reportsHV.ReportsViewer.LocalReport.DataSources.Add(reportDataSource);
            ReportsHV.GetInstance().Show();
            OnInit();
            
        }
        private static ReportsHVPres instance;
        public static ReportsHVPres GetInstance()
        {
            if (instance == null) instance = new ReportsHVPres();
            return instance;
        }
        public static void Dispose()
        {
            instance = null;
        }
        private void OnInit()
        {
            reportsHV.ShowSalesReportView += async delegate { await ShowSalesReportViewAsync(); };
            reportsHV.ShowPurchasesReportView += async delegate { await ShowPurchasesReportViewAsync(); };
            reportsHV.ShowProductsReportView += async delegate { await ShowProductsReportViewAsync(); };
            reportsHV.ShowEmployeesReportView += async delegate { await ShowEmployeesReportViewAsync(); };
            reportsHV.ShowUsersReportView += async delegate { await ShowUsersReportViewAsync(); };
            reportsHV.ShowCustomersReportView += async delegate { await ShowCustomersReportView(); };
            reportsHV.ShowSuppliersReportView += async delegate { await ShowSuppliersReportView(); };
            reportsHV.OnDisposed += delegate { Dispose(); };
        }
        private async Task ShowCustomersReportView()
        {
            reportsHV.ReportsViewer.LocalReport.ReportEmbeddedResource = CustomersReport;
            reportDataSource.Name = CustomersDataSet;
            await LoadCustomersAsync(false);
        }

        

        private async Task ShowSuppliersReportView()
        {
            reportsHV.ReportsViewer.LocalReport.ReportEmbeddedResource = SuppliersReport;
            reportDataSource.Name = SuppliersDataSet;
            await LoadSuppliersAsync(false);
        }
        private async Task LoadCustomersAsync(bool IsFilter)
        {
            RepoResultM res = await CustomersRepo.GetCustomersAsync();
            if (res.IsSucess)
            {
                List<CustomerM> Customers = new List<CustomerM>();
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    Customers.Add((CustomerM)res.ResData[i]);
                }
                if (Customers.Count > 0)
                {
                    reportDataSource.Value = Customers;
                    reportsHV.ReportsViewer.RefreshReport();
                }
            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    reportsHV.ShowMsgBox("The Customers List Is Empty", "Note:", false);
                    return;
                }
                reportsHV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
        }
        private async Task LoadSuppliersAsync(bool IsFilter)
        {
            RepoResultM res = await SuppliersRepo.GetSuppliersAsync();
            if (res.IsSucess)
            {
                List<SupplierM> Suppliers = new List<SupplierM>();
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    Suppliers.Add((SupplierM)res.ResData[i]);
                }
                if (Suppliers.Count > 0)
                {
                    reportDataSource.Value = Suppliers;
                    reportsHV.ReportsViewer.RefreshReport();
                }
            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    reportsHV.ShowMsgBox("The Suppliers List Is Empty", "Note:", false);
                    return;
                }
                reportsHV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
        }

        private async Task ShowSalesReportViewAsync()
        {
            reportsHV.ReportsViewer.LocalReport.ReportEmbeddedResource = SalesReport;
            reportDataSource.Name = SalesDataSet;
            await LoadSalesInvoicesAsync(false);
        }

        private async Task ShowPurchasesReportViewAsync()
        {
            reportsHV.ReportsViewer.LocalReport.ReportEmbeddedResource = PurchasesReport;
            reportDataSource.Name = PurchasesDataSet;
            await LoadPurchasesInvoicesAsync(null);
        }

        private async Task ShowProductsReportViewAsync()
        {
            reportsHV.ReportsViewer.LocalReport.ReportEmbeddedResource = ProductsReport;
            reportDataSource.Name = ProductsDataSet;
            await LoadProductsAsync();
        }

        private async Task ShowEmployeesReportViewAsync()
        {

            reportsHV.ReportsViewer.LocalReport.ReportEmbeddedResource = EmployeesReport;
            reportDataSource.Name = EmployeesDataSet;
            await LoadEmployeesAsync();
        }

        private async Task ShowUsersReportViewAsync()
        {
            reportsHV.ReportsViewer.LocalReport.ReportEmbeddedResource = UsersReport;
            reportDataSource.Name = UsersDataSet;
            await LoadUsersAsync();
        }

        private async Task LoadSalesInvoicesAsync(bool IsFilter)
        {
            RepoResultM res;
            if (IsFilter)
            {
                res = await SalesRepo.SalesReport(1000, 1, 1, "", "2000-1-1", "3000-1-1"); 
            }
            else
            {
                res = await SalesRepo.GetSaleInvoicesAsync();
            }
            if (res.IsSucess)
            {
                List<InvoiceM> Invoices = new List<InvoiceM>();
                for (int i = 0; i < res.ResData.Count; i++)
                {

                    Invoices.Add((InvoiceM)res.ResData[i]);
                }
                if (Invoices.Count > 0)
                {
                    reportDataSource.Value = Invoices;
                    reportsHV.ReportsViewer.RefreshReport();
                }

            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    reportsHV.ShowMsgBox("The Invoices List Is Empty", "Note:", false);
                    return;
                }
                reportsHV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
        }
        private async Task LoadPurchasesInvoicesAsync(string searchValue)
        {
            RepoResultM res;
            if (searchValue == null)
            {
                res = await PurchasesRepo.GetPurchasInvoicesAsync();
            }
            else
            {
                res = await PurchasesRepo.SearchPurchaseInvAsync(searchValue);
            }
            if (res.IsSucess)
            {
                List<InvoiceM> Invoices = new List<InvoiceM>();
                for (int i = 0; i < res.ResData.Count; i++)
                {

                    Invoices.Add((InvoiceM)res.ResData[i]);
                }
                if (Invoices.Count > 0)
                {
                    reportDataSource.Value = Invoices;
                    reportsHV.ReportsViewer.RefreshReport();
                }

            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    reportsHV.ShowMsgBox("The Invoices List Is Empty", "Note:", false);
                    return;
                }
                reportsHV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
        }

        private async Task LoadProductsAsync()
        {
            RepoResultM res = await ProductsRepo.GetFullProductsAsync();
            if (res.IsSucess)
            {
                List<ProductM> productsList = new List<ProductM>();
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    productsList.Add((ProductM)res.ResData[i]);
                }
                if (productsList.Count > 0)
                {
                    reportDataSource.Value = productsList;
                    reportsHV.ReportsViewer.RefreshReport();
                }
            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    reportsHV.ShowMsgBox("The Products List Is Empty", "Note:", false);
                    return;
                }
                reportsHV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }

        }
        private async Task LoadEmployeesAsync()
        {
            
            RepoResultM res = await EmployeesRepo.GetEmployeesAsync();
            if (res.IsSucess)
            {
                List<EmployeeM> employees = new List<EmployeeM>();
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    employees.Add((EmployeeM)res.ResData[i]);
                }
                if (employees.Count > 0)
                {
                    reportDataSource.Value = employees;
                    reportsHV.ReportsViewer.RefreshReport();
                }
            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    this.reportsHV.ShowMsgBox("The Employees List Is Empty", "Note:", false);
                    return;
                }
                this.reportsHV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
        }
        private async Task LoadUsersAsync()
        {
            RepoResultM res = await UsersRepo.GetUsersAsync();
            if (res.IsSucess)
            {
                List<UserM> users = new List<UserM>();
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    users.Add((UserM)res.ResData[i]);
                }
                if (users.Count > 0)
                {
                    reportDataSource.Value = users;
                    reportsHV.ReportsViewer.RefreshReport();
                }
            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    reportsHV.ShowMsgBox("The Users List Is Empty", "Note:", false);
                    return;
                }
                reportsHV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
        }

    }
}
