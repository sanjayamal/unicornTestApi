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
    public class CustomerRepo : IRepository<Customer>
    {
        public readonly DataBaseContext _context;
        private readonly IConfiguration _configuration;

        public CustomerRepo(IConfiguration configuration /*DataBaseContext context*/)
        {
            // _context = context;
            _configuration = configuration;
        }

        public Customer createData(Customer obj)
        {
            Customer customer = new Customer();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SqlServerConnection")))
            {
                string sql = "spCreateCustomer";
                SqlCommand command = new SqlCommand(sql, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter param;
                param = command.Parameters.Add("@FirstName", SqlDbType.VarChar, 100);
                param.Value = obj.FirstName;

                param = command.Parameters.Add("@LastName", SqlDbType.VarChar, 100);
                param.Value = obj.LastName;

                param = command.Parameters.Add("@IDNo", SqlDbType.VarChar, 20);
                param.Value = obj.IDNo;

                param = command.Parameters.Add("@Address", SqlDbType.VarChar, 200);
                param.Value = obj.Address;

                param = command.Parameters.Add("@Mobile", SqlDbType.VarChar, 100);
                param.Value = obj.Mobile;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        customer = MaptoValue(reader);
                    }
                    reader.Close();
                    return customer;
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

            /*            try
                        {
                            SqlParameter pFirstName = new SqlParameter("@FirstName", obj.FirstName);
                            SqlParameter pLastName = new SqlParameter("@LastName", obj.LastName);
                            SqlParameter pIDNo = new SqlParameter("@IDNo", obj.IDNo);
                            SqlParameter pAddress = new SqlParameter("@Address", obj.Address);
                            SqlParameter pMobile = new SqlParameter("@Mobile", obj.Mobile);

                            Customer customer = _context.Customer.FromSqlRaw("spCreateCustomer @FirstName,@LastName, @IDNo,@Address,@Mobile", pFirstName, pLastName, pIDNo, pAddress, pMobile)
                                .AsEnumerable<Customer>()
                                .FirstOrDefault();
                            return customer;
                        }
                        catch (Exception exp)
                        {
                            Console.WriteLine(exp.Message);
                            throw;
                        }*/
        }


        public Customer GetById(int id)
        {
            Customer customer = new Customer();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SqlServerConnection")))
            {
                string sql = "spGetCustomer";
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
                        customer = MaptoValue(reader);
                    }
                    reader.Close();
                    return customer;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
                /*           try
                           {
                               SqlParameter parameter = new SqlParameter("@id", id);
                               Customer customer = _context.Customer.FromSqlRaw("spGetCustomer @id", parameter)
                                   .AsEnumerable<Customer>()
                                   .FirstOrDefault();
                               return customer;
                           }
                           catch (Exception exp)
                           {
                               Console.WriteLine(exp.Message);
                               throw;
                           }*/
            }
        }
        public IEnumerable<Customer> GetAll()
        {
            List<Customer> customers = new List<Customer>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SqlServerConnection")))
            {
                string sql = "spGetCustomer";
                SqlCommand command = new SqlCommand(sql, connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        customers.Add(MaptoValue(reader));
                    }
                    reader.Close();

                    return customers;
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
            /*            try
                        {
                            IEnumerable<Customer> customers = _context.Customer.FromSqlRaw("spGetCustomer").ToList();
                            return customers;
                        }
                        catch (Exception)
                        {
                            throw;
                        }*/

        }

        public Customer updateData(Customer obj)
        {

            Customer customer = new Customer();
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SqlServerConnection")))
            {
                string sql = "spUpdateCustomer";
                SqlCommand command = new SqlCommand(sql, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter param;
                param = command.Parameters.Add("@id", SqlDbType.Int);
                param.Value = obj.CustomerID;

                param = command.Parameters.Add("@FirstName", SqlDbType.VarChar, 100);
                param.Value = obj.FirstName;

                param = command.Parameters.Add("@LastName", SqlDbType.VarChar, 100);
                param.Value = obj.LastName;

                param = command.Parameters.Add("@IDNo", SqlDbType.VarChar, 20);
                param.Value = obj.IDNo;

                param = command.Parameters.Add("@Address", SqlDbType.VarChar, 200);
                param.Value = obj.Address;

                param = command.Parameters.Add("@Mobile", SqlDbType.VarChar, 100);
                param.Value = obj.Mobile;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        customer = MaptoValue(reader);
                    }
                    reader.Close();

                    return customer;
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
            /*try
            {
                SqlParameter pId = new SqlParameter("@id", obj.CustomerID);
                SqlParameter pFirstName = new SqlParameter("@FirstName", obj.FirstName);
                SqlParameter pLastName = new SqlParameter("@LastName", obj.LastName);
                SqlParameter pIDNo = new SqlParameter("@IDNo", obj.IDNo);
                SqlParameter pAddress = new SqlParameter("@Address", obj.Address);
                SqlParameter pMobile = new SqlParameter("@Mobile", obj.Mobile);
                spUpdateCustomer
                Customer customer = _context.Customer.FromSqlRaw("spUpdateCustomer @id,@FirstName,@LastName, @IDNo,@Address,@Mobile", pId, pFirstName, pLastName, pIDNo, pAddress, pMobile)
                    .AsEnumerable<Customer>()
                    .FirstOrDefault();
                return customer;
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
                throw;
            }*/

        }
        public bool DeleteById(int id)
        {

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SqlServerConnection")))
            {
                string sql = "spDeleteCustomer";
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
                finally
                {
                    connection.Close();
                }
                return false;
            }
            /*            try
                        {
                            SqlParameter parameter = new SqlParameter("@id", id);
                            int effectRow = _context.Database.ExecuteSqlRaw("spDeleteCustomer @id", parameter);

                            if (effectRow > 0)
                            {
                                return true;
                            }
                            return false;
                        }
                        catch (Exception exp)
                        {
                            Console.WriteLine(exp.Message);
                            throw;
                        }*/
        }
        private Customer MaptoValue(SqlDataReader reader)
        {
            return new Customer
            {
                CustomerID = (int)reader["CustomerID"],
                FirstName = (string)reader["FirstName"],
                LastName = (string)reader["LastName"],
                IDNo = (string)reader["IDNo"],
                Address = (string)reader["Address"],
                Mobile = (string)reader["Mobile"],
            };
        }

    }
}
