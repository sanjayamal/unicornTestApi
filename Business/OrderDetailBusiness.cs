using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi.Models;
using webApi.Repository;

namespace webApi.Business
{
    public class OrderDetailBusiness
    {
        private readonly IRepository<OrderDetail> _repository;
        private readonly OrderDetailRepo _detailRepo;

        public OrderDetailBusiness(IRepository<OrderDetail> repository,OrderDetailRepo detailRepo)
        {
            _repository = repository;
            _detailRepo = detailRepo;
        }

        public IEnumerable<OrderDetail> GetAllOrderDetail()
        {
            throw new NotImplementedException();
        }

        public OrderDetail GetOneOrderDetail()
        {
            throw new NotImplementedException();
        }
        public OrderDetail CreateOrderDetail(OrderDetail ordersDetailObj)
        {
            OrderDetail ordersDetail = _repository.createData(ordersDetailObj);
            return ordersDetail;
        }

        public List<OrderDetail> GetAllOrderDetailByOrderId(int id)
        {
            List<OrderDetail> orderDetails =(List<OrderDetail>)_detailRepo.GetAllByOrderId(id);
            return orderDetails;
          
        }
    }
}
