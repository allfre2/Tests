using Data.Interfaces;
using Data.Model;
using System.Threading.Tasks;

namespace Data.Context
{
    public class PermissionsUnitOfWork : UnitOfWork<PermissionsContext>, IPermissionsUnitOfWork
    {
        public PermissionsUnitOfWork() : base()
        {
            _permissions = new Repository<Permission, PermissionsContext>(Context);
            _permissionTypes = new Repository<PermissionType, PermissionsContext>(Context);
            InsertMockData().GetAwaiter().GetResult();
        }

        readonly Repository<Permission, PermissionsContext> _permissions;
        public IRepository<Permission, PermissionsContext> Permissions { get => _permissions; }

        readonly Repository<PermissionType, PermissionsContext> _permissionTypes;
        public IRepository<PermissionType, PermissionsContext> PermissionTypes { get => _permissionTypes; }

        /// <summary>
        /// Fill DbContext With Mock Data for the Programming Test
        /// </summary>
        private async Task InsertMockData()
        {
            await PermissionTypes.Add(SeedData.GetPermissionTypes());
            await Permissions.Add(SeedData.GetPermissions());
            await Complete();
        }
    }
}
