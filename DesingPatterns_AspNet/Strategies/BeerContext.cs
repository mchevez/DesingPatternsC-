using DesingPattern.Repository;
using DesingPatterns_AspNet.Models.ViewsModels;

namespace DesingPatterns_AspNet.Strategies
{
    public class BeerContext
    {
        private IStrategy _strategy;
        public IStrategy Strategy { set { _strategy = value; } }
        public BeerContext(IStrategy strategy) { 
            _strategy = strategy;
        }
        public void Add(FormViewModel beerVM, IUnitOfWork unitOfWork) {
            _strategy.Add(beerVM, unitOfWork);
        }
    }
}
