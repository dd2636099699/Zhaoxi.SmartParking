using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.SmartParking.Client.Models;
using Zhaoxi.SmartParking.Client.Log.Aop.Attributes;

namespace Zhaoxi.SmartParking.Client.IBLL
{
    public interface IUpgradeFileBLL
    {
        [Exception]
        [LogBefore]
        Task<List<string>> DiffFileListAsync();

        Task<List<FileInfoModel>> AllFileListAsync();

        Task<bool> UploadFile(string fileName, string fullPath);
    }
}
