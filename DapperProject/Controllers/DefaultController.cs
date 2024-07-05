using DapperProject.Dtos.PlatesDtos;
using DapperProject.Models;
using DapperProject.Services;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;


namespace DapperProject.Controllers
{
    public class DefaultController : Controller
    {
        private readonly ICarListService _carlistService;

		public DefaultController(ICarListService carlistService)
		{
			_carlistService = carlistService;
		}

		public async Task<IActionResult> Index(SearchViewModel? dto,int sayfa=1,int pageSize=20)
        {
            
            if(!string.IsNullOrEmpty(dto.Brand))
            {
				var values = await _carlistService.SearchPlates(dto);
				return View(values.ToList().ToPagedList(sayfa, 20));
			}
            else 
            {
				var values = await _carlistService.GetPlatesList();
				return View(values.ToList().ToPagedList(sayfa, pageSize));
				
            }
        }
   


        public async Task<IActionResult> GetCarDetail(int id)
        {
            var values = await _carlistService.GetByIdPlates(id);
            return View(values);
        }

    }
}
