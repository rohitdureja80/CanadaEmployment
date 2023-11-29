using CanadaEmployment.Model;
using Microsoft.Data.SqlClient;
using System.Data;
using CanadaEmployment.Library;

namespace CanadaEmployment.Data
{
    public class SqlDataAccess : IDataAccess
    {
        private IConfiguration _configuration;
        private readonly ILogger<SqlDataAccess> _logger;

        public SqlDataAccess(ILogger<SqlDataAccess> logger,
            IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        private SqlConnection GetConnectionString()
        {
            return new SqlConnection(_configuration.GetConnectionString("SqlConnectionString"));
        }

        public List<UnemploymentModel> GetUnemploymentData()
        {
            List<UnemploymentModel> list = new List<UnemploymentModel>();
            using (var conn = this.GetConnectionString())
            {
                conn.Open();
                SqlCommand command = new SqlCommand(Constants.StoredProcedures.GET_UNEMPLOYMENT_DATA, conn);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(this.MapUnemploymentDataToReader(reader));
                }
                reader.Close();
                conn.Close();
            }
            return list;
        }

        public List<UnemploymentModel> GetUnemploymentData(string location)
        {
            List<UnemploymentModel> list = new List<UnemploymentModel>();
            using (var conn = this.GetConnectionString())
            {
                conn.Open();
                SqlCommand command = new SqlCommand(Constants.StoredProcedures.GET_UNEMPLOYMENT_DATA_BY_LOCATION, conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@location", SqlDbType.VarChar).Value = location;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(this.MapUnemploymentDataToReader(reader));
                }
                reader.Close();
                conn.Close();
            }
            return list;
        }

        private UnemploymentModel MapUnemploymentDataToReader(SqlDataReader reader)
        {
            UnemploymentModel data = new UnemploymentModel();
            data.ReferenceDate = (string)reader["ReferenceDate"];
            data.GeoLocation = (string)reader["Location"];
            data.Sex = (string)reader["Sex"];
            data.AgeGroup = (string)reader["AgeGroup"];
            data.EmploymentNum = Convert.ToInt32(reader["EmploymentNum"]);
            data.FullTimeEmploymentNum = Convert.ToInt32(reader["FullTimeEmploymentNum"]);
            data.LabourForce = Convert.ToInt32(reader["LabourForceNum"]);
            data.PartTimeEmploymentNum = Convert.ToInt32(reader["PartTimeEmploymentNum"]);
            data.Population = Convert.ToInt32(reader["Population"]);
            data.UnemploymentNum = Convert.ToInt32(reader["UnemploymentNum"]);
            data.EmploymentRate = Convert.ToDecimal(reader["EmploymentRate"]);
            data.ParticipationRate = Convert.ToDecimal(reader["ParticipationRate"]);
            data.UnemploymentRate = Convert.ToDecimal(reader["UnemploymentRate"]);
            return data;
        }


    }
}
