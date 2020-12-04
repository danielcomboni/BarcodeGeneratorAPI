using System;
using System.IO;
using System.Reflection;
using BarcodeGeneratorAPI.Core.Helpers ;
using BarcodeGeneratorAPI.Services ;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;


namespace BarcodeGeneratorAPI.Core.Extensions
{
    public static class ConfigServiceExtension
    {
        public static IServiceCollection AddServicesConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var openApiInfo = configuration.OpenApiConfig();
            services.AddScoped<IGeneratorService, GeneratorService>();

            services.AddControllers();

            services.AddHealthChecks();

            #region Swagger Generator 
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(openApiInfo.Version, new OpenApiInfo
                {
                    Title = openApiInfo.Title,
                    Version = openApiInfo.Version,
                    License = new OpenApiLicense
                    {
                        Name = openApiInfo.License.Name,
                        Url = new Uri(openApiInfo.License.Url),
                    },
                    Description = openApiInfo.Description,
                    Contact = new OpenApiContact
                    {
                        Name = openApiInfo.Contact.Name,
                        Email = openApiInfo.Contact.Email,
                    },
                });

                services.AddSwaggerGenNewtonsoftSupport();

                // set comments path for swagger JSON and UI
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            #endregion

            return services;
        }
    }
}
