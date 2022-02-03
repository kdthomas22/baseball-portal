using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class PitcherStatsDto
    {
        public int Playerid { get; set; }
        public short Yearid { get; set; }
        public byte Levelid { get; set; }
        public short Teamid { get; set; }
        public short G { get; set; }
        public short B1 { get; set; }
        public short B2 { get; set; }
        public short B3 { get; set; }
        public short Hr { get; set; }
        public short Ubb { get; set; }
        public short So { get; set; }
        public short Ibb { get; set; }
        public short Outs { get; set; }
        public short Er { get; set; }
        public short Gs { get; set; }
        public short W { get; set; }
        public short L { get; set; }
        public short Sv { get; set; }
        public int Walks => Ibb + Ubb;
        public int Hits => B1 + B2 + B3 + Hr;
        public double Era => (Er * 27.0) / Outs;
        public double InningsPitched => (Outs / 3) + (Outs % 3) / 10.0;
    }
}

// Games, Games Started, Wins-Losses-Saves, Innings Pitched,  Hits, Strike Outs, Walks (intentional+unintentional), ERA 
