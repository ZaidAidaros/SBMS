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
            userM.Employeem.Id = (int)result[4];
            userM.Permissionm.Id = (int)result[5];
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
                new SqlParameter("@name", SqlDbType.NChar),
                new SqlParameter("@password", SqlDbType.NChar)
            };
            parameters[0].Value = name;
            parameters[1].Value = password;
            RepoResultM repoResult = new RepoResultM();
            DBResult result = await DBHelper.ExcuteStoredProcedQueryAsync(logInProcedName, parameters);
            repoResult.IsSucess = result.IsSucess;
            repoResult.ErrorMsg = result.ErrorMsg;
            if (result.ErrorMsg == "No Result") repoResult.ErrorMsg = "User Name OR Password Incorrect";
            if (result.IsSucess)
            {
                repoResult.ResData.Add(GetUserM(result.ResData[0]));
            }
            return repoResult;
        }

        static public async System.Threading.Tasks.Task<RepoResultM> AddUserAsync(UserM user)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@name", SqlDbType.NVarChar),
                new SqlParameter("@password", SqlDbType.NVarChar),
                new SqlParameter("@empId", SqlDbType.Int),
                new SqlParameter("@permId", SqlDbType.Int)
            };
            parameters[0].Value = user.Name;
            parameters[1].Value = user.Password;
            parameters[2].Value = user.Employeem.Id;
            parameters[3].Value = user.Permissionm.Id;
            DBResult result = await DBHelper.ExcuteStoredProcedNonQueryAsync(addProcedName, parameters,"");
            RepoResultM repoResult = new RepoResultM();
            repoResult.IsSucess = result.IsSucess;
            repoResult.EfectedRows = result.EfectedRows;
            repoResult.ErrorMsg = result.ErrorMsg;
            return repoResult;
        }

        public static async System.Threading.Tasks.Task<RepoResultM> UpdateUserAsync(UserM user)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@id", SqlDbType.Int),
                new SqlParameter("@name", SqlDbType.NVarChar),
                new SqlParameter("@password", SqlDbType.NVarChar),
                new SqlParameter("@empId", SqlDbType.Int),
                new SqlParameter("@permId", SqlDbType.Int)
            };
            parameters[0].Value = user.Id;
            parameters[1].Value = user.Name;
            parameters[2].Value = user.Password;
            parameters[3].Value = user.Employeem.Id;
            parameters[4].Value = user.Permissionm.Id;

            DBResult result = await DBHelper.ExcuteStoredProcedNonQueryAsync(updateProcedName, parameters,"");
            RepoResultM repoResult = new RepoResultM();
            repoResult.IsSucess = result.IsSucess;
            repoResult.EfectedRows = result.EfectedRows;
            repoResult.ErrorMsg = result.ErrorMsg;
            return repoResult;
        }

        public static async System.Threading.Tasks.Task<RepoResultM> DeleteUserAsync(int id)
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
