using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webApi.Business;
using webApi.Models;


namespace webApi.Controllers
{
    [Route("api/Customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerBusiness _business;

        public CustomerController(CustomerBusiness business)
        {
            _business = business;
        }

        [HttpGet]
        public ActionResult <IEnumerable<Customer>> GetAllCustomer()
        {
            List<Customer> customers= (List<Customer>)_business.GetAllCustomer();
            return customers;
        }

        [HttpGet("{id}")]
        public ActionResult <Customer> GetOneCustomer(int id)
        {
            throw new NotImplementedException();
        }
    }
}