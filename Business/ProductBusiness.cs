using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi.Models;
using webApi.Repository;

namespace webApi.Business
{
    public class ProductBusiness
    {
        private readonly IRepository<Product> _repository;

        public ProductBusiness(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Product> GetAllProduct()
        {
            throw new NotImplementedException();
        }
        public Product GetOneProduct(int id)
        {
            throw new NotImplementedException();
        }

    }
}
