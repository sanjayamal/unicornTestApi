using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webApi.Models;
using webApi.Repository;

namespace webApi.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Product> _repository;

        public ProductController(IRepository<Product> repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProduct()
        {
            throw new NotImplementedException();
        }

        public ActionResult<Product> GetOneProduct()
        {
            throw new NotImplementedException();
        }
    }
}