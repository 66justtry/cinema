namespace cinema_API.Models
{
    public class VideoType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public ICollection<Session> SessionNavigation { get; set; } = new List<Session>();
    }
}
