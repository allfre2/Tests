using Data.Context.Repository;
using Data.Interfaces;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Context
{
    public class StoreUnitOfWork : IStoreUnitOfWork
    {
        public IRepository<Product> Products { get; protected set; }

        public StoreUnitOfWork()
        {
            Products = new ProductRepository();
        }

        public void Complete()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        void IUnitOfWork.Complete()
        {
            // pass
        }

        void IDisposable.Dispose()
        {
            // pass
        }
    }
}
