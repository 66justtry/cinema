namespace cinema_API.Models
{
    public class SeatType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public ICollection<Seat> SeatNavigation { get; set; } = new List<Seat>();
        public ICollection<SessionSeatType> SessionSeatTypeNavigation { get; set; } = new List<SessionSeatType>();
    }
}
