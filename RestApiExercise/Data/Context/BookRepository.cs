using Data.Interfaces;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class BookRepository : IRepository<Book>
    {
        protected readonly IBookDataSource Source;

        public BookRepository()
        {
            Source = new FakeRestAPIBookDataSource();
        }

        public BookRepository(IBookDataSource source)
        {
            Source = source;
        }

        public async Task<Book> AddAsync(Book book)
        {
            return await Source.Add(book);
        }

        public async Task<IQueryable<Book>> AddRangeAsync(IEnumerable<Book> books)
        {
            var results = new List<Book>();

            foreach (var book in books)
            {
                results.Add(await AddAsync(book));
            }

            return results as IQueryable<Book>;
        }

        public async Task<IQueryable<Book>> GetAllAsync()
        {
            return (await Source.Get()).AsQueryable();
        }

        public async Task<Book> GetAsync(int id)
        {
            return await Source.Get(id);
        }

        public async Task RemoveAsync(Book book)
        {
            if (! await Source.Remove(book.ID))
            {
                throw new InvalidOperationException();
            }
        }

        public async Task<Book> PatchAsync(Book book)
        {
            return await Source.Edit(book);
        }
    }
}
