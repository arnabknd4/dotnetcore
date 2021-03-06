﻿namespace FMS_API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Hosting;
    using System.IO;
    using System.Net.Http.Headers;

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessExcelController : ControllerBase
    {
        private IHostingEnvironment _hostingEnvironment;

        public ProcessExcelController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Post()
        {
            try
            {
                var file = Request.Form.Files[0];
                string folderName = "Upload";
                string webRootPath = _hostingEnvironment.WebRootPath;
                string newPath = Path.Combine(webRootPath, folderName);
                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }
                if (file.Length > 0)
                {
                    string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    string fullPath = Path.Combine(newPath, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                return Ok("Upload Successful.");
            }
            catch (System.Exception ex)
            {
                
            }
            return BadRequest();
        }
    }
}