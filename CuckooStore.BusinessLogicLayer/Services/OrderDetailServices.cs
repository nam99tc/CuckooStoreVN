using CuckooStore.DataAccessLayer;
using CuckooStore.Models;

namespace CuckooStore.BusinessLogicLayer
{
    public class OrderDetailServices : BaseServices<OrderDetail>, IOrderDetailServices
    {
        public OrderDetailServices(IUnitOfWork unitOfWork, IGenericRepository<OrderDetail> repository) : base(unitOfWork, repository)
        {
        }
    }
}
