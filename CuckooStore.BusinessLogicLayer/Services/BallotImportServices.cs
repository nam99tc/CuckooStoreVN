using CuckooStore.DataAccessLayer;
using CuckooStore.Models;

namespace CuckooStore.BusinessLogicLayer
{
    public class BallotImportServices : BaseServices<BallotImport>, IBallotImportServices
    {
        public BallotImportServices(IUnitOfWork unitOfWork, IGenericRepository<BallotImport> repository) : base(unitOfWork, repository)
        {
        }
    }
}
