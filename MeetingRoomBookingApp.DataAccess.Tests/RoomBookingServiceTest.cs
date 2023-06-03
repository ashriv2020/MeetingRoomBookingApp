using MeetingRoomBookingApp.DataAccess.Repositories;
using MeetingRoomBookingApp.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingRoomBookingApp.DataAccess.Tests
{
    public class RoomBookingServiceTest
    {

        [Fact]
        public void Should_Return_Available_Rooms() 
        {
            //Arrange
            var date = new DateTime(2023, 02, 25);

            var dbOptions = new DbContextOptionsBuilder<BookingAppDbContext>().UseInMemoryDatabase("AvailableRoomTest")
                .Options;
            using var context = new BookingAppDbContext(dbOptions);
            context.Add(new Room { Id = 1, Name = "Room A" });
            context.Add(new Room { Id = 2, Name = "Room B" });
            context.Add(new Room { Id = 3, Name = "Room C" });

            context.Add(new RoomBooking { RoomId = 1, Date = date });
            context.Add(new RoomBooking { RoomId = 2, Date = date.AddDays(-1) });

            context.SaveChanges();
            var roomBookingService = new RoomBookingService(context);
        }
    }
}
