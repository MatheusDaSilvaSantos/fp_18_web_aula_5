using Microsoft.AspNetCore.Http;

namespace fp_web_aula_1_core.Services
{
    public interface ILogerApi
    {
        void Log(HttpContext context, long totalTime);
    }
}
