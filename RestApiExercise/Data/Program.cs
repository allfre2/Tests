using Data.Context;
using Data.Interfaces;
using Data.Model;
using System;

namespace Data
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IRepository<Book> repo = new BookRepository();
            var source = new FakeRestAPIBookDataSource();
            
            foreach (var b in repo.GetAllAsync().GetAwaiter().GetResult())// source.Get().GetAwaiter().GetResult())
            {
                // Console.WriteLine("\n=====\n" + b + "\n=====\n");
            }

            //var book = source.Get(99).GetAwaiter().GetResult();
            var book = repo.GetAsync(88).GetAwaiter().GetResult();
            // Console.WriteLine(book);
            book.Title = "Ownage Pranks!";
            var result = repo.PatchAsync(book).GetAwaiter().GetResult();
            // source.Add(book).GetAwaiter().GetResult();
            repo.RemoveAsync(new Book { ID = 999 });
            Console.WriteLine(result);
            // var deleted = source.Remove(book.ID).GetAwaiter().GetResult();
            // Console.WriteLine(deleted);
            // book.Description = " X X x X X x X X";
            // source.Edit(book).GetAwaiter().GetResult();
        }
    }
}
