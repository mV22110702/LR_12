using LR_12.Models;
using Microsoft.EntityFrameworkCore;

namespace LR_12.Data
{
    public class ApplicationContext:DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }
        
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

    }
}
