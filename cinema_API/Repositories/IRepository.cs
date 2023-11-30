namespace cinema_API.Repositories
{
    public interface IRepository<T, W> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Dictionary<string, string> filter);
        T GetOne(W key);
    }
}
