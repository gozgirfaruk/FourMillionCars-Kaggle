using Dapper;
using DapperProject.Context;
using DapperProject.Dtos.PlatesDtos;

namespace DapperProject.Services
{
	public class CarListService : ICarListService
	{
		private readonly DapperContext _context;

		public CarListService(DapperContext context)
		{
			_context = context;
		}

		public async Task<GetByIdPlateDto> GetByIdPlates(int id)
		{
			string query = "select * from PLATES where ID=@p1";
			var parameter = new DynamicParameters();
			parameter.Add("@p1",id);
			var connection = _context.CreateConnection();
			var values = await connection.QueryFirstOrDefaultAsync<GetByIdPlateDto>(query, parameter);
			return values;
		}

		public async Task<List<ResultPlatesDto>> GetPlatesList()
		{
			string query = "Select Top(200) ID,TITLE,BRAND,MODEL,YEAR_ From dbo.PLATES ";
			var connection=_context.CreateConnection();
			var values = await connection.QueryAsync<ResultPlatesDto>(query);
			return values.ToList();
		}
	}
}
