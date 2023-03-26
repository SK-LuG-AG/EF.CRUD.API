using Microsoft.EntityFrameworkCore;

namespace CarsApp.Data
{
    public class Datenkontext : DbContext
    {
        public Datenkontext(DbContextOptions<Datenkontext>options) : base(options) { }

        public DbSet<Cars>  CarsTB { get; set; }
    }
}
