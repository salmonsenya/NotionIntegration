using Microsoft.AspNetCore.Mvc;

namespace NotionIntegration.Controllers
{
    [Route("test")]
    public class TestController : Controller
    {
        [HttpGet]
        [Route("health")]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
