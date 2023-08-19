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

        public DbSet<Medicamento> ? Medicamentos { get; set; }
        public DbSet<Propietario> ? Propietarios { get; set; }   

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicamento>().HasData(
                new Medicamento()
                {
                    Id = 1,
                     Descripcion = "HOLA",
                     DosisRecomendada = 1,
                      FormaAdministracion = "ORAL",
                      Indicaciones = "NA",
                      Nombre = "PARACETAMIOL"
                }
            );

            modelBuilder.Entity<Propietario>().HasData(
                new Propietario()
                {
                    Id = 1,
                    Nombre = "Milton",
                    Apellidos = "jaimes",
                    Direccion = "Morelos",
                    Correo = "milton@gmail.com",
                    Telefono = 77736050
                }
            );
        }  
    }
}