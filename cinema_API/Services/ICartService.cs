using cinema_API.Models;

namespace cinema_API.Services
{
    public interface ICartService
    {
        CartSessionFull GetCart(int sessionId);
    }
}
