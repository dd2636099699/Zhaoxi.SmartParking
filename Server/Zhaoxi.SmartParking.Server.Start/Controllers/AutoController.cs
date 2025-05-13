using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zhaoxi.SmartParking.Server.IService;

namespace Zhaoxi.SmartParking.Server.Start.Controllers
{
    [ApiController]
    public class AutoController : Controller
    {
        IAutoRegisterService _autoRegisterService;
        public AutoController(IAutoRegisterService autoRegisterService)
        {
            _autoRegisterService = autoRegisterService;
        }
        //做了分页
        [HttpGet("all/{index}/{count}")]
        public JsonResult GetAll([FromRoute] int index, [FromRoute] int count)
        {
            return Json(_autoRegisterService.GetAll(index, count));
        }

        [HttpGet("info/{license}")]
        public JsonResult GetAutoByLicense([FromRoute] string license)
        {
            return Json(_autoRegisterService.GetAutoByLicense(license));
        }
    }
}
