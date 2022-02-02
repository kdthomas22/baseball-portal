using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Data;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries
{
    public interface ITeamQueries
    {
        Task<List<Team>> GetTeamData(CancellationToken token);

        Task<Team> GetTeamById(short teamId, CancellationToken token);
    }
    public class TeamQueries : ITeamQueries
    {
        private readonly DataContext _context;
        public TeamQueries(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Team>> GetTeamData(CancellationToken token)
        {
            var query = await _context.Teams.ToListAsync(default);
            return query;
        }

        public async Task<Team> GetTeamById(short teamId, CancellationToken token)
        {
            var query = await _context.Teams.FindAsync(teamId);
            return query;
        }
    }
}