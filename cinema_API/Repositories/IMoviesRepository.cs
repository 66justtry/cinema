using cinema_API.Models;

namespace cinema_API.Repositories
{
    public interface IMoviesRepository : IRepository<MovieSessionShort, string, int>
    {
    }
}
