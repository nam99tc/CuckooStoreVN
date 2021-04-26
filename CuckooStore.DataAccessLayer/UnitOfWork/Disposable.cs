using System;

namespace CuckooStore.DataAccessLayer
{
    public class Disposable : IDisposable
    {
        private bool _isDisposed;

        public void Dispose()
        {
            Disposo(true);
            GC.SuppressFinalize(this);
        }

        ~Disposable()
        {
            Disposo(false);
        }
        public void Disposo(bool disposing)
        {
            if (!_isDisposed && disposing)
            {
                DisposeCore();
            }
            _isDisposed = true;
        }

        protected virtual void DisposeCore()
        {
        }
    }
}
