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
    [Route("api/OrderDetail")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly OrderDetailBusiness _business;

        public OrderDetailController(OrderDetailBusiness business) 
        {
            _business = business;
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