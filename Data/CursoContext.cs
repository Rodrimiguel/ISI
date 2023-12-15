using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Instituto1.Models;

namespace Instituto1.Data
{
    public class CursoContext : DbContext
    {
        public CursoContext (DbContextOptions<CursoContext> options)
            : base(options)
        {
        }

        public DbSet<Instituto1.Models.Curso> Curso { get; set; } = default!;
        public DbSet<Instituto1.Models.Alumno> Alumno { get; set; } = default!;

       protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curso>()
            .HasMany(p => p.Alumnos)
            .WithMany(p => p.Cursos)
            .UsingEntity("CursoAlumno");
        }


    }
}
