using Microsoft.EntityFrameworkCore;
using ExamenUnidad3.Models;
namespace ExamenUnidad3
{
    
   public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Servicios> Servicios { get; set; } 
           protected override void OnModelCreating (ModelBuilder modelBuilder){
            modelBuilder.Entity<Servicios>().HasData(
                new Servicios(){
                    Id = 1,
                    Nombre = "Desparacitación" ,
                    Descripcion = "Perrita con dolor de estomago",
                    Costo = 100,
                    DuracionEstimada = 1.30,
                    RequisitosPrevios="estar en ayunas"
                }
            );
        }
    }
}