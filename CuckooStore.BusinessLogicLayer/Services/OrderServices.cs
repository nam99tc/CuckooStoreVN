using CuckooStore.DataAccessLayer;
using CuckooStore.Models;

namespace CuckooStore.BusinessLogicLayer
{
    public class OrderServices : BaseServices<Order>, IOrderServices
    {
        public OrderServices(IUnitOfWork unitOfWork, IGenericRepository<Order> repository) : base(unitOfWork, repository)
        {
        }
    }
}
