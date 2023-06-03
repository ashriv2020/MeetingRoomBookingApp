using MeetingRoomBookingApp.Core.Contracts;
using MeetingRoomBookingApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingRoomBookingApp.DataAccess.Repositories
{
    public class RoomBookingService : IRoomBookingService
    {
        private readonly BookingAppDbContext _dbContext;

        public RoomBookingService(BookingAppDbContext bookingAppDbContext)
        {
            _dbContext = bookingAppDbContext;
        }
        public IEnumerable<Room> GetAvailableRooms(DateTime date)
        {
            throw new NotImplementedException();
        }

        public void Save(RoomBooking roomBookingRequest)
        {
            throw new NotImplementedException();
        }
    }
}
