using MeetingRoomBookingApp.Domain;

namespace MeetingRoomBookingApp.Core.Contracts
{
    public interface IRoomBookingService
    {
        void Save(RoomBooking roomBookingRequest);
        IEnumerable<Room> GetAvailableRooms(DateTime date);
    }
}
