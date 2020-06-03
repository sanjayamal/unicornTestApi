using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi.Models;
using webApi.Repository;

namespace webApi.Business
{
    public class OrderBusiness
    {
        private readonly IRepository<Orders> _repository;

        public OrderBusiness(IRepository<Orders> repository)
        {
            _repository = repository;
        }

        public  IEnumerable<Orders> GetAllOrder()
        {
            throw new NotImplementedException();
        }
        public Orders GetOneProduct(int id)
        {
            throw new NotImplementedException();
        }
    }
}
