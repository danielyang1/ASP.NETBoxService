using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Crafty.Models;
using Microsoft.AspNet.Identity;
using System.Data.SqlClient;
using System.Configuration;

namespace Crafty.Controllers
{
    public class SurveyController : Controller
    {
        private RegisteredUserDBContext db = new RegisteredUserDBContext();
        private ApplicationDbContext adb = new ApplicationDbContext();


        // GET: Survey
        public ActionResult Index()
        {
            double numberOfTotalAccounts = adb.Users.Count();
            double numberOfPayingAccounts = db.Questions.Count();
            double numberOfHardLiquorAccounts = db.Questions.Where(h => h.box.boxName == "Hard Liquor Box").Count();
            double numberOfBeerAccounts = db.Questions.Where(b => b.box.boxName == "Beer Box").Count();

            double monthlyRevenue = db.Questions.Select(m => m.box.boxPrice).Sum();

            double percentHardLiqourAccounts = numberOfHardLiquorAccounts / numberOfTotalAccounts;
            double percentBeerAccounts = numberOfBeerAccounts / numberOfTotalAccounts;

            return View(db.Questions.ToList());
        }

        // GET: Survey/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey survey = db.Questions.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            return View(survey);
        }

        // GET: Survey/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Survey/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
       // [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "ID,question1,question2,question3,question4,question5,question6,question7,question8,sum")] Survey survey)
        {

            if (ModelState.IsValid)
            {
                survey.sum = survey.question2 + survey.question4 + survey.question6 + survey.question7 + survey.question8;

                survey.userID = User.Identity.GetUserId();

                var hasUserAlreadyTakenSurvey = db.Questions.Where(y => y.userID == survey.userID).FirstOrDefault();

                if (hasUserAlreadyTakenSurvey != null)
                {
                    db.Questions.RemoveRange(db.Questions.Where(v => v.userID == survey.userID));
                    db.SaveChanges();
                }
    
                //if user exists in survey database, delete user row

                //Determine product here

                // survey.productDemographic = survey.sum < 10 ? "Beer" : survey.sum < 20 ? "Wine" : "Liquor";

                //Box beerBox = new Box("Beer box", 35.00, new List<string>() { "Miller", "PBR", "312 Goose Island" }); //causes entity validation error
                //Box wineBox = new Box("Wine box", 42.00, new List<string>() { "some chardonay, some zinfadel, something else" });
                //Box liquorBox = new Box("Hard liqour box", 40.00, new List<string>() { "Grey Goose", "Bacardi 151", "Patron Silver" });

                Box beerBox = new Box();
                beerBox.boxName = "Beer Box";
                beerBox.boxPrice = 45.00;
                //beerBox.boxContents = new List<AlcoholProduct>() { new Lager("Sam Adams"), new IPA("Ninkasi Tricerahops Double IPA") };
                //beerBox.boxContents = new List<AlcoholProduct>() { new Beer("Miller Lite"), new Beer("PBR"), new Beer("GooseIsland") };
               // beerBox.boxContents = new List<string>(){ "Miller", "PBR", "Goose Island"};

              //  Box wineBox = new Box(); ***Delete No More Wine!!!!***
              //  wineBox.boxName = "Wine box";
              //  wineBox.boxPrice = 35.00;
              ////  wineBox.boxContents = new List<string>() { "some chardony", "some zinfandel", "something else" };

                Box hardLiquorBox = new Box();
                hardLiquorBox.boxName = "Hard Liquor Box";
                hardLiquorBox.boxPrice = 50.00;
                //hardLiquorBox.boxContents = new List<AlcoholProduct>() { new Vodka("Grey Goose"), new Rum("Bacardi 151"), new Tequila("Patron Silver") };
                //array of string names in box

                //survey.box = beerBox;

                survey.box = survey.sum < 30 ? beerBox : hardLiquorBox;
                survey.isSubscribed = false;

                if(survey.sum <30)
                {
                    switch (survey.question1)
                    {
                        case 1:
                            beerBox.boxContents = new List<AlcoholProduct>() { new IPA("Green Flash West Coast"), new IPA("Rebel Rouser IPA") };
                            survey.box = beerBox;
                            break;
                        case 2:
                            beerBox.boxContents = new List<AlcoholProduct>() { new Stout("Guinness Extra Stout"), new Stout("Breckenridge Stout") };
                            survey.box = beerBox;
                            break;
                        case 3:
                            beerBox.boxContents = new List<AlcoholProduct>() { new Lager("Bootlegger's Palomino Pale Ale"), new Lager("Samuel Adam's Botson Lager") };
                            survey.box = beerBox;
                            break;
                        case 4:
                            beerBox.boxContents = new List<AlcoholProduct>() { new Specialty("Hornsby’s Hard Cider"), new Specialty("Sprecher's Hard Root Beer") };
                            survey.box = beerBox;
                            break;
                    }
                }
                if (survey.sum >= 30)
                {
                    switch (survey.question5)
                    {
                        case 8:
                            hardLiquorBox.boxContents = new List<AlcoholProduct>() { new Rum("Bacardi 151"), new Rum("Captain Morgan") };
                            survey.box = hardLiquorBox;
                            break;
                        case 9:
                            hardLiquorBox.boxContents = new List<AlcoholProduct>() { new Tequila("Patron Silver"), new Tequila("Cabo Wabo") };
                            survey.box = hardLiquorBox;
                            break;
                        case 10:
                            hardLiquorBox.boxContents = new List<AlcoholProduct>() { new Vodka("Grey Goose"), new Vodka("Absolut") };
                            survey.box = hardLiquorBox;
                            break;
                    }
                }




                //int count = db.RegisteredUsers.Count(); Entity Framewor


                /*if (ModelState.IsValid)
                {
                db.SurveyResponses.Add(surveyModel);
                db.SaveChanges();
                // int y = surveyModel.Age;
                // db.SurveyResponses.Select(x => x).Where(x => x.Age < 21);
                return RedirectToAction("GetCurrentSurveyResults",survey);             //Joey's example to call method "GetCurrentSurveyResults" with parameter survey
                }

                return View(surveyModel);
                }*/

                // db.BoxModels.Add(survey.box);
                db.Questions.Add(survey);
                db.SaveChanges();
                //return RedirectToAction("Purchase", "Manage"); //this RUNS purchase() in manageController -- NOT what we want
                //return RedirectToRoute("Manage", "Purchase");
                return Redirect("~/Manage/Purchase");
            }

            return View(survey);
        }

        //in SurveyController? Add to database if purchase()

        // GET: Survey/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey survey = db.Questions.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            return View(survey);
        }

        // POST: Survey/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,question1,question2,question3,question4,question5,question6,question7,question8,sum")] Survey survey)
        {
            if (ModelState.IsValid)
            {
                db.Entry(survey).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(survey);
        }

        // GET: Survey/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey survey = db.Questions.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            return View(survey);
        }

        // POST: Survey/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Survey survey = db.Questions.Find(id);
            db.Questions.Remove(survey);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ThankYou(Survey survey)  // https://github.com/mcmadmac11/LastBoxRepo/blob/master/LastBox/Controllers/SurveyModelsController.cs
        {

            string userID = User.Identity.GetUserId();


            //var user = db.Questions.Where(y => y.userID == userID);
            //var user.isSubscribed = true;

            var user =
    (from c in db.Questions
     where c.userID == userID
     select c).First();

            user.isSubscribed = true;

            db.SaveChanges();

            //var
            //if (hasUserAlreadyTakenSurvey != null)
            //{
            //    product = db.Questions.Select(y => y).Where(u => u.userID == userID).Select(m => m.box.boxName).Single();
            //}
            //else product = null;
            ////return product;

            //survey.isSubscribed = true;
            //db.Questions.Add(survey);
            //db.SaveChanges();
            //  return Redirect("~/Home/");
            return View();
        }

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
