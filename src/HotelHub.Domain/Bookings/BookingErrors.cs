using HotelHub.Domain.Abstractions;

namespace HotelHub.Domain.Bookings;

public class BookingErrors
{
    public static readonly Error NotFound = new(
        "Booking.Found",
        "The booking with the specified identifier was not found");
    
    public static readonly Error Overlap = new(
        "Booking.Overlap",
        "The current booking is overlapping with an existing one");
    
    public static readonly Error NotReserved = new(
        "Booking.NotReserved",
        "The booking is not pending");
    
    public static readonly Error NotConfirmed = new(
        "Booking.NotReserved",
        "The booking is not confirmed");
    
    public static readonly Error AlreadyStarted = new(
        "Booking.AlreadyStarted",
        "The booking has already started");
    
    public static readonly Error InvalidStartDate = new(
        "Booking.InvalidStartDate",
        "The start date must be greater than the current date");
    
    public static readonly Error InvalidEndDate = new(
        "Booking.InvalidEndDate",
        "The end date must be greater than the current date");
        
}