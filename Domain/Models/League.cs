using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class League
    {
        public short? Leagueid { get; set; }
        public string Name { get; set; }
        public byte? Levelid { get; set; }
    }
}
