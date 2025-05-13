using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Zhaoxi.SmartParking.Server.ICommon;
using Zhaoxi.SmartParking.Server.IService;
using Zhaoxi.SmartParking.Server.Models;

namespace Zhaoxi.SmartParking.Server.Service
{
    public class AutoRegisterService : BaseService, IAutoRegisterService
    {
        public AutoRegisterService(IDbConnectionFactory contextFactor) : base(contextFactor)
        {
        }

        public PaginationResult GetAll(int pageIndex, int perPageCount)
        {
            PaginationResult result = new PaginationResult();

            try
            {
                int count = Context.Set<AutoRegister>().Where(q => q.State == 1).Count();
                int checkIndex = (pageIndex - 1) * perPageCount;
                if (checkIndex >= count)
                    pageIndex = 1;
                // 根据分布取数据
                var v = from q in Context.Set<AutoRegister>().Skip((pageIndex - 1) * perPageCount).Take(perPageCount).ToList()
                        join lc in Context.Set<LicenseColor>() on q.LicenseColorId equals lc.ColorId
                        join ac in Context.Set<AutoColor>() on q.AutoColorId equals ac.ColorId
                        join am in Context.Set<FeeModel>() on q.FeeModeId equals am.FeeModelId
                        where q.State == 1
                        select new
                        {
                            AutoId = q.AutoId,
                            AutoLicense = q.AutoLicense,
                            LColorId = lc.ColorId,
                            LColorName = lc.ColorName,
                            AColorId = ac.ColorId,
                            AColorName = ac.ColorName,
                            FeeModelId = am.FeeModelId,
                            FeeModelName = am.FeeModelName,
                            Description = q.Description
                        };

                result.State = 1;
                result.Message = "";
                result.PageInfo = new PageInfo() { PageIndex = pageIndex, RecordCount = count };
                result.Data = Newtonsoft.Json.JsonConvert.SerializeObject(v.ToList());
            }
            catch (Exception ex)
            {
                result.State = 0;
                result.Message = ex.Message;
            }

            return result;
        }

        public AutoRegister GetAutoByLicense(string license)
        {
            return this.Query<AutoRegister>(q => q.AutoLicense == license)?.FirstOrDefault();
        }
    }
}
