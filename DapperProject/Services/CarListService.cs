using Dapper;
using DapperProject.Context;
using DapperProject.Dtos.PlatesDtos;
using DapperProject.Models;
using OfficeOpenXml;

namespace DapperProject.Services
{
    public class CarListService : ICarListService
	{
		private readonly DapperContext _context;

		public CarListService(DapperContext context)
		{
			_context = context;
		}

  

        public async Task<GetByIdPlatesDto> GetByIdPlates(int id)
		{
			string query = "select * from PLATES where ID=@p1";
			var parameter = new DynamicParameters();
			parameter.Add("@p1",id);
			var connection = _context.CreateConnection();
			var values = await connection.QueryFirstOrDefaultAsync<GetByIdPlatesDto>(query, parameter);
			return values;
		}

		public async Task<List<SearchResultDto>> GetPlatesList()
		{
			string query = "Select Top(10000) ID,TITLE,BRAND,MODEL,YEAR_ From dbo.PLATES ";
			var connection=_context.CreateConnection();
			var values = await connection.QueryAsync<SearchResultDto>(query);
			return values.ToList();
		}

      

        public async Task<List<SearchResultDto>> SearchPlates(SearchViewModel model)
		{
			string query = "Select Top(200) * From PLATES Where  (( FUEL IS NULL OR FUEL=@p3) OR (YEAR_ IS NULL OR YEAR_=@p4) OR (CITYNR IS NULL OR CITYNR=@p5) OR  (COLOR IS NULL OR COLOR=@p6) OR (CASETYPE IS NULL OR CASETYPE=@p7) OR (SHIFTTYPE IS NULL OR SHIFTTYPE=@p8) OR (MOTORVOLUME IS NULL OR  MOTORVOLUME=@p9)) AND (BRAND=@p1 OR (MODEL IS NULL OR MODEL=@p2)) ";
			var parameters = new DynamicParameters();
			parameters.Add("@p1", model.Brand);
			parameters.Add("@p2", model.Model);
			parameters.Add("@p3", model.Fuel);
			parameters.Add("@p4", model.Year);
			parameters.Add("@p5", model.CityNr);
			parameters.Add("@p6", model.Color);
			parameters.Add("@p7", model.CaseType);
			parameters.Add("@p8", model.ShiftType);
			parameters.Add("@p9", model.MotorVolume);
			var connection= _context.CreateConnection();
			var values = await connection.QueryAsync<SearchResultDto>(query,parameters);
			return values.ToList();

		}

        public int TotalCarCount()
        {
			string query = "Select Count(Distinct Brand ) From PLATES";
			var connection=_context.CreateConnection();
			var values = connection.ExecuteScalar<int>(query);
			return values;
        }

        public int YoungCarYear()
        {
            string query = "Select Max(YEAR_) From PLATES";
            var connection = _context.CreateConnection();
            var values = connection.ExecuteScalar<int>(query);
            return values;
        }

        public int OldCarYear()
        {
            string query = "Select Min(YEAR_) From PLATES";
            var connection = _context.CreateConnection();
            var values = connection.ExecuteScalar<int>(query);
            return values;
        }

        public string MostUseCar()
        {
			string query = "Select Top(1) BRAND  From PLATES Group By BRAND Order By  Count(Brand) Desc";
			var connection = _context.CreateConnection();
			var values = connection.ExecuteScalar<string>(query);
			return values;
        }
    }
}
