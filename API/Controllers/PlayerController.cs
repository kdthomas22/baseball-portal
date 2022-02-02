using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Queries;
using Domain.Models;
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
        public async Task<ActionResult<List<Player>>> GetPlayers()
        {
            var players = await _playerQueries.GetPlayerData(default);
            return Ok(players);
        }

        [HttpGet("{playerId}")]
        public async Task<ActionResult<Player>> GetPlayerById(int playerId)
        {
            var player = await _playerQueries.GetPlayerById(playerId, default);
            return Ok(player);
        }
    }
}