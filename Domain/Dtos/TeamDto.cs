using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Dtos
{
    public class TeamDto
    {
        public short Teamid { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public string Abbr { get; set; }
        public short? Leagueid { get; set; }
        public List<Player> Players { get; set; }
    }
}