using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TravelingDiaries.Models;

namespace TravelingDiaries.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPlaceRepository placeRepository;
        private readonly IHttpContextAccessor httpContextAccessor;

        public HomeController(ILogger<HomeController> logger, IPlaceRepository placeRepository, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            this.placeRepository = placeRepository;
            this.httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
          
            
            return View();

        }

        public IActionResult Search(string Value)
        {
            var place = placeRepository.GetAllPlaces().Where(x=>x.PlaceName.ToLower().Contains(Value.ToLower()));
            int count = place.Count();
            ViewBag.CountPlaces = count;
            return View(place);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}