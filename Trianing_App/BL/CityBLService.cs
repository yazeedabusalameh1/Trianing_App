using DAL.Models;
using DAL.ModelsDAL;

namespace Trianing_App.BL
{
    public class CityBLService
    {
        private readonly CityRepositoryDAL _cityRepositoryDAL;
        public CityBLService(CityRepositoryDAL CityRepositoryDAL)
        {
            _cityRepositoryDAL = CityRepositoryDAL;
        }

        public bool InsertCity(CityInputModelDAL city)
        {
            try
            {
                _cityRepositoryDAL.InsertCity(city);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            } 
        }

        public bool UpdateCity(CityDAL city)
        {
            try
            {
                _cityRepositoryDAL.UpdateCity(city);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteCity(int id) {
            try {
                return true;
            } catch (Exception ex)
            { 
                return false;
            }
        
        }

        public bool GetAllCity()
        {
            try
            {
                _cityRepositoryDAL.GetAllCities();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    
    }
}
