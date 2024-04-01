using RoomBookingApp.Core.Models;
using RoomBookingApp.Core.Processors;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingApp.Core.Tests
{
    public class RoomBookingRequestProcessorTest
    {
        [Fact]
        public void Should_Return_Room_Booking_Response_With_Request_Values()
        {
            //Arrange
            var resquest = new RoomBookingResquest
            {
                FullName = "Test Name",
                Email = "test@request.com",
                Date = new DateTime(2021, 10, 20)
            };

            var processor = new RoomBookingRequestProcessor();
            //Act
            RoomBookingResult result = processor.BookRoom(resquest);   
            
            //Assert
            //Assert.NotNull(result);
            //Assert.Equal(resquest.FullName, result.FullName);
            //Assert.Equal(resquest.Email, result.Email);
            //Assert.Equal(resquest.Date, result.Date);


            result.ShouldNotBeNull();
            result.FullName.ShouldBe(result.FullName);
            result.Email.ShouldBe(result.Email);
            result.Date.ShouldBe(result.Date);
        }

    }
}
