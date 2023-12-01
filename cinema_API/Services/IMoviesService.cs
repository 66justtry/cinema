using cinema_API.Models;

namespace cinema_API.Services
{
    public interface IMoviesService
    {
        IEnumerable<MovieSessionShort> GetAll(Dictionary<string, string> dict);
        string GetOne(int id);
    }
}
