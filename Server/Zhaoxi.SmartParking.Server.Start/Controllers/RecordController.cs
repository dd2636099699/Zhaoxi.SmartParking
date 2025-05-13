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
    public class RecordController : Controller
    {
        IRecordService _recordService;
        public RecordController(IRecordService recordService)
        {
            _recordService = recordService;
        }


        [HttpGet("license/{license}")]
        public JsonResult GetRecordByLicense([FromRoute] string license)
        {
            return Json(_recordService.GetRecordInfo(license));
        }
    }
}
