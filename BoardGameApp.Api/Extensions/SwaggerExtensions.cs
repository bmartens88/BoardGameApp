using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace BoardGameApp.Api.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services) =>
            services.AddSwaggerGen(c =>
            {
                c.IncludeXmlComments(string.Format(@"{0}\BoardGameApp.Api.xml", System.AppDomain.CurrentDomain.BaseDirectory));
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Board Game Application API",
                    Description = "API for the Board Game Mobile/Web Application",
                    Contact = new OpenApiContact { 
                        Name = "Bas Martens",
                        Email = "bmartens@kembit.nl",
                        Url = new Uri("https://twitter.com/BasMartens1988")
                    }
                });
            });
    }
}
