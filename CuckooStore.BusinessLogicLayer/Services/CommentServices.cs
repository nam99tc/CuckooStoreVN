using CuckooStore.DataAccessLayer;
using CuckooStore.Models;

namespace CuckooStore.BusinessLogicLayer
{
    public class CommentServices : BaseServices<Comment>, ICommentServices
    {
        public CommentServices(IUnitOfWork unitOfWork, IGenericRepository<Comment> repository) : base(unitOfWork, repository)
        {
        }
    }
}
