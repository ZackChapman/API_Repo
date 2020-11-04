using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TeamPlayerAPI.ViewModel;

namespace TeamPlayerAPI.Models
{
    public class TeamplayerDBContext : DbContext
    {
        //        public TeamplayerDBContext()
        //        {
        //        }

        //        public TeamplayerDBContext(DbContextOptions<TeamplayerDBContext> options)
        //            : base(options)
        //        {
        //        }

        //        public virtual DbSet<Player> Player { get; set; }
        //        public virtual DbSet<Team> Team { get; set; }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TeamplayerDB;Trusted_Connection=True");
        //            }
        //        }

        //        protected override void OnModelCreating(ModelBuilder modelBuilder)
        //        {
        //            modelBuilder.Entity<Player>(entity =>
        //            {
        //                entity.Property(e => e.Playerid).HasColumnName("PLAYERID");

        //                entity.Property(e => e.FirstName)
        //                    .HasMaxLength(50)
        //                    .IsUnicode(false);

        //                entity.Property(e => e.LastName)
        //                    .HasMaxLength(50)
        //                    .IsUnicode(false);

        //                entity.Property(e => e.Teamid).HasColumnName("TEAMID");

        //                entity.HasOne(d => d.Team)
        //                    .WithMany(p => p.Player)
        //                    .HasForeignKey(d => d.Teamid)
        //                    .HasConstraintName("FK__Player__TEAMID__25869641");
        //            });

        //            modelBuilder.Entity<Team>(entity =>
        //            {
        //                entity.Property(e => e.Teamid).HasColumnName("TEAMID");

        //                entity.Property(e => e.City)
        //                    .HasColumnName("CITY")
        //                    .HasMaxLength(255)
        //                    .IsUnicode(false);

        //                entity.Property(e => e.Teamname)
        //                    .HasColumnName("TEAMNAME")
        //                    .HasMaxLength(255)
        //                    .IsUnicode(false);
        //            });

        //            OnModelCreatingPartial(modelBuilder);
        //        }

        //        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        public TeamplayerDBContext(DbContextOptions<TeamplayerDBContext> options)
            : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<TeamPlayerAPI.ViewModel.TeamPlayerViewModel> TeamPlayerViewModel { get; set; }

    }
}
