using Microsoft.Data.SqlClient;
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
    public class OrderRepo : IRepository<Orders>
    {
        private readonly IConfiguration _configuration;

        public OrderRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Orders createData(Orders obj)
        {
            Orders order = new Orders();
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SqlServerConnection")))
            {
                string sql = "spCreateOrder";
                SqlCommand command = new SqlCommand(sql, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter param;

                param = command.Parameters.Add("@CustomerId", SqlDbType.Int);
                param.Value = obj.CustomerId;

                param = command.Parameters.Add("@OrderDate", SqlDbType.DateTime);
                param.Value = obj.OrderDate;

                param = command.Parameters.Add("@OrderAmount", SqlDbType.Decimal);
                param.Value = obj.OrderAmount;


                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        order = MaptoValue(reader);
                    }
                    reader.Close();
                    return order;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public IEnumerable<Orders> GetAll()
        {
            throw new NotImplementedException();
        }

        public Orders GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Orders updateData(Orders obj)
        {
            throw new NotImplementedException();
        }
        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        private Orders MaptoValue(SqlDataReader reader)
        {
            return new Orders
            {
               
                OrderId = (int)reader["OrderId"],
                CustomerId = (int)reader["CustomerId"],
                OrderDate = (DateTime)reader["OrderDate"],
                OrderAmount = (Decimal)reader["OrderAmount"]

            };
        }
    }
}
