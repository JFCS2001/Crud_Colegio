using Microsoft.EntityFrameworkCore;

namespace Crud_Colegio.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Documentos> Documentos { get; set; }
        public DbSet<Roles> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.2.162)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=orcl)));User Id=jcornejo;Password=Temporal2024;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("USUARIO");
            modelBuilder.Entity<Documentos>().ToTable("DOCUMENTOS");
            modelBuilder.Entity<Roles>().ToTable("ROLES");

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Documentos)
                .WithMany()
                .HasForeignKey(u => u.Id_Doc)
                .HasConstraintName("USUARIO_FK1");

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Roles)
                .WithMany(r => r.Usuario)
                .HasForeignKey(u => u.Id_Rol)
                .HasConstraintName("USUARIO_FK2");
        }
    }
}
