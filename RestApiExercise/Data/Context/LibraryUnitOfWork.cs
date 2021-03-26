using Data.Interfaces;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class LibraryUnitOfWork : ILibraryUnitOfWork
    {
        public IRepository<Book> Books { get; protected set; }

        public LibraryUnitOfWork()
        {
            Books = new BookRepository();
        }

        public void Complete()
        {
            throw new NotImplementedException();
        }

        public Task CompleteAsync()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            // pass
        }
    }
}
