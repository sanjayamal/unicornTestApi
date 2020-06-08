using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webApi.Business;
using webApi.Models;
using webApi.Repository;

namespace webApi.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductBusiness _business;

        public ProductController(ProductBusiness business)
        {
            _business = business;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProduct()
        {
            List<Product> products =(List<Product>)_business.GetAllProduct();
            return products;
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetOneProduct(int id)
        {
            Product product = _business.GetOneProduct(id);
            return product;
        }
        [HttpPost]
        public Product CreateProduct(Product productObj)
        {
            Product product = _business.CreateProduct(productObj);
            return product;
        }
        [HttpPut]
        public Product UpdateProduct(Product productObj)
        {
            Product product = _business.UpdateProduct(productObj);
            return productObj;
        }
        [HttpDelete("{id}")]
        public bool DeleteProduct(int id)
        {
            bool response = _business.DeleteProduct(id);
            return response;
        }
    }
}