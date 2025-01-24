using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Crud_Colegio.Models
{
    public class Roles
    {
        [Key]
        [Column("ID_ROL")]
        public int Id_Rol { get; set; }

        [Column("NOMBRE_ROL")]
        public string Nombre_Rol { get; set; }

        public ICollection<Usuario> Usuario { get; set; }
    }
}
