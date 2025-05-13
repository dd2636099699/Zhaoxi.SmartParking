using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhaoxi.SmartParking.Client.IDAL
{
    public interface IWebDataAccess
    {
        Task<string> GetFileList();
        Task<string> Login(string un, string pwd);
    }
}
