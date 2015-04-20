using Cricket.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Cricket.DAL
{
    public class CricketContext : DbContext
    {
        public CricketContext()
            : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Schedule>()
                    .HasRequired(m => m.HomeTeam)
                    .WithMany(t => t.HomeMatches)
                    .HasForeignKey(m => m.HomeTeamId)
                    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Schedule>()
                        .HasRequired(m => m.GuestTeam)
                        .WithMany(t => t.AwayMatches)
                        .HasForeignKey(m => m.GuestTeamId)
                        .WillCascadeOnDelete(false);
        }
                
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserBet> UserBets { get; set; }
    }
}