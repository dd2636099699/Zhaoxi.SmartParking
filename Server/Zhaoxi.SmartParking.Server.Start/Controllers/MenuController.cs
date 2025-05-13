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
    public class MenuController : Controller
    {
        IMenuService _menuService;
        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }
        [HttpGet]
        [Route("list")]
        public JsonResult GetMenus(int roleId)
        {
            return Json(_menuService.GetMenusByRoleId(roleId));
        }

        [HttpGet]
        [Route("all")]
        public JsonResult GetAllMenus()
        {
            return Json(_menuService.GetAllMenus());
        }

        [HttpPost]
        [Route("save")]
        public IActionResult SaveMenu([FromBody] JsonElement data)
        {
            _menuService.SaveMenu(data.ToString());
            return Ok(data);
        }

        [HttpPost]
        [Route("del")]
        public IActionResult DeleteMenu([FromForm] int menuId)
        {
            _menuService.Delete<MenuInfo>(menuId);
            return Ok();
        }
    }
}
