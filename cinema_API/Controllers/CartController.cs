using cinema_API.Models;
using cinema_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace cinema_API.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        ICartService _cartService;
        ICacheService _cacheService;
        public CartController(ICartService cartService, ICacheService cacheService)
        {
            _cartService = cartService;
            _cacheService = cacheService;
        }
        /// <summary>
        /// Дані для сторінки вибору місць
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        [HttpGet("{sessionId}")]
        [ProducesResponseType(typeof(CartSessionFull), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(object), (int)HttpStatusCode.NotFound)]
        public IActionResult GetCart([FromRoute] int sessionId)
        {
            var key = $"cart/{sessionId}";
            var res = _cacheService.GetData<CartSessionFull>(key);
            if (res != null)
                return Ok(res);
            res = _cartService.GetCart(sessionId);
            if (res != null)
            {
                _cacheService.SetData<CartSessionFull>(key, res);
                return Ok(res);
            }
            return NotFound();
        }
    }
}
