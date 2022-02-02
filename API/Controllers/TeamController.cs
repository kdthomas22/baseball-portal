using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Queries;
using Domain.Dtos;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamQueries _teamQueries;

        public TeamController(ITeamQueries teamQueries)
        {
            _teamQueries = teamQueries;
        }

        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<ActionResult<List<Team>>> GetTeams()
        {
            var teams = await _teamQueries.GetTeamData(default);
            return Ok(teams);
        }

        [HttpGet("{teamId}")]
        public async Task<ActionResult<TeamDto>> GetTeamDetails(short teamId)
        {
            var team = await _teamQueries.GetTeamDetails(teamId);
            return Ok(team);
        }
    }
}