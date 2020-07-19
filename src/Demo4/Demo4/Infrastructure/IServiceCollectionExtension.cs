using Demo4.Infrastructure.MapperOptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace Demo4.Infrastructure
{
    /// <summary>
    /// Extensíon class with the services IServiceCollection
    /// </summary>
    public static class IServiceCollectionExtension
    {
        /// <summary>
        /// Service that load de security configuration with identityserver
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddSecurity(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SecurityOptions>(configuration.GetSection("Security"));
            SecurityOptions securityClients = new SecurityOptions();
            configuration.GetSection("Security").Bind(securityClients);

            services.AddAuthentication("Bearer")
                    .AddIdentityServerAuthentication("Bearer", options =>
                    {
                        options.Authority = securityClients.Authority;
                        options.RequireHttpsMetadata = securityClients.RequireHttpsMetadata;
                        options.ApiName = securityClients.ApiName; 
                    });

            services.AddAuthorization(options => options.AddPolicy("AdminAndUser", policy => policy.RequireRole("administrator", "user")));

            return services;
        }

        /// <summary>
        /// Configure Cors of app
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <param name="corsPolicyName"></param>
        /// <returns></returns>
        public static IServiceCollection AddCorsPolicy(this IServiceCollection services, IConfiguration configuration, string corsPolicyName)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(corsPolicyName,
                                  builder => builder.AllowAnyOrigin()
                                                    .AllowAnyMethod()
                                                    .AllowAnyHeader());
            });

            //services.AddCors(options =>
            //{
            //    options.AddPolicy(corsPolicyName, policy =>
            //    {
            //        string[] origin = configuration.GetSection("AllowedHosts").Get<string[]>();
            //        policy.WithOrigins(origin).AllowAnyHeader()
            //                                  .AllowAnyMethod();
            //    });
            //});

            return services;
        }

        /// <summary>
        /// Service that loads the swagger configuration 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                string xmlFile = "Demo4.XML";
                string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Curso API-REST .NET Core", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                   {
                     new OpenApiSecurityScheme
                     {
                       Reference = new OpenApiReference
                       {
                         Type = ReferenceType.SecurityScheme,
                         Id = "Bearer"
                       }
                      },
                      new string[] { }
                    }
                });

                c.CustomSchemaIds(x => x.FullName);

            });

            return services;
        }
    }
}
