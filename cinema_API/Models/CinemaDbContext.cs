using cinema_API.Domain;
using Microsoft.EntityFrameworkCore;

namespace cinema_API.Models
{
    public partial class CinemaDbContext : DbContext
    {
        public virtual DbSet<Hall> Halls { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderSeat> OrderSeats { get; set; }
        public virtual DbSet<Seat> Seats { get; set; }
        public virtual DbSet<SeatType> SeatTypes { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<SessionSeatType> SessionSeatTypes { get; set; }
        public virtual DbSet<VideoType> VideoTypes { get; set; }
        public CinemaDbContext()
        {

        }
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hall>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.SessionNavigation).WithMany(i => i.OrderNavigation).HasForeignKey(e => e.IdSession);
            });

            modelBuilder.Entity<OrderSeat>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.OrderNavigation).WithMany(i => i.OrderSeatNavigation).HasForeignKey(e => e.IdOrder);
                entity.HasOne(e => e.SeatNavigation).WithMany(i => i.OrderSeatNavigation).HasForeignKey(e => e.IdSeat);
            });

            modelBuilder.Entity<Seat>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.HallNavigation).WithMany(i => i.SeatNavigation).HasForeignKey(e => e.IdHall);
                entity.HasOne(e => e.SeatTypeNavigation).WithMany(i => i.SeatNavigation).HasForeignKey(e => e.IdSeatType);
            });

            modelBuilder.Entity<SeatType>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.MovieNavigation).WithMany(i => i.SessionNavigation).HasForeignKey(e => e.IdMovie);
                entity.HasOne(e => e.HallNavigation).WithMany(i => i.SessionNavigation).HasForeignKey(e => e.IdHall);
                entity.HasOne(e => e.VideoTypeNavigation).WithMany(i => i.SessionNavigation).HasForeignKey(e => e.IdVideoType);
            });

            modelBuilder.Entity<SessionSeatType>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.SeatTypeNavigation).WithMany(i => i.SessionSeatTypeNavigation).HasForeignKey(e =>e.IdSeatType);
                entity.HasOne(e => e.SessionNavigation).WithMany(i => i.SessionSeatTypeNavigation).HasForeignKey(e => e.IdSession);
            });

            modelBuilder.Entity<VideoType>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
