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
    [Route("api/Order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderBusiness _business;

        public OrderController(OrderBusiness business)
        {
            _business = business;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Orders>> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public ActionResult<Orders> GetOneOrder(int id)
        {
            Orders orderswithOrderDetails = _business.GetOrderWithOrderLine(id);
            return orderswithOrderDetails;
        }

        [HttpPost]
        public ActionResult<Orders> CreateOrder(Orders ordersObj)
        {
            Orders order = _business.CreateOrder(ordersObj);
            return order;

        }
    }
}