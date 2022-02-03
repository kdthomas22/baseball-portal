using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Data;
using Domain.Dtos;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries
{
    public interface IPlayerQueries
    {
        Task<List<Player>> GetPlayerData(CancellationToken token);

        Task<PlayerDto> GetPlayerById(int playerId, CancellationToken token);

        Task<PitcherStatsDto> GetPitcherStats(int playerId);
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

        public async Task<PlayerDto> GetPlayerById(int playerId, CancellationToken token)
        {
            var player = await _context.Players.Select(p => new PlayerDto()
            {
                Playerid = p.Playerid,
                Bats = p.Bats,
                Birthcity = p.Birthcity,
                Birthcountry = p.Birthcountry,
                Birthdate = p.Birthdate,
                Birthstate = p.Birthstate,
                Firstname = p.Firstname,
                Headshoturl = p.Headshoturl,
                Height = p.Height,
                Lastname = p.Lastname,
                Number = p.Number,
                Position = p.Position,
                Throws = p.Throws,
                Usesname = p.Usesname,
                Weight = p.Weight,
                Team = _context.Teams.FirstOrDefault(t => t.Teamid == p.Teamid),

            }).FirstOrDefaultAsync();

            return player;
        }

        //TODO: TRY SWITCH STATEMENT FOR THIS
        public async Task<PitcherStatsDto> GetPitcherStats(int playerId)
        {
            var stats = await _context.Pstatsplayersseasonsbyteams.Select(p => new PitcherStatsDto()
            {
                Playerid = p.Playerid,
                Yearid = p.Yearid,
                B1 = p.B1,
                B2 = p.B2,
                B3 = p.B3,
                Er = p.Er,
                G = p.G,
                Gs = p.Gs,
                Hr = p.Hr,
                Ibb = p.Ibb,
                L = p.L,
                Levelid = p.Levelid,
                Outs = p.Outs,
                So = p.So,
                Sv = p.Sv,
                Teamid = p.Teamid,
                Ubb = p.Ubb,
                W = p.W
            }).Where(x => x.Yearid >= 2019 && x.Yearid <= 2021)
              .OrderBy(x => x.Yearid)
              .FirstOrDefaultAsync(x => x.Playerid == playerId);

            return stats;
        }
    }
}