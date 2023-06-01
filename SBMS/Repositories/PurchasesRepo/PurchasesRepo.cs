using SBMS.Models.General;
using SBMS.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SBMS.Repositories.PurchasesRepo
{
    class PurchasesRepo
    {
        private static string AddProcedName = "AddPurchaseInvoice";
        private static string GetProcedName = "GetPurchases";
        private static string SearchProcedName = "SearchPurchaseInv";
        private static string ReportProcedName = "PurchasesReport";
        private static InvoiceM GetPurchaseInvM(List<object> result)
        {
            InvoiceM purchaseM = new InvoiceM();
            purchaseM.Id = (int)result[0];
            purchaseM.Supplier = result[1].ToString();
            purchaseM.NameOnInvoice = result[2].ToString();
            purchaseM.EmpName = result[3].ToString();
            purchaseM.MonyStateName = result[4].ToString();
            purchaseM.InvoiceTypeName = result[5].ToString();
            purchaseM.Total = decimal.Parse(result[6].ToString());
            purchaseM.Note = result[7].ToString();
            purchaseM.Date = DateTime.Parse(result[8].ToString());
            return purchaseM;
        }
        public static async Task<RepoResultM> GetPurchasInvoicesAsync()
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
                    repoResult.ResData.Add((InvoiceM)GetPurchaseInvM(result.ResData[i]));
                }
            }
            return repoResult;
        }
        public static async Task<RepoResultM> SearchPurchaseInvAsync(string searchValueIdBarcodeName)
        {

            SqlParameter[] parameters =
            {
                new SqlParameter("@id", SqlDbType.Int),
                new SqlParameter("@invTypeId", SqlDbType.Int),
                new SqlParameter("@name", SqlDbType.NVarChar),
                new SqlParameter("@date", SqlDbType.DateTime)
            };
            parameters[0].Value = int.TryParse(searchValueIdBarcodeName, out _) ? Convert.ToInt32(searchValueIdBarcodeName) : 0;
            parameters[1].Value = int.TryParse(searchValueIdBarcodeName, out _) ? Convert.ToInt32(searchValueIdBarcodeName) : 0;
            parameters[2].Value = searchValueIdBarcodeName;
            parameters[3].Value = DateTime.TryParse(searchValueIdBarcodeName, out _) ? Convert.ToDateTime(searchValueIdBarcodeName) : DateTime.Now;

            RepoResultM repoResult = new RepoResultM();
            DBResult result = await DBHelper.ExcuteStoredProcedQueryAsync(SearchProcedName, parameters);
            repoResult.IsSucess = result.IsSucess;
            repoResult.ErrorMsg = result.ErrorMsg;
            if (result.IsSucess)
            {
                for (int i = 0; i < result.ResData.Count; i++)
                {
                    repoResult.ResData.Add((InvoiceM)GetPurchaseInvM(result.ResData[i]));
                }
            }
            return repoResult;
        }
        public static async Task<RepoResultM> AddPurchaseInvoiceAsync(InvoiceM purchaseOpM)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@empId", purchaseOpM.EmpId),
                new SqlParameter("@suppId", purchaseOpM.SupplierId),
                new SqlParameter("@invSuppName", purchaseOpM.NameOnInvoice),
                new SqlParameter("@total",purchaseOpM.Total),
                new SqlParameter("@monStateId", purchaseOpM.MonyStateId),
                new SqlParameter("@invTypeId", purchaseOpM.InvoiceTypeId),
                new SqlParameter("@note", purchaseOpM.Note),
                new SqlParameter("@date", purchaseOpM.Date),
                new SqlParameter("@ID", SqlDbType.Int)
            };
            parameters[8].Direction = ParameterDirection.Output;

            DBResult result = await DBHelper.ExcuteStoredProcedNonQueryAsync(AddProcedName, parameters, "@ID");
            RepoResultM repoResult = new RepoResultM();
            repoResult.IsSucess = result.IsSucess;
            repoResult.EfectedRows = result.EfectedRows;
            repoResult.ErrorMsg = result.ErrorMsg;
            repoResult.ResData.Add(result.ReturnIdOfNewRow);
            return repoResult;
        }

        public static async Task<RepoResultM> PurchasesReport(decimal invTotal, int invTypeId, int monyStateId, string custName, string fromDate, string toDate)
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
                    repoResult.ResData.Add((InvoiceM)GetPurchaseInvM(result.ResData[i]));
                }
            }
            return repoResult;
        }

    }
}
