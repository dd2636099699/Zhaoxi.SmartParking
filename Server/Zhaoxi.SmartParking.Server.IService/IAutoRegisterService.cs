using System;
using System.Collections.Generic;
using System.Text;
using Zhaoxi.SmartParking.Server.Models;

namespace Zhaoxi.SmartParking.Server.IService
{
    public interface IAutoRegisterService : IBaseService
    {
        /// <summary>
        /// 通过PaginationResult返回一定的分页信息 （页码、总条数）
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="perPageCount"></param>
        /// <returns></returns>
        PaginationResult GetAll(int pageIndex, int perPageCount);


        AutoRegister GetAutoByLicense(string license);
    }
}
