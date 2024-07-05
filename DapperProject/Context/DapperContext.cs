using Microsoft.Data.SqlClient;
using System.Data;

namespace DapperProject.Context
{
	public class DapperContext
	{
		private readonly IConfiguration _configuration;
		private readonly string _connectionString;

		public DapperContext(IConfiguration configuration)
		{
			_configuration = configuration;
			_connectionString = _configuration.GetConnectionString("connection");
		}

		public IDbConnection CreateConnection()=>new SqlConnection(_connectionString);
	}
}
