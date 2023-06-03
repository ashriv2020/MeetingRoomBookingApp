using MeetingRoomBookingApp.Core.Contracts;
using MeetingRoomBookingApp.Core.Models;
using MeetingRoomBookingApp.Domain;
using MeetingRoomBookingApp.Domain.BaseModels;

namespace MeetingRoomBookingApp.Core.Infrastructures
{
    public class RoomBookingRequestProcessor
    {
        private readonly IRoomBookingService _roomBookingService;

        public RoomBookingRequestProcessor(IRoomBookingService @object)
        {
            _roomBookingService = @object;
        }

        public RoomBookingResult BookRoom(RoomBookingRequest? bookingRequest)
        {
            if(bookingRequest== null) throw new ArgumentNullException(nameof(bookingRequest));

            var availableRooms = _roomBookingService.GetAvailableRooms(bookingRequest.Date);
            var result = CreateRoomBookingObject<RoomBookingResult>(bookingRequest);

            if (availableRooms.Any())
            {
                var room = availableRooms.First();
                var roomBooking = CreateRoomBookingObject<RoomBooking>(bookingRequest);
                roomBooking.RoomId = room.Id;
                _roomBookingService.Save(roomBooking);

                result.RoomBookingId= roomBooking.Id;
                result.Flag = Enums.BookingResultFlag.Success;
            }
            else
            {
                result.Flag = Enums.BookingResultFlag.Failure;
            }


            //return new RoomBookingResult()
            //{
            //    FullName = bookingRequest.FullName,
            //    Date = bookingRequest.Date,
            //    Email = bookingRequest.Email,
            //}; 
            //return CreateRoomBookingObject<RoomBookingResult>(bookingRequest);
            return result;
        }

        private TRoomBooking CreateRoomBookingObject<TRoomBooking>(RoomBookingRequest bookingRequest) where TRoomBooking 
            : RoomBookingBase, new()
        {
            return new TRoomBooking
            {
                FullName = bookingRequest.FullName,
                Date = bookingRequest.Date,
                Email = bookingRequest.Email,
            };
        }
    }
}