using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crafty.Models
{
    public class AlcoholProduct
    {
        public AlcoholProduct(string name)
        {
            this.name = name;
        }

        public AlcoholProduct()
        {

        }
        public int ID { get; set; }
        public string name { get; set; }
    }
}