using CuckooStore.DataAccessLayer;
using CuckooStore.Models;

namespace CuckooStore.BusinessLogicLayer
{
    public class CouponServices : BaseServices<Coupon>, ICouponServices
    {
        public CouponServices(IUnitOfWork unitOfWork, IGenericRepository<Coupon> repository) : base(unitOfWork, repository)
        {
        }
    }
}
