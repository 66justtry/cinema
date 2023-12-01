using cinema_API.Models;
using cinema_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cinema_API.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        IMoviesService _moviesService;
        public MoviesController(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        [HttpGet]
        public IEnumerable<MovieSessionShort> GetMovies([FromQuery] Dictionary<string, string> query)
        {
            return _moviesService.GetAll(query);
        }

        [HttpGet("{id}")]
        public string GetMovie([FromRoute] int id)
        {
            return _moviesService.GetOne(id);
        }
    }
}
