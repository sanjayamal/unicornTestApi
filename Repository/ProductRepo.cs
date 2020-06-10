using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using webApi.DataAccess;
using webApi.Models;

namespace webApi.Repository
{
    public class ProductRepo : IRepository<Product>
    {
   
        private readonly SqlConnection connection;

        public ProductRepo(IConfiguration configuration)
        {
            connection = new SqlConnection(configuration.GetConnectionString("SqlServerConnection"));
        }

        public Product createData(Product obj)
        {
            Product product = new Product();

            using (connection)
            {
                string sql = "spCreateProduct";
                SqlCommand command = new SqlCommand(sql, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter param;
                param = command.Parameters.Add("@ProductName", SqlDbType.VarChar, 100);
                param.Value = obj.ProductName;

                param = command.Parameters.Add("@ProductDescription", SqlDbType.VarChar, 350);
                param.Value = obj.ProductDescription;

                param = command.Parameters.Add("@Price", SqlDbType.Decimal);
                param.Value = obj.Price;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        product = MaptoValue(reader);
                    }
                    reader.Close();
                    return product;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public IEnumerable<Product> GetAll()
        {
            List<Product> products = new List<Product>();


            using (connection)
            {
                string sql = "spGetProduct";
                SqlCommand command = new SqlCommand(sql, connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        products.Add(MaptoValue(reader));
                    }
                    reader.Close();
                    return products;
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                    throw;
                }

            }
        }
        public Product GetById(int id)
        {
            Product product = new Product();
            using (connection)
            {
                string sql = "spGetProduct";
                SqlCommand command = new SqlCommand(sql, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter param;
                param = command.Parameters.Add("@id", SqlDbType.Int);
                param.Value = id;
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        product = MaptoValue(reader);
                    }
                    reader.Close();
                    return product;

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public Product updateData(Product obj)
        {
            Product product = new Product();
            using (connection)
            {
                string sql = "spUpdateProduct";
                SqlCommand command = new SqlCommand(sql, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter param;
                param = command.Parameters.Add("@id", SqlDbType.Int);
                param.Value = obj.ProductId;

                param = command.Parameters.Add("@ProductName", SqlDbType.VarChar, 100);
                param.Value = obj.ProductName;

                param = command.Parameters.Add("@ProductDescription", SqlDbType.VarChar, 100);
                param.Value = obj.ProductDescription;

                param = command.Parameters.Add("@Price", SqlDbType.Decimal);
                param.Value = obj.Price;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        product = MaptoValue(reader);
                    }
                    reader.Close();

                    return product;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public bool DeleteById(int id)
        {
            using (connection)
            {
                string sql = "spDeleteProduct";
                SqlCommand command = new SqlCommand(sql, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter param;
                param = command.Parameters.Add("@id", SqlDbType.Int);
                param.Value = id;

                try
                {
                    connection.Open();
                    int effect_row = command.ExecuteNonQuery();
                    if (effect_row > 0)
                    {
                        return true;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                return false;
            }
        }
        private Product MaptoValue(SqlDataReader reader)
        {
            return new Product
            {
                ProductId = (int)reader["ProductId"],
                ProductName = (string)reader["ProductName"],
                ProductDescription = reader["ProductDescription"] != DBNull.Value ? (string)reader["ProductDescription"] : "No Decription",
                Price = (decimal)reader["Price"]

            };
        }
    }
}
