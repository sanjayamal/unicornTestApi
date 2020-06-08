using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
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

        public Product CreateProduct(Product productObj)
        {
            Product product = _repository.createData(productObj);
            return product;
        }
        public IEnumerable<Product> GetAllProduct()
        {
            IEnumerable<Product> products = _repository.GetAll();
            return products;
        }
        public Product GetOneProduct(int id)
        {
            Product product = _repository.GetById(id);
            return product;
        }

        public Product UpdateProduct(Product productObj)
        {
            Product product = _repository.updateData(productObj);
            return product;
        }

        public bool DeleteProduct(int id)
        {
            bool response = _repository.DeleteById(id);
            return response;
        }
    }
}
