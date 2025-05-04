using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Training_App.Data; 
using Trianing_App.Models;
using Trianing_App.Repository;
using Trianing_App.Helper;

namespace Training_App.Models
{
    public class CityRepository
    {
        private readonly DBContext _dbContext;
        private readonly LogsRepositories _logsRepo;

        public CityRepository(DBContext dbContext, LogsRepositories logsRepo) 
        {
            _dbContext = dbContext;
            _logsRepo = logsRepo;
        }

        // Get All Cities
        public List<City> GetAllCities()
        {
            return _dbContext.Citys.ToList(); 
        }


       

        // Insert City API 
        public bool InsertCity(CityInputModel inModel)
        {
            try
            {
                var city = new City
                {
                    CityID = inModel.CityID,
                    CityName = inModel.CityName,
                    Population = inModel.Population,
                    Governorate = inModel.Governorate,
                    Country = inModel.Country,
                    CityRank = CityRankHelper.CalculateRank(inModel.Population)
                };
                _dbContext.Citys.Add(city);
                int result = _dbContext.SaveChanges();


                if (result > 0) {
                    _logsRepo.AddLog($"{city.CityName} : Created Successfully");
                    return true;
                }
                return false;
            }
            catch
            {
                // Optionally, log the error
                return false;
            }
        }
        public bool UpdateCity(City city)
        {
            try
            {
                var NewCity = _dbContext.Citys.Where(a => a.CityID == city.CityID).FirstOrDefault();
                if (NewCity == null)
                    return false;

                // Update fields
                NewCity.CityName = city.CityName;
                NewCity.Population = city.Population;
                NewCity.Governorate = city.Governorate;
                NewCity.Country = city.Country;
                NewCity.CityRank = city.CityRank;

                int result = _dbContext.SaveChanges();
                if (result > 0)
                {
                    _logsRepo.AddLog($"{city.CityName}: Updated City");
                    return true;

                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCity(int cityId)
        {
            try
            {
                var delCity = _dbContext.Citys.Where (a=>a.CityID == cityId).FirstOrDefault();

                if (delCity == null)
                    return false;

                _dbContext.Remove(delCity);
                int result = _dbContext.SaveChanges();
                if(result > 0)
                {
                    _logsRepo.AddLog($"{delCity.CityName}:  Was deleted successfully ");
                    return true;
                }
                return false;


            }
            catch
            {
                return false;
            }

        }
    }
}
