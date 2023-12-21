using cinema_API.Models;

namespace cinema_API.Repositories
{
    public interface IMoviesRepository
    {
        IEnumerable<MovieSessionShort> GetAll(Dictionary<string, string> filter);
        MovieSessionFull GetOne(int key);
    }
}
