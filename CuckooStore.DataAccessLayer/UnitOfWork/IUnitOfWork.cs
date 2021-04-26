using System.Threading.Tasks;

namespace CuckooStore.DataAccessLayer
{
    public interface IUnitOfWork
    {
        int Commit();
        Task<int> CommitAsync();
    }
}