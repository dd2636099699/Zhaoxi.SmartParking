using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Zhaoxi.SmartParking.Server.ICommon;
using Zhaoxi.SmartParking.Server.IService;
using Zhaoxi.SmartParking.Server.Models;

namespace Zhaoxi.SmartParking.Server.Start.Controllers
{
    [ApiController]
    public class FileController: ControllerBase
    {
        IConfiguration _configuration;
        IFileUpgradeService _fileUpgradeService;
        public FileController(IConfiguration configuration, IFileUpgradeService fileUpgradeService)
        {
            _configuration = configuration;
            _fileUpgradeService = fileUpgradeService;
        }
        /// 提供文件相关的服务
        /// 上传、下载
        /// 说明：为什么下载的文件都是0kb？
        /// 两个原因：
        /// 1、更新程序修改了配置文件后没有编译，导致运行目录下的配置文件还是旧地址
        /// 2、如果添加Route特性的话，需要把Route中的名称添加到Url后面
        /// 综合结论：还是Url的问题，未访问到
        //[Route("aaa")]
        [HttpPost]
        [Route("download")]
        public IActionResult Download([FromForm] IFormCollection formCollection)
        {
            var fileName = formCollection["filename"]; //文件名
            var filePath = Path.Combine(Path.Combine(_configuration.Read("FileFolder"), "upgrade"), fileName); //文件所在路径
            ResFileStream fs = new ResFileStream(filePath, FileMode.Open, FileAccess.Read);

            var type = new MediaTypeHeaderValue("application/oct-stream").MediaType;
            
            //enableRangeProcessing 是否启动断点续传
            return File(fs, contentType: type, fileName, enableRangeProcessing: true);

            //var bytes = new byte[fs.Length];
            //fs.Read(bytes, 0, bytes.Length);
            //fs.Close();
            //return new FileContentResult(bytes, "application/oct-stream");
        }

        /// Post 文件上传
        /// 通过C#代码模拟表单提交

        [HttpPost]
        [Route("upload")]
        public IActionResult Upload([FromForm] IFormCollection formCollection)
        {
            FormFileCollection filelist = (FormFileCollection)formCollection.Files;
            if (filelist.Count > 0)
            {
                string fileName = filelist[0].FileName;
                string fileMD5 = formCollection["md5"].ToString();
                String Tpath = Path.Combine(_configuration.Read("FileFolder"), "upgrade");// 获取文件存放位置

                DirectoryInfo di = new DirectoryInfo(Tpath);
                if (!di.Exists) di.Create();

                using (FileStream fs = System.IO.File.Create(Path.Combine(Tpath, fileName)))
                {
                    // 复制文件
                    filelist[0].CopyToAsync(fs);
                    // 清空缓冲区数据
                    fs.Flush();
                }

                // 更新或新增到数据库
                UpgradeFile upgradeFile = new UpgradeFile
                {
                    FileName = fileName,
                    FileMd5 = fileMD5,
                    UploadTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                };
                //_fileUpgradeService.Insert<UpgradeFile>(upgradeFile);
                _fileUpgradeService.AddOrUpdate(upgradeFile);
            }
            return Ok(new { count = filelist.Count, len = filelist.Sum(f => f.Length) });
        }

        /// url?param=werwe
        /// url/param1/param2
        /// header
        /// body
        /// form

        [HttpGet]
        [Route("check")]
        public JsonResult Check()
        {
            var result = _fileUpgradeService.Query<UpgradeFile>(f => f.FileId > 0);// EFCore
            // 从数据库获取相关的文件信息   文件名-文件MD5
            return new JsonResult(result);
        }

        [HttpGet]
        [Route("list")]
        public JsonResult FileList()
        {
            var result = _fileUpgradeService.Query<UpgradeFile>(f => f.FileId > 0);
            return new JsonResult(result);
        }
    }

    internal class ResFileStream : FileStream
    {
        public ResFileStream(string path, FileMode mode, FileAccess access) : base(path, mode, access) { }

        /// <param name="array"></param>
        /// <param name="offset">偏移量</param>
        /// <param name="count">读取的最大字节数</param>
        /// <returns></returns>
        public override int Read(byte[] array, int offset, int count)
        {
            // 此处可以限制下载速度
            //count = 256;
            //Thread.Sleep(10);
            return base.Read(array, offset, count);
        }
    }
}
