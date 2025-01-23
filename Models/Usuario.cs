using Crud_Colegio.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Usuario
{
    [Key]
    [Column("ID_USER")]
    public int Id_User { get; set; }

    [Required]
    [Column("ID_DOC")]
    public int Id_Doc { get; set; }

    [Required]
    [Column("ID_ROL")]
    public int Id_Rol { get; set; }

    [Required]
    [StringLength(100)]
    [Column("NOMBRE_USER")]
    public string Nombre_User { get; set; }

    [Required]
    [Range(1, 120)]
    [Column("EDAD_USER")]
    public int Edad_User { get; set; }

    [Required]
    [Column("NUMDOC_USER")]
    public int NumDoc_User { get; set; }

    [Required]
    [Column("DATE_USER")]
    public DateTime Date_User { get; set; }

    [Required]
    [EmailAddress]
    [Column("EMAIL_USER")]
    public string Email_User { get; set; }

    [Required]
    [Phone]
    [Column("NUMTEL_USER")]
    public string NumTel_User { get; set; }

    [ForeignKey("Id_Doc")]
    public Documentos Documentos { get; set; }
    [ForeignKey("Id_Rol")]
    public Roles Roles { get; set; }
}
