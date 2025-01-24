using Crud_Colegio.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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

    [EmailAddress]
    [Column("EMAIL_USER")]
    public string Email_User { get; set; }

    [Phone]
    [Column("NUMTEL_USER")]
    public string NumTel_User { get; set; }

    [ForeignKey("Id_Doc")]
    public Documentos Documentos { get; set; }
    [ForeignKey("Id_Rol")]
    public Roles Roles { get; set; }
}
