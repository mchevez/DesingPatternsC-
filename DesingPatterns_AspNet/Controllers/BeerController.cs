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

            return View();
        }
    }
}
