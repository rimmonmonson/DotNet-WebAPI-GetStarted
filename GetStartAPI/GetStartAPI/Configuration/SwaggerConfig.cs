using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace GetStartAPI
{
    public static class SwaggerConfig
    {
        /// <summary>
        /// Add Swagger middleware
        /// </summary>
        /// <remarks>
        /// Reference: https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-5.0&tabs=visual-studio
        /// </remarks>
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(Constants.Swagger.Version, new OpenApiInfo { Title = Constants.Swagger.ApiName,
                    Version = Constants.Swagger.Version,
                    Description = "Demo Application",
                    Contact = new OpenApiContact
                    {
                        Name = "MyName",
                        Email = string.Empty,
                        Url = new Uri("https://www.google.com/"),
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                if (File.Exists(xmlPath))
                {
                    c.IncludeXmlComments(xmlPath);
                }
            });

            return services;
        }
    }
}
