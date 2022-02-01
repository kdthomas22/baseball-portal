using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public partial class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Bstatsplayersseasonsbyteam> Bstatsplayersseasonsbyteams { get; set; }
        public virtual DbSet<League> Leagues { get; set; }
        public virtual DbSet<Level> Levels { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Playermetric> Playermetrics { get; set; }
        public virtual DbSet<Pstatsplayersseasonsbyteam> Pstatsplayersseasonsbyteams { get; set; }
        public virtual DbSet<Team> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:fxzjoebulw.database.windows.net,1433;Database=nya_example;User ID=nyyapplicant; Password=12345!abc;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Bstatsplayersseasonsbyteam>(entity =>
            {
                entity.HasKey(e => new { e.Playerid, e.Yearid, e.Levelid, e.Teamid })
                    .HasName("pk_bstatsplayersseasonsbyteam");

                entity.ToTable("bstatsplayersseasonsbyteam");

                entity.Property(e => e.Playerid).HasColumnName("playerid");

                entity.Property(e => e.Yearid).HasColumnName("yearid");

                entity.Property(e => e.Levelid).HasColumnName("levelid");

                entity.Property(e => e.Teamid).HasColumnName("teamid");

                entity.Property(e => e.Ab).HasColumnName("ab");

                entity.Property(e => e.B1).HasColumnName("b1");

                entity.Property(e => e.B2).HasColumnName("b2");

                entity.Property(e => e.B3).HasColumnName("b3");

                entity.Property(e => e.Ci).HasColumnName("ci");

                entity.Property(e => e.Cs).HasColumnName("cs");

                entity.Property(e => e.G).HasColumnName("g");

                entity.Property(e => e.Hbp).HasColumnName("hbp");

                entity.Property(e => e.Hr).HasColumnName("hr");

                entity.Property(e => e.Ibb).HasColumnName("ibb");

                entity.Property(e => e.Pa).HasColumnName("pa");

                entity.Property(e => e.R).HasColumnName("r");

                entity.Property(e => e.Rbi).HasColumnName("rbi");

                entity.Property(e => e.Sb).HasColumnName("sb");

                entity.Property(e => e.Sf).HasColumnName("sf");

                entity.Property(e => e.Sh).HasColumnName("sh");

                entity.Property(e => e.So).HasColumnName("so");

                entity.Property(e => e.Ubb).HasColumnName("ubb");
            });

            modelBuilder.Entity<League>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("leagues");

                entity.Property(e => e.Leagueid).HasColumnName("leagueid");

                entity.Property(e => e.Levelid).HasColumnName("levelid");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Level>(entity =>
            {
                entity.ToTable("levels");

                entity.Property(e => e.Levelid).HasColumnName("levelid");

                entity.Property(e => e.Abbr)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("abbr")
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Sortorder).HasColumnName("sortorder");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("players");

                entity.Property(e => e.Playerid)
                    .ValueGeneratedNever()
                    .HasColumnName("playerid");

                entity.Property(e => e.Bats).HasColumnName("bats");

                entity.Property(e => e.Birthcity)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("birthcity");

                entity.Property(e => e.Birthcountry)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("birthcountry");

                entity.Property(e => e.Birthdate)
                    .HasColumnType("datetime")
                    .HasColumnName("birthdate");

                entity.Property(e => e.Birthstate)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("birthstate");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("firstname");

                entity.Property(e => e.Headshoturl)
                    .HasMaxLength(59)
                    .IsUnicode(false)
                    .HasColumnName("headshoturl");

                entity.Property(e => e.Height).HasColumnName("height");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("lastname");

                entity.Property(e => e.Number).HasColumnName("number");

                entity.Property(e => e.Position).HasColumnName("position");

                entity.Property(e => e.Teamid).HasColumnName("teamid");

                entity.Property(e => e.Throws).HasColumnName("throws");

                entity.Property(e => e.Usesname)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("usesname");

                entity.Property(e => e.Weight).HasColumnName("weight");
            });

            modelBuilder.Entity<Playermetric>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("playermetrics");

                entity.Property(e => e.Batterid).HasColumnName("batterid");

                entity.Property(e => e.HitVelocity)
                    .HasColumnType("decimal(6, 3)")
                    .HasColumnName("hit_velocity");

                entity.Property(e => e.HitVerticalAngle)
                    .HasColumnType("decimal(6, 3)")
                    .HasColumnName("hit_vertical_angle");

                entity.Property(e => e.PitchResult)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("pitch_result");

                entity.Property(e => e.PitchType)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("pitch_type");

                entity.Property(e => e.PitchVelocity)
                    .HasColumnType("decimal(6, 3)")
                    .HasColumnName("pitch_velocity");

                entity.Property(e => e.Pitcherid).HasColumnName("pitcherid");

                entity.Property(e => e.Platex)
                    .HasColumnType("decimal(6, 3)")
                    .HasColumnName("platex");

                entity.Property(e => e.Platey)
                    .HasColumnType("decimal(6, 3)")
                    .HasColumnName("platey");
            });

            modelBuilder.Entity<Pstatsplayersseasonsbyteam>(entity =>
            {
                entity.HasKey(e => new { e.Playerid, e.Yearid, e.Levelid, e.Teamid })
                    .HasName("pk_pstatsplayersseasonsbyteam");

                entity.ToTable("pstatsplayersseasonsbyteam");

                entity.Property(e => e.Playerid).HasColumnName("playerid");

                entity.Property(e => e.Yearid).HasColumnName("yearid");

                entity.Property(e => e.Levelid).HasColumnName("levelid");

                entity.Property(e => e.Teamid).HasColumnName("teamid");

                entity.Property(e => e.Ab).HasColumnName("ab");

                entity.Property(e => e.B1).HasColumnName("b1");

                entity.Property(e => e.B2).HasColumnName("b2");

                entity.Property(e => e.B3).HasColumnName("b3");

                entity.Property(e => e.Cg).HasColumnName("cg");

                entity.Property(e => e.Er).HasColumnName("er");

                entity.Property(e => e.G).HasColumnName("g");

                entity.Property(e => e.Gf).HasColumnName("gf");

                entity.Property(e => e.Gs).HasColumnName("gs");

                entity.Property(e => e.Hbp).HasColumnName("hbp");

                entity.Property(e => e.Hr).HasColumnName("hr");

                entity.Property(e => e.Ibb).HasColumnName("ibb");

                entity.Property(e => e.L).HasColumnName("l");

                entity.Property(e => e.Outs).HasColumnName("outs");

                entity.Property(e => e.Pa).HasColumnName("pa");

                entity.Property(e => e.R).HasColumnName("r");

                entity.Property(e => e.Sf).HasColumnName("sf");

                entity.Property(e => e.Sh).HasColumnName("sh");

                entity.Property(e => e.Sho).HasColumnName("sho");

                entity.Property(e => e.So).HasColumnName("so");

                entity.Property(e => e.Sv).HasColumnName("sv");

                entity.Property(e => e.Ubb).HasColumnName("ubb");

                entity.Property(e => e.W).HasColumnName("w");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("teams");

                entity.Property(e => e.Teamid)
                    .ValueGeneratedNever()
                    .HasColumnName("teamid");

                entity.Property(e => e.Abbr)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("abbr");

                entity.Property(e => e.City)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Leagueid).HasColumnName("leagueid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
