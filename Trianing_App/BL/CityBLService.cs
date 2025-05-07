
using DAL.Interface;
using DAL.ModelsDAL;
using Trianing_App.BL.BLInterface;


namespace Trianing_App.BL
{
    public class CityBLService: ICityBLService
    {
        private readonly ICityRepositoryDAL _cityRepositoryDAL;
        private readonly ILogsRepositoriesDAL _logsBLservice;
        public CityBLService(ICityRepositoryDAL CityRepositoryDAL, ILogsRepositoriesDAL logsBLservice)
        {
            _cityRepositoryDAL = CityRepositoryDAL;
            _logsBLservice = logsBLservice;
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

        public List<CityDAL> GetAllCity()
        {
            try
            {
                var x = _cityRepositoryDAL.GetAllCities();

                return x;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    
    }
}
