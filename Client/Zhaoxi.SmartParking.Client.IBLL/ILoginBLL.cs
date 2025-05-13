using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhaoxi.SmartParking.Client.IBLL
{
    public interface ILoginBLL
    {
        Task<bool> Login(string uName, string pwd);
    }
}
