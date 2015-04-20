using Cricket.DAL;
using Cricket.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace Cricket.Controllers
{
    public class HomeController : Controller
    {
        private CricketContext db = new CricketContext();
        
        public ActionResult Index()
        {
            ViewBag.Message = "Conditions Apply";
            var md = from t in db.Schedules
                     where t.MatchDate.Year == DateTime.Now.Year
                        && t.MatchDate.Month == DateTime.Now.Month
                        && t.MatchDate.Day == DateTime.Now.Day
                     select t;
            ViewBag.MatchDetails = md.FirstOrDefault().HomeTeam.TeamName + " Vs " + md.FirstOrDefault().GuestTeam.TeamName;

            //Users can place new bets if current time is more than ONE Hours of scheduled Match start time
            ViewBag.CanPlaceNewBet = DateTime.Now < md.FirstOrDefault().MatchTime.AddHours(-1);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "This site is for fun only.. ";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public void PlaceNewBet(int betAmount)
        {
            //Check if user already placed bet or not. If placed, then get Bet details
            var userBet = db.UserBets.Where(u => u.UserId == WebSecurity.GetUserId(User.Identity.Name)).ToList().FirstOrDefault();
            if (userBet != null)
            {
                userBet.BetAmount = betAmount;
                userBet.BetOnDate = DateTime.Now;

                db.SaveChanges();
            }
            //update bet amount for logged-in user            
            else
            {
                var md = from t in db.Schedules
                         where t.MatchDate.Year == DateTime.Now.Year
                            && t.MatchDate.Month == DateTime.Now.Month
                            && t.MatchDate.Day == DateTime.Now.Day
                         select t;

                db.UserBets.Add(new UserBet() { 
                    UserId = WebSecurity.GetUserId(User.Identity.Name),
                    ScheduleId = md.FirstOrDefault().ScheduleId,
                    BetAmount = betAmount,
                    BetOnDate = DateTime.Now
                });

                db.SaveChanges();
            }
            //save changes
        }
    }
}
