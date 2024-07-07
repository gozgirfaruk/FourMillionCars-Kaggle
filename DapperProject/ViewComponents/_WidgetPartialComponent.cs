using DapperProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.ViewComponents
{
    public class _WidgetPartialComponent : ViewComponent
    {
        private readonly ICarListService _carService;
        public _WidgetPartialComponent(ICarListService carService)
        {
            _carService = carService;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.distinctCar = _carService.TotalCarCount();
            ViewBag.oldcar = _carService.OldCarYear();
            ViewBag.youngcar = _carService.YoungCarYear();
            ViewBag.mostcar = _carService.MostUseCar();
            return View();
        }
    }
}
