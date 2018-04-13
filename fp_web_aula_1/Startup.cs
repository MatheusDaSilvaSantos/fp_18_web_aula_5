using fp_18_web_aula_1_core.Services;
using fp_web_aula_1.Controllers;
using fp_web_aula_1_core.Models;
using fp_web_aula_1_core.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using System.Collections.Generic;
using System.Text;

namespace fp_web_aula_1
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IChaveService, ChaveService>();
            services.AddScoped<INoticiaService, NoticiaService>();


            services.AddTransient<ILogerApi, LogerApi>();
            //services.AddScoped<ILogerApi, LogerApi>();
            //services.AddSingleton<ILogerApi, LogerApi>();

            var connection = @"Server=(localdb)\mssqllocaldb;Database=EFGetStarted.AspNetCore.NewDb2;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<CopaContext>
                (options => options.UseSqlServer(connection));

            services.AddMemoryCache();

            services.AddMvc();

            services.Configure<GzipCompressionProviderOptions>(
              o => o.Level = System.IO.Compression.CompressionLevel.Fastest);

            services.AddResponseCompression(o =>
            {
                o.Providers.Add<GzipCompressionProvider>();
            });

            services.AddAuthentication("app")
                .AddCookie("app",
                o =>
                {
                    o.LoginPath = "/account/index";
                    o.AccessDeniedPath = "/account/denied";
                });

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

            app.UseResponseCompression();

            //app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    const int durationInSeconds = 60 * 60 * 24;
                    ctx.Context.Response.Headers[HeaderNames.CacheControl] =
                        "public,max-age=" + durationInSeconds;
                }
            });

            app.UseAuthentication();

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
