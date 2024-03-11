using Bongo.Core.Services;
using Bongo.DataAccess.Repository.IRepository;
using Bongo.Models.Model;
using Moq;

namespace Bongo.Core.Tests
{
    public class StudyRoomBookingServiceTests
    {
        private StudyRoomBooking _request;
        private IList<StudyRoom> _availableStudyRoom;
        private Mock<IStudyRoomBookingRepository> _studyRoomBookingRepositoryMock;
        private Mock<IStudyRoomRepository> _studyRoomRepositoryMock;
        private StudyRoomBookingService _studyRoomBookingService;

        public StudyRoomBookingServiceTests()
        {
            _request = new()
            {
                BookingId=1,
                Date= DateTime.Now.AddDays(1),
                Email="ben@gmail.com",
                StudyRoomId=1          
            };
            _availableStudyRoom= new List<StudyRoom>()
            { 
                new StudyRoom() 
                {
                    Id=1,
                    RoomName="Michigan",
                    RoomNumber="A202"
                }
            };
            _studyRoomBookingRepositoryMock = new Mock<IStudyRoomBookingRepository>();
            _studyRoomRepositoryMock = new Mock<IStudyRoomRepository>();
            _studyRoomRepositoryMock.Setup(x => x.GetAll()).Returns(_availableStudyRoom);
            _studyRoomBookingService = new StudyRoomBookingService(
                    _studyRoomBookingRepositoryMock.Object,
                    _studyRoomRepositoryMock.Object
                );
        }   

        [Fact]
        public void GetAllBooking_InvokedMethodCheckIfIsCalled()
        {
            _studyRoomBookingService.GetAllBooking();
            _studyRoomBookingRepositoryMock.Verify(x => x.GetAll(null), Times.Once);
        }

        [Fact]
        public void BookingException_NullRequest_ThrowsException()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _studyRoomBookingService.BookStudyRoom(null));
            Assert.Equal("Value cannot be null. (Parameter 'request')", exception.Message);
            Assert.Equal("request", exception.ParamName);
        }


        [Fact]
        public void StudyRoomBooking_SaveBookingWithAvailableRoomReturnsResultWithValues()
        {
            StudyRoomBooking savedStudyRoomBooking=null;
            _studyRoomBookingRepositoryMock.Setup(x => x.Book(It.IsAny<StudyRoomBooking>()))
                .Callback<StudyRoomBooking>(booking =>
                {
                    savedStudyRoomBooking = booking;
                });
            _studyRoomBookingService.BookStudyRoom(_request);

            _studyRoomBookingRepositoryMock.Verify(x=>x.Book(It.IsAny<StudyRoomBooking>()), Times.Once);
            Assert.NotNull(savedStudyRoomBooking);
            Assert.Equal(_request.FirstName, savedStudyRoomBooking.FirstName);
            Assert.Equal(_request.LastName, savedStudyRoomBooking.LastName);
            Assert.Equal(_request.Date, savedStudyRoomBooking.Date);
            Assert.Equal(_availableStudyRoom.First().Id, savedStudyRoomBooking.StudyRoomId);
            Assert.Equal(_request.Email, savedStudyRoomBooking.Email);
        }
    }
}