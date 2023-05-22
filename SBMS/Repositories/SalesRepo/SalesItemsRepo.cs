using SBMS.Models.General;
using SBMS.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SBMS.Repositories.SalesRepo
{
    class SalesItemsRepo
    {
        private static string AddSaleItem = "AddSaleItem";
        private static string GetSaleItems = "GetSaleItems";
        private static InvoiceItemM GetSaleItemM(List<object> result)
        {
            InvoiceItemM saleItemM = new InvoiceItemM();
            saleItemM.Id = (int)result[0];
            saleItemM.Name = result[1].ToString();
            saleItemM.Unit = result[1].ToString();
            saleItemM.Quantity = decimal.Parse(result[3].ToString());
            saleItemM.Price = decimal.Parse(result[2].ToString());
            saleItemM.ExpireDate = DateTime.Parse(result[2].ToString()).ToShortDateString();
            return saleItemM;
        }
        public static async Task<RepoResultM> GetSaleItemsAsync(int saleId)
        {

            SqlParameter[] parameters = { new SqlParameter("@saleId", SqlDbType.Int) };
            parameters[0].Value = saleId;
            RepoResultM repoResult = new RepoResultM();
            DBResult result = await DBHelper.ExcuteStoredProcedQueryAsync(GetSaleItems, parameters);
            repoResult.IsSucess = result.IsSucess;
            repoResult.ErrorMsg = result.ErrorMsg;
            if (result.IsSucess)
            {
                for (int i = 0; i < result.ResData.Count; i++)
                {
                    repoResult.ResData.Add((InvoiceItemM)GetSaleItemM(result.ResData[i]));
                }
            }
            return repoResult;
        }
        static public async Task<RepoResultM> AddSaleItemAsync(InvoiceItemM saleItemM, int one)
        {
            RepoResultM repoResult = new RepoResultM();    
            if (one==-1 && one == 1)
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@saleId", saleItemM.InvoiceId),
                    new SqlParameter("@prodId", saleItemM.ProductId),
                    new SqlParameter("@proddId", saleItemM.ProductDId),
                    new SqlParameter("@price", saleItemM.Price),
                    new SqlParameter("@quantity", saleItemM.Quantity),
                    new SqlParameter("@offerId", saleItemM.OfferId),
                    new SqlParameter("@one", one)
                };
                DBResult result = await DBHelper.ExcuteStoredProcedNonQueryAsync(AddSaleItem, parameters, "");
                
                repoResult.IsSucess = result.IsSucess;
                repoResult.EfectedRows = result.EfectedRows;
                repoResult.ErrorMsg = result.ErrorMsg;
                repoResult.ResData.Add(result.ResData[0][0]);
                return repoResult;
            }
            repoResult.IsSucess = false;
            repoResult.ErrorMsg = "one must be 1 for sale invoice and -1 for return sale invoice";
            return repoResult;


        }

    }
}
