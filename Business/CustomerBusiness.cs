using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi.Models;
using webApi.Repository;

namespace webApi.Business
{
    public class CustomerBusiness
    {
        private readonly IRepository<Customer> _repository;

        public CustomerBusiness(IRepository<Customer> repository)
        {
            _repository = repository;
        }
        public IEnumerable<Customer> GetAllCustomer()
        {
            IEnumerable<Customer> customers = _repository.GetAll();
            return customers;
        }

        public Customer GetOneCustomer(int id)
        {
            throw new NotImplementedException();
        }
    }
}
