using SBMS.Models.General;
using SBMS.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SBMS.Repositories.SalesRepo
{
    class SalesRepo
    {
        private static string AddProcedName = "AddSaleInvoice";
        private static string GetProcedName = "GetSales";
        private static string SearchProcedName = "SearchSales";
        private static string ReportProcedName = "SalesReport";
        private static InvoiceM GetSaleInvM(List<object> result)
        {
            InvoiceM invoiceM = new InvoiceM();
            invoiceM.Id = (int)result[0];
            invoiceM.Customer = result[1].ToString();
            invoiceM.NameOnInvoice = result[2].ToString();
            invoiceM.EmpName = result[3].ToString();
            invoiceM.MonyStateName = result[4].ToString();
            invoiceM.InvoiceTypeName = result[5].ToString();
            invoiceM.Total = decimal.Parse(result[6].ToString());
            invoiceM.DiscountRate = decimal.Parse(result[7].ToString());
            invoiceM.Date = DateTime.Parse(result[8].ToString()); 
            invoiceM.Note = result[9].ToString();
            return invoiceM;
        }
        public static async Task<RepoResultM> GetSaleInvoicesAsync()
        {

            SqlParameter[] parameters = { };
            RepoResultM repoResult = new RepoResultM();
            DBResult result = await DBHelper.ExcuteStoredProcedQueryAsync(GetProcedName, parameters);
            repoResult.IsSucess = result.IsSucess;
            repoResult.ErrorMsg = result.ErrorMsg;
            if (result.IsSucess)
            {
                for (int i = 0; i < result.ResData.Count; i++)
                {
                    repoResult.ResData.Add((InvoiceM)GetSaleInvM(result.ResData[i]));
                }
            }
            return repoResult;
        }
        public static async Task<RepoResultM> SearchSaleInvAsync(string searchValueIdBarcodeName)
        {

            SqlParameter[] parameters =
            {
                new SqlParameter("@id", SqlDbType.Int),
                new SqlParameter("@invTypId", SqlDbType.Int),
                new SqlParameter("@name", SqlDbType.NVarChar),
                new SqlParameter("@date", SqlDbType.DateTime)
            };
            parameters[0].Value = int.TryParse(searchValueIdBarcodeName, out _) ? Convert.ToInt32(searchValueIdBarcodeName) : 0;
            parameters[1].Value = int.TryParse(searchValueIdBarcodeName, out _) ? Convert.ToInt32(searchValueIdBarcodeName) : 0;
            parameters[2].Value = searchValueIdBarcodeName;
            parameters[3].Value =DateTime.TryParse(searchValueIdBarcodeName,out _) ? Convert.ToDateTime(searchValueIdBarcodeName) : new DateTime(3000,1,1);
            
            RepoResultM repoResult = new RepoResultM();
            DBResult result = await DBHelper.ExcuteStoredProcedQueryAsync(SearchProcedName, parameters);
            repoResult.IsSucess = result.IsSucess;
            repoResult.ErrorMsg = result.ErrorMsg;
            if (result.IsSucess)
            {
                for (int i = 0; i < result.ResData.Count; i++)
                {
                    repoResult.ResData.Add((InvoiceM)GetSaleInvM(result.ResData[i]));
                }
            }
            return repoResult;
        }
        public static async Task<RepoResultM> SalesReport(decimal invTotal,int invTypeId,int monyStateId,string custName,string fromDate,string toDate)
        {

            SqlParameter[] parameters =
            {
                new SqlParameter("@invTotal", invTotal),
                new SqlParameter("@invTypId", invTypeId),
                new SqlParameter("@monyStaeId", monyStateId),
                new SqlParameter("@name", custName),
                new SqlParameter("@fromDate", fromDate),
                new SqlParameter("@toDate", toDate)
            };
            RepoResultM repoResult = new RepoResultM();
            DBResult result = await DBHelper.ExcuteStoredProcedQueryAsync(ReportProcedName, parameters);
            repoResult.IsSucess = result.IsSucess;
            repoResult.ErrorMsg = result.ErrorMsg;
            if (result.IsSucess)
            {
                for (int i = 0; i < result.ResData.Count; i++)
                {
                    repoResult.ResData.Add((InvoiceM)GetSaleInvM(result.ResData[i]));
                }
            }
            return repoResult;
        }

        static public async Task<RepoResultM> AddSaleInvAsync(InvoiceM saleInvM)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@empId", saleInvM.EmpId),
                new SqlParameter("@custId", saleInvM.CustomerId),
                new SqlParameter("@invCustName", saleInvM.NameOnInvoice),
                new SqlParameter("@total", saleInvM.Total),
                new SqlParameter("@monStateId", saleInvM.MonyStateId),
                new SqlParameter("@invTypeId", saleInvM.InvoiceTypeId),
                new SqlParameter("@note", saleInvM.Note),
                new SqlParameter("@date", saleInvM.Date),
                new SqlParameter("@discountRate", saleInvM.DiscountRate),
                new SqlParameter("@ID", SqlDbType.Int)
            };
            parameters[9].Direction = ParameterDirection.Output;

            DBResult result = await DBHelper.ExcuteStoredProcedNonQueryAsync(AddProcedName, parameters,"@ID");
            RepoResultM repoResult = new RepoResultM();
            repoResult.IsSucess = result.IsSucess;
            repoResult.EfectedRows = result.EfectedRows;
            repoResult.ReturnNewRowId = result.ReturnIdOfNewRow;
            repoResult.ResData.Add(result.ReturnIdOfNewRow);
            repoResult.ErrorMsg = result.ErrorMsg;
            return repoResult;
        }

    }
}
