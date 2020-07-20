using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Hosting;
using System.Globalization;

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

        /// <summary>
        /// Add cultures in app
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseInternationalLocalization(this IApplicationBuilder app)
        {
            var suporrtedCultures = new[]
            {
                new CultureInfo("en-US"),
                new CultureInfo("es-Es")
            };
            var locOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("es-Es"),
                SupportedCultures = suporrtedCultures,
                SupportedUICultures = suporrtedCultures
            };

            app.UseRequestLocalization(locOptions);
            return app;
        }
    }
}
