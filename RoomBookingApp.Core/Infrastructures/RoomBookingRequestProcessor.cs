using MeetingRoomBookingApp.Core.Models;

namespace MeetingRoomBookingApp.Core.Infrastructures
{
    public class RoomBookingRequestProcessor
    {

        public RoomBookingResult BookRoom(RoomBookingRequest bookingRequest)
        {
            return new RoomBookingResult()
            {
                FullName = bookingRequest.FullName,
                Date = bookingRequest.Date,
                Email = bookingRequest.Email,
            };
        }
    }
}