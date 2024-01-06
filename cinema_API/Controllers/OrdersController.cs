using cinema_API.Models;
using cinema_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace cinema_API.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        public class CreateRequestModel
        {
            public int SessionId { get; set; }
            public string Phone { get; set; }
            public int Sum { get; set; }
            public List<int> SeatIds { get; set; }
        }
        IOrdersService _ordersService;
        ICacheService _cacheService;
        public OrdersController(IOrdersService ordersService, ICacheService cacheService)
        {
            _ordersService = ordersService;
            _cacheService = cacheService;
        }
        /// <summary>
        /// Всі замовлення квитків по номеру телефону
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        [HttpGet("{phone}")]
        [ProducesResponseType(typeof(List<OrderFull>), (int)HttpStatusCode.OK)]
        public IActionResult GetOrders([FromRoute] string phone)
        {
            var key = $"orders/{phone}";
            var res = _cacheService.GetData<IEnumerable<OrderFull>>(key);
            if (res != null)
                return Ok(res);
            res = _ordersService.GetAll(phone);
            _cacheService.SetData<IEnumerable<OrderFull>>(key, res);
            return Ok(res);
        }
        /// <summary>
        /// Створення нового замовлення квитків
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(object), (int)HttpStatusCode.BadRequest)]
        public IActionResult CreateOrder([FromBody] CreateRequestModel request)
        {
            var res = _ordersService.Create(request.SessionId, request.Phone, request.Sum, request.SeatIds);
            if (res)
            {
                string key1 = $"cart/{request.SessionId}";
                string key2 = $"orders/{request.Phone}";
                _cacheService.RemoveData(key1);
                _cacheService.RemoveData(key2);
                return Ok();
            }
            return BadRequest();
        }
    }
}
