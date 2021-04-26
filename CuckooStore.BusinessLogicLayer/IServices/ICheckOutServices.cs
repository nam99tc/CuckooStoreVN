using CuckooStore.Models;
using System.Collections.Generic;

namespace CuckooStore.BusinessLogicLayer
{
    public interface ICheckOutServices
    {
        void CheckOut(Order order, List<OrderDetail> orderDetails);
    }
}
