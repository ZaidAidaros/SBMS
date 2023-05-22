using SBMS.Models.Suppliers;
using SBMS.Services;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SBMS.Repositories.SuppliersRepo
{
    class SuppCategoriesRepo
    {
        private static string addProcedName = "AddSuppCategory";
        private static string updateProcedName = "UpdateSuppCategory";
        private static string deleteProcedName = "DeleteSuppCategory";
        private static string getProcedName = "GetSuppCategories";

        private static SuppCategory GetSuppCategoryM(List<object> result)
        {
            SuppCategory categ = new SuppCategory();
            categ.Id = (int)result[0];
            categ.Name = result[1].ToString();
            categ.Description = result[2].ToString();
            return categ;
        }
        public static async Task<RepoResultM> GetSuppCategoriesAsync()
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
                    repoResult.ResData.Add((SuppCategory)GetSuppCategoryM(result.ResData[i]));
                }
            }
            return repoResult;
        }

        static public async Task<RepoResultM> AddSuppCategoryAsync(SuppCategory cateM)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@name", SqlDbType.NVarChar),
                new SqlParameter("@description", SqlDbType.NVarChar)
            };
            parameters[0].Value = cateM.Name;
            parameters[1].Value = cateM.Description;
            DBResult result = await DBHelper.ExcuteStoredProcedNonQueryAsync(addProcedName, parameters ,"");
            RepoResultM repoResult = new RepoResultM();
            repoResult.IsSucess = result.IsSucess;
            repoResult.EfectedRows = result.EfectedRows;
            repoResult.ErrorMsg = result.ErrorMsg;
            return repoResult;
        }

        public static async Task<RepoResultM> UpdateSuppCategoryAsync(SuppCategory cateM)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@id", SqlDbType.Int),
                new SqlParameter("@name", SqlDbType.NVarChar),
                new SqlParameter("@description", SqlDbType.NVarChar)
            };
            parameters[0].Value = cateM.Id;
            parameters[1].Value = cateM.Name;
            parameters[2].Value = cateM.Description;

            DBResult result = await DBHelper.ExcuteStoredProcedNonQueryAsync(updateProcedName, parameters ,"");
            RepoResultM repoResult = new RepoResultM();
            repoResult.IsSucess = result.IsSucess;
            repoResult.EfectedRows = result.EfectedRows;
            repoResult.ErrorMsg = result.ErrorMsg;
            return repoResult;
        }

        public static async Task<RepoResultM> DeleteSuppCategoryAsync(int id)
        {
            SqlParameter[] parameters = { new SqlParameter("@id", SqlDbType.Int) };
            parameters[0].Value = id;
            DBResult result = await DBHelper.ExcuteStoredProcedNonQueryAsync(deleteProcedName, parameters ,"");
            RepoResultM repoResult = new RepoResultM();
            repoResult.IsSucess = result.IsSucess;
            repoResult.ErrorMsg = result.ErrorMsg;
            repoResult.EfectedRows = result.EfectedRows;
            return repoResult;
        }
    }
}
