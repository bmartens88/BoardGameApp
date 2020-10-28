using System;
using System.Threading.Tasks;
using BoardGameApp.Infrastructure.Identity.Contexts;
using BoardGameApp.Infrastructure.Identity.Models;
using BoardGameApp.Infrastructure.Identity.Seeds;
using BoardGameApp.Infrastructure.Persistence.Data.Contexts;
using BoardGameApp.Infrastructure.Persistence.Data.Seeds;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BoardGameApp.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();
            try
            {
                var context = services.GetRequiredService<BoardGamesContext>();
                await context.Database.MigrateAsync(); // Applies any pending migration(s)
                await BoardGameSeed.SeedAsync(context);

                var identityContext = services.GetRequiredService<IdentityContext>();
                var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                await identityContext.Database.MigrateAsync(); // Applies any pending migration(s)
                await DefaultRoles.SeedAsync(roleManager);
                await DefaultAdmin.SeedAsync(userManager);
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "An error occured during migration");
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
