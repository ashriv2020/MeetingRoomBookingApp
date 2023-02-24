using MeetingRoomBookingApp.Core.Domain;
using MeetingRoomBookingApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingRoomBookingApp.Core.Contracts
{
    public interface IRoomBookingService
    {
        void Save(RoomBooking roomBookingRequest);
        IEnumerable<Room> GetAvailableRooms(DateTime date);
    }
}
