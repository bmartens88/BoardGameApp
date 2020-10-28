using BoardGameApp.Core.Application.Interfaces;
using BoardGameApp.Infrastructure.Persistence.Data;
using BoardGameApp.Infrastructure.Persistence.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BoardGameApp.Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<BoardGamesContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(BoardGamesContext).Assembly.FullName)))
                .AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>))
                .AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
