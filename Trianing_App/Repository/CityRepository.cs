using Microsoft.EntityFrameworkCore;
using Training_App.Data; 
using Trianing_App.Models;

namespace Training_App.Models
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
            return _dbContext.Citys.ToList(); 
        }

        // Insert City
        public bool InsertCity(City city)
        {
            try
            {
                _dbContext.Citys.Add(city);
                int result = _dbContext.SaveChanges();
            
                return result > 0; // returns true if at least one row was affected
            }
            catch
            {
                // Optionally, log the error
                return false;
            }
        }
    }
}
