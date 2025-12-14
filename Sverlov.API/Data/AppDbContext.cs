using Microsoft.EntityFrameworkCore;
using Sverlov.Domain.Entities;



namespace Sverlov.API.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt):base(opt)
        {
            
        }

        public DbSet<Automobile> Automodiles { get; set; }
        public DbSet<TheTransportType> TheTransportTypes { get; set; } = null;
    }
}
