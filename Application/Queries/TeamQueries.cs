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

        Task<Team> GetTeamById(short teamId, CancellationToken token);

        Task<List<TeamDto>> GetRoster(CancellationToken token);
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

        public async Task<Team> GetTeamById(short teamId, CancellationToken token)
        {
            var query = await _context.Teams.FindAsync(teamId);
            return query;
        }

        public async Task<List<TeamDto>> GetRoster(CancellationToken token)
        {
            var team = await _context.Teams
                                .ProjectTo<TeamDto>(_mapper.ConfigurationProvider)
                                .ToListAsync();

            return team;
        }
    }
}