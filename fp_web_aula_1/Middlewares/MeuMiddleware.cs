using fp_web_aula_1_core.Services;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Threading.Tasks;

namespace fp_web_aula_1
{
    public class MeuMiddleware
    {
        private readonly ILogerApi _loggerApi;
        private readonly RequestDelegate _next;
        private Stopwatch inicio { get; set; }

        public MeuMiddleware(RequestDelegate next)
        {
            _loggerApi = new LogerApi();
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {

            inicio = Stopwatch.StartNew();// = DateTime.Now; 
            //logica do middleware
            await _next(httpContext);
            //login do fim do middleware aqui
            inicio.Stop();

            var final = inicio.ElapsedMilliseconds;// DateTime.Now.Subtract(inicio).TotalMilliseconds;
            _loggerApi.Log(httpContext, final);
        }

    }
}
