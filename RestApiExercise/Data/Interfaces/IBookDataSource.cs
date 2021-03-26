using Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IBookDataSource
    {
        Task<IEnumerable<Book>> Get();
        Task<Book> Get(int id);
        Task<Book> Add(Book book);
        Task<Book> Edit(Book book);
        Task<bool> Remove(int id);
    }
}
