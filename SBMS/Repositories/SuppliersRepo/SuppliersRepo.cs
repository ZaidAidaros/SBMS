using SBMS.Models.Suppliers;
using SBMS.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS.Repositories.SuppliersRepo
{
    class SuppliersRepo
    {
        private static string addProcedName = "AddSupolier";
        private static string updateProcedName = "UpdateSupplier";
        private static string deleteProcedName = "DeleteSupplier";
        private static string getProcedName = "GetSuppliers";
        private static string searchProcedName = "SearchSupplier";
        private static string filterCategProcedName = "FilterSuppByCategory";

        private static SupplierM GetSupplierM(List<object> result)
        {
            SupplierM supplierM = new SupplierM();
            supplierM.Id = (int)result[0];
            supplierM.Name = result[1].ToString();
            supplierM.Address = result[2].ToString();
            supplierM.Phone = result[3].ToString();
            supplierM.CategoryM.Name = result[4].ToString();
            return supplierM;
        }
        public static async Task<RepoResultM> GetSuppliersAsync()
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
                    repoResult.ResData.Add((SupplierM)GetSupplierM(result.ResData[i]));
                }
            }
            return repoResult;
        }

        public static async Task<RepoResultM> SearchSupplierAsync(string searchValueIdName)
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
                    repoResult.ResData.Add((SupplierM)GetSupplierM(result.ResData[i]));
                }
            }
            return repoResult;
        }

        public static async Task<RepoResultM> FilterSuppliersByCategoryAsync(int cateId)
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
                    repoResult.ResData.Add((SupplierM)GetSupplierM(result.ResData[i]));
                }
            }
            return repoResult;
        }

        static public async Task<RepoResultM> AddCustomerAsync(SupplierM supplierM)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@name", SqlDbType.NVarChar),
                new SqlParameter("@address", SqlDbType.NVarChar),
                new SqlParameter("@phone", SqlDbType.NVarChar),
                new SqlParameter("@cateId", SqlDbType.Int)
            };
            parameters[0].Value = supplierM.Name;
            parameters[1].Value = supplierM.Address;
            parameters[2].Value = supplierM.Phone;
            parameters[3].Value = supplierM.CategoryM.Id;
            DBResult result = await DBHelper.ExcuteStoredProcedNonQueryAsync(addProcedName, parameters, "");
            RepoResultM repoResult = new RepoResultM();
            repoResult.IsSucess = result.IsSucess;
            repoResult.EfectedRows = result.EfectedRows;
            repoResult.ErrorMsg = result.ErrorMsg;
            return repoResult;
        }

        public static async Task<RepoResultM> UpdateCustomerAsync(SupplierM supplierM)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@id", SqlDbType.Int),
                new SqlParameter("@name", SqlDbType.NVarChar),
                new SqlParameter("@address", SqlDbType.NVarChar),
                new SqlParameter("@phone", SqlDbType.NVarChar),
                new SqlParameter("@cateId", SqlDbType.Int)
            };
            parameters[0].Value = supplierM.Id;
            parameters[1].Value = supplierM.Name;
            parameters[2].Value = supplierM.Address;
            parameters[3].Value = supplierM.Phone;
            parameters[4].Value = supplierM.CategoryM.Id;
            
            DBResult result = await DBHelper.ExcuteStoredProcedNonQueryAsync(updateProcedName, parameters, "");
            RepoResultM repoResult = new RepoResultM();
            repoResult.IsSucess = result.IsSucess;
            repoResult.EfectedRows = result.EfectedRows;
            repoResult.ErrorMsg = result.ErrorMsg;
            return repoResult;
        }

        public static async Task<RepoResultM> DeleteCustomerAsync(int id)
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
