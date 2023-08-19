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
    }
}

