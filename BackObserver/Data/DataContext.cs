using Microsoft.EntityFrameworkCore;
using ControllerObserver.Entidades;
using Microsoft.AspNetCore.Identity;
namespace BackObserver.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Productos> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
