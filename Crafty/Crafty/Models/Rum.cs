using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crafty.Models
{
    public class Rum : AlcoholProduct
    {
        public string name;

        public Rum(string name)
        {
            this.name = name;
        }
    }
}