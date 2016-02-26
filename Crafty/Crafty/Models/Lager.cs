using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crafty.Models
{
    public class Lager : AlcoholProduct
    {

        public Lager()
        {

        }

        public Lager(string name) :base(name)
        {
           // this.name = name;
        }
    }
}