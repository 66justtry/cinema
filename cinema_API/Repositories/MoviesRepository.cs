using cinema_API.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace cinema_API.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        CinemaDbContext _context;
        public MoviesRepository(CinemaDbContext context)
        {
            _context = context;
        }
     
        public IEnumerable<MovieSessionShort> GetAll(Dictionary<string, string> filter)
        {
            var query = _context.Movies.AsQueryable();
            DateTime dateTime;
            if (!filter.ContainsKey("date") || !DateTime.TryParse(filter["date"], out dateTime))
            {
                dateTime = DateTime.Today;
            }
            query = query.Include(m => m.SessionNavigation).ThenInclude(s => s.SessionSeatTypeNavigation)
                .Include(m => m.SessionNavigation)
                .ThenInclude(s => s.VideoTypeNavigation)
                .Where(m => m.SessionNavigation.Any(s => s.DateTime.Date == dateTime && s.DateTime > DateTime.Now))
                .AsNoTracking();
            var result = query
                .Select(m => new MovieSessionShort(m.Id, m.Name, m.Age, m.PhotoUrl, m.SessionNavigation.Where(s => s.DateTime.Date == dateTime && s.DateTime > DateTime.Now).OrderBy(s => s.DateTime).ToList()));
            return result.ToList();
        }

        public MovieSessionFull GetOne(int key)
        {
            var query = _context.Movies.AsQueryable();
            query = query.Where(m => m.Id == key)
                .Include(m => m.SessionNavigation)
                .ThenInclude(s => s.VideoTypeNavigation)
                .Include(m => m.SessionNavigation)
                .ThenInclude(s => s.SessionSeatTypeNavigation)
                .AsNoTracking();
            var result = query
                .Select(m => new MovieSessionFull(m)).ToList();
            return result.Count > 0 ? result.First() : null;
        }
    }
}
