namespace FMS_API.Controllers
{
    using FMS_API_BAL;
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
            var template = await email.GetTemplate();
            EmailConfig config = new EmailConfig() {
                Body = template.ToString(),
                Subject = " Test Message",
                TextFormatter = "html",
                ToEmailAddress = "arnabknd4@gmail.com",
                ToName = "Arnab"
            };

            var result = await email.send(config);
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