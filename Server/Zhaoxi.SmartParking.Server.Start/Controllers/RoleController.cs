using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zhaoxi.SmartParking.Server.IService;
using Zhaoxi.SmartParking.Server.Models;

namespace Zhaoxi.SmartParking.Server.Start.Controllers
{
    [ApiController]
    public class RoleController : Controller
    {
        IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        [Route("all")]
        public JsonResult GetAll()
        {
            return Json(_roleService.Query<RoleInfo>(r => r.state == 1));
        }

        [HttpGet("all/{userId}")]
        public JsonResult GetRolesByUserId(int userId)
        {
            return Json(_roleService.GetRolesByUserId(userId));
        }

        [HttpGet("all_users/{roleId}")]
        public JsonResult GetAllUsers(int roleId)
        {
            return Json(_roleService.GetAllUsers(roleId));
        }

        [HttpPost]
        [Route("save")]
        public IActionResult SaveRole([FromForm] IFormCollection values)
        {
            _roleService.Save(values["role"].ToString(), values["users"], values["menus"]);
            return Ok();
        }
    }
}
