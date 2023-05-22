using SBMS.Models.Stores;
using SBMS.Services;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SBMS.Repositories.StoresRepo
{
    class ProdCategoriesRepo
    {
        private static string addProcedName = "AddProdCategory";
        private static string updateProcedName = "UpdateProdCategory";
        private static string deleteProcedName = "DeleteProdCategory";
        private static string getProcedName = "GetProdCategories";

        private static ProdCategoryM GetProdCategoryM(List<object> result)
        {
            ProdCategoryM categ = new ProdCategoryM();
            categ.Id = (int)result[0];
            categ.Name = result[1].ToString();
            categ.Description = result[2].ToString();
            return categ;
        }
        public static async Task<RepoResultM> GetProdCategoriesAsync()
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
                    repoResult.ResData.Add((ProdCategoryM)GetProdCategoryM(result.ResData[i]));
                }
            }
            return repoResult;
        }

        static public async Task<RepoResultM> AddProdCategoryAsync(ProdCategoryM prodCategoryM)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@name", SqlDbType.NVarChar),
                new SqlParameter("@description", SqlDbType.NVarChar)
            };
            parameters[0].Value = prodCategoryM.Name;
            parameters[1].Value = prodCategoryM.Description;
            DBResult result = await DBHelper.ExcuteStoredProcedNonQueryAsync(addProcedName, parameters, "");
            RepoResultM repoResult = new RepoResultM();
            repoResult.IsSucess = result.IsSucess;
            repoResult.EfectedRows = result.EfectedRows;
            repoResult.ErrorMsg = result.ErrorMsg;
            return repoResult;
        }

        public static async Task<RepoResultM> UpdateProdCategoryAsync(ProdCategoryM prodCategoryM)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@id", SqlDbType.Int),
                new SqlParameter("@name", SqlDbType.NVarChar),
                new SqlParameter("@description", SqlDbType.NVarChar)
            };
            parameters[0].Value = prodCategoryM.Id;
            parameters[1].Value = prodCategoryM.Name;
            parameters[2].Value = prodCategoryM.Description;

            DBResult result = await DBHelper.ExcuteStoredProcedNonQueryAsync(updateProcedName, parameters, "");
            RepoResultM repoResult = new RepoResultM();
            repoResult.IsSucess = result.IsSucess;
            repoResult.EfectedRows = result.EfectedRows;
            repoResult.ErrorMsg = result.ErrorMsg;
            return repoResult;
        }

        public static async Task<RepoResultM> DeleteProdCategoryAsync(int id)
        {
            SqlParameter[] parameters = { new SqlParameter("@id", SqlDbType.Int) };
            parameters[0].Value = id;
            DBResult result = await DBHelper.ExcuteStoredProcedNonQueryAsync(deleteProcedName, parameters, "");
            RepoResultM repoResult = new RepoResultM();
            repoResult.IsSucess = result.IsSucess;
            repoResult.ErrorMsg = result.ErrorMsg;
            repoResult.EfectedRows = result.EfectedRows;
            return repoResult;
        }
    }
}
