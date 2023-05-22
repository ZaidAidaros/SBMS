using SBMS.Models.Customers;
using SBMS.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SBMS.Repositories.CustomersRepo
{
    class CustomersRepo
    {
        private static string addProcedName = "AddCustomer";
        private static string updateProcedName = "UpdateCustomer";
        private static string deleteProcedName = "DeleteCustomer";
        private static string getProcedName = "GetCustomers";
        private static string searchProcedName = "SearchCustomer";
        private static string filterCategProcedName = "FilterCustByCategory";

        private static CustomerM GetCustomerM(List<object> result)
        {
            CustomerM customerM = new CustomerM();
            customerM.Id = int.Parse(result[0].ToString());
            customerM.Name = result[1].ToString();
            customerM.NIC = int.TryParse(result[2].ToString(), out _) ? Convert.ToInt32(result[2].ToString()) : 0;
            customerM.BirthDate = result[3].ToString();
            customerM.Address = result[4].ToString();
            customerM.Phone = result[5].ToString();
            customerM.GenderM.Name = result[6].ToString();
            customerM.CategoryM.Name = result[7].ToString();
            return customerM;
        }
        public static async System.Threading.Tasks.Task<RepoResultM> GetCustomersAsync()
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
                    repoResult.ResData.Add((CustomerM)GetCustomerM(result.ResData[i]));
                }
            }
            return repoResult;
        }

        public static async System.Threading.Tasks.Task<RepoResultM> SearchCustomerAsync(string searchValueIdName)
        {

            SqlParameter[] parameters = {
                new SqlParameter("@id", SqlDbType.Int),
                new SqlParameter("@name", SqlDbType.NChar)
            };
            parameters[0].Value = int.TryParse(searchValueIdName, out _) ? Convert.ToInt32(searchValueIdName) : 0;
            parameters[1].Value = searchValueIdName;
            RepoResultM repoResult = new RepoResultM();
            DBResult result = await DBHelper.ExcuteStoredProcedQueryAsync(searchProcedName, parameters);
            repoResult.IsSucess = result.IsSucess;
            repoResult.ErrorMsg = result.ErrorMsg;
            if (result.IsSucess)
            {
                for (int i = 0; i < result.ResData.Count; i++)
                {
                    repoResult.ResData.Add((CustomerM)GetCustomerM(result.ResData[i]));
                }
            }
            return repoResult;
        }

        public static async System.Threading.Tasks.Task<RepoResultM> FilterCustomersByCategoryAsync(int cateId)
        {

            SqlParameter[] parameters = {
                new SqlParameter("@cateId", SqlDbType.Int)
            };
            parameters[0].Value = cateId;
            RepoResultM repoResult = new RepoResultM();
            DBResult result = await DBHelper.ExcuteStoredProcedQueryAsync(filterCategProcedName, parameters);
            repoResult.IsSucess = result.IsSucess;
            repoResult.ErrorMsg = result.ErrorMsg;
            if (result.IsSucess)
            {
                for (int i = 0; i < result.ResData.Count; i++)
                {
                    repoResult.ResData.Add((CustomerM)GetCustomerM(result.ResData[i]));
                }
            }
            return repoResult;
        }

        static public async System.Threading.Tasks.Task<RepoResultM> AddCustomerAsync(CustomerM customerM)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@name", customerM.Name),
                new SqlParameter("@nic", customerM.NIC),
                new SqlParameter("@birthDate", customerM.BirthDate),
                new SqlParameter("@address", customerM.Address),
                new SqlParameter("@phone", customerM.Phone),
                new SqlParameter("@genId", customerM.GenderM.Id),
                new SqlParameter("@cateId", customerM.CategoryM.Id)
            };

            DBResult result = await DBHelper.ExcuteStoredProcedNonQueryAsync(addProcedName, parameters, "");
            RepoResultM repoResult = new RepoResultM();
            repoResult.IsSucess = result.IsSucess;
            repoResult.EfectedRows = result.EfectedRows;
            repoResult.ErrorMsg = result.ErrorMsg;
            return repoResult;
        }

        public static async Task<RepoResultM> UpdateCustomerAsync(CustomerM customerM)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@id", customerM.Id),
                new SqlParameter("@name", customerM.Name),
                new SqlParameter("@nic", customerM.NIC),
                new SqlParameter("@birthDate", customerM.BirthDate),
                new SqlParameter("@address", customerM.Address),
                new SqlParameter("@phone", customerM.Phone),
                new SqlParameter("@genId", customerM.GenderM.Id),
                new SqlParameter("@cateId", customerM.CategoryM.Id)
            };

            DBResult result = await DBHelper.ExcuteStoredProcedNonQueryAsync(updateProcedName, parameters, "");
            RepoResultM repoResult = new RepoResultM();
            repoResult.IsSucess = result.IsSucess;
            repoResult.EfectedRows = result.EfectedRows;
            repoResult.ErrorMsg = result.ErrorMsg;
            return repoResult;
        }

        public static async System.Threading.Tasks.Task<RepoResultM> DeleteCustomerAsync(int id)
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
