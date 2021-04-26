using System;

namespace CuckooStore.DataAccessLayer
{
    public interface IDbFactory : IDisposable
    {
        CuckooDBcontext Init();
    }
}
