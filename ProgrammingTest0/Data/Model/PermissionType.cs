using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model
{
    [Table("TipoPermiso")]
    public class PermissionType
    {
        public int Id { get; set; }
        [Column("Descripción")]
        public string Description { get; set; }

        public override string ToString() => $"{Description} ({Id})";
    }
}
