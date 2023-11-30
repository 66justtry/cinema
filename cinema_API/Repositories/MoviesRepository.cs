namespace cinema_API.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        public IEnumerable<string> GetAll()
        {
            return new[] { "GetAll without parameters" };
        }

        public IEnumerable<string> GetAll(Dictionary<string, string> filter)
        {
            return new[] { "GetAll with parameters" };
        }

        public string GetOne(int key)
        {
            return new string("GetOne");
        }
    }
}
