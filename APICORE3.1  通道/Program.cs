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
        {// ���� WEB����
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)// ���� WEB���� ʵ��
                .UseStartup<Startup>();// ���� WEB���� ����ʵ��
    }
}
