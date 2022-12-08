using Microsoft.AspNetCore.Mvc;


namespace CommandApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommandController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "this", "is", "hard", "coded" };
        }
    }
}