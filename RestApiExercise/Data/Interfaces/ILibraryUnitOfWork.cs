using Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Interfaces
{
    public interface ILibraryUnitOfWork : IUnitOfWork
    {
        IRepository<Book> Books { get; }
    }
}
