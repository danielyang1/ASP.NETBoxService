using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Crafty.Models;

namespace Crafty.Controllers
{
    public class AdminsController : Controller
    {
        private RegisteredUserDBContext db = new RegisteredUserDBContext();
        private ApplicationDbContext adb = new ApplicationDbContext();

        // GET: Admins
        public ActionResult Index()
        {
            var model = new AdminModel
            {
                numberOfTotalAccounts = getNumberOfTotalAccounts(),
                numberOfPayingAccounts = getNumberOfPayingAccounts(),      //aaaaaaa what if complete survey but don't subscribe? have in survey a bool for whether paying or not? Workaround: Change button at bottom of survey page to say "subscribe"....
                numberOfHardLiquorAccounts = db.Questions.Where(h => h.box.boxName == "Hard liquor box").Count(),
                numberOfBeerAccounts = db.Questions.Where(b => b.box.boxName == "Beer box").Count(),

                monthlyRevenue = getMonthlyRevenue(),

                percentHardLiqourAccounts = db.Questions.Where(h => h.box.boxName == "Hard liquor box").Count() / getNumberOfPayingAccounts(),
                percentBeerAccounts = db.Questions.Where(b => b.box.boxName == "Beer box").Count() / getNumberOfPayingAccounts(),
                percentWineAccounts = db.Questions.Where(w => w.box.boxName == "Wine box").Count() / getNumberOfPayingAccounts(),
            };
            return View(model);
        }


        private double? getNumberOfTotalAccounts()
        {
            double? numberOfTotalAccounts;
            var isDatabaseEmpty = db.Questions.Select(y => y).FirstOrDefault();
            if (isDatabaseEmpty != null)
            {
                numberOfTotalAccounts = adb.Users.Count();
            }
            else numberOfTotalAccounts = 0;
            return numberOfTotalAccounts;
        }

        private double? getNumberOfPayingAccounts()
        {
            double? numberOfPayingAccounts;
            var isDatabaseEmpty = db.Questions.Select(y => y).FirstOrDefault();
            if (isDatabaseEmpty != null)
            {
                numberOfPayingAccounts = db.Questions.Count();
            }
            else numberOfPayingAccounts = 0;
            return numberOfPayingAccounts;
        }

        //private double? getNumberOfHardLiquorAccounts()
        //{
        //    double? numberOfHardLiquorAccounts;
        //    var anyBeerDrinkers = db.Questions.Where(b => b.box.boxName == "Beer box").Count();
        //    if(anyBeerDrinkers != null)
        //    {
        //        numberOfHardLiquorAccounts = db.Questions.Where(b => b.box.boxName == "Beer box").Count();
        //    }
        //    else numberOfHardLiquorAccounts = null;
        //    return numberOfHardLiquorAccounts;
        //}

        private double? getMonthlyRevenue()
        {
            double? monthlyRevenue;
            var anyRevenue = db.Questions.Select(m => m.box.boxPrice).FirstOrDefault();
            if (anyRevenue != 0)
            {
                monthlyRevenue = db.Questions.Select(m => m.box.boxPrice).Sum();
            }
            else monthlyRevenue = 0;
            return monthlyRevenue;
        }



        // GET: Admins/Details/5

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
