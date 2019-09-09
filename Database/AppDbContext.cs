using Microsoft.EntityFrameworkCore;
using TaskManagerApi.Models;

namespace TaskManager.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Chore> Chores { get; set; }
    }
}