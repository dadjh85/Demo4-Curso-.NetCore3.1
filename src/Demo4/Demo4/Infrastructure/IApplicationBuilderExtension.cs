using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Demo4.Infrastructure
{
    /// <summary>
    /// Personals extensions of object IApplicationBuilder
    /// </summary>
    public static class IApplicationBuilderExtension
    {
        /// <summary>
        /// Middleware for configurate swagger
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseSwagger(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Curso API-REST .NET Core 3.1 - Demo4");
                });
            }

            return app;
        }
    }
}
