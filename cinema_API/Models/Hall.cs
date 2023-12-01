namespace cinema_API.Models
{
    public class Hall
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public ICollection<Session> SessionNavigation { get; set; } = new List<Session>();
        public ICollection<Seat> SeatNavigation { get; set; } = new List<Seat>();
    }
}
