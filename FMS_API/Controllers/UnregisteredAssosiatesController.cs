namespace FMS_API.Controllers
{
    using FMS_API_BAL;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;
    using UtilityService;

    [Route("api/[controller]")]
    [ApiController]
    public class UnregisteredAssosiatesController : ControllerBase
    {
        private readonly IProcessExcel _processExcel;
        private readonly IEmail _email;
        public UnregisteredAssosiatesController(
            IProcessExcel processExcel,
            IEmail email
            )
        {
            this._processExcel = processExcel;
            this._email = email;
        }

        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> Post()
        {
            try
            {
                var file = Request.Form.Files[0];
                if (file.Length > 0)
                {
                    var result = await _processExcel.ProcessBulkUploadForAssosiates(file.OpenReadStream());
                    foreach (var item in result)
                    {
                        var emailBodyTemplate = await _email.GetEmailTemplate
                            (
                            "Unregistered",
                            Convert.ToDateTime(item.EventDate).ToString("dd/MM/yyyy"),
                            item.EventName,
                            item.EmplotyeeId.ToString()
                            );
                        EmailConfig config = new EmailConfig()
                        {
                            Body = emailBodyTemplate.ToString(),
                            Subject = " Test Message",
                            TextFormatter = "html",
                            ToEmailAddress = item.EmplotyeeId + "@cognizant.com",
                            ToName = Convert.ToString(item.EmplotyeeId)
                        };

                        var emailResult = await this._email.Send(config);
                    }
                }
                return Ok("Upload Successful.");
            }
            catch (System.Exception)
            {

            }
            return BadRequest();
        }
    }
}