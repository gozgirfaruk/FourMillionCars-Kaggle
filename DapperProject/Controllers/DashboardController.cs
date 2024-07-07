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

        public IActionResult Index()
		{
			ViewBag.distinctCar = _carService.TotalCarCount();
			ViewBag.oldcar=_carService.OldCarYear();
			ViewBag.youngcar = _carService.YoungCarYear();
			ViewBag.mostcar = _carService.MostUseCar();
			return View();
		}
	}
}
