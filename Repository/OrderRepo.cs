using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi.DataAccess;
using webApi.Models;

namespace webApi.Repository
{
    public class OrderRepo : IRepository<Orders>
    {
        private readonly DataBaseContext _context;

        public OrderRepo(DataBaseContext context)
        {
            _context= context
        }
        public IEnumerable<Orders> GetAll()
        {
            throw new NotImplementedException();
        }

        public Orders GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
