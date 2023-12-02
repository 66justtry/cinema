using cinema_API.Models;

namespace cinema_API.Services
{
    public interface IOrdersService
    {
        IEnumerable<OrderFull> GetAll(string phone);
        bool Create(int sessionId, string phone, int sum, List<int> seatIds);
    }
}
