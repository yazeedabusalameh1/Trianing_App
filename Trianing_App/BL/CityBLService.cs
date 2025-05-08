
using DAL.Interface;
using DAL.ModelsDAL;
using Trianing_App.BL.BLInterface;
using Trianing_App.Helper;
using Trianing_App.ViewModels;


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

        public bool InsertCity(CityInputModel city)
        {
            try
            {
                var rank = CityRankHelper.CalculateRank(city.Population);
                var cityModel = new CityDAL
                {
                    CityID = city.CityID,
                    CityName = city.CityName,
                    Population = city.Population,
                    Governorate = city.Governorate,
                    Country = city.Country,
                    CityRank = rank,
                };
                var isadded = _cityRepositoryDAL.InsertCity(cityModel);
                if (isadded)
                {
                    _logsBLservice.AddLog($"{city.CityName} : Created Successfully");
                    return true;
                }
                else {
                    _logsBLservice.AddLog($"{city.CityName} : Filaed to Create City");
                    return false;
                }
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
