using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.SmartParking.Client.Entity;
using Zhaoxi.SmartParking.Client.IBLL;
using Zhaoxi.SmartParking.Client.IDAL;
using Zhaoxi.SmartParking.Client.ILog;
using Zhaoxi.SmartParking.Client.Models;

namespace Zhaoxi.SmartParking.Client.BLL
{
    public class UpgradeFileBLL : IUpgradeFileBLL
    {
        IUpgradeDal _upgradeDal = null;
        ILocalDataAccess _localDataAccess;
        ILogHelper _logHelper;
        public UpgradeFileBLL(IUpgradeDal upgradeDal, ILocalDataAccess localDataAccess,
            ILogHelper logHelper)
        {
            _upgradeDal = upgradeDal;
            _localDataAccess = localDataAccess;
            _logHelper = logHelper;
        }

        public async Task<List<FileInfoModel>> AllFileListAsync()
        {
            string infoWeb = await _upgradeDal.GetFileList();
            List<UpgradeFileInfo> result = JsonConvert.DeserializeObject<List<UpgradeFileInfo>>(infoWeb);

            return result.Select((s, index) => new FileInfoModel
            {
                Index = (index + 1).ToString("00"),
                FileName = s.FileName,
                UploadTime = s.UploadTime
            }).ToList();
        }

        public async Task<List<string>> DiffFileListAsync()
        {
            //int a = 0;
            //var v = 0 / a;
            //Info
            //_logHelper.Debug("UpgradeFileBLL。DiffFileListAsync。方法进入");// 侵入式，利用AOP配合特性的方式 ILog 
            //_logHelper.Debug(this, "Hello Log4Net");

            List<string> diffFiles = new List<string>();
            //try
            //{
            // 获取文件版本信息
            // 从服务器拿到更新文件列表信息（文件名、MD5）
            string infoWeb = await _upgradeDal.GetFileList();
            List<UpgradeFileInfo> fileInfoWeb = JsonConvert.DeserializeObject<List<UpgradeFileInfo>>(infoWeb);
            if (fileInfoWeb?.Count > 0)
            {
                // 从本地缓存数据库（Sqlite）中取当前本地的文件信息（文件名、MD5）
                List<UpgradeFileInfo> fileInfoLocal = _localDataAccess.GetLocalFileInfo().Select(f => new UpgradeFileInfo { FileName = f[0], FileMd5 = f[1] }).ToList();

                // 对比之后返回差异的文件名称列表
                // 1.Web列表中不存在于Local列表中的数据返回更新
                // 2.Web列表中存在于Local列中，但MD5码不一致
                fileInfoWeb.ForEach(fw =>
                {
                    if (fileInfoLocal == null ||
                    fileInfoLocal.Exists(fl => fl.FileName == fw.FileName && fl.FileMd5 != fw.FileMd5) ||
                    !fileInfoLocal.Exists(fl => fl.FileName == fw.FileName))
                    {
                        diffFiles.Add(fw.FileName + "|" + fw.FileMd5);
                    }
                });
            }

            //}
            //catch (Exception ex)
            //{
            //    //_logHelper.Error(ex.Message);
            //    _logHelper.Error(this, ex.Message);
            //    throw ex;
            //}
            // 异常可能只会在生产环境出现、在开发环境无法重现

            return diffFiles;
        }

        public async Task<bool> UploadFile(string fileName, string fullPath)
        {
            // 获取文件的MD5码并上传

            var result = await _upgradeDal.UploadFiles(fileName, fullPath, this.GetMD5HashFromFile(fullPath));
            return true;
        }

        public string GetMD5HashFromFile(string fileName)
        {
            try
            {
                FileStream file = new FileStream(fileName, System.IO.FileMode.Open);
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(file);
                file.Close();
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("GetMD5HashFromFile() fail,error:" + ex.Message);
            }
        }
    }
}
