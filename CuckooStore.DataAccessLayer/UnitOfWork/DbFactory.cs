namespace CuckooStore.DataAccessLayer
{
    public class DbFactory : Disposable, IDbFactory
    {
        CuckooDBcontext _dbContext;

        public CuckooDBcontext Init() => _dbContext ?? (_dbContext = new CuckooDBcontext());

        protected override void DisposeCore()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
            }
        }
    }
}
