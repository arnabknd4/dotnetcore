namespace FMS_API.Controllers
{
    using FMS_API_BAL;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;
    using UtilityService;

    [Route("api/[controller]")]
    [ApiController]
    public class PerticipatedAssosiatesController : ControllerBase
    {
        private readonly IProcessExcel _processExcel;
        private readonly IEmail _email;
        public PerticipatedAssosiatesController(
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
                            ToEmailAddress = item.EmplotyeeId+"@cognizant.com",
                            ToName =Convert.ToString(item.EmplotyeeId)
                        };

                        var emailResult = await this._email.Send(config);
                    }
                }
                return Ok("Upload Successful.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}