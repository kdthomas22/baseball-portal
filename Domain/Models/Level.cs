using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class Level
    {
        public byte Levelid { get; set; }
        public string Abbr { get; set; }
        public string Name { get; set; }
        public byte Sortorder { get; set; }
    }
}
