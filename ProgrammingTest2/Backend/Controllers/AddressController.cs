using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Data.Interfaces;
using Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        readonly IBussinessUnitOfWork db;

        public AddressController(IBussinessUnitOfWork db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<IEnumerable<Address>> Get()
        {
            return await db.Addresses.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var address = await db.Addresses.Get(id);
            if (address == null) return NotFound();
            else return Ok(address);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Address address)
        {
            try
            {
                await db.Addresses.Add(address);
                await db.Complete();
                return Created(HttpContext.Request.Path, address);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = "No se ha podido agregar la dirección",
                    Exception = ex.InnerException?.Message ?? ex.Message
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Address newValues)
        {
            try
            {
                var address = await db.Addresses.Get(id);
                
                if (address == null) return NotFound();
                
                address.AddressLine1 = newValues.AddressLine1;
                address.AddressLine2 = newValues.AddressLine2;
                address.ZipCode = newValues.ZipCode;
                address.ClientId = newValues.ClientId;

                await db.Complete();

                return Created(HttpContext.Request.Path, address);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = $"No se ha podido modificar la dirección con id: {id}",
                    Exception = ex.InnerException?.Message ?? ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await db.Addresses.Remove(id);
                await db.Complete();
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = $"No se ha podido eliminar la dirección con id: {id}",
                    Exception = ex.InnerException?.Message ?? ex.Message
                });
            }
        }
    }
}
