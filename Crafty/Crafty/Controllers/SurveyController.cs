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
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "ID,question1,question2,question3,question4,question5,question6,question7,question8,sum")] Survey survey)
        {
            if (ModelState.IsValid)
            {
                survey.sum = survey.question1 + survey.question2 + survey.question3 + survey.question4 + survey.question5 + survey.question6 + survey.question7 + survey.question8;

                survey.userID = User.Identity.GetUserId();            ///this should be int? not sure

                // User.Identity.getUser

              //  var d = db.Questions.First(a => a.ID == survey.ID);


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
                //            //users.Add(reader.GetInt32(0), reader.GetInt32(1));
                //        reader.Close();
                //    }
                //    connection.Close();
                //}


         


                //Determine product here

                survey.productDemographic = survey.sum < 10 ? "Beer" : survey.sum < 20 ? "Wine" : "Liquor";


                //int count = db.RegisteredUsers.Count(); Entity Framework

                //if wine...
                //if hard liquor...differentiate between hard liquors
                //if beer....have some question that differentiates between beer types




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
                return RedirectToAction("Index");
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
