using System;
using ExamenUnidad3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ExamenUnidad3
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Paciente> ? Pacientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Paciente>().HasData(
                new Paciente()
                {
                    Id = 1,
                     Nombre = "Perro Lobo Mexicano",
                     Especie = "C. lupus",
                      Raza = "Canina",
                      Peso = 20,
                      FechaNacimiento = new DateTime()
                }
            );
        }

    }
}