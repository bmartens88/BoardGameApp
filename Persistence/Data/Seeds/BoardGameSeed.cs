using BoardGameApp.Core.Domain.Entities;
using BoardGameApp.Infrastructure.Persistence.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BoardGameApp.Infrastructure.Persistence.Data.Seeds
{
    public static class BoardGameSeed
    {
        public static async Task SeedAsync(BoardGamesContext context)
        {
            var boardGame = new BoardGame
            {
                Title = "De Legenden van Andor",
                Description = "Spannend coöperatief bordspel voor het hele gezin. Verdedig Andor als tovenaar, dwerg, boogschutter of krijger tegen onder andere trollen en een oeroude draak. Vijf verschillende legenden leiden je stap voor stap door het verhaal en de spelregels!",
                MinPlayers = 2,
                MaxPlayers = 4,
                MinAge = 10,
                Price = 44.99m,
                PictureUri = "https://www.999games.nl/media/catalog/product/cache/59229511a255889d0a4402cca1d50739/D/e/De_Legenden_van_Andor.png",
                Publisher = new Publisher
                {
                    Name = "999 Games",
                    Description = "999 Games is een Nederlandse uitgever van bordspellen, kaartspellen en ruilkaartspellen. Het bedrijf ontstond in 1990 als postorderbedrijf."
                }
            };

            if (!await context.BoardGames.AnyAsync())
            {
                context.BoardGames.Add(boardGame);
                await context.SaveChangesAsync();
            }
        }
    }
}
