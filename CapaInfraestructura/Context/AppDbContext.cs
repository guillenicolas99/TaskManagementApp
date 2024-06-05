using CapaDominio.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaInfraestructura.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {
            
        }

        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Prioridad> Prioridades { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar las relaciones
            modelBuilder.Entity<Tarea>()
                .HasOne(t => t.Estado)
                .WithMany(e => e.Tareas)
                .HasForeignKey(t => t.IdEstado);

            modelBuilder.Entity<Tarea>()
                .HasOne(t => t.Prioridad)
                .WithMany(p => p.Tareas)
                .HasForeignKey(t => t.IdPrioridad);

            modelBuilder.Entity<Tarea>()
                .HasOne(t => t.Categoria)
                .WithMany(c => c.Tareas)
                .HasForeignKey(t => t.IdCategoria);

            modelBuilder.Entity<Tarea>()
                .HasOne(t => t.UsuarioPropietario)
                .WithMany(u => u.TareasPropietario)
                .HasForeignKey(t => t.IdUsuarioPropietario)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Tarea>()
                .HasOne(t => t.UsuarioAsignado)
                .WithMany(u => u.TareasAsignado)
                .HasForeignKey(t => t.IdUsuarioAsignado)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed data for Estado
            modelBuilder.Entity<Estado>().HasData(
                new Estado { IdEstado = 1, Nombre = "Pendiente" },
                new Estado { IdEstado = 2, Nombre = "En Proceso" },
                new Estado { IdEstado = 3, Nombre = "Detenido" },
                new Estado { IdEstado = 4, Nombre = "Completado" }
            );

            // Seed data for Prioridad
            modelBuilder.Entity<Prioridad>().HasData(
                new Prioridad { IdPrioridad = 1, Nombre = "Alta", Clase = "badge text-bg-danger" },
                new Prioridad { IdPrioridad = 2, Nombre = "Media", Clase = "badge text-bg-warning" },
                new Prioridad { IdPrioridad = 3, Nombre = "Baja", Clase = "badge text-bg-success" }
            );

            // Seed data for Categoria
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { IdCategoria = 1, Nombre = "Web" },
                new Categoria { IdCategoria = 2, Nombre = "Diseño Gráfico" },
                new Categoria { IdCategoria = 3, Nombre = "SEO" },
                new Categoria { IdCategoria = 4, Nombre = "Redes Sociales" },
                new Categoria { IdCategoria = 5, Nombre = "Google" }
            );
        }

    }
}
