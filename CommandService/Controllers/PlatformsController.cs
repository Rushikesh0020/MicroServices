using Microsoft.AspNetCore.Mvc;

namespace CommandService.Controllers
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        public PlatformsController()
        {

        }
        public ActionResult TestInboundConnection() 
        {
            Console.WriteLine("Test Inbound Connection!!!");
            return Ok("Test Inbound Connection Successful");
        }
    }
}