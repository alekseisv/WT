using Microsoft.EntityFrameworkCore;
using Sverlov.Domain.Entities;

namespace Sverlov.UI
{
    public class TempContext : DbContext
    {
        public TempContext(DbContextOptions<TempContext> opt) : base(opt)
        {

        }

        public DbSet<TheTransportType> TheTransportTypes { get; set; }
        public DbSet<Automobile> Automobiles { get; set; }

    }
}
