using System;
using Domain.Models;

namespace Domain.Dtos
{
    public class PlayerDto
    {
        public int Playerid { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Usesname { get; set; }
        public byte Bats { get; set; }
        public byte Throws { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Birthcity { get; set; }
        public string Birthcountry { get; set; }
        public string Birthstate { get; set; }
        public byte? Height { get; set; }
        public short? Weight { get; set; }
        public byte Position { get; set; }
        public byte? Number { get; set; }
        public string Headshoturl { get; set; }
        public Team Team { get; set; }
        public Pstatsplayersseasonsbyteam Stats { get; set; }
    }
}