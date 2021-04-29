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
    public class BussinessController : ControllerBase
    {
        readonly IBussinessUnitOfWork db;

        public BussinessController(IBussinessUnitOfWork db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<IEnumerable<Bussiness>> Get()
        {
            return await db.Bussinesses.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var bussiness = await db.Bussinesses.Get(id);
            if (bussiness == null) return NotFound();
            else return Ok(bussiness);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Bussiness bussiness)
        {
            try
            {
                await db.Bussinesses.Add(bussiness);
                await db.Complete();
                return Created(HttpContext.Request.Path, bussiness);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = "No se ha podido agregar la empresa",
                    Exception = ex.InnerException?.Message ?? ex.Message
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Bussiness newValues)
        {
            try
            {
                var bussiness = await db.Bussinesses.Get(id);
                
                if (bussiness == null) return NotFound();
                
                bussiness.Name = newValues.Name;
                bussiness.Description = newValues.Description;
                bussiness.PhoneNumber = newValues.PhoneNumber;
                await db.Complete();

                return Created(HttpContext.Request.Path, bussiness);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = $"No se ha podido modificar la empresa con id: {id}",
                    Exception = ex.InnerException?.Message ?? ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await db.Bussinesses.Remove(id);
                await db.Complete();
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = $"No se ha podido eliminar la empresa con id: {id}",
                    Exception = ex.InnerException?.Message ?? ex.Message
                });
            }
        }
    }
}
