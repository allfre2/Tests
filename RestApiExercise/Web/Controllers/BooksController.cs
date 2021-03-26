using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Interfaces;
using Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ILibraryUnitOfWork Library;

        public BooksController(ILibraryUnitOfWork library)
        {
            Library = library;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> Get()
        {
            return (await Library.Books.GetAllAsync()).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            return await Library.Books.GetAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> Post(Book book)
        {
            Book result = await Library.Books.AddAsync(book);
            if (result != null)
            {
                return Created(HttpContext.Request.Path, result);
            }
            else return BadRequest(new
            { 
                Message = "No se ha podido agregar el Libro",
                Exception = ""
            });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> Put(int id, Book book)
        {
            book.ID = id;
            Book result = await Library.Books.PatchAsync(book);
            if (result != null)
            {
                return Created(HttpContext.Request.Path, result);
            }
            else return BadRequest(new
            {
                Message = "No se ha podido modificar el record del Libro",
                Exception = ""
            });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await Library.Books.RemoveAsync(new Book { ID = id });
                return Ok(id);
            }
            catch(Exception ex) 
            {
                return BadRequest(new
                {
                    Message = $"No se ha podido borrar el Libro",
                    Exception = ex.Message
                }); ;
            }   
        }
    }
}