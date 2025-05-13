using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhaoxi.SmartParking.Client.IDAL
{
    public interface IUpgradeDal
    {
        Task<string> GetFileList();
        Task<string> UploadFiles(string fileName, string fullPath, string md5);
    }
}
