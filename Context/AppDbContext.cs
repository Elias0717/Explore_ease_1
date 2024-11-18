using Explore_ease.Models;
using Microsoft.EntityFrameworkCore;

namespace Explore_ease.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }
        public DbSet<Person> Persons { get; set; }
    }
}
