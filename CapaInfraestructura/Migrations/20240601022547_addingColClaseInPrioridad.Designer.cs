﻿// <auto-generated />
using System;
using CapaInfraestructura.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CapaInfraestructura.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240601022547_addingColClaseInPrioridad")]
    partial class addingColClaseInPrioridad
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CapaDominio.Entities.Categoria", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCategoria"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdCategoria");

                    b.ToTable("Categorias");

                    b.HasData(
                        new
                        {
                            IdCategoria = 1,
                            Nombre = "Web"
                        },
                        new
                        {
                            IdCategoria = 2,
                            Nombre = "Diseño Gráfico"
                        },
                        new
                        {
                            IdCategoria = 3,
                            Nombre = "SEO"
                        },
                        new
                        {
                            IdCategoria = 4,
                            Nombre = "Redes Sociales"
                        },
                        new
                        {
                            IdCategoria = 5,
                            Nombre = "Google"
                        });
                });

            modelBuilder.Entity("CapaDominio.Entities.Estado", b =>
                {
                    b.Property<int>("IdEstado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEstado"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdEstado");

                    b.ToTable("Estados");

                    b.HasData(
                        new
                        {
                            IdEstado = 1,
                            Nombre = "Pendiente"
                        },
                        new
                        {
                            IdEstado = 2,
                            Nombre = "En Proceso"
                        },
                        new
                        {
                            IdEstado = 3,
                            Nombre = "Detenido"
                        },
                        new
                        {
                            IdEstado = 4,
                            Nombre = "Completado"
                        });
                });

            modelBuilder.Entity("CapaDominio.Entities.Prioridad", b =>
                {
                    b.Property<int>("IdPrioridad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPrioridad"));

                    b.Property<string>("Clase")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdPrioridad");

                    b.ToTable("Prioridades");

                    b.HasData(
                        new
                        {
                            IdPrioridad = 1,
                            Clase = "badge text-bg-danger",
                            Nombre = "Alta"
                        },
                        new
                        {
                            IdPrioridad = 2,
                            Clase = "badge text-bg-warning",
                            Nombre = "Media"
                        },
                        new
                        {
                            IdPrioridad = 3,
                            Clase = "badge text-bg-success",
                            Nombre = "Baja"
                        });
                });

            modelBuilder.Entity("CapaDominio.Entities.Tarea", b =>
                {
                    b.Property<int>("IdTarea")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTarea"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaEstimadaEntrega")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<int>("IdEstado")
                        .HasColumnType("int");

                    b.Property<int>("IdPrioridad")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuarioAsignado")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuarioPropietario")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdTarea");

                    b.HasIndex("IdCategoria");

                    b.HasIndex("IdEstado");

                    b.HasIndex("IdPrioridad");

                    b.HasIndex("IdUsuarioAsignado");

                    b.HasIndex("IdUsuarioPropietario");

                    b.ToTable("Tareas");
                });

            modelBuilder.Entity("CapaDominio.Entities.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("CapaDominio.Entities.Tarea", b =>
                {
                    b.HasOne("CapaDominio.Entities.Categoria", "Categoria")
                        .WithMany("Tareas")
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CapaDominio.Entities.Estado", "Estado")
                        .WithMany("Tareas")
                        .HasForeignKey("IdEstado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CapaDominio.Entities.Prioridad", "Prioridad")
                        .WithMany("Tareas")
                        .HasForeignKey("IdPrioridad")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CapaDominio.Entities.Usuario", "UsuarioAsignado")
                        .WithMany("TareasAsignado")
                        .HasForeignKey("IdUsuarioAsignado")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CapaDominio.Entities.Usuario", "UsuarioPropietario")
                        .WithMany("TareasPropietario")
                        .HasForeignKey("IdUsuarioPropietario")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Estado");

                    b.Navigation("Prioridad");

                    b.Navigation("UsuarioAsignado");

                    b.Navigation("UsuarioPropietario");
                });

            modelBuilder.Entity("CapaDominio.Entities.Categoria", b =>
                {
                    b.Navigation("Tareas");
                });

            modelBuilder.Entity("CapaDominio.Entities.Estado", b =>
                {
                    b.Navigation("Tareas");
                });

            modelBuilder.Entity("CapaDominio.Entities.Prioridad", b =>
                {
                    b.Navigation("Tareas");
                });

            modelBuilder.Entity("CapaDominio.Entities.Usuario", b =>
                {
                    b.Navigation("TareasAsignado");

                    b.Navigation("TareasPropietario");
                });
#pragma warning restore 612, 618
        }
    }
}
