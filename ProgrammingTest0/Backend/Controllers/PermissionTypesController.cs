using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Interfaces;
using Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionTypesController : ControllerBase
    {
        readonly IPermissionsUnitOfWork DB;

        public PermissionTypesController(IPermissionsUnitOfWork db)
        {
            this.DB = db;
        }

        [HttpGet]
        public async Task<IEnumerable<PermissionType>> Get()
        {
            return await DB.PermissionTypes.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<PermissionType> Get(int id)
        {
            return await DB.PermissionTypes.Get(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PermissionType type)
        {
            try
            {
                await DB.PermissionTypes.Add(type);
                await DB.Complete();
                return Created(HttpContext.Request.Path, type);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                { 
                    Message = "No se ha podido agregar el tipo de permiso",
                    Exception = ex.InnerException?.Message ?? ex.Message
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PermissionType type)
        {
            try
            {
                var permissionType = await DB.PermissionTypes.Get(id);
                if (permissionType == null) return NotFound();
                permissionType.Description = type.Description;
                await DB.Complete();
                return Created(HttpContext.Request.Path, permissionType);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = $"No se ha podido modificar el tipo de permiso id: {id}",
                    Exception = ex.InnerException?.Message ?? ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await DB.PermissionTypes.Remove(id);
                await DB.Complete();
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = $"No se ha podido eliminar el tipo de permiso id: {id}",
                    Exception = ex.InnerException?.Message ?? ex.Message
                });
            }
        }
    }
}
