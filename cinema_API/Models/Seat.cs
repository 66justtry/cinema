namespace cinema_API.Models
{
    public class Seat
    {
        public int Id { get; set; }
        public int IdHall { get; set; }
        public int IdSeatType { get; set; }
        public int Row { get; set; }
        public int Place { get; set; }
    }
}
