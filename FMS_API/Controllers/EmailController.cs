namespace FMS_API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using UtilityService;

    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmail email;
        public EmailController(IEmail email)
        {
            this.email = email;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await email.send();
            if (result)
            {
                return Ok("Success");
            }
            else
            {
                return NoContent();
            }

        }
    }
}