﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crafty.Models
{
    public class Survey
    {
        public int ID { get; set; }
        public int question1 { get; set; }
        public int question2 { get; set; }
        public int question3 { get; set; }
        public int question4 { get; set; }
        public int question5 { get; set; }
        public int question6 { get; set; }
        public int question7 { get; set; }
        public int question8 { get; set; }
        //RegisteredUser user { get; set; }
        public int userID { get; set; }
        public int sum { get; set; }
        public string productDemographic { get; set; }

    }
}