using Demo4.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service.UserService;

//[assembly: ApiController]
[assembly: ApiConventionType(typeof(DefaultApiConventions))]
namespace Demo4
{
    /// <summary>
    /// Startup class for init .NET Core
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Constructor of startup
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Object of load the personal configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// dependency injection container of .NET Core
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwagger();
            services.AddControllers();
            services.AddScoped<IUserService, UserService>();
            services.AddLogging();
            services.AddSecurity(Configuration);
            services.AddAuthorization();
        }


        /// <summary>
        /// pipeline of netcore
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger(env);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "areaRoute",
                                            pattern: "{area:exists}/{controller}/{action}",
                                            defaults: new { action = "Index" });

                endpoints.MapControllerRoute(name: "default",
                                             pattern: "{controller}/{action}/{id?}",
                                             defaults: new { controller = "Home", action = "Index" });

                endpoints.MapControllerRoute(name: "api",
                                             pattern: "{controller}/{id?}");

                //endpoints.MapControllers()
                         //.RequireAuthorization(new AuthorizeAttribute());
            });
        }
    }
}
