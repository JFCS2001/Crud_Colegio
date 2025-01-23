using System.ComponentModel.DataAnnotations;

namespace Crud_Colegio.Models
{
    public class Entities
    {
        public class Usuario
        {
            [Key]
            public int Id_User { get; set; }
            public int Id_Rol { get; set; }
            public int Id_Doc { get; set; }
            public string Nombre_User { get; set; }

            //Calculo de edad
            public string Edad_USer
            {
                get
                {
                    var hoy = DateOnly.FromDateTime(DateTime.Today);
                    var edad = hoy.Year - Date_User.Year;
                    if (Date_User > hoy.AddYears(-edad)) edad--;
                    return edad.ToString();
                }
            }
            public int NumDoc_USer { get; set; }
            public DateOnly Date_User { get; set; }
            public string Email_User { get; set; }
            public int NumTel_User { get; set; }

            public Documentos Documentos { get; set; }
            public Roles Roles { get; set; }
        }

        public class Documentos
        {
            [Key]
            public int Id_Doc { get; set; }
            public string Nombre_Doc { get; set; }
        }

        public class Roles
        {
            [Key]
            public int Id_Rol { get; set; }
            public string Nombre_Rol { get; set; }
            public ICollection<Usuario> Usuario { get; set; }
        }
    }
}
