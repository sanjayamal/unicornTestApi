using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webApi.Models;
using webApi.Repository;

namespace webApi.Controllers
{
    [Route("api/OrderDetail")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IRepository<OrderDetail> _repository;

        public OrderDetailController(IRepository<OrderDetail> repository) 
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OrderDetail>> GetAllOrderDetails()
        {
            throw new NotImplementedException();
        }
        [HttpGet("{id}")]
        public ActionResult<OrderDetail> GetOneOrderDetail(int id)
        {
            throw new NotImplementedException();
        }
    }
}