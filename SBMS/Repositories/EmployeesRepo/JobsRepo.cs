using SBMS.Models.Employees;
using SBMS.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS.Repositories.EmployeesRepo
{
    class JobsRepo
    {
        private static string addProcedName = "AddJobT";
        private static string updateProcedName = "UpdateJobT";
        private static string deleteProcedName = "DeleteJobT";
        private static string getProcedName = "GetJobTitles";

        private static JobM GetJobM(List<object> result)
        {
            JobM jobTitleM = new JobM();
            jobTitleM.Id = (int)result[0];
            jobTitleM.Name = result[1].ToString();
            jobTitleM.Description = result[2].ToString();
            return jobTitleM;
        }
        public static async Task<RepoResultM> GetJobsAsync()
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
                    repoResult.ResData.Add((JobM)GetJobM(result.ResData[i]));
                }
            }
            return repoResult;
        }

        static public async Task<RepoResultM> AddJobAsync(JobM jobTitleM)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@name", SqlDbType.NVarChar),
                new SqlParameter("@description", SqlDbType.NVarChar)
            };
            parameters[0].Value = jobTitleM.Name;
            parameters[1].Value = jobTitleM.Description;
            DBResult result = await DBHelper.ExcuteStoredProcedNonQueryAsync(addProcedName, parameters, "");
            RepoResultM repoResult = new RepoResultM();
            repoResult.IsSucess = result.IsSucess;
            repoResult.EfectedRows = result.EfectedRows;
            repoResult.ErrorMsg = result.ErrorMsg;
            return repoResult;
        }

        public static async Task<RepoResultM> UpdateJobAsync(JobM jobTitleM)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@id", SqlDbType.Int),
                new SqlParameter("@name", SqlDbType.NVarChar),
                new SqlParameter("@description", SqlDbType.NVarChar)
            };
            parameters[0].Value = jobTitleM.Id;
            parameters[1].Value = jobTitleM.Name;
            parameters[2].Value = jobTitleM.Description;

            DBResult result = await DBHelper.ExcuteStoredProcedNonQueryAsync(updateProcedName, parameters, "");
            RepoResultM repoResult = new RepoResultM();
            repoResult.IsSucess = result.IsSucess;
            repoResult.EfectedRows = result.EfectedRows;
            repoResult.ErrorMsg = result.ErrorMsg;
            return repoResult;
        }

        public static async Task<RepoResultM> DeleteJobAsync(int id)
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
