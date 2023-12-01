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
        public IEnumerable<MovieSessionShort> GetAll()
        {
            var query = _context.Movies.Include(m => m.SessionNavigation.Where(s => s.DateTime.Date == DateTime.Today))
                .ThenInclude(s => s.SessionSeatTypeNavigation)
                .Include(m => m.SessionNavigation.Where(s => s.DateTime.Date == DateTime.Today))
                .ThenInclude(s => s.VideoTypeNavigation)
                .Where(m => m.SessionNavigation.Count > 0)
                .AsNoTracking()
                .Select(m => new MovieSessionShort(m.Id, m.Name, m.Age, m.PhotoUrl, m.SessionNavigation));
            return query.ToList();
        }

        public IEnumerable<MovieSessionShort> GetAll(Dictionary<string, string> filter)
        {
            var query = _context.Movies.AsQueryable();
            DateTime dateTime;
            if (!filter.ContainsKey("date") || !DateTime.TryParse(filter["date"], out dateTime))
            {
                dateTime = DateTime.Today;
            }
            query = query.Include(m => m.SessionNavigation.Where(s => s.DateTime.Date == dateTime))
                .ThenInclude(s => s.SessionSeatTypeNavigation)
                .Include(m => m.SessionNavigation.Where(s => s.DateTime.Date == dateTime))
                .ThenInclude(s => s.VideoTypeNavigation)
                .Where(m => m.SessionNavigation.Count > 0)
                .AsNoTracking();
            var result = query
                .Select(m => new MovieSessionShort(m.Id, m.Name, m.Age, m.PhotoUrl, m.SessionNavigation));
            return result.ToList();
        }

        public MovieSessionFull GetOne(int key)
        {
            var query = _context.Movies.AsQueryable();
            query = query.Where(m => m.Id == key)
                .Include(m => m.SessionNavigation.Where(s => s.DateTime.Date >= DateTime.Today))
                .ThenInclude(s => s.VideoTypeNavigation)
                .Include(m => m.SessionNavigation.Where(s => s.DateTime.Date >= DateTime.Today))
                .ThenInclude(s => s.SessionSeatTypeNavigation)
                .Where(m => m.SessionNavigation.Count > 0)
                .AsNoTracking();
            var result = query
                .Select(m => new MovieSessionFull(m)).ToList();
            return result.Count > 0 ? result.First() : null;
        }
    }
}
