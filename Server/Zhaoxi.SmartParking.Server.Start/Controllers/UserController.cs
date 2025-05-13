using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Zhaoxi.SmartParking.Server.IService;
using Zhaoxi.SmartParking.Server.Models;

namespace Zhaoxi.SmartParking.Server.Start.Controllers
{
    //[Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("all")]
        public JsonResult GetUsers()
        {
            return Json(_userService.Query<SysUserInfo>(u => u.state == 1));
        }

        [HttpPost]
        [Route("state")]
        public IActionResult UpdateState([FromForm] IFormCollection form)
        {
            _userService.ChangeState(int.Parse(form["userId"]), int.Parse(form["state"]));
            return Ok();
        }

        [HttpPost]
        [Route("save")]
        public IActionResult UpdateUserInfo([FromBody] JsonElement data)
        {
            _userService.SaveUser(data.ToString());
            return Ok(data);
        }

        [HttpPost]
        [Route("resetpwd")]
        public IActionResult ResetPassword([FromForm] IFormCollection form)
        {
            _userService.ResetPassword(int.Parse(form["userId"]));
            return Ok();
        }

        [HttpPost]
        [Route("roles")]
        public IActionResult UpdateRoles([FromForm] IFormCollection form)
        {
            List<int> roles = Newtonsoft.Json.JsonConvert.DeserializeObject<List<int>>(form["roles"].ToString());
            _userService.UpdateRoles(int.Parse(form["userId"]), roles);
            return Ok();
        }
    }
}
