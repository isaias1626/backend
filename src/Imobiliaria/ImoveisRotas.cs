using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace ApiCrud.Imobiliarias
{
    public static class ImoveisRotas
    {
        public static void AddRotasImobiliarias(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/imobiliaria", async context =>
                {
                    await context.Response.WriteAsync("Endpoint para imobiliárias");
                });
            });
        }
    }
}
