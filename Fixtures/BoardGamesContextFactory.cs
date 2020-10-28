using BoardGameApp.Infrastructure.Persistence.Data.Contexts;
using Fixtures.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace Fixtures
{
    public class BoardGamesContextFactory
    {
        public readonly BoardGamesContext ContextInstance;

        public BoardGamesContextFactory()
        {
            var contextOptions = new DbContextOptionsBuilder<BoardGamesContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()
                .Options;
            EnsureCreated(contextOptions);
            ContextInstance = new BoardGamesContext(contextOptions);

            // Seed data
            ContextInstance.BoardGames.Add(BoardGames.DEFAULT_BOARDGAME);
            ContextInstance.SaveChanges();
        }

        private void EnsureCreated(DbContextOptions<BoardGamesContext> options)
        {
            using var context = new BoardGamesContext(options);
            context.Database.EnsureCreated();
        }
    }
}
