﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DesingPattern.DependencyInjection
{
    public class Beer
    {
        private string _name;
        private string _brand;

        public string Name { 
            get { return _name; }
        }
        public Beer(string name, string brand) 
        {    
            _name = name;
            _brand = brand;
        }
    }
}
