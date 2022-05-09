using Microsoft.EntityFrameworkCore;

namespace FirstApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(prop => prop.Name)
                .HasMaxLength(80);

            modelBuilder.Entity<Product>()
                .Property(prop => prop.Price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Product>()
                .HasData(
                new Product { Id = 1, Name = "Notebook", Price = 7.95M, Stock = 10 },
                new Product { Id = 2, Name = "Eraser", Price = 2.45M, Stock = 30 },
                new Product { Id = 3, Name = "Pencil case", Price = 6.25M, Stock = 15 });
        }
    }
}
