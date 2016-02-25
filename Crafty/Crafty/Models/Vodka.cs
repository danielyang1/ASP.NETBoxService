using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crafty.Models
{
    public class Vodka : AlcoholProduct
    {
        public string name;

        public Vodka(string name)
        {
            this.name = name;
        }
    }
}