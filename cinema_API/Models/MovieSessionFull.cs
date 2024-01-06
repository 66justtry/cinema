using cinema_API.Domain;

namespace cinema_API.Models
{
    public class MovieSessionFull
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
        public List<SessionShort> Sessions { get; set; } = new List<SessionShort>();
        public MovieSessionFull()
        {

        }
        public MovieSessionFull(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            Age = movie.Age;
            PhotoUrl = movie.PhotoUrl;
            Year = movie.Year;
            NameOriginal = movie.NameOriginal;
            Director = movie.Director;
            Genre = movie.Genre;
            Duration = movie.Duration;
            Country = movie.Country;
            Actors = movie.Actors;
            Info = movie.Info;
            foreach (var session in movie.SessionNavigation.Where(s => s.DateTime > DateTime.Now))
            {
                Sessions.Add(new SessionShort(session.Id, session.VideoTypeNavigation.Name, session.DateTime, session.SessionSeatTypeNavigation.Min(x => x.Price)));
            }
            Sessions = Sessions.OrderBy(s => s.DateTime).ToList();
        }
    }
}
