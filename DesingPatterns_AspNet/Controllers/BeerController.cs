using DesingPattern.Models.Data;
using DesingPattern.Repository;
using DesingPatterns_AspNet.Models.ViewsModels;
using DesingPatterns_AspNet.Strategies;
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
            GetBrandsData();
            return View();
        }
        [HttpPost]
        public IActionResult Add(FormViewModel beerVM) {

            if (!ModelState.IsValid) {
                GetBrandsData();
                return View("Add", beerVM);
            }

            var context = beerVM.BrandId == null ?
                            new BeerContext(new BeerWithBrandStrategy()) :
                            new BeerContext(new BeerStrategy());

            context.Add(beerVM, _unitOfWork);
            
            return RedirectToAction("Index");
        }

        #region HELPERS
        private void GetBrandsData() {
            var brands = _unitOfWork.Brands.Get();
            ViewBag.Brands = new SelectList(brands, "BrandId", "Name");
        }
        #endregion
    }
}
