using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class Playermetric
    {
        public int Pitcherid { get; set; }
        public int Batterid { get; set; }
        public string PitchResult { get; set; }
        public string PitchType { get; set; }
        public decimal? PitchVelocity { get; set; }
        public decimal? Platex { get; set; }
        public decimal? Platey { get; set; }
        public decimal? HitVelocity { get; set; }
        public decimal? HitVerticalAngle { get; set; }
    }
}
