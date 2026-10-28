public class Booking
{
    public int Id{get;set;}
    public int EventId{get;set;}
    public int UserId{get;set;}
    public int Seats{get;set;}
    public decimal TotalPrice{get;set;}
    public BookingStatus Status{get;set;}
    public DateTime CreatedAt{get;set;}
    public DateTime ExpiresAt{get;set;}
    public Event Event{get;set;}=null!;
}
