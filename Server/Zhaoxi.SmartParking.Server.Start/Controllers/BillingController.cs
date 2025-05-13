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
    public class BillingController : Controller
    {
        IBillingService _billingService;
        public BillingController(IBillingService billingService)
        {
            _billingService = billingService;
        }




        [HttpGet("all")]
        public JsonResult GetAllBillings()
        {
            return Json(_billingService.Query<BillingInfo>(q => 1 == 1).ToList());
        }
    }
}
