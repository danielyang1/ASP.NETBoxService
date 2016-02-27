using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crafty.Models
{


    public class RegisteredUserDBContext : DbContext
    {
        public RegisteredUserDBContext() : base("DefaultConnection")
            {
            }

        public DbSet<RegisteredUser> RegisteredUsers { get; set; }
        public DbSet<Survey> Questions { get; set; }

        public System.Data.Entity.DbSet<Crafty.Models.Box> BoxModels { get; set; }

        public System.Data.Entity.DbSet<Crafty.Models.AdminModel> Admins { get; set; }
    }



}