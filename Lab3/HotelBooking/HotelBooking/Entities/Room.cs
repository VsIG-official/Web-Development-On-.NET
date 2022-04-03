namespace HotelBooking.DAL.Entities;

public class Room
{
    public int Id { get; set; }
    public int HotelId { get; set; }
    public string Name { get; set; } = "Default Name";
    public bool IsAvailable { get; set; } = true;
    public int Price { get; set; }
    public int Type { get; set; }
    public int Capacity { get; set; }
}
