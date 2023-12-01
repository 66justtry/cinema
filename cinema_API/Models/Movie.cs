using cinema_API.Models;

namespace cinema_API.Domain
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string PhotoUrl { get; set; }
        public int Year { get; set; }
        public string NameOriginal { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }
        public string Country { get; set; }
        public string Actors { get; set; }
        public string Info { get; set; }
        public ICollection<Session> SessionNavigation { get; set; } = new List<Session>();
    }
}
