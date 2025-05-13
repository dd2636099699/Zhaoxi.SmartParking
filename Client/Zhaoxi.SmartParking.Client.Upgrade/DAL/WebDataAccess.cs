using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.SmartParking.Client.Upgrade.Model;

namespace Zhaoxi.SmartParking.Client.Upgrade.DAL
{
    public class WebDataAccess
    {
        LocalDataAccess localDataAccess = new LocalDataAccess();

        public async Task<int> DownloadAsync(List<FileInfoModel> files, Action<FileInfoModel> callback)
        {
            using (var client = new HttpClient())
            {
                foreach (var item in files)
                {
                    //
                    try
                    {
                        string url = ConfigurationManager.AppSettings["file_download_url"];
                        var postContent = new MultipartFormDataContent();
                        string boundary = string.Format("--{0}", DateTime.Now.Ticks.ToString("x"));
                        postContent.Headers.Add("ContentType", $"multipart/form-data, boundary={boundary}");
                        postContent.Add(new StringContent(item.FileName), "filename");


                        var response = await client.PostAsync(url, postContent);
                        /// 文件下载
                        byte[] result = await response.Content.ReadAsByteArrayAsync();

                        string fileName = Path.Combine(Environment.CurrentDirectory, item.FileName);
                        using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
                        {
                            fs.Write(result, 0, result.Length);
                            fs.Flush();
                        }

                        // 数据更新到本地缓存数据库
                        if (!localDataAccess.UpdateFileInfo(item.FileName, item.FileMd5))
                        {
                            throw new Exception("同步更新本地缓存出现异常");
                        }

                        item.State = "完成";
                    }
                    catch (Exception ex)
                    {
                        item.ErrorMsg = $"[{ex.Message}]";
                    }
                    finally
                    {
                        callback?.Invoke(item);
                    }

                }
                return files.Count(f => f.State == "完成");
            }
        }
    }
}
