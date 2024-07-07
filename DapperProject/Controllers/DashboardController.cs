using DapperProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.Controllers
{
	public class DashboardController : Controller
	{
		private readonly ICarListService _carService;

        public DashboardController(ICarListService carService)
        {
            _carService = carService;
        }

		public  IActionResult Index()
		{
            List<int> data = _carService.MostFiceCarCount();
            List<string> labels = _carService.MostFiveCarName();
            ViewBag.Data = data;
            ViewBag.Labels = labels;


            List<int> data1 = _carService.CartLinecount();
            List<string> label1 = _carService.ChartLinename();
            ViewBag.name = data1;
            ViewBag.number = label1;
            return View();
		}

	}
}
