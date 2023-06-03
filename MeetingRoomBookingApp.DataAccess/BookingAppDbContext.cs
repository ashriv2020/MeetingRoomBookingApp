using MeetingRoomBookingApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace MeetingRoomBookingApp.DataAccess
{
    public class BookingAppDbContext : DbContext
    {
        public BookingAppDbContext(DbContextOptions<BookingAppDbContext> options) : base(options)
        {

        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomBooking> RoomBookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Room>().HasData(
                new Room { Id = 1, Name = "Conference Room A" },
                new Room { Id = 2, Name = "Conference Room B" },
                new Room { Id = 2, Name = "Conference Room B" }
                );
        }
    }
}
