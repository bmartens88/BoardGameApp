using BoardGameApp.Core.Application.Interfaces;
using BoardGameApp.Infrastructure.Shared.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace BoardGameApp.Infrastructure.Shared
{
    public static class DependencyInjection
    {
        public static void AddSharedInfrastructure(this IServiceCollection services) =>
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
    }
}
