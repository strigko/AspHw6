using Microsoft.AspNetCore.Mvc;

namespace AspHw6
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestsController : ControllerBase
    {
        private readonly RequestLoggingService _loggingService;

        public RequestsController(RequestLoggingService loggingService)
        {
            _loggingService = loggingService;
        }

        [HttpGet]
        public IActionResult GetRequests()
        {
            return Ok(_loggingService.GetRequests());
        }
    }
}