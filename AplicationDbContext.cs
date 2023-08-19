using System;
using ExamenUnidad3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ExamenUnidad3;
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Servicios> Servicios { get; set; } 
      
        public DbSet<Medicamento> ? Medicamentos { get; set; }
        public DbSet<Propietario> ? Propietarios { get; set; }   

         
    }
