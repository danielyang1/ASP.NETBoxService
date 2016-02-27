using System;
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
        public string userID { get; set; }
        public int sum { get; set; }
        public Box box { get; set; }
        public bool isSubscribed { get; set; }
    }
}