using CuckooStore.DataAccessLayer;
using CuckooStore.Models;

namespace CuckooStore.BusinessLogicLayer
{
    public class UserServices : BaseServices<User>, IUserServices
    {
        public UserServices(IUnitOfWork unitOfWork, IGenericRepository<User> repository) : base(unitOfWork, repository)
        {
        }
    }
}
