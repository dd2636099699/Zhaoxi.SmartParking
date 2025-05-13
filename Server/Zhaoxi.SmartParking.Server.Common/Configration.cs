using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Zhaoxi.SmartParking.Server.ICommon;

namespace Zhaoxi.SmartParking.Server.Common
{
    public class Configration: ICommon.IConfiguration
    {
        private static IConfigurationRoot _iConfiguration;
        static Configration()
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");

            _iConfiguration = builder.Build();
        }


        public string Read(string key)
        {
            return _iConfiguration[key];
        }
    }
}
