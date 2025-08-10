using DesingPattern.Repository;
using DesingPatterns_AspNet.Models.ViewsModels;

namespace DesingPatterns_AspNet.Strategies
{
    public interface IStrategy
    {
        public void Add(FormViewModel beerVM, IUnitOfWork unitOfWork);
    }
}
