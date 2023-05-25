using SBMS.Models.Users;
using SBMS.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
namespace SBMS.Repositories
{
    public class UsersRepo
    {

        private static string addProcedName = "AddUser";
        private static string updateProcedName = "UpdateUser";
        private static string deleteProcedName = "DeleteUser";
        private static string getProcedName = "GetUsers";
        private static string logInProcedName = "CheckUser";
        private static string searchProcedName = "SearchUser";
        private static string getPermProcedName = "GetPermissions";

        private static UserM GetUserM(List<object> result)
        {
            UserM userM = new UserM();
            userM.Id = (int)result[0];
            userM.Name = result[1].ToString();
            userM.Employee = result[2].ToString();
            userM.Permission = result[3].ToString();
            userM.EmployeeId = (int)result[4];
            userM.PermissionId = (int)result[5];
            return userM;
        }
        private static PermissionM GetPermissionM(List<object> result)
        {
            PermissionM permission = new PermissionM();
            permission.Id = (int)result[0];
            permission.Name = result[1].ToString();
            return permission;
        }
        public static async Task<RepoResultM> GetUsersAsync()
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
                    repoResult.ResData.Add((UserM)GetUserM(result.ResData[i]));
                }
            }
            return repoResult;
        }
        public static async Task<RepoResultM> GetPermissionsAsync()
        {

            SqlParameter[] parameters = { };
            RepoResultM repoResult = new RepoResultM();
            DBResult result = await DBHelper.ExcuteStoredProcedQueryAsync(getPermProcedName, parameters);
            repoResult.IsSucess = result.IsSucess;
            repoResult.ErrorMsg = result.ErrorMsg;
            if (result.IsSucess)
            {
                for (int i = 0; i < result.ResData.Count; i++)
                {
                    repoResult.ResData.Add((PermissionM)GetPermissionM(result.ResData[i]));
                }
            }
            return repoResult;
        }
        public static async Task<RepoResultM> SearchUserAsync(string searchValueIdName)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@id", SqlDbType.Int),
                new SqlParameter("@permId", SqlDbType.Int),
                new SqlParameter("@name", SqlDbType.NChar)
            };
            parameters[0].Value = int.TryParse(searchValueIdName, out _) ? Convert.ToInt32(searchValueIdName) : 0;
            parameters[1].Value = int.TryParse(searchValueIdName, out _) ? Convert.ToInt32(searchValueIdName) : 0;
            parameters[2].Value = searchValueIdName;
            RepoResultM repoResult = new RepoResultM();
            DBResult result = await DBHelper.ExcuteStoredProcedQueryAsync(searchProcedName, parameters);
            repoResult.IsSucess = result.IsSucess;
            repoResult.ErrorMsg = result.ErrorMsg;
            if (result.IsSucess)
            {

                for (int i = 0; i < result.ResData.Count; i++)
                {
                    repoResult.ResData.Add((UserM)GetUserM(result.ResData[i]));
                }
            }
            return repoResult;
        }
        public static async Task<RepoResultM> LogInAsync(string name, string password)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@name", name),
                new SqlParameter("@password", password)
            };
            RepoResultM repoResult = new RepoResultM();
            DBResult result = await DBHelper.ExcuteStoredProcedQueryAsync(logInProcedName, parameters);
            repoResult.IsSucess = result.IsSucess;
            repoResult.ErrorMsg = result.ErrorMsg;
            if (result.ErrorMsg == "No Result")
            {
                repoResult.IsSucess = false;
                repoResult.ErrorMsg = "User Name OR Password Incorrect";
            }
            if (repoResult.IsSucess)
            {
                repoResult.ResData.Add(GetUserM(result.ResData[0]));
            }
            return repoResult;
        }
        static public async Task<RepoResultM> AddUserAsync(UserM user)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@name", user.Name),
                new SqlParameter("@password",user.Password),
                new SqlParameter("@empId", user.EmployeeId),
                new SqlParameter("@permId", user.PermissionId)
            };

            DBResult result = await DBHelper.ExcuteStoredProcedNonQueryAsync(addProcedName, parameters,"");
            RepoResultM repoResult = new RepoResultM();
            repoResult.IsSucess = result.IsSucess;
            repoResult.EfectedRows = result.EfectedRows;
            repoResult.ErrorMsg = result.ErrorMsg;
            return repoResult;
        }
        public static async Task<RepoResultM> UpdateUserAsync(UserM user)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@id", user.Id),
                new SqlParameter("@name", user.Name),
                new SqlParameter("@password", user.Password),
                new SqlParameter("@empId", user.EmployeeId),
                new SqlParameter("@permId", user.PermissionId)
            };

            DBResult result = await DBHelper.ExcuteStoredProcedNonQueryAsync(updateProcedName, parameters,"");
            RepoResultM repoResult = new RepoResultM();
            repoResult.IsSucess = result.IsSucess;
            repoResult.EfectedRows = result.EfectedRows;
            repoResult.ErrorMsg = result.ErrorMsg;
            return repoResult;
        }
        public static async Task<RepoResultM> DeleteUserAsync(int id)
        {
            SqlParameter[] parameters = { new SqlParameter("@id", id) };

            DBResult result = await DBHelper.ExcuteStoredProcedNonQueryAsync(deleteProcedName, parameters,"");
            RepoResultM repoResult = new RepoResultM();
            repoResult.IsSucess = result.IsSucess;
            repoResult.ErrorMsg = result.ErrorMsg;
            repoResult.EfectedRows = result.EfectedRows;
            return repoResult;
        }


    }

 

    
}
