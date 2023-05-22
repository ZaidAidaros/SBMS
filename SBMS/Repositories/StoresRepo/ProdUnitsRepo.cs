using SBMS.Models.Stores;
using SBMS.Services;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SBMS.Repositories.StoresRepo
{
    class ProdUnitsRepo
    {

        private static string addProcedName = "AddProdUnit";
        private static string updateProcedName = "UpdateProdUnit";
        private static string deleteProcedName = "DeleteProdUnit";
        private static string getProcedName = "GetProdUnits";


        private static ProdUnitM GetProdUnitM(List<object> result)
        {
            ProdUnitM unitM = new ProdUnitM();
            unitM.Id = (int)result[0];
            unitM.Name = result[1].ToString();
            unitM.Symbole = result[2].ToString();
            unitM.SubUnitName = result[3].ToString();
            unitM.SubUnitSymbole = result[4].ToString();
            unitM.Description = result[5].ToString();
            unitM.RateMainBranch = (int) result[6];
            return unitM;
        }
        public static async Task<RepoResultM> GetProdUnitsAsync()
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
                    repoResult.ResData.Add((ProdUnitM)GetProdUnitM(result.ResData[i]));
                }
            }
            return repoResult;
        }

        static public async Task<RepoResultM> AddProdUnitAsync(ProdUnitM prodUnitM)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@name", SqlDbType.NVarChar),
                new SqlParameter("@symbole", SqlDbType.NVarChar),
                new SqlParameter("@subUName", SqlDbType.NVarChar),
                new SqlParameter("@subSymbole", SqlDbType.NVarChar),
                new SqlParameter("@description", SqlDbType.NVarChar),
                new SqlParameter("@rateMB", SqlDbType.Int)
            };
            parameters[0].Value = prodUnitM.Name;
            parameters[1].Value = prodUnitM.Symbole;
            parameters[2].Value = prodUnitM.SubUnitName;
            parameters[3].Value = prodUnitM.SubUnitSymbole;
            parameters[4].Value = prodUnitM.Description;
            parameters[5].Value = prodUnitM.RateMainBranch;
            DBResult result = await DBHelper.ExcuteStoredProcedNonQueryAsync(addProcedName, parameters, "");
            RepoResultM repoResult = new RepoResultM();
            repoResult.IsSucess = result.IsSucess;
            repoResult.EfectedRows = result.EfectedRows;
            repoResult.ErrorMsg = result.ErrorMsg;
            return repoResult;
        }

        public static async Task<RepoResultM> UpdateProdUnitAsync(ProdUnitM prodUnitM)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@id", SqlDbType.Int),
                new SqlParameter("@name", SqlDbType.NVarChar),
                new SqlParameter("@symbole", SqlDbType.NVarChar),
                new SqlParameter("@subUName", SqlDbType.NVarChar),
                new SqlParameter("@subSymbole", SqlDbType.NVarChar),
                new SqlParameter("@description", SqlDbType.NVarChar),
                new SqlParameter("@rateMB", SqlDbType.Int)
            };
            parameters[0].Value = prodUnitM.Id;
            parameters[1].Value = prodUnitM.Name;
            parameters[2].Value = prodUnitM.Symbole;
            parameters[3].Value = prodUnitM.SubUnitName;
            parameters[4].Value = prodUnitM.SubUnitSymbole;
            parameters[5].Value = prodUnitM.Description;
            parameters[6].Value = prodUnitM.RateMainBranch;

            DBResult result = await DBHelper.ExcuteStoredProcedNonQueryAsync(updateProcedName, parameters, "");
            RepoResultM repoResult = new RepoResultM();
            repoResult.IsSucess = result.IsSucess;
            repoResult.EfectedRows = result.EfectedRows;
            repoResult.ErrorMsg = result.ErrorMsg;
            return repoResult;
        }

        public static async Task<RepoResultM> DeleteProdUnitAsync(int id)
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
