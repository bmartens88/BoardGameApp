using BoardGameApp.Core.Application.DTO.BoardGame;
using BoardGameApp.Core.Application.Features.BoardGame.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoardGameApp.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class BoardGamesController : ApiBaseController
    {
        /// <summary>
        /// Get all the board games in the system
        /// </summary>
        /// <returns>All board games in the system</returns>
        /// <response code="200">Returns all board games in the system</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<BoardGameDTO>>> GetAllBoardGames()
        {
            var result = await Mediator.Send(new GetAllBoardGamesQuery());
            return Ok(result);
        }
    }
}
