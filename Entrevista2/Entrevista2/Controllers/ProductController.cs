using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Interfaces;
using Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Entrevista2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        readonly IStoreUnitOfWork Store;

        public ProductController(IStoreUnitOfWork store)
        {
            Store = store;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return Store.Products.GetAll();
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return Store.Products.Get(id);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            return Ok();
        }
    }
}
