using MeetingRoomBookingApp.Core.Contracts;
using MeetingRoomBookingApp.Core.Enums;
using MeetingRoomBookingApp.Core.Infrastructures;
using MeetingRoomBookingApp.Core.Models;
using MeetingRoomBookingApp.Domain;
using Moq;
using Shouldly;

namespace MeetingRoomBookingApp.Core.Tests
{
    public class RoomBookingRequestProcessorTest
    {
        private readonly RoomBookingRequestProcessor _processor;
        private readonly RoomBookingRequest _request;
        private readonly Mock<IRoomBookingService> _roomBookingServiceMock;
        private List<Room> _availableRomms;

        public RoomBookingRequestProcessorTest()
        {
            //Arrange
            

            _request = new RoomBookingRequest()
            {
                FullName = "Test Name",
                Email = "test@request.com",
                Date = new DateTime(2023, 02, 19)
            };
            _availableRomms = new List<Room>() { new Room() {  Id = 1} };

            _roomBookingServiceMock = new Mock<IRoomBookingService>();
            _roomBookingServiceMock.Setup(r => r.GetAvailableRooms(_request.Date))
                .Returns(_availableRomms);
            _processor = new RoomBookingRequestProcessor(_roomBookingServiceMock.Object);
        }

        [Fact]
        public void Should_Return_Room_Booking_Response_With_Request_Values()
        {
            

            //Act
            RoomBookingResult result = _processor.BookRoom(_request);

            //Assert
            Assert.NotNull(result);           
            Assert.Equal(_request.FullName, result.FullName);
            Assert.Equal(_request.Date, result.Date);

            result.ShouldNotBeNull();
            result.FullName.ShouldBe(_request.FullName);
            result.Date.ShouldBe(_request.Date);
        }

        [Fact]
        public void Should_Throw_Exception_IF_Request_Is_Null()
        {
            var exception = Should.Throw<ArgumentNullException>(() => _processor.BookRoom(null));
            exception.ParamName.ShouldBe("bookingRequest");
        }

        [Fact]
        public void Should_Save_Room_Booking_Request()
        {
            RoomBooking savedBooking = null;
            _roomBookingServiceMock.Setup(q => q.Save(It.IsAny<RoomBooking>()))
                .Callback<RoomBooking>(booking =>
                {
                    savedBooking = booking;
                }
                );
            _processor.BookRoom(_request);

            _roomBookingServiceMock.Verify(q=>q.Save(It.IsAny<RoomBooking>()), Times.Once);

            savedBooking.ShouldNotBeNull() ;
            savedBooking.FullName.ShouldBe(_request.FullName);
            savedBooking.Email.ShouldBe(_request.Email);
            savedBooking.RoomId.ShouldBe(_availableRomms.First().Id);
        }

        [Fact]
        public void Should_NOT_Save_Room_If_No_Room_Available()
        {
           _availableRomms.Clear();
            _processor.BookRoom(_request);
            _roomBookingServiceMock.Verify(q => q.Save(It.IsAny<RoomBooking>()), Times.Never);

        }

        [Theory]
        [InlineData(BookingResultFlag.Failure, false)]
        [InlineData(BookingResultFlag.Success, true)]
        public void Should_Return_Success_Flag_In_Result(BookingResultFlag bookingSuccessFlag, bool isAvailable)
        {
            if(!isAvailable)
            {
                _availableRomms.Clear();
            }
            var result = _processor.BookRoom(_request);
            bookingSuccessFlag.ShouldBe(result.Flag);
        }

        [Theory]
        [InlineData(1, true)]
        [InlineData(null, false)]
        public void Should_Return_RoomBookingId_In_Result(int? roomBookingId, bool isAvailable)
        {
            if(!isAvailable) { _availableRomms.Clear(); }
            else
            {
                _roomBookingServiceMock.Setup(q => q.Save(It.IsAny<RoomBooking>()))
                .Callback<RoomBooking>(booking =>
                {
                    booking.Id = roomBookingId.Value;
                }
                );
            }

            var result = _processor.BookRoom(_request);
            result.RoomBookingId.ShouldBe(roomBookingId);

        }
    }

    
}
