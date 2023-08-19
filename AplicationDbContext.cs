using Microsoft.EntityFrameworkCore;
using ExamenUnidad3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenUnidad3
{
   public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Citas>? Cita { get; set; }
        // protected override void OnModelCreating (ModelBuilder modelBuilder){
        //     modelBuilder.Entity<Citas>().HasData(
        //         new Citas(){
        //             Id = 1,
        //             MotivoVisita = "Enfermo" ,
        //             NombreVeterinario = "Milton",
        //             FechaReservada = '',
        //             FechaAtencion = '',
        //             Observaciones="estar en ayunas"
        //         }
        //     );
        // }

            
    }
}

