using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crud_Colegio.Migrations
{
    /// <inheritdoc />
    public partial class AddPrimaryKeyToDocumentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documentos",
                columns: table => new
                {
                    Id_Doc = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nombre_Doc = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documentos", x => x.Id_Doc);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id_Rol = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nombre_Rol = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id_Rol);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id_User = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Id_Rol = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Id_Doc = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Nombre_User = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NumDoc_USer = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Date_User = table.Column<string>(type: "NVARCHAR2(10)", nullable: false),
                    Email_User = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NumTel_User = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DocumentosId_Doc = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    RolesId_Rol = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id_User);
                    table.ForeignKey(
                        name: "FK_Usuario_Documentos_DocumentosId_Doc",
                        column: x => x.DocumentosId_Doc,
                        principalTable: "Documentos",
                        principalColumn: "Id_Doc",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuario_Roles_RolesId_Rol",
                        column: x => x.RolesId_Rol,
                        principalTable: "Roles",
                        principalColumn: "Id_Rol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_DocumentosId_Doc",
                table: "Usuario",
                column: "DocumentosId_Doc");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_RolesId_Rol",
                table: "Usuario",
                column: "RolesId_Rol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Documentos");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
