using System;
using System.Collections.Generic;
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
    }
}