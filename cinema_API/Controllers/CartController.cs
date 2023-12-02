using cinema_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("{sessionId}")]
        public IActionResult GetCart([FromRoute] int sessionId)
        {
            var res = _cartService.GetCart(sessionId);
            return res != null ? Ok(res) : NotFound();
        }
    }
}
