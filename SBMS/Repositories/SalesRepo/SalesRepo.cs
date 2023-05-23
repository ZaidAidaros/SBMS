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
        private static string addProcedName = "AddSaleInvoice";
        private static string getProcedName = "GetSales";
        private static string searchProcedName = "SearchSales";
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
            invoiceM.Date = DateTime.Parse(result[7].ToString()); 
            invoiceM.Note = result[8].ToString();
            return invoiceM;
        }
        public static async Task<RepoResultM> GetSaleInvoicesAsync()
        {

            SqlParameter[] parameters = { };
            RepoResultM repoResult = new RepoResultM();
            DBResult result = await DBHelper.ExcuteStoredProcedQueryAsync(getProcedName, parameters);
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
            DBResult result = await DBHelper.ExcuteStoredProcedQueryAsync(searchProcedName, parameters);
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
                new SqlParameter("@ID", SqlDbType.Int)
            };
            parameters[8].Direction = ParameterDirection.Output;

            DBResult result = await DBHelper.ExcuteStoredProcedNonQueryAsync(addProcedName, parameters,"@ID");
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
