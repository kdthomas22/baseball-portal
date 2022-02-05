namespace Domain.Dtos
{
    public class StatsDto
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
        public short Ab { get; set; }
        public short Hbp { get; set; }
        public short Sf { get; set; }
        public int Position { get; set; }
        public bool isHitter => Position >= 2 && Position <= 10;
        public bool isPitcher => Position == 1 || Position == 11 || Position == 12;
        public bool zeroVal => Ab == 0 && Ubb == 0 && Ibb == 0 && Hbp == 0 && Sf == 0;
        public int OBP => isHitter && !zeroVal ? (B1 + B2 + B3 + Hr + Ubb + Ibb + Hbp) / (Ab + Ubb + Ibb + Hbp + Sf) : 0;
        public int SLG => isHitter && Ab != 0 ? (B1 + 2 * B2 + 3 * B3 + 4 * Hr) / Ab : 0;
        public int OPS => isHitter ? OBP + SLG : 0;
        public int Avg => isHitter && Ab != 0 ? B1 + B2 + B3 + Hr / Ab : 0;
        public int BB => Ibb + Ubb;
        public int Hits => B1 + B2 + B3 + Hr;
        public double Era => isPitcher && Outs != 0 ? (Er * 27.0) / Outs : 0;
        public double InningsPitched => isPitcher ? (Outs / 3) + (Outs % 3) / 10.0 : 0;
    }
}

