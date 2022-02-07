using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Queries;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    public class PlayerController : Controller
    {
        private readonly IPlayerQueries _playerQueries;

        public PlayerController(IPlayerQueries playerQueries)
        {
            _playerQueries = playerQueries;
        }

        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<ActionResult<List<PlayerDto>>> GetPlayers()
        {
            var players = await _playerQueries.GetPlayerData(default);
            return Ok(players);
        }

        [HttpGet("{playerId}")]
        public async Task<ActionResult<PlayerDto>> GetPlayerById(int playerId)
        {
            var player = await _playerQueries.GetPlayerById(playerId, default);
            return Ok(player);
        }

        [HttpGet("stats/{playerId}/{yearId}")]
        public async Task<ActionResult<StatsDto>> GetStats(int playerId, int yearId)
        {
            var stats = await _playerQueries.GetPlayerStats(playerId, yearId, default);
            return Ok(stats);
        }

        [HttpGet("paginated")]
        public async Task<ActionResult<PlayerDto>> GetPaginated([FromQuery] int pageIndex = 0, [FromQuery] int pageSize = 10)
        {
            var players = await _playerQueries.GetPaginatedPlayers(pageIndex, pageSize, default);
            return Ok(players);
        }
    }
}