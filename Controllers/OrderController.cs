using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webApi.Models;
using webApi.Repository;

namespace webApi.Controllers
{
    [Route("api/Order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IRepository<Orders> _repository;

        public OrderController(IRepository<Orders> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Orders>> GetAllOrders()
        {
            throw new NotImplementedException();
        }
        [HttpGet("{id}")]
        public ActionResult<Orders> GetOneOrder(int id)
        {
            throw new NotImplementedException();
        }
    }
}