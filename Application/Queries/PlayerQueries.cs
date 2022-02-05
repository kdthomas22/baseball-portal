using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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
    public interface IPlayerQueries
    {
        Task<List<Player>> GetPlayerData(CancellationToken token);

        Task<PlayerDto> GetPlayerById(int playerId, CancellationToken token);

        Task<List<StatsDto>> GetPlayerStats(int playerId);
    }
    public class PLayerQueries : IPlayerQueries
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public PLayerQueries(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
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
            }).FirstOrDefaultAsync(x => x.Playerid == playerId);

            return player;
        }

        public async Task<List<StatsDto>> GetPlayerStats(int playerId)
        {
            var player = _context.Players.FirstOrDefault(x => x.Playerid == playerId);
            var stats = await _context.Bstatsplayersseasonsbyteams.Select(p => new StatsDto()
            {
                Playerid = p.Playerid,
                Yearid = p.Yearid,
                B1 = p.B1,
                B2 = p.B2,
                B3 = p.B3,
                G = p.G,
                Hr = p.Hr,
                Ibb = p.Ibb,
                Levelid = p.Levelid,
                So = p.So,
                Teamid = p.Teamid,
                Ubb = p.Ubb,
                Position = player.Position
            }).Where(x => x.Yearid >= 2019 && x.Yearid <= 2021)
              .OrderBy(x => x.Yearid)
              .ToListAsync();

            return stats;
        }
    }
}