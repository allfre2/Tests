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
    public class PermissionsController : ControllerBase
    {
        readonly IPermissionsUnitOfWork DB;

        public PermissionsController(IPermissionsUnitOfWork db)
        {
            this.DB = db;
        }

        [HttpGet]
        public async Task<IEnumerable<Permission>> Get()
        {
            return await DB.Permissions.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var permission = await DB.Permissions.Get(id);
            if (permission == null) return NotFound();
            else return Ok(permission);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Permission permission)
        {
            try
            {
                await DB.Permissions.Add(permission);
                await DB.Complete();
                return Created(HttpContext.Request.Path, permission);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = "No se ha podido agregar el permiso",
                    Exception = ex.InnerException?.Message ?? ex.Message
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Permission newValues)
        {
            try
            {
                var permission = await DB.Permissions.Get(id);
                if (permission == null) return NotFound();
                permission.EmployeeName = newValues.EmployeeName;
                permission.EmployeeLastName = newValues.EmployeeLastName;
                permission.PermissionTypeId = newValues.PermissionTypeId;
                permission.PermissionDate = newValues.PermissionDate;
                await DB.Complete();
                return Created(HttpContext.Request.Path, permission);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = $"No se ha podido modificar el permiso con id: {id}",
                    Exception = ex.InnerException?.Message ?? ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await DB.Permissions.Remove(id);
                await DB.Complete();
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = $"No se ha podido eliminar el permiso id: {id}",
                    Exception = ex.InnerException?.Message ?? ex.Message
                });
            }
        }
    }
}
