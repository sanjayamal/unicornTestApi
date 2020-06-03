using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi.Models;
using webApi.Repository;

namespace webApi.Business
{
    public class OrderDetailBusiness
    {
        private readonly IRepository<OrderDetail> _repository;

        public OrderDetailBusiness(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public IEnumerable<OrderDetail> GetAllOrderDetail()
        {
            throw new NotImplementedException();
        }

        public OrderDetail GetOneOrderDetail()
        {
            throw new NotImplementedException();
        }
    }
}
