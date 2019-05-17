namespace FMS_API.Controllers
{
    using FMS_API.Models;
    using FMS_API_BAL;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;
    using UtilityService;

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AssosiateFeedbackController : ControllerBase
    {
        private readonly IProcessExcel _processExcel;
        private readonly IEmail _email;

        public AssosiateFeedbackController(
            IProcessExcel processExcel,
            IEmail email
            )
        {
            this._processExcel = processExcel;
            this._email = email;
        }
        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> PerticipatedAssosiates()
        {
            try
            {
                var file = Request.Form.Files[0];
                if (file.Length > 0)
                {
                    var result = await _processExcel.ProcessBulkUploadForAssosiates(file.OpenReadStream());
                    foreach (var item in result)
                    {
                        var emailBodyTemplate = _email.GetEmailTemplate
                            (
                            "Perticipated",
                            Convert.ToDateTime(item.EventDate).ToString("dd/MM/yyyy"),
                            item.EventName,
                            item.EmplotyeeId.ToString()
                            );
                        EmailConfig config = new EmailConfig()
                        {
                            Body = emailBodyTemplate.ToString(),
                            Subject = "Your feedback is valuable for us",
                            TextFormatter = "html",
                            ToEmailAddress = "arnabknd4@gmail.com",
                            ToName = "Arnab"
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
        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> UnregisteredAssosiates()
        {
            try
            {
                var file = Request.Form.Files[0];
                if (file.Length > 0)
                {
                    var result = await _processExcel.ProcessBulkUploadForAssosiates(file.OpenReadStream());
                    foreach (var item in result)
                    {
                        var emailBodyTemplate = _email.GetEmailTemplate
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
                            ToEmailAddress = "arnabknd4@gmail.com",
                            ToName = "Arnab"
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
        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> NotPerticipatedAssosiates()
        {
            try
            {
                var file = Request.Form.Files[0];
                if (file.Length > 0)
                {
                    var result = await _processExcel.ProcessBulkUploadForAssosiates(file.OpenReadStream());
                    foreach (var item in result)
                    {
                        var emailBodyTemplate = _email.GetEmailTemplate
                            (
                            "NotPerticipated",
                            Convert.ToDateTime(item.EventDate).ToString("dd/MM/yyyy"),
                            item.EventName,
                            item.EmplotyeeId.ToString()
                            );
                        EmailConfig config = new EmailConfig()
                        {
                            Body = emailBodyTemplate.ToString(),
                            Subject = " Test Message",
                            TextFormatter = "html",
                            ToEmailAddress = "arnabknd4@gmail.com",
                            ToName = "Arnab"
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