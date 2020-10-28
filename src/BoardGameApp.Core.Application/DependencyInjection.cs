using AutoMapper;
using BoardGameApp.Core.Application.Mapping;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BoardGameApp.Core.Application
{
    public static class DependencyInjection
    {
        public static void AddApplicationCore(this IServiceCollection services) =>
            services
                .AddMediatR(Assembly.GetExecutingAssembly())
                .AddAutoMapper(typeof(MappingProfile).Assembly);
    }
}
