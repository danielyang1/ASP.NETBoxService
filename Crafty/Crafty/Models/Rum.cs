using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crafty.Models
{
    public class Rum : AlcoholProduct
    {

        public Rum()
        {

        }

        public Rum(string name) : base(name)
        {
           // this.name = name;
        }
    }
}