using Microsoft.EntityFrameworkCore;
using MyPersonalApp.Models;

namespace MyPersonalApp.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Employees> Employees { get; set; }  
        public DbSet<Position> Positions { get; set; }  
    }
}
