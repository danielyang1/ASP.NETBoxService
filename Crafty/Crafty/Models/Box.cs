using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crafty.Models
{
    public class Box
    {
        public int ID { get; set; }
        public string boxName { get; set; }
        public double boxPrice { get; set; }
        public double test { get; set; }
        public virtual List<AlcoholProduct> boxContents { get; set; }
    }
}