using cinema_API.Domain;

namespace cinema_API.Models
{
    public class Session
    {
        public int Id { get; set; }
        public int IdMovie { get; set; }
        public int IdHall { get; set; }
        public int IdVideoType { get; set; }
        public DateTime DateTime { get; set; }
        public Movie? MovieNavigation { get; set; }
        public Hall? HallNavigation { get; set; }
        public VideoType? VideoTypeNavigation { get; set; }
        public ICollection<Order> OrderNavigation { get; set; } = new List<Order>();
        public ICollection<SessionSeatType> SessionSeatTypeNavigation { get; set; } = new List<SessionSeatType>();
    }
}
