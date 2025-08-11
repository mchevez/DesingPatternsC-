using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesingPattern.Builder
{
    public interface IBuilder
    {
        public void Reset();
        public void SetAlcohol(decimal alcohol);
        public void SetMilk(int milk);
        public void SetWater(int water);
        public void AddIngredients(string ingredients);
        public void Mix();
        public void Rest(int time);
    }
}
