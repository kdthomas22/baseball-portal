using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class Team
    {
        public short Teamid { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public string Abbr { get; set; }
        public short? Leagueid { get; set; }
    }
}
