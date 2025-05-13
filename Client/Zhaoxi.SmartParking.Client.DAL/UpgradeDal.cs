using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.SmartParking.Client.IDAL;

namespace Zhaoxi.SmartParking.Client.DAL
{
    public class UpgradeDal : WebDataAccess, IUpgradeDal
    {
        public Task<string> GetFileList()
        {
            // 获取服务中已上传的文件列表   从数据库表UpgradeFiles
            return this.GetDatas($"{domain}file/list");//"[]"
        }

        public Task<string> UploadFiles(string fileName, string fullPath, string md5)
        {
            // 模拟Form表单
            var postContent = new MultipartFormDataContent();
            string boundary = string.Format("--{0}", DateTime.Now.Ticks.ToString("x"));
            postContent.Headers.Add("ContentType", $"multipart/form-data, boundary={boundary}");
            FileStream fs1 = new FileStream(fullPath, FileMode.Open);
            postContent.Add(new StreamContent(fs1, (int)fs1.Length), "file", fileName);
            postContent.Add(new StringContent(md5), "MD5");

            /// 文件上传接口
            return this.PostDatas($"{domain}file/Upload", postContent);
        }
    }
}
