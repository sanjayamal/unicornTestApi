using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi.Models;
using webApi.Repository;

namespace webApi.Business
{
    public class OrderBusiness
    {
        private readonly IRepository<Orders> _repository;
        private readonly OrderDetailBusiness _business;

        public OrderBusiness(IRepository<Orders> repository,OrderDetailBusiness business)
        {
            _repository = repository;
            _business = business;
        }

        public  IEnumerable<Orders> GetAllOrder()
        {
            throw new NotImplementedException();
        }
        public Orders GetOneOrder(int id)
        {
            Orders order=_repository.GetById(id);
            return order;
        }

        public Orders CreateOrder(Orders ordersObj)
        {
            Orders orders = _repository.createData(ordersObj);
            return orders;
        }

        public Orders GetOrderWithOrderLine(int id)
        {
            Orders order= GetOneOrder(id);
            List<OrderDetail> orderDetails = _business.GetAllOrderDetailByOrderId(id);
            order.Orderdetails = orderDetails;
            return order;
        }
    }
}
