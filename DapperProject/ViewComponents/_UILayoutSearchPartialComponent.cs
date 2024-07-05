using DapperProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.ViewComponents
{
	public class _UILayoutSearchPartialComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View(new SearchViewModel());
		}
	}
}
