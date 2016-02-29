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

            //commit: changed adminsController query functions

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

            //CANCEL SUBSCRIPTION OPTION?

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

                Box beerBox = new Box();
                beerBox.boxName = "Beer Box";
                beerBox.boxPrice = 45.00;

                Box hardLiquorBox = new Box();
                hardLiquorBox.boxName = "Hard Liquor Box";
                hardLiquorBox.boxPrice = 50.00;

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
                            beerBox.boxContents = new List<AlcoholProduct>() { new Lager("Pre-Prohibition Style Lager"), new Lager("Samuel Adam's Botson Lager") };
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

                db.Questions.Add(survey);
                db.SaveChanges();
                return Redirect("~/Manage/Purchase");
            }

            return View(survey);
        }

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
            var user = db.Questions.Where(c => c.userID == userID).Select(c => c).First();
            user.isSubscribed = true;

            db.SaveChanges();
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
