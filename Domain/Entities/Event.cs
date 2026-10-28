public class Event
{
    public int Id{get;set;}
    public string Title{get;set;}=string.Empty;
    public string? Description{get;set;}
    public string Location{get;set;}=string.Empty;
    public DateTime StartAt{get;set;}
    public decimal Price{get;set;}
    public int TotalSeats{get;set;}
    public int AvailableSeats{get;set;}
    public DateTime CreatedAt{get;set;}
    public int CategoryId{get;set;}
    public int OrganizerId{get;set;}
    public Category Category{get;set;}=null!;
    public List<Booking> Bookings{get;set;}=[];
}