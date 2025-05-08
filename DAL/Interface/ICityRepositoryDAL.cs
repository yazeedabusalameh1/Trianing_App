using DAL.ModelsDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface ICityRepositoryDAL
    {
        List<CityDAL> GetAllCities();

        // Insert a new city
        bool InsertCity(CityDAL inModel);

        // Update an existing city
        bool UpdateCity(CityDAL city);

        // Delete a city by ID
        bool DeleteCity(int cityId);
    }
}
