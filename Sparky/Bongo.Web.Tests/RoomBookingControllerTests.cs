using Bongo.Core.Services.IServices;
using Bongo.Models.Model;
using Bongo.Models.Model.VM;
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

        [Fact]
        public void BookRRoomCheck_NotSuccessful_NoRoomCode()
        {
            _studyRoomBookingService.Setup(x => x.BookStudyRoom(It.IsAny<StudyRoomBooking>())).Returns(new StudyRoomBookingResult() { Code=StudyRoomBookingCode.NoRoomAvailable});
            
            var result = _roomBookingController.Book(new());
            Assert.IsType<ViewResult>(result);
            ViewResult viewResult = result as ViewResult;
            Assert.Equal("No Study Room available for selected date", viewResult.ViewData["Error"]);
        }
        [Fact]
        public void BookRRoomCheck_Successful_Redirect()
        {
            _studyRoomBookingService.Setup(x => x.BookStudyRoom(It.IsAny<StudyRoomBooking>()))
                .Returns((StudyRoomBooking studyRoomBooking)=>new StudyRoomBookingResult() 
                    { 
                        BookingId = studyRoomBooking.BookingId,
                        Date = studyRoomBooking.Date,
                        Email = studyRoomBooking.Email,
                        FirstName = studyRoomBooking.FirstName,
                        LastName = studyRoomBooking.LastName,   
                        Code = StudyRoomBookingCode.Success 
                    }
                );

            var result = _roomBookingController.Book(new() 
            { 
                BookingId=1,
                Date=DateTime.Now.AddDays(1),
                Email="paras@gmail.com",
                LastName="Rawat",
                FirstName="Paras",
                StudyRoomId=1
            });
            Assert.IsType<RedirectToActionResult>(result);
            RedirectToActionResult viewResult = result as RedirectToActionResult;
            Assert.Equal("Paras", viewResult.RouteValues["FirstName"]);
            Assert.Equal(StudyRoomBookingCode.Success, viewResult.RouteValues["Code"]);
        }

    }
}
