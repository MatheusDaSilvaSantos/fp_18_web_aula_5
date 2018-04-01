using fp_web_aula_1_core.Models;
using fp_web_aula_1_core.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace fp_18_web_aula_1_api
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ILogerApi, LogerApi>();
            services.AddScoped<INoticiaService, NoticiaService>();

            var connection = @"Server=(localdb)\mssqllocaldb;Database=EFGetStarted.AspNetCore.NewDb2;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<CopaContext>
            (options => options.UseSqlServer(connection));

            services.AddMvc(
                o =>
                {
                    o.RespectBrowserAcceptHeader = true;
                    o.OutputFormatters.Add(new XmlSerializerOutputFormatter());
                });

            services.AddCors(x =>
            {
                x.AddPolicy("Default",
                builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod(); ;
                });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
            services.Configure<GzipCompressionProviderOptions>(
                o => o.Level = System.IO.Compression.CompressionLevel.Fastest);
            services.AddResponseCompression(o =>
            {
                o.Providers.Add<GzipCompressionProvider>();
            });
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });


            app.UseResponseCompression();

            app.UseCors("Default");

            app.UseMvc(r =>
           {
               r.MapRoute(
               name: "default",
               template: "{controller=Home}/{action=Index}/{id?}");
           });
        }
    }

}

