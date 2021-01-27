using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Purchase_Sell_Stock.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
      //发布程序出现错误帮助定位详细错误信息
      // .UseKestrel()
      //.UseContentRoot(Directory.GetCurrentDirectory())
      //.UseSetting("detailedErrors", "true")
      //.UseIISIntegration()

      .CaptureStartupErrors(true)
                .UseStartup<Startup>()
                .Build();
    }
}
