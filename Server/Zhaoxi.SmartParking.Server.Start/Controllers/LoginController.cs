using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zhaoxi.SmartParking.Server.ICommon;
using Zhaoxi.SmartParking.Server.IService;
using Zhaoxi.SmartParking.Server.Models;

namespace Zhaoxi.SmartParking.Server.Start.Controllers
{
    //[Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        ILoginService _loginService;
        IMenuService _menuService;
        IUtils _utils;
        public LoginController(ILoginService loginService, IUtils utils, IMenuService menuService)
        {
            _loginService = loginService;
            _menuService = menuService;
            _utils = utils;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromForm] string userName, [FromForm] string pwd)
        {
            //"123456"->md5   
            //  MD5(MD5("123456") + "|" + userName)
            string password = _utils.GetMD5Str(_utils.GetMD5Str(pwd) + "|" + userName);

            var users = _loginService.Query<SysUserInfo>(u => u.UserName == userName && u.Password == password);

            // 如果找到一个用户信息，则继续查找权限，如果有权限则继续生成对应的菜单列表
            if (users?.Count() > 0)
            {
                var userInfo = users.ToList();
                SysUserInfo sysUserInfo = userInfo[0];
                // 根据权限获取菜单 
                List<MenuInfo> menus = _menuService.GetMenusByUserId(sysUserInfo.UserId);
                sysUserInfo.Menus = menus;

                return Ok(sysUserInfo);
            }
            else
            {
                return NoContent();
            }
        }
    }
}
