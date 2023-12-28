namespace cinema_API.Models
{
    public class SessionSeatType
    {
        public int Id { get; set; }
        public int IdSeatType { get; set; }
        public int IdSession { get; set; }
        public int Price { get; set; }
        public SeatType? SeatTypeNavigation { get; set; }
        public Session? SessionNavigation { get; set; }
    }
}
