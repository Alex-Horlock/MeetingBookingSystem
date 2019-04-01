using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using AlexHorlock.BookingSystem.Models;


namespace AlexHorlock.BookingSystem.Repositories
{
    public interface IBookingSystemService
    {
        bool AddMeeting(Meeting meeting,  out int httpStatusCode);

        bool AddSeats(IEnumerable<Seat> seatRequests, out int httpStatusCode); 
        
        IEnumerable<Seat> GetSeats(Guid meetingId);

        IEnumerable<Meeting> GetMeetings();
    }
}