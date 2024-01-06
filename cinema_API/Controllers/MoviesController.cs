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
        ICacheService _cacheService;
        public MoviesController(IMoviesService moviesService, ICacheService cacheService)
        {
            _moviesService = moviesService;
            _cacheService = cacheService;
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
            var key = "movies" + Request.QueryString.ToString();
            var res = _cacheService.GetData<IEnumerable<MovieSessionShort>>(key);
            if (res != null)
                return Ok(res);
            res = _moviesService.GetAll(query);
            _cacheService.SetData<IEnumerable<MovieSessionShort>>(key, res);
            return Ok(res);
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
            var key = $"movies/{id}";
            var res = _cacheService.GetData<MovieSessionFull>(key);
            if (res != null)
                return Ok(res);
            res = _moviesService.GetOne(id);
            if (res != null)
            {
                _cacheService.SetData<MovieSessionFull>(key, res);
                return Ok(res);
            }
            return NotFound();
        }
    }
}
