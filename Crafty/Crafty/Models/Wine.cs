using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crafty.Models
{
    public class Wine : AlcoholProduct
    {
        public string name;

        public Wine(string name)
        {
            this.name = name;
        }
    }
}