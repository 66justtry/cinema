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
        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
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
            return Ok(_ordersService.GetAll(phone));
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
            return res ? Ok() : BadRequest();
        }
    }
}
