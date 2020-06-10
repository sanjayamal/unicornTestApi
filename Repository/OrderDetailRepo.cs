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
    public class OrderDetailRepo : IRepository<OrderDetail>
    {
       
        private readonly SqlConnection connection;

        public OrderDetailRepo(IConfiguration configuration)
        {
            connection = new SqlConnection(configuration.GetConnectionString("SqlServerConnection"));
        }

        public OrderDetail createData(OrderDetail obj)
        {
            OrderDetail orderDetail = new OrderDetail();

            using (connection)
            {
                string sql = "spCreateOrderDetail";
                SqlCommand command = new SqlCommand(sql, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter param;
                param = command.Parameters.Add("@LineNo", SqlDbType.Int);
                param.Value = obj.LineNos;

                param = command.Parameters.Add("@OrderNo", SqlDbType.Int);
                param.Value = obj.OrderNo;

                param = command.Parameters.Add("@ProductId", SqlDbType.Int);
                param.Value = obj.ProductId;

                param = command.Parameters.Add("@NoOfUnits", SqlDbType.Int);
                param.Value = obj.NoOfUnits;

                param = command.Parameters.Add("@UnitPrice", SqlDbType.Decimal);
                param.Value = obj.UnitPrice;

                param = command.Parameters.Add("@Amount", SqlDbType.Decimal);
                param.Value = obj.Amount;

                param = command.Parameters.Add("@Discount", SqlDbType.Decimal);
                param.Value = obj.Discount;

                param = command.Parameters.Add("@NetAmount", SqlDbType.Decimal);
                param.Value = obj.NetAmount;


                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        orderDetail = MaptoValue(reader);
                    }
                    reader.Close();
                    return orderDetail;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public IEnumerable<OrderDetail> GetAll()
        {
            throw new NotImplementedException();
        }

        public OrderDetail GetById(int id)
        {
            throw new NotImplementedException();
        }

        public OrderDetail updateData(OrderDetail obj)
        {
            throw new NotImplementedException();
        }
        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDetail> GetAllByOrderId(int id)
        {
            List<OrderDetail> orderDetails = new List<OrderDetail>();

            using (connection)
            {
                string sql = "spGetOrderdetail";
                SqlCommand command = new SqlCommand(sql, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter param;
                param = command.Parameters.Add("@OrderNo", SqlDbType.Int);
                param.Value = id;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        orderDetails.Add(MaptoValue(reader));
                    }
                    reader.Close();

                    return orderDetails;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public OrderDetail MaptoValue(SqlDataReader reader)
        {
            return new OrderDetail
            {
                OrderDetailId = (int)reader["OrderDetailId"],
                LineNos = (int)reader["LineNos"],
                OrderNo = (int)reader["OrderNo"],
                ProductId = (int)reader["ProductId"],
                NoOfUnits = (int)reader["NoOfUnits"],
                UnitPrice = (Decimal)reader["UnitPrice"],
                Amount = (Decimal)reader["UnitPrice"],
                Discount = (Decimal)reader["Discount"],
                NetAmount = (Decimal)reader["NetAmount"],
            };
        }
    }
}
