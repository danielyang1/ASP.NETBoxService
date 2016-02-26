using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crafty.Models
{
    public class Vodka : AlcoholProduct
    {
        public Vodka()
        {

        }

        public Vodka(string name) : base(name)
        {
            this.name = name;
        }
    }
}