namespace HotelBooking.DAL.Entities;

public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int HotelId { get; set; }
    public int RoomId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Price { get; set; }
}
