using Microsoft.EntityFrameworkCore;

namespace ExamenUnidad3
{
    class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
    }
}