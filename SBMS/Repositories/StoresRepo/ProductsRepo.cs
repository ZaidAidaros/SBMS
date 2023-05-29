using SBMS.Models.Stores;
using SBMS.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SBMS.Repositories.StoresRepo
{
    class ProductsRepo
    {

        private static string AddProcedName = "AddProduct";
        private static string UpdateProcedName = "UpdateProduct";
        private static string DeleteProcedName = "DeleteProduct";
        private static string GetProductProcedName = "GetProducts";
        private static string GetFullProductProcedName = "GetFullProductsInfo";
        private static string GetProductDProcedName = "GetProductD";
        private static string SearchProcedName = "SearchProduct";
        private static string filterProcedName = "FilterByProdCategory";
        private static string GetFilterdFullProductProcedName = "GetFilterdFullProduct";
        private static string SearchFullProductProcedName = "SearchFullProduct";
        private static ProductM GetProductM(List<object> result)
        {
            ProductM product = new ProductM();
            product.Id = (int)result[0];
            product.BarCode = (int)result[1];
            product.Name = result[2].ToString();
            product.Description = result[3].ToString();
            product.Category = result[4].ToString();
            product.Unit = result[5].ToString();
            product.DefPrice = decimal.Parse(result[6].ToString());
            product.TotalQuantity = decimal.Parse(result[7].ToString());
            return product;
        }
        private static ProductM GetFullProductM(List<object> result)
        {
            ProductM product = new ProductM();
            product.DId = int.Parse(result[0].ToString());
            product.Id = int.Parse(result[1].ToString());
            product.BarCode = int.Parse(result[2].ToString());
            product.Name = result[3].ToString();
            product.Description = result[4].ToString();
            product.Category = result[5].ToString();
            product.Unit = result[6].ToString();
            product.DefPrice = decimal.Parse(result[7].ToString());
            product.Price = decimal.Parse(result[8].ToString());
            product.Cost = decimal.Parse(result[9].ToString());
            product.Quantity = decimal.Parse(result[10].ToString());
            product.TotalQuantity = decimal.Parse(result[11].ToString());
            product.ExpireDate = DateTime.Parse(result[12].ToString()).ToShortDateString();
            product.StoreDate = DateTime.Parse(result[13].ToString());
            return product;
        }
        public static async Task<RepoResultM> GetProductsAsync()
        {

            SqlParameter[] parameters = { };
            RepoResultM repoResult = new RepoResultM();
            DBResult result = await DBHelper.ExcuteStoredProcedQueryAsync(GetProductProcedName, parameters);
            repoResult.IsSucess = result.IsSucess;
            repoResult.ErrorMsg = result.ErrorMsg;
            if (result.IsSucess)
            {
                for (int i = 0; i < result.ResData.Count; i++)
                {
                    repoResult.ResData.Add((ProductM)GetProductM(result.ResData[i]));
                }
            }
            return repoResult;
        }
        public static async Task<RepoResultM> GetFullProductsAsync()
        {

            SqlParameter[] parameters = { };
            RepoResultM repoResult = new RepoResultM();
            DBResult result = await DBHelper.ExcuteStoredProcedQueryAsync(GetFullProductProcedName, parameters);
            repoResult.IsSucess = result.IsSucess;
            repoResult.ErrorMsg = result.ErrorMsg;
            if (result.IsSucess)
            {
                for (int i = 0; i < result.ResData.Count; i++)
                {
                    repoResult.ResData.Add((ProductM)GetFullProductM(result.ResData[i]));
                }
            }
            return repoResult;
        }
        public static async Task<RepoResultM> GetProdDetailsAsync(int pId)
        {

            SqlParameter[] parameters =
            {
                new SqlParameter("@prodId", pId)
            };
            RepoResultM repoResult = new RepoResultM();
            DBResult result = await DBHelper.ExcuteStoredProcedQueryAsync(GetProductDProcedName, parameters);
            repoResult.IsSucess = result.IsSucess;
            repoResult.ErrorMsg = result.ErrorMsg;
            if (result.IsSucess)
            {
                for (int i = 0; i < result.ResData.Count; i++)
                {
                    repoResult.ResData.Add((ProductM)GetProductM(result.ResData[i]));
                }
            }
            return repoResult;
        }
        public static async Task<RepoResultM> SearchProductAsync(string searchValueIdBarcodeName)
        {

            SqlParameter[] parameters = 
            {
                new SqlParameter("@id", SqlDbType.Int),
                new SqlParameter("@barCode", SqlDbType.Int),
                new SqlParameter("@name", SqlDbType.NVarChar),
            };
            parameters[0].Value = int.TryParse(searchValueIdBarcodeName, out _) ? Convert.ToInt32(searchValueIdBarcodeName) : 0;
            parameters[1].Value = int.TryParse(searchValueIdBarcodeName, out _) ? Convert.ToInt32(searchValueIdBarcodeName) : 0;
            parameters[2].Value = searchValueIdBarcodeName;
            RepoResultM repoResult = new RepoResultM();
            DBResult result = await DBHelper.ExcuteStoredProcedQueryAsync(SearchProcedName, parameters);
            repoResult.IsSucess = result.IsSucess;
            repoResult.ErrorMsg = result.ErrorMsg;
            if (result.IsSucess)
            {
                for (int i = 0; i < result.ResData.Count; i++)
                {
                    repoResult.ResData.Add((ProductM)GetProductM(result.ResData[i]));
                }
            }
            return repoResult;
        }
        public static async Task<RepoResultM> SearchFullProductAsync(string searchValueIdBarcodeName)
        {

            SqlParameter[] parameters =
            {
                new SqlParameter("@Id", SqlDbType.Int),
                new SqlParameter("@name", SqlDbType.NVarChar),
            };
            parameters[0].Value = int.TryParse(searchValueIdBarcodeName, out _) ? Convert.ToInt32(searchValueIdBarcodeName) : 0;
            parameters[1].Value = searchValueIdBarcodeName;
            RepoResultM repoResult = new RepoResultM();
            DBResult result = await DBHelper.ExcuteStoredProcedQueryAsync(SearchFullProductProcedName, parameters);
            repoResult.IsSucess = result.IsSucess;
            repoResult.ErrorMsg = result.ErrorMsg;
            if (result.IsSucess)
            {
                for (int i = 0; i < result.ResData.Count; i++)
                {
                    repoResult.ResData.Add((ProductM)GetFullProductM(result.ResData[i]));
                }
            }
            return repoResult;
        }
        public static async Task<RepoResultM> FilterProductsAsync(int cateId)
        {

            SqlParameter[] parameters =
            {
                new SqlParameter("@cateId", cateId),
            };
            RepoResultM repoResult = new RepoResultM();
            DBResult result = await DBHelper.ExcuteStoredProcedQueryAsync(filterProcedName, parameters);
            repoResult.IsSucess = result.IsSucess;
            repoResult.ErrorMsg = result.ErrorMsg;
            if (result.IsSucess)
            {
                for (int i = 0; i < result.ResData.Count; i++)
                {
                    repoResult.ResData.Add((ProductM)GetProductM(result.ResData[i]));
                }
            }
            return repoResult;
        }
        public static async Task<RepoResultM> FilterFullProductsAsync(int cateId)
        {

            SqlParameter[] parameters =
            {
                new SqlParameter("@cateId",cateId),
            };
            RepoResultM repoResult = new RepoResultM();
            DBResult result = await DBHelper.ExcuteStoredProcedQueryAsync(GetFilterdFullProductProcedName, parameters);
            repoResult.IsSucess = result.IsSucess;
            repoResult.ErrorMsg = result.ErrorMsg;
            if (result.IsSucess)
            {
                for (int i = 0; i < result.ResData.Count; i++)
                {
                    repoResult.ResData.Add((ProductM)GetFullProductM(result.ResData[i]));
                }
            }
            return repoResult;
        }
        static public async Task<RepoResultM> AddProductAsync(ProductM product)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@barCode", product.BarCode),
                new SqlParameter("@name", product.Name),
                new SqlParameter("@description",product.Description),
                new SqlParameter("@defPrice", product.DefPrice),
                new SqlParameter("@cateId", product.CategoryId),
                new SqlParameter("@unitId", product.UnitId)
            };

            DBResult result = await DBHelper.ExcuteStoredProcedNonQueryAsync(AddProcedName, parameters, "");
            RepoResultM repoResult = new RepoResultM();
            repoResult.IsSucess = result.IsSucess;
            repoResult.EfectedRows = result.EfectedRows;
            repoResult.ErrorMsg = result.ErrorMsg;
            return repoResult;
        }
        public static async Task<RepoResultM> UpdateProductAsync(ProductM product)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@id", product.Id),
                new SqlParameter("@barCode", product.BarCode),
                new SqlParameter("@name", product.Name),
                new SqlParameter("@description", product.Description),
                new SqlParameter("@defPrice", product.DefPrice),
                new SqlParameter("@cateId", product.CategoryId),
                new SqlParameter("@unitId", product.UnitId)
            };

            DBResult result = await DBHelper.ExcuteStoredProcedNonQueryAsync(UpdateProcedName, parameters, "");
            RepoResultM repoResult = new RepoResultM();
            repoResult.IsSucess = result.IsSucess;
            repoResult.EfectedRows = result.EfectedRows;
            repoResult.ErrorMsg = result.ErrorMsg;
            return repoResult;
        }
        public static async Task<RepoResultM> DeleteProductAsync(int id)
        {
            SqlParameter[] parameters = { new SqlParameter("@id", SqlDbType.Int) };
            parameters[0].Value = id;
            DBResult result = await DBHelper.ExcuteStoredProcedNonQueryAsync(DeleteProcedName, parameters, "");
            RepoResultM repoResult = new RepoResultM();
            repoResult.IsSucess = result.IsSucess;
            repoResult.ErrorMsg = result.ErrorMsg;
            repoResult.EfectedRows = result.EfectedRows;
            return repoResult;
        }

    }
}
