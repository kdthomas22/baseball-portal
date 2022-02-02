using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data;
using Domain.Dtos;
using Domain.Models;

namespace Application.Mapping
{
    public class MappingProfile : Profile
    {
        private readonly DataContext _context;
        public MappingProfile(DataContext context)
        {
            _context = context;
        }

        public MappingProfile()
        {
            CreateMap<Team, TeamDto>()
                .ForMember(d => d.Players, o => o.MapFrom(s => _context.Players.Where(p => p.Teamid == s.Teamid)));
        }
    }
}