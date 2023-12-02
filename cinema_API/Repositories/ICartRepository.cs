using cinema_API.Models;

namespace cinema_API.Repositories
{
    public interface ICartRepository
    {
        CartSessionFull GetCard(int sessionId);
    }
}
