using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore;


namespace APICore
{
    public class Program
    {
        public static void Main(string[] args)
        {// 创建 WEB主机
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)// 创建 WEB主机 实例
                .UseStartup<Startup>();// 创建 WEB主机 开启实例
    }
}
