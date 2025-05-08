using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using DAL.Data; 
using DAL.ModelsDAL;
using DAL.RepositoryDAL;
using DAL.Interface;



//using Trianing_App.RepositoryDAL;
//using Trianing_App.Helper;


namespace DAL.RepositoryDAL
{
    public class CityRepositoryDAL: ICityRepositoryDAL

    {
        private readonly DBContext _dbContext;
        

        public CityRepositoryDAL(DBContext dbContext) 
        {
            _dbContext = dbContext;
           
        }
       
        // Get All Cities
        public List<CityDAL> GetAllCities()
        {
            return _dbContext.Citys.ToList(); 
        }


       

        // Insert City API 
        public bool InsertCity(CityDAL inModel)
        {
            try
            {
               
                _dbContext.Citys.Add(inModel);
                int result = _dbContext.SaveChanges();


                if (result > 0) {
                   
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
        public bool UpdateCity(CityDAL city)
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
                    //_logsRepo.AddLog($"{city.CityName}: Updated City");
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
                    //_logsRepo.AddLog($"{delCity.CityName}:  Was deleted successfully ");
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
