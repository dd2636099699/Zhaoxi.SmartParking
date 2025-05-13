using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.SmartParking.Client.IDAL;

namespace Zhaoxi.SmartParking.Client.DAL
{
    public class WebDataAccess : IWebDataAccess
    {
        protected string domain = "http://localhost:5000/api/v1/";

        public async Task<string> GetDatas(string url)
        {
            using (var client = new HttpClient())
            {
                var resp = await client.GetAsync(url);
                return await resp.Content.ReadAsStringAsync();
            }
        }

        public MultipartFormDataContent GetFormData(Dictionary<string, HttpContent> contents)
        {
            var postContent = new MultipartFormDataContent();
            string boundary = string.Format("--{0}", DateTime.Now.Ticks.ToString("x"));
            postContent.Headers.Add("ContentType", $"multipart/form-data, boundary={boundary}");

            foreach (var item in contents)
            {
                postContent.Add(item.Value, item.Key);
            }

            return postContent;
        }
        public async Task<string> PostDatas(string url, HttpContent content)
        {
            using (var client = new HttpClient())
            {
                var resp = await client.PostAsync(url, content);
                return await resp.Content.ReadAsStringAsync();
            }
        }




        public async Task<string> GetFileList()
        {
            //return await this.GetDatas($"{domain}file/list");
            using (var client = new HttpClient())
            {
                var resp = await client.GetAsync($"{domain}file/check");
                return await resp.Content.ReadAsStringAsync();
            }
        }

        public async Task<string> Login(string un, string pwd)
        {
            var postContent = new MultipartFormDataContent();
            string boundary = string.Format("--{0}", DateTime.Now.Ticks.ToString("x"));
            postContent.Headers.Add("ContentType", $"multipart/form-data, boundary={boundary}");
            postContent.Add(new StringContent(un), "username");
            postContent.Add(new StringContent(pwd), "pwd");

            using (var client = new HttpClient())
            {
                var resp = await client.PostAsync($"{domain}login/login", postContent);
                var data = await resp.Content.ReadAsStringAsync();
                return data;
            }
        }
    }
}
