using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi.Models;

namespace webApi.Repository
{
    public class OrderDetailRepo : IRepository<OrderDetail>
    {
        public IEnumerable<OrderDetail> GetAll()
        {
            throw new NotImplementedException();
        }

        public OrderDetail GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
