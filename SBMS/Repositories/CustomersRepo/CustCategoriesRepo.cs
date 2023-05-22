using SBMS.Models.Customers;
using SBMS.Services;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SBMS.Repositories.CustomersRepo
{
    class CustCategoriesRepo
    {
        private static string addProcedName = "AddCustCategory";
        private static string updateProcedName = "UpdateCustCategory";
        private static string deleteProcedName = "DeleteCustCategory";
        private static string getProcedName = "GetCustCategories";

        private static CustCategoryM GetCustCategoryM(List<object> result)
        {
            CustCategoryM categ = new CustCategoryM();
            categ.Id = (int)result[0];
            categ.Name = result[1].ToString();
            categ.Description = result[2].ToString();
            return categ;
        }
        public static async System.Threading.Tasks.Task<RepoResultM> GetCustCategoriesAsync()
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
                    repoResult.ResData.Add((CustCategoryM)GetCustCategoryM(result.ResData[i]));
                }
            }
            return repoResult;
        }

        static public async System.Threading.Tasks.Task<RepoResultM> AddCustCategoryAsync(CustCategoryM cateM)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@name", SqlDbType.NVarChar),
                new SqlParameter("@description", SqlDbType.NVarChar)
            };
            parameters[0].Value = cateM.Name;
            parameters[1].Value = cateM.Description;
            DBResult result = await DBHelper.ExcuteStoredProcedNonQueryAsync(addProcedName, parameters,"");
            RepoResultM repoResult = new RepoResultM();
            repoResult.IsSucess = result.IsSucess;
            repoResult.EfectedRows = result.EfectedRows;
            repoResult.ErrorMsg = result.ErrorMsg;
            return repoResult;
        }

        public static async System.Threading.Tasks.Task<RepoResultM> UpdateCustCategoryAsync(CustCategoryM cateM)
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

            DBResult result = await DBHelper.ExcuteStoredProcedNonQueryAsync(updateProcedName, parameters,"");
            RepoResultM repoResult = new RepoResultM();
            repoResult.IsSucess = result.IsSucess;
            repoResult.EfectedRows = result.EfectedRows;
            repoResult.ErrorMsg = result.ErrorMsg;
            return repoResult;
        }

        public static async System.Threading.Tasks.Task<RepoResultM> DeleteCustCategoryAsync(int id)
        {
            SqlParameter[] parameters = { new SqlParameter("@id", SqlDbType.Int) };
            parameters[0].Value = id;
            DBResult result = await DBHelper.ExcuteStoredProcedNonQueryAsync(deleteProcedName, parameters,"");
            RepoResultM repoResult = new RepoResultM();
            repoResult.IsSucess = result.IsSucess;
            repoResult.ErrorMsg = result.ErrorMsg;
            repoResult.EfectedRows = result.EfectedRows;
            return repoResult;
        }
    }
}
