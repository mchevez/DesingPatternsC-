using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesingPattern.Builder
{
    public class BarmanDirector
    {
        private IBuilder _builder;
        public BarmanDirector(IBuilder builder) {
            _builder = builder;
        }
        public void SetBuilder(IBuilder builder) {
            _builder = builder;
        }

        public void PreparedMargarita() { 
            _builder.Reset();
            _builder.SetAlcohol(9);
            _builder.SetWater(30);
            _builder.AddIngredients("2 limones");
            _builder.AddIngredients("Una pizca de sal");
            _builder.AddIngredients("1/2 tasa de tequila");
            _builder.AddIngredients("3/4 de licor de naranja");
            _builder.AddIngredients("4 cubos de hielo");
            _builder.Mix();
            _builder.Rest(2000);
        }

        public void PreparedPinaColada()
        {
            _builder.Reset();
            _builder.SetAlcohol(20);
            _builder.SetWater(10);
            _builder.SetMilk(500);
            _builder.AddIngredients("1/2 tasa de ron");
            _builder.AddIngredients("1/2 crema de coco");
            _builder.AddIngredients("3/4 tazas de jugo de piña");
            _builder.Mix();
            _builder.Rest(4000);
        }
    }
}
