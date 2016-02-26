using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crafty.Models
{
    public class Beer : AlcoholProduct
    {

        public Beer()
        {

        }

        public Beer(string name) :base(name)
        {
            this.name = name;
        }
    }
}