using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi.DataAccess;
using webApi.Models;

namespace webApi.Repository
{
    public class CustomerRepo : IRepository<Customer>
    {
        public readonly DataBaseContext _context;

        public CustomerRepo(DataBaseContext context)
        {
            _context = context;
        }

        public Customer createData(Customer obj)
        {
            try
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
            }

        }


        public Customer GetById(int id)
        {
            try
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
            }


        }

        public IEnumerable<Customer> GetAll()
        {
            try
            {
                IEnumerable<Customer> customers = _context.Customer.FromSqlRaw("spGetCustomer").ToList();
                return customers;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Customer updateData(Customer obj)
        {
            throw new NotImplementedException();
        }
        public bool DeleteById(int id)
        {
            try
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
            }
        }


    }
}
