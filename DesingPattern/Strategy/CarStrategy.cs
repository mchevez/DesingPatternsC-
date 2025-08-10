using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DesingPattern.Strategy
{
    public class CarStrategy : IStrategy
    {
        public void Run()
        {
            Console.WriteLine("Soy un carro y me muevo con 4 ruedas");
        }
    }
}
