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
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
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
            var res = _cartService.GetCart(sessionId);
            return res != null ? Ok(res) : NotFound();
        }
    }
}
