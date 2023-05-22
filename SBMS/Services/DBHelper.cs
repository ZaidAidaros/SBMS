using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS.Services
{
    internal static class DBHelper
    {
        
        private static SqlConnection GetDBConnect()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = Properties.Settings.Default.DBServerName;
            builder.InitialCatalog = Properties.Settings.Default.DBName;
            builder.IntegratedSecurity = true;
            return new SqlConnection(builder.ConnectionString);
        }


       

        public static async Task<DBResult> ExcuteStoredProcedQueryAsync(string procedName, SqlParameter[] parameters)
        {
            DBResult dBResult = new DBResult();

            using (SqlConnection connection = GetDBConnect())
            using(SqlCommand sqlCommand = new SqlCommand(procedName,connection))
            {
                try
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    if (parameters.Length>0) sqlCommand.Parameters.AddRange(parameters);
                    connection.Open();
                    SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {
                        dBResult.IsSucess = true;
                        while (reader.Read())
                        {
                            List<object> row = new List<object>();
                            int c = reader.VisibleFieldCount;
                            for (int i = 0; i < c; i++) row.Add(reader[i]);
                            dBResult.ResData.Add(row);
                        }
                    }
                    else
                    {
                        dBResult.IsSucess = false;
                        dBResult.ErrorMsg = "No Result";
                    }
                    

                }
                catch(SqlException ex)
                {
                    dBResult.IsSucess = false;
                    dBResult.ErrorMsg = ex.Message;
                    dBResult.ResData = null;
                }
                finally
                {
                    connection.Close();
                }
            }

            return dBResult;
        }

        public static async Task<DBResult> ExcuteStoredProcedNonQueryAsync(string procedName, SqlParameter[] parameters,string outParameterName)
        {
            DBResult dBResult = new DBResult();

            using (SqlConnection connection = GetDBConnect())
            using (SqlCommand sqlCommand = new SqlCommand(procedName, connection))
            {
                try
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    if (parameters.Length > 0) sqlCommand.Parameters.AddRange(parameters);
                    connection.Open();
                    dBResult.EfectedRows = await sqlCommand.ExecuteNonQueryAsync();
                    dBResult.IsSucess = true;
                    if (!string.IsNullOrEmpty(outParameterName))
                    {
                        dBResult.ReturnIdOfNewRow = (int)sqlCommand.Parameters[outParameterName].Value;
                        
                    }
                }
                catch (SqlException ex)
                {
                    dBResult.IsSucess = false;
                    dBResult.ErrorMsg = ex.Message + "ErrorCode: " + ex.Number;
                    dBResult.EfectedRows = 0;
                    dBResult.ResData = null;
                }
                finally
                {
                    connection.Close();
                }
            }

            return dBResult;
        }





    }


    public class DBResult
    {
        public bool IsSucess { get; set; }
        public string ErrorMsg { get; set; }
        public List<List<object>> ResData { get; set; }
        public int EfectedRows { get; set; }
        public int ReturnIdOfNewRow { get; set; }
        public DBResult()
        {
            ResData = new List<List<object>>();
        }

    }
}
