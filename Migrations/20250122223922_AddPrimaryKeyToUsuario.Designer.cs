﻿// <auto-generated />
using Crud_Colegio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace Crud_Colegio.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20250122223922_AddPrimaryKeyToUsuario")]
    partial class AddPrimaryKeyToUsuario
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Crud_Colegio.Models.Entities+Documentos", b =>
                {
                    b.Property<int>("Id_Doc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Doc"));

                    b.Property<string>("Nombre_Doc")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id_Doc");

                    b.ToTable("Documentos");
                });

            modelBuilder.Entity("Crud_Colegio.Models.Entities+Roles", b =>
                {
                    b.Property<int>("Id_Rol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Rol"));

                    b.Property<string>("Nombre_Rol")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id_Rol");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Crud_Colegio.Models.Entities+Usuario", b =>
                {
                    b.Property<int>("Id_User")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_User"));

                    b.Property<string>("Date_User")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(10)");

                    b.Property<int>("DocumentosId_Doc")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Email_User")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("Id_Doc")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("Id_Rol")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Nombre_User")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("NumDoc_USer")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("NumTel_User")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("RolesId_Rol")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id_User");

                    b.HasIndex("DocumentosId_Doc");

                    b.HasIndex("RolesId_Rol");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Crud_Colegio.Models.Entities+Usuario", b =>
                {
                    b.HasOne("Crud_Colegio.Models.Entities+Documentos", "Documentos")
                        .WithMany()
                        .HasForeignKey("DocumentosId_Doc")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Crud_Colegio.Models.Entities+Roles", "Roles")
                        .WithMany("Usuario")
                        .HasForeignKey("RolesId_Rol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Documentos");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("Crud_Colegio.Models.Entities+Roles", b =>
                {
                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
