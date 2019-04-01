using System;
using Xunit;
using AlexHorlock.BookingSystem.Controllers;
using AlexHorlock.BookingSystem.Data;
using AlexHorlock.BookingSystem.Models;
using AlexHorlock.BookingSystem.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace MeetingBookingSystem.IntegrationTests
{
    public class SeatBookingSystemTest
    {
        MeetingDbContext _context;
        BookingSystemService _testBookingRepository;
        ZupaDevApiController _devController;
        
        public SeatBookingSystemTest()
        {
            // test with an in memory database
            var options = new DbContextOptionsBuilder<MeetingDbContext>()
                .UseInMemoryDatabase(databaseName: "test")
                .Options;

            _context = new MeetingDbContext(options);
            _testBookingRepository = new BookingSystem(_context);
            _devController = new ZupaDevApiController(_testBookingRepository);
        }

        [Fact]
        public void DoesSystemRejectMoreThanFourSeatRequestsAtOnce()
        {
            Seat testSeat = new Seat{Name="Alex"};
            List<Seat> seats = new List<Seat>(){
                testSeat,
                testSeat,
                testSeat,
                testSeat,
                testSeat
            };

            var response = _devController.BookSeatRequest(seats);

            // Assert
            Assert.IsType<StatusCodeResult>(response);

            var objectResponse = response as StatusCodeResult; 

            Assert.Equal(400, objectResponse.StatusCode);
        }
    }
}
