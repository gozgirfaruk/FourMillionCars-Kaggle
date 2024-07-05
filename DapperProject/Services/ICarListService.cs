using DapperProject.Dtos.PlatesDtos;

namespace DapperProject.Services
{
	public interface ICarListService
	{
		Task<List<ResultPlatesDto>> GetPlatesList();
		Task<GetByIdPlateDto> GetByIdPlates(int id);
	}
}
