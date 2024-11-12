using Microsoft.EntityFrameworkCore;
using NorthwindApi.Model;
namespace NorthwindApi.Data
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext(DbContextOptions<NorthwindContext> options) : base (options) {
        
        }

        public DbSet<Category> category { get; set; }
    }
}
