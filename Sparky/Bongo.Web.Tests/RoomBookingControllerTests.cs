using Bongo.Core.Services.IServices;
using Bongo.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Bongo.Web.Tests
{
    public class RoomBookingControllerTests
    {
        private Mock<IStudyRoomBookingService> _studyRoomBookingService;
        private RoomBookingController _roomBookingController;
        public RoomBookingControllerTests()
        {
            _studyRoomBookingService = new Mock<IStudyRoomBookingService>();
            _roomBookingController = new RoomBookingController(_studyRoomBookingService.Object);
        }

        [Fact]
        public void IndexPage_CallRequest_VerifyGetAllInvoked()
        {
            _roomBookingController.Index();
            _studyRoomBookingService.Verify(x => x.GetAllBooking(), Times.Once);
        }
        [Fact]
        public void BookRoomCheck_ModelStateInvalid_ReturnView()
        {
            _roomBookingController.ModelState.AddModelError("test", "test");
            var result= _roomBookingController.Book(new());
            ViewResult viewResult = result as ViewResult;
            Assert.Equal("Book",viewResult.ViewName);
        }

    }
}
