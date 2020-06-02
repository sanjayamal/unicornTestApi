using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webApi.Models;
using webApi.Repository;

namespace webApi.Controllers
{
    [Route("api/Customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IRepository<Customer> _repository;

        public CustomerController(IRepository<Customer> repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public ActionResult <IEnumerable<Customer>> GetAllCustomer()
        {
             throw new System.ArgumentException("original");
        }
        [HttpGet("{id}")]
        public ActionResult <Customer> GetOneCustomer(int id)
        {
            throw new System.ArgumentException("original");
        }
    }
}