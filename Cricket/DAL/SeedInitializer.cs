using Cricket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cricket.DAL
{
    public class SeedInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<CricketContext>
    {
        protected override void Seed(CricketContext context)
        {
            #region Tournament Details
            context.Tournaments.Add(new Tournament()
                {
                    TournamentName = "IPL 2015",
                    StartDate = DateTime.Parse("08-April-2015"),
                    EndDate = DateTime.Parse("24-May-2015")
                });

            context.SaveChanges(); 
            #endregion

            #region Teams

            context.Teams.Add(new Team() { TournamentId = 1, TeamName = "Mumbai Indians" });            //1
            context.Teams.Add(new Team() { TournamentId = 1, TeamName = "Delhi Daredevils" });          //2
            context.Teams.Add(new Team() { TournamentId = 1, TeamName = "Chennai Super Kings" });       //3
            context.Teams.Add(new Team() { TournamentId = 1, TeamName = "Kolkata Knight Riders" });     //4
            context.Teams.Add(new Team() { TournamentId = 1, TeamName = "Rajasthan Royals" });          //5
            context.Teams.Add(new Team() { TournamentId = 1, TeamName = "Kings XI Punjab" });           //6
            context.Teams.Add(new Team() { TournamentId = 1, TeamName = "Royal Challengers Bangalore" });//7
            context.Teams.Add(new Team() { TournamentId = 1, TeamName = "Sunrisers Hyderabad" });       //8

            context.SaveChanges();

            #endregion

            #region Schedule

            context.Schedules.Add(new Schedule() { TournamentId = 1, MatchDate = DateTime.Parse("08-April-2015 20:00"), MatchTime = DateTime.Parse("08-April-2015 20:00"), HomeTeamId = 4, GuestTeamId = 1, Ground = "Eden Gardens", City = "Kolkata" });
            context.Schedules.Add(new Schedule() { TournamentId = 1, MatchDate = DateTime.Parse("17-April-2015 20:00"), MatchTime = DateTime.Parse("17-April-2015 20:00"), HomeTeamId = 1, GuestTeamId = 3, Ground = "Wankhede Stadium", City = "Mumbai" });

            context.SaveChanges();
            #endregion
        }
    }
}