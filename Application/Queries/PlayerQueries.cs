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
    public interface IPlayerQueries
    {
        Task<List<Player>> GetPlayerData(CancellationToken token);

        Task<Player> GetPlayerById(int playerId, CancellationToken token);
    }
    public class PLayerQueries : IPlayerQueries
    {
        private readonly DataContext _context;
        public PLayerQueries(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Player>> GetPlayerData(CancellationToken token)
        {
            var query = await _context.Players.ToListAsync(default);
            return query;
        }

        public async Task<Player> GetPlayerById(int playerId, CancellationToken token)
        {
            var query = await _context.Players.FindAsync(playerId);
            return query;
        }
    }
}