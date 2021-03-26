using Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Interfaces
{
    public interface IStoreUnitOfWork : IUnitOfWork
    {
        IRepository<Product> Products { get; }
    }
}
