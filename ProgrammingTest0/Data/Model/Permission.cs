using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model
{
    [Table("Permiso")]
    public class Permission
    {
        public int Id { get; set; }

        [Column("NombreEmpleado")]
        public string EmployeeName { get; set; }
        
        [Column("ApellidoEmpleado")]
        public string EmployeeLastName { get; set; }
        
        [Column("TipoPermiso")]
        public int PermissionTypeId { get; set; }

        [Column("FechaPermiso")]
        public DateTime PermissionDate { get; set; } = DateTime.Now;


        [ForeignKey("PermissionTypeId")]
        public virtual PermissionType PermissionType { get; set; }

        public override string ToString() 
            => $"{EmployeeName} {EmployeeLastName}, {PermissionType}, {PermissionDate}";
    }
}
