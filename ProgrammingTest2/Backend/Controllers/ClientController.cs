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
    public class ClientController : ControllerBase
    {
        readonly IBussinessUnitOfWork db;

        public ClientController(IBussinessUnitOfWork db)
        {
            this.db = db;
        }
        // TODO handle addresses
        [HttpGet]
        public async Task<IEnumerable<Client>> Get()
        {
            return await db.Clients.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var client = await db.Clients.Get(id);
            if (client == null) return NotFound();
            else return Ok(client);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Client client)
        {
            try
            {
                await db.Clients.Add(client);
                await db.Complete();
                return Created(HttpContext.Request.Path, client);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = "No se ha podido agregar el cliente",
                    Exception = ex.InnerException?.Message ?? ex.Message
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Client newValues)
        {
            try
            {
                var client = await db.Clients.Get(id);

                if (client == null) return NotFound();

                client.Name = newValues.Name;
                client.LastName = newValues.LastName;
                client.SSN = newValues.SSN;
                client.BussinessId = newValues.BussinessId;

                await db.Complete();

                return Created(HttpContext.Request.Path, client);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = $"No se ha podido modificar el cliente con id: {id}",
                    Exception = ex.InnerException?.Message ?? ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await db.Clients.Remove(id);
                await db.Complete();
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = $"No se ha podido eliminar el cliente con id: {id}",
                    Exception = ex.InnerException?.Message ?? ex.Message
                });
            }
        }
    }
}
