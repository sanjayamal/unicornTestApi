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
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetOneProduct(int id)
        {
            throw new NotImplementedException();
        }
    }
}