using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.SmartParking.Client.Entity;

namespace Zhaoxi.SmartParking.Client.IBLL
{
    public interface IAutoRegisterBLL
    {
        Task<PaginationResult> GetAll(int index, int count);

        Task<AutoRegisterEntity> GetAutoByLicense(string license);
    }
}
