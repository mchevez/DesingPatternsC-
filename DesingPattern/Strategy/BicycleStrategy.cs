using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesingPattern.Strategy
{
    public class BicycleStrategy: IStrategy
    {
        public void Run()
        {
            Console.WriteLine("Soy una bicibleta me muevo con 2 ruedas y soy impulsada por los pies");
        }
    }
}
