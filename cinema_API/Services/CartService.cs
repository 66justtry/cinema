using cinema_API.Models;
using cinema_API.Repositories;

namespace cinema_API.Services
{
    public class CartService : ICartService
    {
        ICartRepository _repository;
        public CartService(ICartRepository repository)
        {
            _repository = repository;
        }

        public CartSessionFull GetCart(int sessionId)
        {
            return _repository.GetCart(sessionId);
        }
    }
}
