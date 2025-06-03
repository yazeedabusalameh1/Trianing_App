using DAL.ModelsDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface ICitizenRepositoryDAL
    {
        List<Citizen> GetAllCitizens();
        Citizen GetCitizenById(string id);
        bool AddCitizen(Citizen citizen);
        bool UpdateCitizen(Citizen citizen);
        bool DeleteCitizen(string id);
    }
}
