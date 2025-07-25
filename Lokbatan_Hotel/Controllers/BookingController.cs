using Lokbatan_Hotel.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lokbatan_Hotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IHomeService _homeService;

        public BookingController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        [HttpGet("available-homes")]
        public async Task<IActionResult> GetAvailableHomes([FromQuery] string startDate, [FromQuery] string endDate)
        {
            if (!DateTime.TryParse(startDate, out var start) || !DateTime.TryParse(endDate, out var end))
                return BadRequest(new { status = "Error", message = "Invalid startDate or endDate format. Use YYYY-MM-DD." });

            var homes = await _homeService.GetAvailableHomesAsync(start, end);

            return Ok(new { status = "OK", homes });
        }
    }
}
