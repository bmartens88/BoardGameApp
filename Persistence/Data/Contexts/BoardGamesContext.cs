using BoardGameApp.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BoardGameApp.Infrastructure.Persistence.Data.Contexts
{
    public class BoardGamesContext : DbContext
    {
        public BoardGamesContext(DbContextOptions<BoardGamesContext> options) : base(options) { }

        public DbSet<BoardGame> BoardGames { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
