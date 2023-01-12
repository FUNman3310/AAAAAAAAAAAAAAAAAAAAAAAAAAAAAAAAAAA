using Microsoft.EntityFrameworkCore;

namespace Fiorello.Models
{
    public class FiorelloContext:DbContext
    {

        public FiorelloContext(DbContextOptions<FiorelloContext> options):base(options) 
        {

        }

        public DbSet<Slider> sliders { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }

    }
}
