using cinema_API.Models;
using Microsoft.EntityFrameworkCore;

namespace cinema_API.Repositories
{
    public class CartRepository : ICartRepository
    {
        CinemaDbContext _context;
        public CartRepository(CinemaDbContext context)
        {
            _context = context;
        }
        public CartSessionFull GetCart(int sessionId)
        {
            var query = _context.Sessions.AsQueryable().Where(s => s.Id == sessionId)
                .Include(s => s.HallNavigation).ThenInclude(h => h.SeatNavigation).ThenInclude(s => s.SeatTypeNavigation)
                .Include(s => s.SessionSeatTypeNavigation)
                .Include(s => s.OrderNavigation).ThenInclude(o => o.OrderSeatNavigation)
                .Include(s => s.VideoTypeNavigation)
                .Include(s => s.MovieNavigation)
                .AsNoTracking();
            var result = query.Select(s => new CartSessionFull(s)).ToList();
            return result.Count > 0 ? result.First() : null;
        }
    }
}
