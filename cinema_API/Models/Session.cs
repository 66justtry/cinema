namespace cinema_API.Models
{
    public class Session
    {
        public int Id { get; set; }
        public int IdMovie { get; set; }
        public int IdHall { get; set; }
        public int IdVideoType { get; set; }
        public DateTime DateTime { get; set; }
    }
}
