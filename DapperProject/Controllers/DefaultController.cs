﻿using DapperProject.Services;
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

		public async Task<IActionResult> Index(int sayfa=1)
        {
           var values = await _carlistService.GetPlatesList();
            return View(values.ToList().ToPagedList(sayfa,20));
        }


        public async Task<IActionResult> GetCarDetail(int id)
        {
            var values = await _carlistService.GetByIdPlates(id);
            return View(values);
        }

        public PartialViewResult Search()
        {
            return PartialView();
        }

        
    }
}