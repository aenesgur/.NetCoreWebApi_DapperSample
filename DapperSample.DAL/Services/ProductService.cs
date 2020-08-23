using Dapper;
using DapperSample.DAL.Helpers;
using DapperSample.DAL.Services.Interfaces;
using DapperSample.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace DapperSample.DAL.Services
{
    public class ProductService : IProductService
    {
        private Product _product;
        private List<Product> _products;

        public async Task<bool> Create(Product product)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(SqlHelper.ConnectionString))
                {
                    if (connection.State == ConnectionState.Closed) connection.Open();

                    await connection.QueryAsync<Product>("sp_ProductSave",
                        this.SetParameters(product),
                        commandType: CommandType.StoredProcedure);

                    return true;
                }           
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var product = Get(id);
                if (product.Result == null)
                    return false;

                using (IDbConnection connection = new SqlConnection(SqlHelper.ConnectionString))
                {
                    if (connection.State == ConnectionState.Closed) connection.Open();

                    await connection.QueryAsync<Product>("sp_ProductDelete",
                        new { Id = id },
                        commandType: CommandType.StoredProcedure);

                    return true;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<List<Product>> Get()
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(SqlHelper.ConnectionString))
                {
                    if (connection.State == ConnectionState.Closed) connection.Open();

                    var products = await connection.QueryAsync<Product>("SELECT * FROM PRODUCT");

                    if (products != null && products.Count() > 0)
                    {
                        return products.ToList();
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<Product> Get(int id)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(SqlHelper.ConnectionString))
                {
                    if (connection.State == ConnectionState.Closed) connection.Open();

                    var product = await connection.QueryAsync<Product>("SELECT * FROM PRODUCT WHERE Id = "+ id);


                    if (product != null && product.Count() > 0)
                    {
                        return product.FirstOrDefault();
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        private DynamicParameters SetParameters(Product product)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Name", product.Name);
            parameters.Add("@Price", product.Price);
            parameters.Add("@Origin", product.Origin);

            return parameters;

        }
    }
}
