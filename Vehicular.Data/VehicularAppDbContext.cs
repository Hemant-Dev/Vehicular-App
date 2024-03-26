using Microsoft.EntityFrameworkCore;
using Vehicular.Model;

namespace Vehicular.Data
{
    public class VehicularAppDbContext : DbContext
    {
        public VehicularAppDbContext(DbContextOptions<VehicularAppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Color> Colors { get; set; }
    }
}
