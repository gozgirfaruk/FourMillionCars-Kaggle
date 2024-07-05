using DapperProject.Dtos.PlatesDtos;
using DapperProject.Models;

namespace DapperProject.Services
{
	public interface ICarListService
	{
		Task<List<SearchResultDto>> GetPlatesList();
		Task<GetByIdPlatesDto> GetByIdPlates(int id);
		Task<List<SearchResultDto>> SearchPlates(SearchViewModel model);
	}
}
