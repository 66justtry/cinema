using Microsoft.EntityFrameworkCore;

namespace cinema_API.Models
{
    public partial class CinemaDbContext : DbContext
    {
        public CinemaDbContext()
        {

        }
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //to do: get connection string from json file
            optionsBuilder.UseNpgsql();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
