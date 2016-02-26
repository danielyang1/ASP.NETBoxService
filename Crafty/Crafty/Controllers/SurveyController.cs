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

        // GET: Survey
        public ActionResult Index()
        {
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
                survey.sum = survey.question1 + survey.question2 + survey.question3 + survey.question4 + survey.question5 + survey.question6 + survey.question7 + survey.question8;

                survey.userID = User.Identity.GetUserId();

                var hasUserAlreadyTakenSurvey = db.Questions.Where(y => y.userID == survey.userID).FirstOrDefault();

                if (hasUserAlreadyTakenSurvey != null)
                {
                    db.Questions.RemoveRange(db.Questions.Where(v => v.userID == survey.userID));
                    db.SaveChanges();
                }





                //if user exists in survey database, delete user row

                //1234 rebuild database after lunch

                //using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()))            //SQL connection; this kind of works
                //{
                //    // string query = "SELECT ID FROM Surveys";
                //    string query = "SELECT Id FROM AspNetUsers";
                //    string query2 = "Select * FROM AspNetUsers where Id=@survey.ID";
                //    string n;
                //    SqlCommand command = new SqlCommand(query, connection);
                //    connection.Open();
                //    using (SqlDataReader reader = command.ExecuteReader())
                //    {
                //        while (reader.Read())
                //            n = reader.GetValue(0).ToString();
                //        //users.Add(reader.GetInt32(0), reader.GetInt32(1));
                //        reader.Close();
                //    }
                //    connection.Close();
                //}

                //Determine product here

                // survey.productDemographic = survey.sum < 10 ? "Beer" : survey.sum < 20 ? "Wine" : "Liquor";

                //Box beerBox = new Box("Beer box", 35.00, new List<string>() { "Miller", "PBR", "312 Goose Island" }); //causes entity validation error
                //Box wineBox = new Box("Wine box", 42.00, new List<string>() { "some chardonay, some zinfadel, something else" });
                //Box liquorBox = new Box("Hard liqour box", 40.00, new List<string>() { "Grey Goose", "Bacardi 151", "Patron Silver" });

                Box beerBox = new Box();
                beerBox.boxName = "Beer box";
                beerBox.boxPrice = 45.00;
                beerBox.boxContents = new List<AlcoholProduct>() { new Beer("Miller Lite"), new Beer("PBR"), new Beer("GooseIsland") };
               // beerBox.boxContents = new List<string>(){ "Miller", "PBR", "Goose Island"};

                Box wineBox = new Box();
                wineBox.boxName = "Wine box";
                wineBox.boxPrice = 35.00;
              //  wineBox.boxContents = new List<string>() { "some chardony", "some zinfandel", "something else" };

                Box hardLiquorBox = new Box();
                hardLiquorBox.boxName = "Hard liquor box";
                hardLiquorBox.boxPrice = 50.00;
                hardLiquorBox.boxContents = new List<AlcoholProduct>() { new Vodka("Grey Goose"), new Rum("Bacardi 151"), new Tequila("Patron Silver") };
                //array of string names in box

                survey.box = beerBox;

                survey.box = survey.sum < 10 ? beerBox : survey.sum < 20 ? wineBox : hardLiquorBox;

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

                db.Questions.Add(survey);
                db.SaveChanges();
                return RedirectToAction("ThankYou");
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
        public ActionResult ThankYou()
        {
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
