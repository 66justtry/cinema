namespace cinema_API.Models
{
    public class MovieSessionShort
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string PhotoUrl { get; set; }
        public IEnumerable<SessionShort> Sessions { get; set; }
        public MovieSessionShort(int id, string name, int age, string photoUrl, IEnumerable<Session> sessions)
        {
            Id = id;
            Name = name;
            Age = age;
            PhotoUrl = photoUrl;
            Sessions = new List<SessionShort>();
            foreach (var session in sessions)
            {
                Sessions.Append(new SessionShort(session.Id, session.VideoTypeNavigation.Name, session.DateTime));
            }
        }
    }
}
