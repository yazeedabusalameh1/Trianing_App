using System.Data;
using System.Data.SqlClient;
using Training_App.Data;
using Trianing_App.Models;

namespace Training_App.Data
{
    public class CityRepository
    {
        private readonly DBContext _dbContext;

        public CityRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Get All Cities
        public List<City> GetAllCities()
        {
            List<City> cities = new List<City>();

            var connection = _dbContext.OpenConnection();
            var command = new SqlCommand("GetAllCities", connection);
            
                command.CommandType = CommandType.StoredProcedure;

                var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        cities.Add(new City
                        {
                            CityID = Convert.ToInt32(reader["CityId"]),
                            CityName = reader["CityName"].ToString(),
                            Population = reader["Population"] is DBNull ? 0 : Convert.ToInt32(reader["Population"]),
                            Province = reader["Province"]?.ToString(),
                            Country = reader["Country"]?.ToString(),
                            CityRank = reader["CityRank"] is DBNull ? 0 : Convert.ToInt32(reader["CityRank"])
                        });
                    }
                
            

            return cities;
        }

        // Insert City
        public void InsertCity(City city)
        {
            var connection = _dbContext.OpenConnection();
            var command = new SqlCommand("InsertCity", connection);
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CityID", city.CityID);
                command.Parameters.AddWithValue("@CityName", city.CityName);
                command.Parameters.AddWithValue("@Population", city.Population);
                command.Parameters.AddWithValue("@Province", city.Province);
                command.Parameters.AddWithValue("@Country", city.Country);
                command.Parameters.AddWithValue("@CityRank", city.CityRank);

                command.ExecuteNonQuery();
            }
        }
    }
}
