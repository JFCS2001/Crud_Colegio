using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crud_Colegio.Models
{
    public class Documentos
    {
        [Key]
        [Column("ID_DOC")]
        public int Id_Doc { get; set; }

        [Column("NOMBRE_DOC")]
        public string Nombre_Doc { get; set; }
    }
}
