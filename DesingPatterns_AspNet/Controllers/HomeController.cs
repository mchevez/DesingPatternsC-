using DesingPattern.Repository;
//using DesingPatterns.Models.Data;
using DesingPattern.Models.Data;
using DesingPatterns_AspNet.Configuration;
using DesingPatterns_AspNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using Tools;

namespace DesingPatterns_AspNet.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly IOptions<MyConfig> _config;
        private readonly IRepository<Beer> _repository;
        public HomeController(IOptions<MyConfig> config, IRepository<Beer> repository)
        {
            //_logger = logger;
            _config = config;
            _repository = repository;
        }

        public IActionResult Index()
        {
            Log.GetInstance(_config.Value.PathLog).Save("Entro a Index");

            IEnumerable<Beer> lst = _repository.Get();
            return View("Index", lst);
        }

        public IActionResult Privacy()
        {
            Log.GetInstance(_config.Value.PathLog).Save("Entro a Privacy");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
