using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using  AlexHorlock.BookingSystem.Models;
using System.Linq;

namespace AlexHorlock.BookingSystem.Data
{
    public class MeetingDbContext : DbContext
    {
        public MeetingDbContext(DbContextOptions<MeetingDbContext> options) : base(options)
        {
            
        }
        public DbSet<Meeting> Meetings { get; set; }
        
        public DbSet<Seat> Seats { get; set; }
    }

     // just a test class to add some data.
    public static class SeedData
    {
        public static void SeedMeetings(IServiceProvider serviceProvider)
        {
            using (var context = new MeetingDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MeetingDbContext>>()))
            {
                // Look for any previous seedings.
                if (context.Meetings.Any())
                {
                    return;   // DB has been seeded
                }

                context.Meetings.AddRange(
                    new Meeting
                    {
                        Id = Guid.NewGuid(),
                        Organiser = "Alex Horlock",
                        Date = DateTime.UtcNow,
                        Location = "zupaTech HQ"
                    },

                    new Meeting
                    {
                        Id = Guid.NewGuid(),
                        Organiser = "Someone Else",
                        Date = DateTime.UtcNow.AddMonths(1),
                        Location = "zupaTech HQ"
                    }
                );
                context.SaveChanges();
            }
        }

        public static void SeedSeats(IServiceProvider serviceProvider)
        {
            using (var context = new MeetingDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MeetingDbContext>>()))
            {
                // Look for any previous seedings.
                if (context.Seats.Any())
                {
                    return;   // DB has been seeded
                }

                if (!context.Meetings.Any())
                {
                    return; // must make a meeting first to add some seats.
                }

                context.Seats.AddRange(
                    new Seat
                    {
                        Id = Guid.NewGuid(),
                        Name = "Alex Horlock",
                        Email = "alexhorlock93@gmail.com",
                        Row = "a",
                        Column = 1,
                        MeetingId = context.Meetings.FirstOrDefault().Id,
                        IsBooked = true
                    },

                    new Seat
                    {
                        Id = Guid.NewGuid(),
                        Name = "The Cookie Monster",
                        Email = "cookieMonster@ilovecookie.com",
                        Row = "a",
                        Column = 2,
                        MeetingId = context.Meetings.FirstOrDefault().Id,
                        IsBooked = true
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
