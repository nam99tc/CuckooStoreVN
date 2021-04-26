using CuckooStore.DataAccessLayer;
using CuckooStore.Models;
using System;
using System.Collections.Generic;
using System.Transactions;

namespace CuckooStore.BusinessLogicLayer
{
    public class CheckOutServices : ICheckOutServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Order> _orderReposistory;
        private readonly IGenericRepository<OrderDetail> _orderDetailReposistory;
        private readonly IGenericRepository<Product> _productReposistory;

        public CheckOutServices(
            IUnitOfWork unitOfWork, 
            IGenericRepository<Order> orderReposistory, 
            IGenericRepository<OrderDetail> orderDetailReposistory,
            IGenericRepository<Product> productReposistory)
        {
            _unitOfWork = unitOfWork;
            _orderReposistory = orderReposistory;
            _orderDetailReposistory = orderDetailReposistory;
            _productReposistory = productReposistory;
        }
        public void CheckOut(Order order, List<OrderDetail> orderDetails)
        {
            using (var transaction = new TransactionScope())
            {
                _orderReposistory.Add(order);
                foreach (var orderDetail in orderDetails)
                {
                    var product = _productReposistory.GetById(orderDetail.ProductID);
                    product.Quantity -= orderDetail.Quantity;
                    _productReposistory.Update(product);

                    _orderDetailReposistory.Add(orderDetail);
                }
                _unitOfWork.Commit();
                transaction.Complete();
            }
        }
    }
}
