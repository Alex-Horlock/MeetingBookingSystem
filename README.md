# MeetingBookingSystem
An API implementation which allows users to view and book avaialble meetings and seats.

# Approach

The system uses an ASP.Net core Web API which is specified using Swagger and then autocoded with their codegen tool.

You can view the proposed API here: https://app.swaggerhub.com/apis/Alex-Horlock/SeatBooking/1.0.0

The API allows basic users to GET meetings and current seat bookings and POST seat bookings. Admins can POST new meetings.

Swagger was chosen because I feel it is a great tool for communicating an interface clearly which is often one of the biggest issues when working with multiple teams on the same project. 

The system uses an SQLite database with Entity Framework Core to keep things simple.

There is a single example integration test to show how I would test the system were it business critical, for now I have tested it manually with the Swagger UI.

Price could be added simply by adding another field to the 'Seat' class but I have not included this as that will require specifying a new API version and I prefer not to write code that may or may not be used.

# Review 

This was the first API I've ever made so it was a bit of a learning curve, I am still a little unsure about some of the best practice in ASP.Net but I feel I made some good general decisions and have produced a robust demonstration which fulfills all the requirements.
