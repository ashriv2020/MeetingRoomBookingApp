using MeetingRoomBookingApp.Core.Infrastructures;
using MeetingRoomBookingApp.Core.Models;
using Shouldly;

namespace MeetingRoomBookingApp.Core.Tests
{
    public class RoomBookingRequestProcessorTest
    {
        [Fact]
        public void Should_Return_Room_Booking_Response_With_Request_Values()
        {
            var request = new RoomBookingRequest()
            {
                FullName = "Test Name",
                Email = "test@request.com",
                Date = new DateTime(2023, 02, 19)
            };
            var processor = new RoomBookingRequestProcessor();

            //Act
            RoomBookingResult result = processor.BookRoom(request);

            //Assert
            Assert.NotNull(result);           
            Assert.Equal(request.FullName, result.FullName);
            Assert.Equal(request.Date, result.Date);

            result.ShouldNotBeNull();
            result.FullName.ShouldBe(request.FullName);
            result.Date.ShouldBe(request.Date);
        }
    }

    
}
