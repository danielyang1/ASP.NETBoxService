using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Crafty.Models
{
    public class RegisteredUser
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public int subscriptionCost { get; set; }
        public int totalSubscriptionCost { get; set; }
        //add "demographic"
    }

    public class RegisteredUserDBContext : DbContext
    {
        public DbSet<RegisteredUser> RegisteredUsers { get; set; }
        //this is where we can add more databases
    }





    //public class SurveyModel
    //{
    //    public int ID { get; set; }
    //    public int q1 { get; set; }
    //    public int q2 { get; set; }
    //}

    //public class Survey : DbContext
    //{
    //    public Survey() : base("SurveyResponses")
    //    {

    //    }

    //    public DbSet<SurveyModel> Surveys { get; set; }

    //    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    //    {
    //        modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
    //    }
    //}

    ////not sure if below code is ever used
    //public class SurveyInitializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<Survey>
    //{
    //    protected override void Seed(Survey context)
    //    {
    //        var surveyResponses = new List<SurveyModel>
    //        {
    //            new SurveyModel {ID = 1, q1=10, q2=5 },
    //            new SurveyModel {ID = 2, q1=5, q2=6 },
    //        };

    //        surveyResponses.ForEach(s => context.Surveys.Add(s));
    //        context.SaveChanges();
    //    }
    //}
}