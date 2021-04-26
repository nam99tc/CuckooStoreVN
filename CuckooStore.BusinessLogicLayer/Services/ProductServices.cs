using CuckooStore.DataAccessLayer;
using CuckooStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CuckooStore.BusinessLogicLayer
{
    public class ProductServices : BaseServices<Product>, IProductServices
    {
        
        public ProductServices(IUnitOfWork unitOfWork, IGenericRepository<Product> repository) : base(unitOfWork, repository)
        {
        }
    }
}
