using DapperProject.Dtos.PlatesDtos;
using DapperProject.Dtos.StatisticDtos;
using DapperProject.Models;

namespace DapperProject.Services
{
	public interface ICarListService
	{
		Task<List<SearchResultDto>> GetPlatesList();
		Task<GetByIdPlatesDto> GetByIdPlates(int id);
		Task<List<SearchResultDto>> SearchPlates(SearchViewModel model);

	 	int TotalCarCount();
		int OldCarYear();
		int YoungCarYear();

		string MostUseCar();
		List<string> MostFiveCarName();
		List<int> MostFiceCarCount();

        List<string> ChartLinename();
        List<int> CartLinecount();


    }
}
