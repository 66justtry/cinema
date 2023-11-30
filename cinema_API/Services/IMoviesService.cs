namespace cinema_API.Services
{
    public interface IMoviesService
    {
        IEnumerable<string> GetAll(Dictionary<string, string> dict);
        string GetOne(int id);
    }
}
