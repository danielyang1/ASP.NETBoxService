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
                numberOfPayingAccounts = getNumberOfPayingAccounts(),

                numberOfHardLiquorAccounts = db.Questions.Where(h => h.isSubscribed == true).Where(a => a.box.boxName == "Hard Liquor Box").Count(),
                numberOfBeerAccounts = db.Questions.Where(b => b.isSubscribed == true).Where(n => n.box.boxName == "Beer Box").Count(),

                monthlyRevenue = getMonthlyRevenue(),

                percentHardLiqourAccounts = (db.Questions.Where(h => h.isSubscribed == true).Where(a => a.box.boxName == "Hard Liquor Box").Count() / getNumberOfPayingAccounts()) * 100,
                percentBeerAccounts = (db.Questions.Where(b => b.isSubscribed == true).Where(n => n.box.boxName == "Beer Box").Count() / getNumberOfPayingAccounts()) * 100,
            };
            return View(model);
        }


        private double? getNumberOfTotalAccounts()        //should this count include admin? if no, then -1
        {
            double? numberOfTotalAccounts = 0;
            var isDatabaseEmpty = adb.Users.Select(y => y).FirstOrDefault();
            if (isDatabaseEmpty != null)
            {
                numberOfTotalAccounts = adb.Users.Count();
            }
            return numberOfTotalAccounts;
        }

        private double? getNumberOfPayingAccounts()     
        {
            double? numberOfPayingAccounts = 0;
            var isDatabaseEmpty = db.Questions.Select(y => y).FirstOrDefault();
            if (isDatabaseEmpty != null)
            {
                numberOfPayingAccounts = db.Questions.Select(y => y).Where(c => c.isSubscribed == true).Count();
            }
            return numberOfPayingAccounts;
        }

        private double? getMonthlyRevenue()
        {
            double? monthlyRevenue = 0;
            var anyRevenue = db.Questions.Select(m => m.box.boxPrice).FirstOrDefault();
            if (anyRevenue != 0)
            {
                var mr = db.Questions.Where(n => n.isSubscribed == true).Select(m => (double?)m.box.boxPrice).FirstOrDefault();
                if (mr != null)
                {
                    monthlyRevenue = db.Questions.Where(n => n.isSubscribed == true).Select(m => m.box.boxPrice).Sum();

                }
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
