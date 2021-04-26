using CuckooStore.DataAccessLayer;
using CuckooStore.Models;

namespace CuckooStore.BusinessLogicLayer
{
    public class BallotImportDetailServices : BaseServices<BallotImportDetail>, IBallotImportDetailServices
    {
        public BallotImportDetailServices(IUnitOfWork unitOfWork, IGenericRepository<BallotImportDetail> repository) : base(unitOfWork, repository)
        {
        }
    }
}
