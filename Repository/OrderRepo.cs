using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi.Models;

namespace webApi.Repository
{
    public class OrderRepo : IRepository<Orders>
    {
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
