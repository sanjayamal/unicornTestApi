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
        private readonly DataBaseContext _context;

        public CustomerRepo(DataBaseContext context)
        {
            _context = context;
        }
        public IEnumerable<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
