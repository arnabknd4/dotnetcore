using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FMS_API_BAL;
using FMS_API_DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //private readonly Login_DAL _loginDal;

        //public LoginController(Login_DAL loginDal)
        //{
        //    //this._loginDal = loginDal;
        //}
        // GET: api/Login
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello World");
        }
        // GET: api/Login
        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody] User user)
        //{
        //    var userResult = await _loginDal.fetchUser(user);
        //    if(userResult == null)
        //    {
        //       return NotFound();
        //    }
        //    else
        //    {
        //        return Ok(userResult);
        //    }
        //}
    }
}