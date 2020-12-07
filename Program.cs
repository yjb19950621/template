using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace template
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
           WebHost.CreateDefaultBuilder(args)//ʹ��Ĭ�ϵ�������Ϣ����ʼ��һ���µ�IWebHostBuilderʵ��
           .ConfigureAppConfiguration((hostingContext, config) =>
           {
               var env = hostingContext.HostingEnvironment;

               config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                     .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                     .AddJsonFile("Content.json", optional: false, reloadOnChange: false)
                     .AddEnvironmentVariables();

           })
           .UseStartup<Startup>();// ΪWeb Hostָ����Startup��
    //    public static IHostBuilder CreateHostBuilder(string[] args) =>
    //Host.CreateDefaultBuilder(args)
    //    .ConfigureWebHostDefaults(webBuilder =>
    //    {
    //        webBuilder.UseStartup<Startup>();
    //    });
    }
}
