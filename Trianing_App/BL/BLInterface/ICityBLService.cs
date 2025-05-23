﻿using DAL.ModelsDAL;
using Trianing_App.ViewModels;

namespace Trianing_App.BL.BLInterface
{
    public interface ICityBLService
    {
        bool InsertCity(CityInputModel city);

        // Update an existing city
        bool UpdateCity(CityDAL city);

        // Delete a city by ID
        bool DeleteCity(int id);

        // Get all cities
        List<CityDAL> GetAllCity();
    }
}
