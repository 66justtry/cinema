namespace cinema_API.Repositories
{
    public interface IRepository<T1, T2, T3>
    {
        IEnumerable<T1> GetAll();
        IEnumerable<T1> GetAll(Dictionary<string, string> filter);
        T2 GetOne(T3 key);
    }
}
