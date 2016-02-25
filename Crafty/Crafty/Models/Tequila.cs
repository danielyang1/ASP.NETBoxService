using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crafty.Models
{
    public class Tequila : AlcoholProduct
    {
        public string name;

        public Tequila(string name)
        {
            this.name = name;
        }
    }
}