using SBMS.Models.General;
using SBMS.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS.Repositories.PurchasesRepo
{
    class PurchasesItemsRepo
    {
        private static string AddPurchaseItemProcedName = "AddPurchaseItem";
        private static string AddRePurchaseItemProcedName = "AddRePurchItem";
        private static string GetProcedName = "GetPurchaseInvItems";
        private static InvoiceItemM GetPurchaseInvItemM(List<object> result)
        {
            InvoiceItemM purchaseItemM = new InvoiceItemM();
            purchaseItemM.Id = (int)result[0];
            purchaseItemM.BarCode = (int)result[1];
            purchaseItemM.Name = result[2].ToString();
            purchaseItemM.Unit = result[3].ToString();
            purchaseItemM.Price = decimal.Parse(result[4].ToString());
            purchaseItemM.Quantity = decimal.Parse(result[5].ToString());
            purchaseItemM.ExpireDate = result[6].ToString();
            return purchaseItemM;
        }

        public static async Task<RepoResultM> GetPurchaseItemsAsync(int purchId)
        {

            SqlParameter[] parameters = { new SqlParameter("@purchId", SqlDbType.Int) };
            parameters[0].Value = purchId;
            RepoResultM repoResult = new RepoResultM();
            DBResult result = await DBHelper.ExcuteStoredProcedQueryAsync(GetProcedName, parameters);
            repoResult.IsSucess = result.IsSucess;
            repoResult.ErrorMsg = result.ErrorMsg;
            if (result.IsSucess)
            {
                for (int i = 0; i < result.ResData.Count; i++)
                {
                    repoResult.ResData.Add((InvoiceItemM)GetPurchaseInvItemM(result.ResData[i]));
                }
            }
            return repoResult;
        }



        static public async Task<RepoResultM> AddPurchaseInvItemAsync(InvoiceItemM rePurchaseItemM)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@prodId", rePurchaseItemM.ProductId),
                new SqlParameter("@purchId", rePurchaseItemM.InvoiceId),
                new SqlParameter("@cost", rePurchaseItemM.Price),
                new SqlParameter("@price", rePurchaseItemM.DefPrice),
                new SqlParameter("@quantity", rePurchaseItemM.Quantity),
                new SqlParameter("@exDate", rePurchaseItemM.ExpireDate)
            };

            DBResult result = await DBHelper.ExcuteStoredProcedNonQueryAsync(AddPurchaseItemProcedName, parameters, "");
            RepoResultM repoResult = new RepoResultM();
            repoResult.IsSucess = result.IsSucess;
            repoResult.EfectedRows = result.EfectedRows;
            repoResult.ErrorMsg = result.ErrorMsg;
            repoResult.ResData.Add(result.ReturnIdOfNewRow);
            return repoResult;
        }

        static public async Task<RepoResultM> AddRePurchaseInvItemAsync(InvoiceItemM rePurchaseItemM)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@purchId", rePurchaseItemM.InvoiceId),
                new SqlParameter("@prodId", rePurchaseItemM.ProductId),
                new SqlParameter("@proddId", rePurchaseItemM.ProductDId),
                new SqlParameter("@price", rePurchaseItemM.Price),
                new SqlParameter("@quantity", rePurchaseItemM.Quantity)
            };

            DBResult result = await DBHelper.ExcuteStoredProcedNonQueryAsync(AddRePurchaseItemProcedName, parameters, "");
            RepoResultM repoResult = new RepoResultM();
            repoResult.IsSucess = result.IsSucess;
            repoResult.EfectedRows = result.EfectedRows;
            repoResult.ErrorMsg = result.ErrorMsg;
            repoResult.ResData.Add(result.ReturnIdOfNewRow);
            return repoResult;
        }


    }
}
