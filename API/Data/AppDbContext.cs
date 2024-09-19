using API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {

        }

        public DbSet<Category> Categories { get; set; }
    }
}
