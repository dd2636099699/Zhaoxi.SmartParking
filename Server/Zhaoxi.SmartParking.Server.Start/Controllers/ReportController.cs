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
    public class ReportController : Controller
    {
        IReportService _reportService;
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("all")]
        public JsonResult GetReportAll()
        {
            return Json(_reportService.Query<RecordInfo>(q => 1 == 1));
        }
    }
}
