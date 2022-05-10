using FirstApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstApi.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) 
            : base(options) => Database.EnsureCreated();

        public DbSet<Product> Product { get; set; }
    }
}
