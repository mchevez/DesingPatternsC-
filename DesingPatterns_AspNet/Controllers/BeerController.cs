using DesingPattern.Models.Data;
using DesingPattern.Repository;
using DesingPatterns_AspNet.Models.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DesingPatterns_AspNet.Controllers
{
    public class BeerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public BeerController(IUnitOfWork unitOfWork) { 
            _unitOfWork = unitOfWork;
        } 

        public IActionResult Index()
        {
            IEnumerable<BeerViewModel> beers = from a in _unitOfWork.Beers.Get()
                                               select new BeerViewModel { 
                                                   Id = a.BeerId,
                                                   Name = a.Name,
                                                   Style = a.Style,
                                               };

            return View("Index", beers);
        }

        [HttpGet]
        public IActionResult Add() 
        {
            var brands = _unitOfWork.Brands.Get();
            ViewBag.Brands = new SelectList(brands, "BrandId", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Add(FormViewModel beerVM) {

            if (!ModelState.IsValid) {
                var brands = _unitOfWork.Brands.Get();
                ViewBag.Brands = new SelectList(brands, "BrandId", "Name");
                return View("Add", beerVM);
            }

            var beer = new Beer();
            beer.Name = beerVM.Name;
            beer.Style = beerVM.Style;

            beer.BrandId = beerVM.BrandId == null? Guid.NewGuid() : (Guid)beerVM.BrandId;
            
            if (beerVM.BrandId == null)
            {
                var brand = new Brand();
                brand.Name = beerVM.OtherBrand;
                brand.BrandId = beer.BrandId;
                _unitOfWork.Brands.Add(brand);
            }
           
            _unitOfWork.Beers.Add(beer);
            _unitOfWork.Save();
            
            return RedirectToAction("Index");
        }
    }
}
