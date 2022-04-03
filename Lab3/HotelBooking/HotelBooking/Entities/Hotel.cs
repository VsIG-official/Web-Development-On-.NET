namespace HotelBooking.DAL.Entities;

public class Hotel
{
    public int Id { get; set; }
    public string Name { get; set; } = "Default Name";
    public string Address { get; set; } = "Default Address";
    public string Description { get; set; } = "Default Description";
    public List<Room> Rooms { get; set; } = new List<Room>();
}
