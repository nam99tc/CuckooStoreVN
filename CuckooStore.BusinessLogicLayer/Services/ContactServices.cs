using CuckooStore.DataAccessLayer;
using CuckooStore.Models;

namespace CuckooStore.BusinessLogicLayer
{
    public class ContactServices : BaseServices<Contact>, IContactServices
    {
        public ContactServices(IUnitOfWork unitOfWork, IGenericRepository<Contact> repository) : base(unitOfWork, repository)
        {
        }
    }
}
