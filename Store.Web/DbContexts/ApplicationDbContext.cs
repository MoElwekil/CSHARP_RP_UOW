using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Store.Web.Models;

namespace Store.Web.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
