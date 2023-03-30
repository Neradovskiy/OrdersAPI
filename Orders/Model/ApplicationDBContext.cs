using Microsoft.EntityFrameworkCore;

namespace Orders.Model
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Client> Clients { get; set; }

        public DbSet<Stitching> Stitching { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                 .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                 .AddJsonFile("appsettings.json")
                 .Build();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("MyConnection"));
        }
    }
}
