using MeetingRoomBookingApp.Core.Enums;

namespace MeetingRoomBookingApp.Core.Models
{
    public class RoomBookingResult : RoomBookingBase
    {
        public BookingResultFlag Flag { get; set; }
        public int? RoomBookingId { get; set; }
    }
}