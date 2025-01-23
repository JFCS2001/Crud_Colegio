using static Crud_Colegio.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Crud_Colegio.Models
{
    public class Usuario
    {
            [Key]
            [Column("ID_USER")]
            public int Id_User { get; set; }

            [Column("ID_DOC")]
            public int Id_Doc { get; set; }

            [Column("ID_ROL")]
            public int Id_Rol { get; set; }

            [Column("NOMBRE_USER")]
            public string Nombre_User { get; set; }

            [Column("EDAD_USER")]
            public int Edad_User { get; set; }

            [Column("NUMDOC_USER")]
            public int NumDoc_User { get; set; }

            [Column("DATE_USER")]
            public DateTime Date_User { get; set; }

            [Column("EMAIL_USER")]
            public string Email_User { get; set; }

            [Column("NUMTEL_USER")]
            public string NumTel_User { get; set; }

            public Documentos Documentos { get; set; }
            public Roles Roles { get; set; }
    }
}
