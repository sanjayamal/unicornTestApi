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
        public  IEnumerable<Customer> GetAll()
        {
            
            string queryString = "Exec spGetCustomer";
            IEnumerable<Customer> cst = _context.Customer.FromSqlRaw(queryString).ToList();
           // await this.Query<Customer>().FromSql(queryString).ToListAsync();
            return cst;
        }

        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
