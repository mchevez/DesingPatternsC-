using DesingPattern.Repository;
using DesingPatterns_AspNet.Models.ViewsModels;
using Microsoft.AspNetCore.Mvc;

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
    }
}
