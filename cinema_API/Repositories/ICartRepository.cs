using cinema_API.Models;

namespace cinema_API.Repositories
{
    public interface ICartRepository
    {
        CartSessionFull GetCart(int sessionId);
    }
}
