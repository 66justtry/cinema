using cinema_API.Models;
using cinema_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
        /// <summary>
        /// Всі фільми в прокаті в заданий день
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<MovieSessionShort>), (int)HttpStatusCode.OK)]
        public IActionResult GetMovies([FromQuery] Dictionary<string, string> query)
        {
            return Ok(_moviesService.GetAll(query));
        }
        /// <summary>
        /// Дані для сторінки фільму та його сеансів
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(MovieSessionFull), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(object), (int)HttpStatusCode.NotFound)]
        public IActionResult GetMovie([FromRoute] int id)
        {
            var res = _moviesService.GetOne(id);
            return res != null ? Ok(res) : NotFound();
        }
    }
}
