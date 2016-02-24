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
        public string productDemographic { get; set; }

        //public Product product {get; set;}

        //after adding new property, update "Bind(include" in Create and Edit action methods; also edit the Views\RegisteredUser\Index.cshtml and Views\RegisteredUsers\Create file to include <th> and <td> NEW PROPERTY 
        //or just read http://www.asp.net/mvc/overview/getting-started/introduction/adding-a-new-field

        //will need a Question Model/Controller

    }
}