using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using AlexHorlock.BookingSystem.Models;
using AlexHorlock.BookingSystem.Data;
using System.Linq;


namespace AlexHorlock.BookingSystem.Repositories
{
    public class BookingSystemService: IBookingSystemService
    {
        private readonly MeetingDbContext _context;

        public BookingSystemService (MeetingDbContext context)
        {
            _context = context;
        }
        public bool AddMeeting(Meeting meeting, out int httpStatusCode)
        {
            if (meeting == null)
            {
                httpStatusCode = 400;
                return false;
            } 
            
            if (meeting.Id == null)
                meeting.Id = Guid.NewGuid();

            _context.Meetings.Add(meeting);

            _context.SaveChangesAsync();

            httpStatusCode = 201;
            return true; 
        }

        public bool AddSeats(IEnumerable<Seat> seatRequests, out int httpStatusCode)
        {
            if (seatRequests.Count() > 4)
            {
                httpStatusCode = 400;
                return false;
            }
                

            // check if seats are booked
            foreach (Seat requestedSeat in seatRequests)
            {
                foreach (Seat currentSeat in _context.Seats)
                {
                    if (requestedSeat.Column == currentSeat.Column 
                    && requestedSeat.Row == currentSeat.Row)
                    {
                        httpStatusCode = 409;
                        return false; // seat already booked -> reject
                    }
                }
            }

            // check for duplicate seat requests in single booking request
            foreach (Seat requestedSeat in seatRequests)
            {
                foreach (Seat possibleDuplicateSeat in seatRequests)
                {
                    if (possibleDuplicateSeat.Column == requestedSeat.Column
                    && possibleDuplicateSeat.Row == requestedSeat.Row)
                    {
                        httpStatusCode = 400;
                        return false; // requested the same seat twice.
                    }
                }
            }
            
            _context.Seats.AddRange(seatRequests);

            _context.SaveChangesAsync();

            httpStatusCode = 201;
            return true; 
        } 
        
        public IEnumerable<Seat> GetSeats(Guid meetingId)
        {
            if (meetingId != null)
                return _context.Seats.Where(x => x.MeetingId == meetingId);

            return _context.Seats;
        }

        public IEnumerable<Meeting> GetMeetings()
        {
            return _context.Meetings;
        }
    }
}