using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CICDDemoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                status = "Healthy",
                application = "CICDDemoApi",
                version = "1.0"
            });
        }
    }
}
