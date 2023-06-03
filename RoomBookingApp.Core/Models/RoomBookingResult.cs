using MeetingRoomBookingApp.Core.Enums;
using MeetingRoomBookingApp.Domain.BaseModels;

namespace MeetingRoomBookingApp.Core.Models
{
    public class RoomBookingResult : RoomBookingBase
    {
        public BookingResultFlag Flag { get; set; }
        public int? RoomBookingId { get; set; }
    }
}