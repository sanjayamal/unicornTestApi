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
       
        private readonly SqlConnection connection;

        public OrderRepo(IConfiguration configuration)
        {
            connection = new SqlConnection(configuration.GetConnectionString("SqlServerConnection"));

        }

        public Orders createData(Orders obj)
        {
            Orders order = new Orders();
            using (connection)
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
            }
        }
        public IEnumerable<Orders> GetAll()
        {
            throw new NotImplementedException();
        }

        public Orders GetById(int id)
        {
            Orders orders = new Orders();

            using (connection)
            {
                string sql = "spGetOrder";
                SqlCommand command = new SqlCommand(sql, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter param;
                param = command.Parameters.Add("@OrderId", SqlDbType.Int);
                param.Value = id;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        orders = MaptoValue(reader);
                    }
                    reader.Close();
                    return orders;
                }
                catch (Exception)
                {
                    throw;
                }
            }
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
                OrderAmount = (Decimal)reader["OrderAmount"],

            };
        }
    }
}
