using DesingPattern.Models.Data;
using DesingPattern.Repository;
using DesingPatterns_AspNet.Models.ViewsModels;

namespace DesingPatterns_AspNet.Strategies
{
    public class BeerWithBrandStrategy : IStrategy
    {
        public void Add(FormViewModel beerVM, IUnitOfWork unitOfWork)
        {
            var beer = new Beer();
            beer.Name = beerVM.Name;
            beer.Style = beerVM.Style;

            var brand = new Brand();
            brand.Name = beerVM.OtherBrand;
            brand.BrandId = Guid.NewGuid();

            beer.BrandId = brand.BrandId;

            unitOfWork.Brands.Add(brand);
            unitOfWork.Beers.Add(beer);

            unitOfWork.Save();
        }
    }
}
