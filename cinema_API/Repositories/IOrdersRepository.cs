using cinema_API.Models;

namespace cinema_API.Repositories
{
    public interface IOrdersRepository
    {
        IEnumerable<OrderFull> GetAll(string phone);
        bool Create(int sessionId, string phone, int sum, List<int> seatIds);
    }
}
