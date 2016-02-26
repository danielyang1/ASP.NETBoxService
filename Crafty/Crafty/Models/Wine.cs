using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crafty.Models
{
    public class Wine : AlcoholProduct
    {

        public Wine()
        {

        }

        public Wine(string name) : base(name)
        {
            this.name = name;
        }
    }
}