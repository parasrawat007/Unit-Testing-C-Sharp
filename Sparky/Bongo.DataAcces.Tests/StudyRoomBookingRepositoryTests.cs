using Bongo.DataAccess;
using Bongo.DataAccess.Repository;
using Bongo.Models.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Bongo.DataAcces
{
    public class StudyRoomBookingRepositoryTests
    {
        private StudyRoomBooking roomBooking1;
        private StudyRoomBooking roomBooking2;
        public StudyRoomBookingRepositoryTests() 
        { 
            roomBooking1= new StudyRoomBooking()
            { 
                BookingId = 1,
                Date = DateTime.Now.AddDays(1),
                Email="Ben@mail.com",
                FirstName="Ben",
                LastName="Spark",
                StudyRoomId=1
            };
            roomBooking2= new StudyRoomBooking()
            {
                BookingId = 2,
                Date = DateTime.Now.AddDays(2),
                Email = "Ben1@mail.com",
                FirstName = "Ben1",
                LastName = "Spark1",
                StudyRoomId = 2
            };
        }

        [Fact]
        public void SaveBooking_Booing1_CheckTheValuesFormDb()
        {
            //arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName:"TempDb").Options;

            //act
            using (var context= new ApplicationDbContext(options))
            {
                var repository = new StudyRoomBookingRepository(context);
                repository.Book(roomBooking1);
            }

            //assert 

            using (var context = new ApplicationDbContext(options))
            {
                var bookingFromDb = context.StudyRoomBookings.FirstOrDefault(u=>u.BookingId==11);
                Assert.Equal(roomBooking1.BookingId, bookingFromDb.BookingId);
                Assert.Equal(roomBooking1.StudyRoomId, bookingFromDb.StudyRoomId);
                Assert.Equal(roomBooking1.FirstName, bookingFromDb.FirstName);
                Assert.Equal(roomBooking1.LastName, bookingFromDb.LastName);
                Assert.Equal(roomBooking1.Date, bookingFromDb.Date);
                Assert.Equal(roomBooking1.Email, bookingFromDb.Email);
            }
        }
    }
}
