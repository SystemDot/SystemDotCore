using System;

namespace SystemDot.Core
{
    public class Disposable : IDisposable
    {
        bool disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void CheckDisposed()
        {
            if (disposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }

        void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    DisposeOfManagedResources();
                }
                DisposeOfUnmanagedResources();
                disposed = true;
            }
        }

        protected virtual void DisposeOfManagedResources()
        {
        }

        protected virtual void DisposeOfUnmanagedResources()
        {
        }

        ~Disposable()
        {
            Dispose(false);
        }
    }
}