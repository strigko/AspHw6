using Microsoft.AspNetCore.Mvc;

namespace AspHw6.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly List<string> products = new()
        {
            "Phone",
            "Laptop",
            "Keyboard",
            "Mouse",
            "Monitor",
            "Headphones"
        };

        [HttpGet]
        public IActionResult Products([FromQuery] int? startFrom, [FromQuery] int? endsWith)
        {
            if (startFrom.HasValue && (startFrom < 0 || startFrom >= products.Count))
            {
                return BadRequest(new
                {
                    Status = 400,
                    Message = $"StartFrom must be between 0 and {products.Count - 1}"
                });
            }

            if (endsWith.HasValue && (endsWith < 0 || endsWith >= products.Count))
            {
                return BadRequest(new
                {
                    Status = 400,
                    Message = $"EndsWith must be between 0 and {products.Count - 1}"
                });
            }

            int start = startFrom ?? 0;
            int end = endsWith ?? products.Count - 1;

            if (start > end)
            {
                return BadRequest(new
                {
                    Status = 400,
                    Message = "StartFrom cannot be greater than EndsWith"
                });
            }

            var result = products.Skip(start).Take(end - start + 1).ToList();

            return Ok(new
            {
                Status = 200,
                Message = "Ok",
                Products = result
            });
        }
    }
}