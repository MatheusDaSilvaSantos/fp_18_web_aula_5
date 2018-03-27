using Microsoft.AspNetCore.Builder;

namespace fp_web_aula_1
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMeuMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MeuMiddleware>();
        }

    }
}
