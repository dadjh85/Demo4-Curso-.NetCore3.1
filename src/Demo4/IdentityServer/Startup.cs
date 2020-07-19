using IdentityServer4;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityServer().AddInMemoryIdentityResources(Config.Ids)
                                        .AddInMemoryApiResources(Config.Apis)
                                        .AddInMemoryClients(Config.Clients)
                                        .AddTestUsers(Config.Users)
                                        .AddDeveloperSigningCredential(false, null, IdentityServerConstants.RsaSigningAlgorithm.RS256);

            services.AddTransient<IProfileService, ProfileService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseIdentityServer();
        }
    }
}
