﻿using System;
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


        private double? getNumberOfTotalAccounts()        //THIS SHOULD NOT INCLUDE ADMIN?
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
                numberOfPayingAccounts = db.Questions.Select(y => y).Where(c => c.isSubscribed == true).Count();
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
            var anyRevenue = db.Questions.Select(m => m.box.boxPrice).FirstOrDefault();       //AND isSubscribed = true;
            if (anyRevenue != 0)
            {
                monthlyRevenue = db.Questions.Where(n => n.isSubscribed == true).Select(m => m.box.boxPrice).Sum();
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
