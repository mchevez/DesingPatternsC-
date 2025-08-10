using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesingPattern.Strategy
{
    internal class MotoStrategy: IStrategy
    {
        public void Run()
        {
            Console.WriteLine("Soy una moto y me muevo con 2 ruedas");
        }
    }
}
