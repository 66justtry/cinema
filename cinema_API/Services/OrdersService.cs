using cinema_API.Models;
using cinema_API.Repositories;

namespace cinema_API.Services
{
    public class OrdersService : IOrdersService
    {
        IOrdersRepository _repository;
        public OrdersService(IOrdersRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<OrderFull> GetAll(string phone)
        {
            return _repository.GetAll(phone);
        }
        public bool Create(int sessionId, string phone, int sum, List<int> seatIds)
        {
            return _repository.Create(sessionId, phone, sum, seatIds);
        }
    }
}
