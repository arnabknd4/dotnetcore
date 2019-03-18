﻿namespace FMS_API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Hosting;
    using System.IO;
    using System.Net.Http.Headers;
    using UtilityService;

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessExcelController : ControllerBase
    {
        private IHostingEnvironment _hostingEnvironment;
        private readonly IProcessExcel processExcel;

        public ProcessExcelController(
            IHostingEnvironment hostingEnvironment,
            IProcessExcel processExcel
            )
        {
            _hostingEnvironment = hostingEnvironment;
            this.processExcel = processExcel;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Working!");
        }
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Post()
        {
            try
            {
                var file = Request.Form.Files[0];
                if (file.Length > 0 && file.ContentType == "application/vnd.ms-excel")
                {
                    var result  = processExcel.ProcessFile(file);
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