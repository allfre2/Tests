using Data.Context;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Interfaces
{
    public interface IPermissionsUnitOfWork : IUnitOfWork
    {
        IRepository<Permission, PermissionsContext> Permissions { get; }
        IRepository<PermissionType, PermissionsContext> PermissionTypes { get; }
    }
}
