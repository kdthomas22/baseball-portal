using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data;
using Domain.Dtos;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries
{
    public interface ITeamQueries
    {
        Task<List<Team>> GetTeamData(CancellationToken token);

        Task<TeamDto> GetTeamDetails(short teamId);
    }
    public class TeamQueries : ITeamQueries
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public TeamQueries(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Team>> GetTeamData(CancellationToken token)
        {
            var query = await _context.Teams
                                .ToListAsync(default);
            return query;
        }

        public async Task<TeamDto> GetTeamDetails(short teamId)
        {
            var players = _context.Players.AsEnumerable();
            var team = await _context.Teams.Select(t =>
                                new TeamDto()
                                {
                                    Teamid = t.Teamid,
                                    Abbr = t.Abbr,
                                    City = t.City,
                                    Leagueid = t.Leagueid,
                                    Name = t.Name,
                                    Players = (List<Player>)players.Where(p => p.Teamid == t.Teamid).AsEnumerable()
                                }
                                ).FirstOrDefaultAsync(x => x.Teamid == teamId);

            return team;
        }
    }
}