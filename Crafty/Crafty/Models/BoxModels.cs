using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crafty.Models
{
    public class BoxModels
    {
        public string ID { get; set; }
        public string boxName { get; set; }
        public double boxPrice { get; set; }
        public List<string> boxContents { get; set; }

    }
}