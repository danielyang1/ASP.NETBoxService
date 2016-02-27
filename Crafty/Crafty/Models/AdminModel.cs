using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crafty.Models
{
    public class AdminModel
    {
        public int ID { get; set; }
        public double? numberOfTotalAccounts { get; set;  }
        public double? numberOfPayingAccounts { get; set; }
        public double? numberOfHardLiquorAccounts { get; set; }
        public double? numberOfBeerAccounts { get; set; }
        public double? monthlyRevenue { get; set; }
        public double? percentHardLiqourAccounts { get; set; }
        public double? percentBeerAccounts { get; set; }
    }
}