using cinema_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace cinema_API.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        CinemaDbContext _context;
        public OrdersRepository(CinemaDbContext context)
        {
            _context = context;
        }
        public bool Create(int sessionId, string phone, int sum, List<int> seatIds)
        {
            List<OrderSeat> list = new List<OrderSeat>();
            foreach (int seatId in seatIds)
                list.Add(new OrderSeat { IdSeat = seatId });
            _context.Orders.Add(new Order { IdSession = sessionId, Phone = phone, Sum = sum, OrderSeatNavigation = list });
            int k = _context.SaveChanges();
            return k == list.Count + 1;
        }

        public IEnumerable<OrderFull> GetAll(string phone)
        {
            var query = _context.Orders.AsQueryable().Where(o => o.Phone == phone)
                .Include(o => o.OrderSeatNavigation).ThenInclude(o => o.SeatNavigation)
                .Include(o => o.SessionNavigation).ThenInclude(s => s.MovieNavigation)
                .Include(o => o.SessionNavigation).ThenInclude(s => s.HallNavigation)
                .AsNoTracking();
            var result = query.Select(o => new OrderFull(o.SessionNavigation.MovieNavigation.Name, o.SessionNavigation.DateTime, o.SessionNavigation.HallNavigation.Name, o.Sum, o.OrderSeatNavigation)).ToList();
            return result;
        }
    }
}
