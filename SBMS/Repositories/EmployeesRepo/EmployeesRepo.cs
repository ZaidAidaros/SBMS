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
    class EmployeesRepo
    {
        private static string addProcedName = "AddEmployee";
        private static string updateProcedName = "UpdateEmployee";
        private static string deleteProcedName = "DeleteEmployee";
        private static string getProcedName = "GetEmployees";
        private static string searchProcedName = "SearchEmployee";
        private static string filterJobTitleProcedName = "FilterEmpByJTitle";

        private static EmployeeM GetEmployeeM(List<object> result)
        {
            EmployeeM employeeM = new EmployeeM();
            employeeM.Id = (int)result[0];
            employeeM.Name = result[1].ToString();
            employeeM.NIC = (int)result[2];
            employeeM.BirthDate = (DateTime)result[3];
            employeeM.Address = result[4].ToString();
            employeeM.Phone = result[5].ToString();
            employeeM.Salary = decimal.Parse(result[6].ToString());
            employeeM.Genderm.Name = result[7].ToString();
            employeeM.Jobm.Name = result[8].ToString();
            employeeM.Note = result[9].ToString();
            return employeeM;
        }
        public static async Task<RepoResultM> GetEmployeesAsync()
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
                    repoResult.ResData.Add((EmployeeM)GetEmployeeM(result.ResData[i]));
                }
            }
            return repoResult;
        }

        public static async Task<RepoResultM> SearchEmployeeAsync(string searchValueIdName)
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
                    repoResult.ResData.Add((EmployeeM)GetEmployeeM(result.ResData[i]));
                }
            }
            return repoResult;
        }

        public static async Task<RepoResultM> FilterEmployeesByJobTitleAsync(int jobTitleId)
        {

            SqlParameter[] parameters = {
                new SqlParameter("@jobTitleId", SqlDbType.Int)
            };
            parameters[0].Value = jobTitleId;
            RepoResultM repoResult = new RepoResultM();
            DBResult result = await DBHelper.ExcuteStoredProcedQueryAsync(filterJobTitleProcedName, parameters);
            repoResult.IsSucess = result.IsSucess;
            repoResult.ErrorMsg = result.ErrorMsg;
            if (result.IsSucess)
            {
                for (int i = 0; i < result.ResData.Count; i++)
                {
                    repoResult.ResData.Add((EmployeeM)GetEmployeeM(result.ResData[i]));
                }
            }
            return repoResult;
        }

        static public async Task<RepoResultM> AddEmployeeAsync(EmployeeM employeeM)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@name", SqlDbType.NVarChar),
                new SqlParameter("@nic", SqlDbType.Int),
                new SqlParameter("@birthDate", SqlDbType.Date),
                new SqlParameter("@address", SqlDbType.NVarChar),
                new SqlParameter("@phone", SqlDbType.NVarChar),
                new SqlParameter("@basicSalary", SqlDbType.Real),
                new SqlParameter("@genderId", SqlDbType.Int),
                new SqlParameter("@jobTitleId", SqlDbType.Int),
                new SqlParameter("@note", SqlDbType.NVarChar)
            };
            parameters[0].Value = employeeM.Name;
            parameters[1].Value = employeeM.NIC;
            parameters[2].Value = employeeM.BirthDate.ToShortDateString();
            parameters[3].Value = employeeM.Address;
            parameters[4].Value = employeeM.Phone;
            parameters[5].Value = employeeM.Salary;
            parameters[6].Value = employeeM.Genderm.Id;
            parameters[7].Value = employeeM.Jobm.Id;
            parameters[8].Value = employeeM.Note;
            DBResult result = await DBHelper.ExcuteStoredProcedNonQueryAsync(addProcedName, parameters, "");
            RepoResultM repoResult = new RepoResultM();
            repoResult.IsSucess = result.IsSucess;
            repoResult.EfectedRows = result.EfectedRows;
            repoResult.ErrorMsg = result.ErrorMsg;
            return repoResult;
        }

        public static async Task<RepoResultM> UpdateEmployeeAsync(EmployeeM employeeM)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@id", SqlDbType.Int),
                new SqlParameter("@name", SqlDbType.NVarChar),
                new SqlParameter("@nic", SqlDbType.Int),
                new SqlParameter("@birthDate", SqlDbType.Date),
                new SqlParameter("@address", SqlDbType.NVarChar),
                new SqlParameter("@phone", SqlDbType.NVarChar),
                new SqlParameter("@basicSalary", SqlDbType.Real),
                new SqlParameter("@genderId", SqlDbType.Int),
                new SqlParameter("@jobTitleId", SqlDbType.Int),
                new SqlParameter("@note", SqlDbType.NVarChar)
            };
            parameters[0].Value = employeeM.Id;
            parameters[1].Value = employeeM.Name;
            parameters[2].Value = employeeM.NIC;
            parameters[3].Value = employeeM.BirthDate.ToShortDateString();
            parameters[4].Value = employeeM.Address;
            parameters[5].Value = employeeM.Phone;
            parameters[6].Value = employeeM.Salary;
            parameters[7].Value = employeeM.Genderm.Id;
            parameters[8].Value = employeeM.Jobm.Id;
            parameters[9].Value = employeeM.Note;

            DBResult result = await DBHelper.ExcuteStoredProcedNonQueryAsync(updateProcedName, parameters, "");
            RepoResultM repoResult = new RepoResultM();
            repoResult.IsSucess = result.IsSucess;
            repoResult.EfectedRows = result.EfectedRows;
            repoResult.ErrorMsg = result.ErrorMsg;
            return repoResult;
        }

        public static async Task<RepoResultM> DeleteEmployeeAsync(int id)
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
