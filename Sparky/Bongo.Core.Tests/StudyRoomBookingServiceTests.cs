using Bongo.Core.Services;
using Bongo.DataAccess.Repository.IRepository;
using Moq;

namespace Bongo.Core.Tests
{
    public class StudyRoomBookingServiceTests
    {
        private Mock<IStudyRoomBookingRepository> _studyRoomBookingRepositoryMock;
        private Mock<IStudyRoomRepository> _studyRoomRepositoryMock;
        private StudyRoomBookingService _studyRoomBookingService;

        public StudyRoomBookingServiceTests()
        {
            _studyRoomBookingRepositoryMock = new Mock<IStudyRoomBookingRepository>();
            _studyRoomRepositoryMock = new Mock<IStudyRoomRepository>();
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
    }
}