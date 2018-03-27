using fp_web_aula_1.Controllers;
using fp_web_aula_1_core.Models;
using fp_web_aula_1_core.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Text;

namespace fp_web_aula_1
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ILogerApi, LogerApi>();
            //services.AddScoped<ILogerApi, LogerApi>();
            services.AddScoped<INoticiaService, NoticiaService>();
            //services.AddSingleton<ILogerApi, LogerApi>();

            var connection =  @"Server=(localdb)\mssqllocaldb;Database=EFGetStarted.AspNetCore.NewDb2;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<CopaContext>
                (options => options.UseSqlServer(connection));


            services.AddMvc();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            //app.Use(async (context, next) =>
            // {
            //     var a = 123;
            //     await next.Invoke();
            //     var b = 123;
            // });
            // app.Use(async (context, next) =>
            // {
            //     await next.Invoke();
            // });
            // app.Run(async context =>
            // {
            //     await context.Response.WriteAsync("Hello from 3nd delegate.");
            // });

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            // app.UseMiddleware<MeuMiddleware>();
            app.UseMeuMiddleware();

            app.UseStaticFiles();

            app.UseMvc(r =>
            {
                //r.MapRoute(
                //name: "palestrantes",
                //template: "trilha/{nomedatrilha}",
                //defaults: new { controller = "Home", action = "listarpalestrantes" });

                r.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
