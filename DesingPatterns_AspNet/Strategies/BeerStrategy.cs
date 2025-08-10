using DesingPattern.Models.Data;
using DesingPattern.Repository;
using DesingPatterns_AspNet.Models.ViewsModels;

namespace DesingPatterns_AspNet.Strategies
{
    public class BeerStrategy : IStrategy
    {
        public void Add(FormViewModel beerVM, IUnitOfWork unitOfWork)
        {
            var beer = new Beer();
            beer.Name = beerVM.Name;
            beer.Style = beerVM.Style;
            beer.BrandId = (Guid) beerVM.BrandId;

            unitOfWork.Beers.Add(beer);
            unitOfWork.Save();
        }
    }
}
