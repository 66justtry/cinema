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
        public IActionResult GetMovies([FromQuery] Dictionary<string, string> query)
        {
            return Ok(_moviesService.GetAll(query));
        }

        [HttpGet("{id}")]
        public IActionResult GetMovie([FromRoute] int id)
        {
            var res = _moviesService.GetOne(id);
            return res != null ? Ok(res) : NotFound();
        }
    }
}
