namespace cinema_API.Models
{
    public class MovieSessionShort
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string PhotoUrl { get; set; }
        public List<SessionShort> Sessions { get; set; } = new List<SessionShort>();
        public MovieSessionShort(int id, string name, int age, string photoUrl, IEnumerable<Session> sessions)
        {
            Id = id;
            Name = name;
            Age = age;
            PhotoUrl = photoUrl;
            foreach (var session in sessions)
            {
                Sessions.Add(new SessionShort(session.Id, session.VideoTypeNavigation.Name, session.DateTime, session.SessionSeatTypeNavigation.Min(x => x.Price)));
            }
        }
    }
}
