using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FMS_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly FMSContext fMSContext;

        //private readonly Login_DAL _loginDal;

        public LoginController(FMSContext fMSContext)
        {
            //this._loginDal = loginDal;
            this.fMSContext = fMSContext;
        }
        // GET: api/Login
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello World");
        }
        //GET: api/Login
       [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            var userResult = await fMSContext.Users.FindAsync(user);
            if (userResult == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(userResult);
            }
        }
    }
}