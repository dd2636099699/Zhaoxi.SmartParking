using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhaoxi.SmartParking.Client.IDAL
{
    public interface IAutoRegisterDal
    {
        Task<string> GetAll(int index,int count);

        Task<string> GetAutoByLicense(string license);
    }
}
