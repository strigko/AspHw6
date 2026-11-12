using Microsoft.AspNetCore.Mvc;

namespace AspHw6
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly ShoppingCartService _shoppingCartService;

        public ShoppingCartController(ShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        [HttpPost("add")]
        public IActionResult AddProduct(string product)
        {
            _shoppingCartService.AddProduct(product);

            return Ok(_shoppingCartService.GetProducts());
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_shoppingCartService.GetProducts());
        }
    }
}