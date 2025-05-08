using CartService.Model;
using CartService.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CartService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly CartServices _cartService;

        public CartController(CartServices cartService)
        {
            _cartService = cartService;
        }
        [HttpGet]
        public IActionResult GetCartData()
        {
            var orders = _cartService.GetAllOrders();
            return Ok(orders);
        }
        [HttpPost]
        public IActionResult AddToCart(CartModel model)
        {
            _cartService.AddOrder(model);
            return Ok();
        }
        [HttpGet("{id}")]
        public CartModel GetCart(int id)
        {
            var order = _cartService.GetOrderById(id);
            return order;
        }
    }
}
