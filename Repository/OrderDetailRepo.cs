﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi.DataAccess;
using webApi.Models;

namespace webApi.Repository
{
    public class OrderDetailRepo : IRepository<OrderDetail>
    {
        private readonly DataBaseContext _context;

        public OrderDetailRepo(DataBaseContext context)
        {
            _context = context;
        }

        public OrderDetail createData(OrderDetail obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDetail> GetAll()
        {
            throw new NotImplementedException();
        }

        public OrderDetail GetById(int id)
        {
            throw new NotImplementedException();
        }

        public OrderDetail updateData(OrderDetail obj)
        {
            throw new NotImplementedException();
        }
        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

    }
}
