﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crafty.Models
{
    public class Beer : AlcoholProduct
    {
        public string name;

        public Beer(string name)
        {
            this.name = name;
        }
    }
}