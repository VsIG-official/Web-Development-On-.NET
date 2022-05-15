namespace Lab3.DAL.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public State State { get; set; }
        public decimal Price { get; set; }
    }
}
