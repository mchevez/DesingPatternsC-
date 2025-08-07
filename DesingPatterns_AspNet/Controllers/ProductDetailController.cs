using Microsoft.AspNetCore.Mvc;
using Tools.Earn;

namespace DesingPatterns_AspNet.Controllers
{
    public class ProductDetailController : Controller
    {
        private ForeignEarnFactory _foreignEarnFactory;
        private LocalEarnFactory _localEarnFactory;

        public ProductDetailController(ForeignEarnFactory foreignEarnFactory, LocalEarnFactory localEarnFactory) {
            _foreignEarnFactory = foreignEarnFactory;
            _localEarnFactory = localEarnFactory;
        }

        public IActionResult Index(decimal total)
        {
            //Factories
            //EarnFactory localEarnFactory = new LocalEarnFactory(0.2m);
            //EarnFactory foreignEarnFactory = new ForeignEarnFactory(0.3m, 20);

            //Products
            var localEarn = _localEarnFactory.GetEarn();
            var foreignEarn = _foreignEarnFactory.GetEarn();

            //Total
            ViewBag.totalLocal = total + localEarn.Earn(total);
            ViewBag.totalForeign = total + foreignEarn.Earn(total);
            return View();
        }
    }
}
