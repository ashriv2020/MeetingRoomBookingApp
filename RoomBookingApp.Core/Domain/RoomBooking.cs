using MeetingRoomBookingApp.Core.Models;

namespace MeetingRoomBookingApp.Core.Domain
{
    public class RoomBooking : RoomBookingBase
    {
        public int RoomId { get; set; }
        public int? Id { get; set; }
    }
}