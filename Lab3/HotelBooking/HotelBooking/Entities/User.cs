namespace HotelBooking.DAL.Entities;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; } = "Default First Name";
    public string LastName { get; set; } = "Default Last Name";
    public string Email { get; set; } = "Default Email";
}
