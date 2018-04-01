using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;

namespace fp_18_web_aula_1_api
{
    class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
